using BoTech;
using CoreFunction;
using Help;
using LogsHelper;
using System;
using System.Threading;
using XStation;
using static CoreFunction.mFunction;
using static Help.AxisHelper;
using static ParName.名称枚举;

namespace 运动模块
{
    public abstract class 下料Base : mWorkShare
    {
        #region 私有变量

        internal abstract Task_ID task_ID { get; }
        internal abstract AxisID axisID { get; }
        internal abstract StationID stationID { get; }
        internal abstract Axis axis { get; }

        #endregion 私有变量

        #region 输入信号
        public abstract bool 出料流线流入光电 { get; }
        public abstract bool 出料流线到位光电 { get; }
        public abstract bool 出料流线有料检测光电 { get; }
        public abstract bool 出料顶升气缸原点 { get; }
        public abstract bool 出料顶升气缸动点 { get; }
        public abstract bool 出料分盘气缸原点 { get; }
        public abstract bool 出料分盘气缸动点 { get; }
        public abstract bool 出料流线缺料对射 { get; } // 按现在的逻辑来说用不到
        public abstract bool 出料流线满料对射 { get; }

        // *****************************************************
        public abstract bool 操作按钮 { get; }
        public abstract bool 进料感应 { get; }
        public abstract bool 出料感应 { get; }
        public abstract bool 分盘感应 { get; }
        public abstract bool 满料感应 { get; }
        public abstract bool 分盘气缸伸出位 { get; }
        public abstract bool 分盘气缸缩回位 { get; }

        #endregion 输入信号

        #region 输出信号
        public abstract bool 出料流线正转 { set; }
        public abstract bool 出料流线反转 { set; }
        public abstract bool 出料流线停止 { set; }
        public abstract bool 出料顶升气缸缩回 { set; }
        public abstract bool 出料顶升气缸伸出 { set; }
        public abstract bool 出料分盘气缸缩回 { set; }
        public abstract bool 出料分盘气缸伸出 { set; }

        // ***************************************************
        public abstract bool 流线进料 { set; }
        public abstract bool 流线出料 { set; }

        public abstract bool 流线停止 { set; }

        public abstract bool 分盘气缸伸出 { set; }
        public abstract bool 按钮灯 { set; }

        #endregion 输出信号

        #region 事件委托

        //public abstract Action 进料Event { get; set; }

        #endregion

        #region 交互信号

        public short 回零步序 { get; set; }
        public abstract bool 给移载平台要料盘信号 { get; set; }

        public abstract bool 移载平台有料盘信号 { get; }

        public abstract bool 给移载平台下料完成信号 { get; set; }

        #endregion 交互信号

        #region 基础功能

        public override void Initialize()
        {
            TaskID = (short)task_ID;
            WkManager.BindStation((short)task_ID, task_ID.ToString(), this);

            _Logs = new cLogs(TaskName, TaskID);
            mDoDi.mAction += Err;
            pMove.mAction += Err;
            //进料Event += () => 流线进料 = true;
            base.Initialize();
        }

        public override void Err(string CtrName, string ErrInfo)
        {
            switch (CtrName)
            {
                case "DoAndDi":
                    if (State != State.RUNNING && State != State.MANUAL)
                    {
                        zThread.Abort();
                        return;
                    }
                    break;

                case "mSend":
                    zThread.Abort();
                    break;

                case "Moving":
                    mFunction.DialogShow(1, $"{zThread.Name}: {CtrName} {ErrInfo}", 1);
                    State = State.WAITRUN;
                    zThread.Abort();
                    break;
            }
        }

        public override short mReady()
        {
            if (this.State == State.WAITRESET)
            {
                return 0;
            }
            WorkStep_Int = 10;

            AutoFunction = null;
            AutoFunction += 进料流程;
            return 1;
        }

        #endregion 基础功能

        #region 回零

