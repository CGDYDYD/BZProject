using BoTech;
using CoreFunction;
using Help;
using LogsHelper;
using System.Threading;
using XStation;
using static CoreFunction.mFunction;
using static Help.AxisHelper;
using static ParName.名称枚举;

namespace 运动模块
{
    /// <summary>
    /// 上料基类，定义了上料相关的基本功能和流程
    /// 继承自mWorkShare
    /// </summary>
    public abstract class 上料Base : mWorkShare
    {
        #region 私有变量

        internal abstract Task_ID task_ID { get; } // 工站ID 00 01 02 03 04 05 06
        internal abstract AxisID axisID { get; } /// 轴ID 轴 枚 举
        internal abstract StationID stationID { get; } /// 工位信息
        internal abstract Axis axis { get; }  /// 轴方向 X、Y、Z等

        #endregion 私有变量

        #region 输入信号
        public abstract bool 进料流线流入光电 { get; }
        public abstract bool 进料流线到位光电 { get; }
        public abstract bool 进料流线有料检测光电 { get; }

        public abstract bool 进料顶升气缸原点 { get; }
        public abstract bool 进料顶升气缸动点 { get; }

        public abstract bool 进料分盘气缸原点 { get; }
        public abstract bool 进料分盘气缸动点 { get; }

        public abstract bool 进料流线缺料对射 { get; }
        public abstract bool 进料流线满料对射 { get; }
        public abstract bool 移栽到位光电检测 { get; }
        public abstract bool 出料流线有料检测光电 { get; }


        #endregion 输入信号

        #region 输出信号
        public abstract bool 进料流线正转 { set; }
        public abstract bool 进料流线反转 { set; }
        public abstract bool 进料流线停止 { set; }

        public abstract bool 移栽流线正转 { set; }
        public abstract bool 移栽流线反转 { set; }
        public abstract bool 移栽流线停止 { set; }

        public abstract bool 进料顶升气缸缩回 { set; }
        public abstract bool 进料顶升气缸伸出 { set; }

        public abstract bool 进料分盘气缸缩回 { set; }
        public abstract bool 进料分盘气缸伸出 { set; }
        public abstract bool 按钮灯 { set; }

        //******************************************************************
        #endregion 输出信号

        #region 交互信号

        /// <summary>
        /// 回零步序，用于控制回零流程的步骤
        /// </summary>
        public short 回零步序 { get; set; }

        public abstract bool 给移载平台有料盘信号 { get; set; }

        public abstract bool 移载平台要料盘信号 { get; }

        public abstract bool 移载平台进料盘完成信号 { get; set; }

        #endregion 交互信号 

        #region 流程枚举
        private enum Workstep
        {
            流程开始 = 10,

            轴就位供料位,

            分盘气缸缩回,
            分盘气缸缩回位到位判断,

            轴就位分盘位,

            分盘气缸伸出, 
            分盘气缸伸出位到位判断,

            轴就位出料位,

            等待移载平台要料信号,
            执行出料,
            出料完成,


            //轴就位供料位 循环
        }

        #endregion 流程枚举

        #region 基础功能

        /// <summary>
        /// 初始化方法，设置任务ID、绑定工位、初始化日志等
        /// </summary>
        public override void Initialize()
        {
            // 设置任务ID
            TaskID = (short)task_ID;
            // 绑定工位到任务管理器
            WkManager.BindStation((short)task_ID, task_ID.ToString(), this);

            // 初始化日志
            _Logs = new cLogs(TaskName, TaskID);
            // 绑定错误处理事件
            mDoDi.mAction += Err;
            pMove.mAction += Err;
            // 调用基类的初始化
            base.Initialize();
        }