        public override void Homing()
        {
            base.Homing();
            State = State.RESETTING;
            AddLog($"{(GoHomeStep)回零步序}", LogsType._Auto, 回零步序, true);
            if (mGlobal.OffLine_VirtualRun脱机空跑)
            {
                Clear();
                StaHomeOK = true;
            }
            else
            {
                SetStep(ref StaInfo, 回零步序, true);

                switch ((GoHomeStep)回零步序)
                {
                    case GoHomeStep.轴上使能:
                        SeverOFF(axisID);
                        Thread.Sleep(1000);
                        SeverON(axisID);
                        if (GetServoState(axisID))
                        {
                            回零步序 = (int)GoHomeStep.流线停止;
                        }
                        break;

                    case GoHomeStep.流线停止:
                        出料流线停止 = true;
                        回零步序 = (int)GoHomeStep.料仓回原点;
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
                            回零步序 = (int)GoHomeStep.判断流线是否有料;
                        }
                        break;

                    case GoHomeStep.判断流线是否有料:
                        回零步序 = 出料流线流入光电 || 出料流线到位光电 || 出料流线有料检测光电 ? (short)myTipNew(GoHomeStep.判断流线是否有料, GoHomeStep.料仓回接料位, eErrCode.清料盘提示) : (short)(int)GoHomeStep.料仓回接料位;
                        break;

                    case GoHomeStep.料仓回接料位:
                        if (AxisGoPoint(stationID, axisID, (int)PosName.接料位, axis, true))
                        {
                            回零步序 = (int)GoHomeStep.顶升气缸伸出;
                        }
                        break;
                    case GoHomeStep.顶升气缸伸出:
                        出料顶升气缸伸出 = true;
                        回零步序 = (int)GoHomeStep.顶升气缸伸出到位判断;
                        break;

                    case GoHomeStep.顶升气缸伸出到位判断:
                        if (出料顶升气缸动点)
                        {
                            回零步序 = (int)GoHomeStep.分盘气缸伸出;
                        }
                        else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                        {
                            回零步序 = (short)myTipNew(GoHomeStep.顶升气缸伸出, GoHomeStep.顶升气缸伸出到位判断, eErrCode.顶升气缸伸出超时);
                        }
                        break;

                    case GoHomeStep.分盘气缸伸出:
                        出料分盘气缸伸出 = true;
                        回零步序 = (int)GoHomeStep.分盘气缸伸出到位判断;
                        break;

                    case GoHomeStep.分盘气缸伸出到位判断:
                        if (出料分盘气缸动点)
                        {
                            回零步序 = (int)GoHomeStep.清除数据;
                        }
                        else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                        {
                            回零步序 = (short)myTipNew(GoHomeStep.分盘气缸伸出, GoHomeStep.分盘气缸伸出到位判断, eErrCode.分盘气缸伸出超时);
                        }
                        break;

                    case GoHomeStep.清除数据:
                        Clear();
                        回零步序 = (int)GoHomeStep.回零成功;
                        break;

                    case GoHomeStep.回零成功:
                        StaHomeOK = true;
                        回零步序 = 0;
                        break;

                    case GoHomeStep.回零失败:
                        StaHomeOK = false;
                        回零步序 = 0;
                        WkManager.Cancel();
                        break;
                }
            }
            mReady();
        }

        private enum GoHomeStep
        {
            轴上使能,
            流线停止,
            判断流线是否有料, // 有料的话报警并且提示取料
            料仓回原点, // Z轴回到原点位置
            判断料仓回原点是否成功,
            料仓回接料位,
            顶升气缸伸出,
            顶升气缸伸出到位判断,
            分盘气缸伸出,
            分盘气缸伸出到位判断,
            清除数据,
            回零成功,
            回零失败 = 1000,
        }

        #endregion 回零

        #region 点位名称

        private enum PosName
        {
            供料位,
            分盘位,
            接料位,

            //接料位,
            //分盘位,
            //过渡位,
            //取料盘位,
            //下料盘位
        }

        #endregion 点位名称

        #region 流程枚举

        private enum Workstep
        {
            流程开始 = 10,
            接料条件判断,
            执行接料,
            接料完成,
            轴就位供料位,
            分盘气缸缩回,
            分盘气缸缩回位到位判断,
            轴就位分盘位,
            分盘气缸伸出,
            分盘气缸伸出位到位判断,
            轴就位接料位,