        /// <summary>
        /// 错误处理方法，处理不同类型的错误
        /// </summary>
        /// <param name="CtrName">控制器名称</param>
        /// <param name="ErrInfo">错误信息</param>
        public override void Err(string CtrName, string ErrInfo)
        {
            switch (CtrName)
            {
                case "DoAndDi":
                    // 非运行和手动状态下，中止线程
                    if (State != State.RUNNING && State != State.MANUAL)
                    {
                        zThread.Abort();
                        return;
                    }
                    break;

                case "mSend":
                    // 发送错误，中止线程
                    zThread.Abort();
                    break;

                case "Moving":
                    // 运动错误，显示对话框并记录日志
                    mFunction.DialogShow(1, $"{zThread.Name}: {CtrName} {ErrInfo}", 1);
                    AddLog($"{zThread.Name}: {CtrName} {ErrInfo}", LogsType._ErrorCode, WorkStep_Int, true);
                    State = State.WAITRUN;
                    zThread.Abort();
                    break;
            }
        }

        /// <summary>
        /// 准备方法，设置初始工作步骤和自动函数
        /// </summary>
        /// <returns>准备结果，1表示成功，0表示失败</returns>
        public override short mReady()
        {
            if (this.State == State.WAITRESET)
            {
                return 0;
            }
            // 设置初始工作步骤
            WorkStep_Int = 10;

            // 初始化自动函数，添加进料流程
            AutoFunction = null;
            AutoFunction += 进料流程;
            return 1;
        }

        #endregion 基础功能

        #region 回零

        /// <summary>
        /// 回零方法，控制设备回到初始位置
        /// </summary>
        public override void Homing()
        {
            // 调用基类的回零方法
            base.Homing();
            // 设置状态为回零中
            State = State.RESETTING;
            // 记录回零步骤
            AddLog($"{(GoHomeStep)回零步序}", LogsType._Auto, 回零步序, true);
            // 脱机空跑模式
            if (mGlobal.OffLine_VirtualRun脱机空跑)
            {
                Clear();
                StaHomeOK = true;
                AddLog($"{this.TaskName}" + "复位完成", LogsType._Auto, 0, true);
            }
            else
            {
                // 设置当前步骤信息
                SetStep(ref StaInfo, 回零步序, true);

                // 根据回零步序执行不同的操作
                switch ((GoHomeStep)回零步序)
                {
                    case GoHomeStep.轴上使能:
                        // 先关闭使能，再打开使能，确保轴处于初始状态
                        SeverOFF(axisID);
                        Thread.Sleep(1000);
                        SeverON(axisID);
                        // 判断轴上使能是否成功
                        if (GetServoState(axisID))
                        {
                            回零步序 = (int)GoHomeStep.流线停止;
                        } 
                        else
                        {
                               // 轴上使能失败
                              回零步序 = (short)myTipNew(GoHomeStep.轴上使能, GoHomeStep.流线停止, eErrCode.轴上使能失败);
                        }
                        break;

                    case GoHomeStep.流线停止:
                        // 停止流线
                        进料流线停止 = true;
                        回零步序 = (int)GoHomeStep.判断流线是否有料;
                        break;

                    case GoHomeStep.判断流线是否有料:
                        // 检查流线是否有料，有料则提示清料
                        回零步序 = 进料流线流入光电 || 进料流线到位光电 || 进料流线有料检测光电 ? (short)myTipNew(GoHomeStep.判断流线是否有料, GoHomeStep.料仓回原点, eErrCode.清料盘提示) : (short)(int)GoHomeStep.料仓回原点;
                        break;

                    case GoHomeStep.料仓回原点:
                        if (AxisGoHome(this, axisID, true))
                        {
                            回零步序 = (int)GoHomeStep.判断料仓回原点是否成功;
                        }
                        break;
                    case GoHomeStep.判断料仓回原点是否成功:
                        if (IsHomeFinished(axisID))
                        {
                            回零步序 = (int)GoHomeStep.顶升气缸伸出;
                        }
                        break;
                    //case GoHomeStep.料仓回供料位:
                    //    // 轴运动到点位
                    //    if (AxisGoPoint(stationID, axisID, (int)PosName.供料位, axis, true))
                    //    {
                    //        回零步序 = (int)GoHomeStep.分盘气缸伸出;
                    //    }
                    //    break;
                    case GoHomeStep.顶升气缸伸出:
                        进料顶升气缸伸出 = true;
                        回零步序 = (int)GoHomeStep.顶升气缸伸出到位判断;
                        break;
                    case GoHomeStep.顶升气缸伸出到位判断:
                        // 检查顶升气缸是否伸出到位
                        if (进料顶升气缸动点)
                        {
                            回零步序 = (int)GoHomeStep.分盘气缸伸出;
                        }
                        else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                        {
                            // 超时处理
                            回零步序 = (short)myTipNew(GoHomeStep.顶升气缸伸出, GoHomeStep.顶升气缸伸出到位判断, eErrCode.顶升气缸缩回超时);
                        }
                        break;
                    case GoHomeStep.分盘气缸伸出:
                        进料分盘气缸伸出 = true;
                        回零步序 = (int)GoHomeStep.分盘气缸伸出到位判断;
                        break;

                    case GoHomeStep.分盘气缸伸出到位判断:
                        if (进料分盘气缸动点)
                        {
                            回零步序 = (int)GoHomeStep.清除数据;
                        }
                        else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                        {
                            // 超时处理
                            回零步序 = (short)myTipNew(GoHomeStep.分盘气缸伸出, GoHomeStep.分盘气缸伸出到位判断, eErrCode.分盘气缸伸出超时);
                        }
                        break;

                    case GoHomeStep.清除数据:
                        // 清除数据
                        Clear();
                        回零步序 = (int)GoHomeStep.回零成功;
                        break;

                    case GoHomeStep.回零成功:
                        // 回零成功
                        StaHomeOK = true;
                        回零步序 = 0;
                        break;

                    case GoHomeStep.回零失败:
                        // 回零失败
                        StaHomeOK = false;
                        回零步序 = 0;
                        WkManager.Cancel();
                        break;
                }
            }
            // 调用准备方法
            mReady();
        }