            //轴就位取料盘位,
            //轴就位接料位,
            //分盘气缸缩回,
            //分盘气缸缩回位到位判断,
            //进料条件判断,
            //执行进料,
            //进料完成,
            //轴就位过渡位,
            //轴就位分盘位,
            //分盘气缸伸出,
            //分盘气缸伸出位到位判断,
            //轴就位下料盘位,
            //等待下料盘完成
        }

        #endregion 流程枚举

        #region 自动流程

        /// <summary>
        /// 主程序
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
            AutoFunction?.Invoke();
        }

        private void 进料流程()
        {
            AutoLog<Workstep>();
            switch ((Workstep)WorkStep_Int)
            {
                case Workstep.流程开始:
                    给移载平台要料盘信号 = false;
                    if (ParHelper.OffLine_VirtualRun脱机空跑)
                    {
                        按钮灯 = false;  // TODO: 按钮灯???
                        WorkStep_Int = (int)Workstep.接料条件判断;
                    }
                    else if (出料流线满料对射)
                    {
                        按钮灯 = true;
                        WorkStep_Int = (int)myTipNew(Workstep.流程开始, Workstep.流程开始, eErrCode.满料盘提示);
                    }
                    else
                    {
                        按钮灯 = false;
                        WorkStep_Int = (int)Workstep.接料条件判断;
                    }

                    break;
                case Workstep.接料条件判断:
                    if (移载平台有料盘信号)
                    {
                        WorkStep_Int = (int)Workstep.执行接料;
                    }
                    break;
                case Workstep.执行接料:
                    出料流线反转 = true;
                    给移载平台要料盘信号 = true;
                    WorkStep_Int = (int)Workstep.接料完成;
                    break;
                case Workstep.接料完成:
                    // 停止流线
                    出料流线停止 = true;
                    // 重置信号
                    给移载平台要料盘信号 = false;
                    // 判断
                    if (出料流线到位光电 || ParHelper.OffLine_VirtualRun脱机空跑)
                    {
                        WorkStep_Int = (int)Workstep.轴就位供料位;
                    } 
                    else
                    {
                        // 出料异常处理
                        WorkStep_Int = (short)myTipNew(Workstep.执行接料, Workstep.接料完成, eErrCode.接料盘异常);
                    }
                    break;
                case Workstep.轴就位供料位:
                    if (AxisGoPoint(stationID, axisID, (int)PosName.供料位, axis, true))
                    {
                        WorkStep_Int = (int)Workstep.分盘气缸缩回;
                    }
                    break;
                case Workstep.分盘气缸缩回:
                    出料分盘气缸缩回 = true;
                    WorkStep_Int = (int)Workstep.分盘气缸缩回位到位判断;
                    break;

                case Workstep.分盘气缸缩回位到位判断:
                    if (出料分盘气缸原点)
                    {
                        WorkStep_Int = (int)Workstep.轴就位分盘位;
                    }
                    else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                    {
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
                    出料分盘气缸伸出 = true;
                    WorkStep_Int = (int)Workstep.分盘气缸伸出位到位判断;
                    break;

                case Workstep.分盘气缸伸出位到位判断:
                    if (出料分盘气缸动点)
                    {
                        WorkStep_Int = (int)Workstep.轴就位接料位;
                    }
                    else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                    {
                        WorkStep_Int = (short)myTipNew(Workstep.分盘气缸伸出, Workstep.分盘气缸伸出位到位判断, eErrCode.分盘气缸伸出超时);
                    }
                    break;

                case Workstep.轴就位接料位:
                    if (AxisGoPoint(stationID, axisID, (int)PosName.接料位, axis, true))
                    {
                        WorkStep_Int = (int)Workstep.流程开始;
                        AutoFunction = null;
                        AutoFunction += 进料流程;
                    }
                    break;
            }
        }
        #endregion 自动流程

        #region 私有方法

        public void Clear()
        {
            给移载平台要料盘信号 = false;
            给移载平台下料完成信号 = false;
        }

        #endregion 私有方法
    }
}