        /// <summary>
        /// 回零步骤枚举
        /// </summary>
        private enum GoHomeStep
        {
            轴上使能,
            流线停止,
            判断流线是否有料, // 有料的话报警并且提示取料
            料仓回原点, // Z轴回到原点位置
            判断料仓回原点是否成功,
            //料仓回供料位,
            顶升气缸伸出,
            顶升气缸伸出到位判断,
            分盘气缸伸出,
            分盘气缸伸出到位判断,
            清除数据,
            回零成功,
            回零失败 = 1000,
        }

        #endregion 回零

        #region 点位名称枚举
        private enum PosName
        {
            供料位,
            分盘位,
            出料位,
        }

        #endregion 点位名称

        #region 自动流程

        /// <summary>
        /// 主程序，控制自动运行流程
        /// </summary>
        public override void AutoRun()
        {
            if (ManaulRun)
            {
                ManaulRun = false;
                if (mReady() == -1)
                {
                    State = State.WAITRUN;
                    return;
                }
            }
            // 执行自动函数 委托
            AutoFunction?.Invoke();
        }

        /// <summary>
        /// 进料流程，处理进料相关操作
        /// </summary>
        private void 进料流程()
        {
            // 记录当前工作步骤
            AutoLog<Workstep>();
            switch ((Workstep)WorkStep_Int)
            {
                case Workstep.流程开始:
                    // 初始化信号
                    给移载平台有料盘信号 = false;
                    按钮灯 = true;
                    // 检查分盘感应和操作按钮，或空跑模式
                    //if ((分盘感应 && 操作按钮) || ParHelper.不带载具空跑 || ParHelper.VirtualRunWithCarrier带载具空跑)
                    if (进料流线缺料对射 || ParHelper.不带载具空跑 || ParHelper.VirtualRunWithCarrier带载具空跑)
                    {
                        WorkStep_Int = (int)Workstep.轴就位供料位;
                    }
                    else if (!进料流线缺料对射)
                    {
                        // 生产模式下缺料提示
                        if (ParHelper.Production生产模式)
                        {
                            WorkStep_Int = (short)myTipNew(Workstep.流程开始, Workstep.流程开始, eErrCode.料仓缺料盘);
                        }
                    }
                    break;
                case Workstep.轴就位供料位:
                    if (AxisGoPoint(stationID, axisID, (int)PosName.供料位, axis, true))
                    {
                        WorkStep_Int = (int)Workstep.分盘气缸缩回;
                    }
                    break;

                case Workstep.分盘气缸缩回:
                    进料分盘气缸缩回 = true;
                    WorkStep_Int = (int)Workstep.分盘气缸缩回位到位判断;
                    break;

                case Workstep.分盘气缸缩回位到位判断:
                    if (进料分盘气缸原点)
                    {
                        WorkStep_Int = (int)Workstep.轴就位分盘位;
                    }
                    else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                    {
                        // 超时处理
                        WorkStep_Int = (short)myTipNew(Workstep.分盘气缸缩回, Workstep.分盘气缸缩回位到位判断, eErrCode.分盘气缸缩回超时);
                    }
                    break;

                case Workstep.轴就位分盘位:
                    if (AxisGoPoint(stationID, axisID, (int)PosName.分盘位, axis, true))
                    {
                        WorkStep_Int = (int)Workstep.分盘气缸伸出;
                    }
                    break;

                case Workstep.分盘气缸伸出:
                    进料分盘气缸伸出 = true;
                    WorkStep_Int = (int)Workstep.分盘气缸伸出位到位判断;
                    break;

                case Workstep.分盘气缸伸出位到位判断:
                    if (进料分盘气缸动点)
                    {
                        WorkStep_Int = (int)Workstep.轴就位出料位;
                    }
                    else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                    {
                        // 超时处理
                        WorkStep_Int = (short)myTipNew(Workstep.分盘气缸伸出, Workstep.分盘气缸伸出位到位判断, eErrCode.分盘气缸伸出超时);
                    }
                    break;
                case Workstep.轴就位出料位:
                    if (AxisGoPoint(stationID, axisID, (int)PosName.出料位, axis, true))
                    {
                        WorkStep_Int = (int)Workstep.等待移载平台要料信号;
                    }
                    break;
                case Workstep.等待移载平台要料信号:
                    给移载平台有料盘信号 = true;
                    if (移载平台要料盘信号)
                    {
                        WorkStep_Int = (int)Workstep.执行出料;
                    }
                    break;

                case Workstep.执行出料:
                    进料流线正转 = true;
                    移栽流线正转 = true;
                    Thread.Sleep(2000);
                    WorkStep_Int = (int)Workstep.出料完成;
                    break;

                case Workstep.出料完成:
                    if (移载平台进料盘完成信号) 
                    {
                        // 停止流线
                        进料流线停止= true;
                        移栽流线停止 = true;

                        // 重置信号
                        给移载平台有料盘信号 = false;

                        // 检查是否为脱机空跑模式或流线无料
                        if (ParHelper.OffLine_VirtualRun脱机空跑 || !进料流线有料检测光电)
                        {
                            // 切换回进料流程开始，开始新一轮循环
                            WorkStep_Int = (int)Workstep.流程开始;
                            AutoFunction = null;
                            AutoFunction += 进料流程;
                        }
                        else
                        {
                            // 出料异常处理
                            WorkStep_Int = (short)myTipNew(Workstep.执行出料, Workstep.出料完成, eErrCode.出料盘异常);
                        }
                    }
                    break;
            }
        }
        #endregion 自动流程

        #region 私有方法

        /// <summary>
        /// 清除方法，重置相关信号
        /// </summary>
        public void Clear()
        {
            给移载平台有料盘信号 = false;
        }

        #endregion 私有方法
    }
}