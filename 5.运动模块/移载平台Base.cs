using BoTech;
using CoreFunction;
using Help;
using LogsHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using XStation;
using static CoreFunction.mFunction;
using static Help.AxisHelper;
using static ParName.名称枚举;

namespace 运动模块
{
    public abstract class 移载平台Base : mWorkShare
    {
        #region 私有变量

        internal abstract Task_ID task_ID { get; }// 工站ID 00 01 02 03 04 05 06
        internal abstract AxisID axisID { get; }/// 轴ID 轴 枚 举
        internal abstract StationID stationID { get; }/// 工位信息
        internal abstract Axis axis { get; }/// 轴方向 X、Y、Z等

        #endregion 私有变量

        #region 输入信号
        public abstract bool 移栽流入光电检测 { get; }
        public abstract bool 移栽到位光电检测 { get; }
        public abstract bool 移栽顶升气缸缩回位 { get; }
        public abstract bool 移栽顶升气缸伸出位 { get; }
        public abstract bool 移栽夹紧气缸缩回位 { get; }
        public abstract bool 移栽夹紧气缸伸出位 { get; }

        #endregion 输入信号

        #region 输出信号
        public abstract bool 移栽流线正转 { set; }
        public abstract bool 移栽流线反转 { set; }
        public abstract bool 移栽流线停止 { set; }
        public abstract bool 移栽顶升气缸缩回 { set; }
        public abstract bool 移栽顶升气缸伸出 { set; }
        public abstract bool 移栽夹紧气缸缩回 { set; }
        public abstract bool 移栽夹紧气缸伸出 { set; }

        #endregion 输出信号

        #region 交互信号

        public short 回零步序 { get; set; }

        public abstract bool 机械手取料中 { get; } // 输入
        public abstract bool 流线左有料信号 {  set; } // 输出
        public abstract bool 流线右有料信号 {  set; } // 输出


        public abstract bool 给上料进料盘完成信号 { get; set; } // 移栽光电到位
        public abstract bool 给上料要料盘信号 { get; set; } // 
        public abstract bool 上料有料盘信号 { get; } 

        public abstract bool 给下料有料盘信号 { get; set; }  // 移载平台有料盘信号
        public abstract bool 下料要料盘信号 { get; } // 给移载平台要料盘信号
        public abstract bool 下料完成 { get; set; }

        //*******************************************************


        #endregion 交互信号

        #region 事件委托

        //public abstract Action 顶升气缸伸出 { get; set; }
        //public abstract Action 顶升气缸缩回 { get; set; }

        #endregion

        #region 基础功能

        public override void Initialize()
        {
            TaskID = (short)task_ID;
            WkManager.BindStation((short)task_ID, task_ID.ToString(), this);

            _Logs = new cLogs(TaskName, TaskID);
            mDoDi.mAction += Err;
            pMove.mAction += Err;
            //顶升气缸伸出 += () => 顶升伸出 = true;
            //顶升气缸缩回 += () => 顶升伸出 = false;
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
                    AddLog($"{zThread.Name}: {CtrName} {ErrInfo}", LogsType._ErrorCode, WorkStep_Int, true);
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
                //ExitInterferenceZone(InterferenceZone_干涉区.移载平台干涉区);
                Clear();
                StaHomeOK = true;
                AddLog($"{this.TaskName}" + "复位完成", LogsType._Auto, 0, true);
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
                        移栽流线停止 = true; // TODO: 这里可能有问题
                        回零步序 = (int)GoHomeStep.判断流线是否有料;
                        break;

                    case GoHomeStep.判断流线是否有料:
                        回零步序 = 移栽流入光电检测 || 移栽到位光电检测
                            ? (short)myTipNew(GoHomeStep.判断流线是否有料, GoHomeStep.夹紧气缸缩回, eErrCode.清料盘提示)
                            : (short)(int)GoHomeStep.夹紧气缸缩回;
                        break;
                    case GoHomeStep.夹紧气缸缩回:
                        移栽夹紧气缸缩回 = true;
                        回零步序 = (int)GoHomeStep.夹紧气缸缩回到位判断;
                        break;

                    case GoHomeStep.夹紧气缸缩回到位判断:
                        if (移栽夹紧气缸缩回位)
                        {
                            回零步序 = (int)GoHomeStep.顶升气缸缩回;
                        }
                        else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                        {
                            回零步序 = (short)myTipNew(GoHomeStep.夹紧气缸缩回, GoHomeStep.夹紧气缸缩回到位判断, eErrCode.夹紧气缸缩回超时);
                        }
                        break;

                    case GoHomeStep.顶升气缸缩回:
                        移栽顶升气缸缩回 = true;
                        回零步序 = (int)GoHomeStep.顶升气缸缩回到位判断;
                        break;

                    case GoHomeStep.顶升气缸缩回到位判断:
                        if (移栽顶升气缸缩回位)
                        {
                            回零步序 = (int)GoHomeStep.移载轴回原点;
                        }
                        if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                        {
                            回零步序 = (short)myTipNew(GoHomeStep.顶升气缸缩回, GoHomeStep.顶升气缸缩回到位判断, eErrCode.顶升气缸缩回超时);
                        }
                        break;

                    case GoHomeStep.移载轴回原点:
                        if (AxisGoHome(this, axisID, true))
                        {
                            回零步序 = (int)GoHomeStep.判断移载轴回原点是否成功;
                        }
                        break;
                    case GoHomeStep.判断移载轴回原点是否成功:
                        if (IsHomeFinished(axisID))
                        {
                            回零步序 = (int)GoHomeStep.清除数据;
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
            判断流线是否有料,
            夹紧气缸缩回,
            夹紧气缸缩回到位判断,
            顶升气缸缩回,
            顶升气缸缩回到位判断,
            移载轴回原点,
            判断移载轴回原点是否成功,
            清除数据,
            回零成功,
            回零失败 = 1000,
        }

        #endregion 回零

        #region 流程枚举

        public enum Workstep
        {
            
            接料条件判断 = 10,
            就位接料盘位,// X 轴移动至接料位
            执行接料,
            移栽夹紧气缸伸出,
            移栽夹紧气缸伸出到位判断,
            移栽顶升气缸伸出,
            移栽顶升气缸伸出到位判断,
            就位出料盘位, // X 轴移动至 出料位 并给机械手抓取
            等待机械手抓料完成, // 给对方机械手信号执行抓料
            移栽顶升气缸缩回,
            移栽顶升气缸缩回到位判断,
            移栽夹紧气缸缩回,
            移栽夹紧气缸缩回到位判断,
            下料判断,  // 
            执行下料, // 顶升缩回, 夹紧缩回,流线反转
            更新UPH,
            出料完成, 
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
               

                case Workstep.接料条件判断:
                    if (ParHelper.OffLine_VirtualRun脱机空跑 || (!移栽流入光电检测 && !移栽到位光电检测))
                    {
                        放料日志分割();
                        给上料要料盘信号 = true;
                        if (上料有料盘信号)
                        {
                            mGlobal.进料时间.Enqueue(DateTime.Now);
                            WorkStep_Int = (int)Workstep.就位接料盘位;
                        }
                    }
                    else
                    {
                        WorkStep_Int = (short)myTipNew(Workstep.接料条件判断, Workstep.就位接料盘位, eErrCode.清料盘提示);
                    }
                    break;

                case Workstep.就位接料盘位:
                    if (AxisGoPoint(stationID, axisID, (int)PosName.接料盘位, axis, true))
                    {
                        WorkStep_Int = (int)Workstep.执行接料;
                    }
                    break;
                case Workstep.执行接料:
                    移栽流线正转 = true;
                    if ((移栽到位光电检测) || ParHelper.不带载具空跑 || ParHelper.VirtualRunWithCarrier带载具空跑)
                    {
                        Thread.Sleep(1000);
                        给上料要料盘信号 = false;
                        移栽流线停止 = true;
                        Thread.Sleep(500);
                        WorkStep_Int = (int)Workstep.移栽夹紧气缸伸出;
                    }
                    break;
                case Workstep.移栽夹紧气缸伸出:
                    移栽夹紧气缸伸出 = true;
                    WorkStep_Int = (int)Workstep.移栽夹紧气缸伸出到位判断;
                    break;
                case Workstep.移栽夹紧气缸伸出到位判断:
                    if (移栽夹紧气缸缩回位)
                    {
                        回零步序 = (int)Workstep.移栽顶升气缸伸出;
                    }
                    else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                    {
                        // 超时处理
                        回零步序 = (short)myTipNew(Workstep.移栽夹紧气缸伸出, Workstep.移栽夹紧气缸伸出到位判断, eErrCode.夹紧气缸缩回超时);
                    }
                    break;
                case Workstep.移栽顶升气缸伸出:
                    移栽顶升气缸伸出 = true;
                    WorkStep_Int = (int)Workstep.移栽顶升气缸伸出到位判断;
                    break;
                case Workstep.移栽顶升气缸伸出到位判断:
                    if (移栽顶升气缸伸出位)
                    {
                        回零步序 = (int)Workstep.就位出料盘位;
                    }
                    else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                    {
                        // 超时处理
                        回零步序 = (short)myTipNew(Workstep.移栽顶升气缸伸出, Workstep.移栽顶升气缸伸出到位判断, eErrCode.顶升气缸伸出超时);
                    }
                    break;
                case Workstep.就位出料盘位:
                    if (AxisGoPoint(stationID, axisID, (int)PosName.出料盘位, axis, true))
                    {
                        流线左有料信号 = true;
                        流线右有料信号 = true;
                        WorkStep_Int = (int)Workstep.等待机械手抓料完成;
                    }
                    break;
                case Workstep.等待机械手抓料完成:
                    if (!机械手取料中) // 机械手取料完成
                    {
                        流线左有料信号 = false;
                        流线右有料信号 = false;
                    }
                    WorkStep_Int = (int)Workstep.移栽顶升气缸缩回;
                    break;
                case Workstep.移栽顶升气缸缩回:
                    移栽顶升气缸缩回 = true;
                    WorkStep_Int = (int)Workstep.移栽顶升气缸缩回到位判断;
                    break;
                case Workstep.移栽顶升气缸缩回到位判断:
                    if (移栽顶升气缸缩回位)
                    {
                        回零步序 = (int)Workstep.移栽夹紧气缸缩回;
                    }
                    else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                    {
                        // 超时处理
                        回零步序 = (short)myTipNew(Workstep.移栽顶升气缸缩回, Workstep.移栽顶升气缸缩回到位判断, eErrCode.顶升气缸缩回超时);
                    }
                    break;
                case Workstep.移栽夹紧气缸缩回:
                    移栽夹紧气缸缩回 = true;
                    WorkStep_Int = (int)Workstep.移栽夹紧气缸缩回到位判断;
                    break;
                case Workstep.移栽夹紧气缸缩回到位判断:
                    if (移栽夹紧气缸缩回位)
                    {
                        回零步序 = (int)Workstep.下料判断;
                    }
                    else if (OverTime(StaInfo.起始时间, ParHelper.气缸信号报警超时))
                    {
                        // 超时处理
                        回零步序 = (short)myTipNew(Workstep.移栽夹紧气缸缩回, Workstep.移栽夹紧气缸缩回到位判断, eErrCode.夹紧气缸缩回超时);
                    }
                    break;
                case Workstep.下料判断:
                    给下料有料盘信号 = true;
                    if (下料要料盘信号)
                    {
                        WorkStep_Int = (int)Workstep.执行下料;
                    }
                    break;
                case Workstep.执行下料:
                    if (移栽流入光电检测 || 移栽到位光电检测 || ParHelper.不带载具空跑)
                    {
                        移栽流线反转 = true;
                    }
                    if ((!移栽流入光电检测 && !移栽到位光电检测) || ParHelper.不带载具空跑 || ParHelper.OffLine_VirtualRun脱机空跑)
                    {
                        mGlobal.出料时间.Enqueue(DateTime.Now);
                        Thread.Sleep(1000);
                        给下料有料盘信号 = false;
                        移栽流线停止 = true;
                        WorkStep_Int = (int)Workstep.更新UPH;
                    }
                    break;
                case Workstep.更新UPH: 

                    bool flag1 = mGlobal.进料时间.TryDequeue(out DateTime inTime);
                    bool flag2 = mGlobal.出料时间.TryDequeue(out DateTime outtime);
                    if (flag1 && flag2)
                    {
                        mGlobal.CT = (outtime - inTime).TotalSeconds;
                        mGlobal.更新每小时CT(mGlobal.CT);
                        Debug.WriteLine(mGlobal.CT);
                    }
                    WorkStep_Int = (int)Workstep.出料完成;
                    break;
                case Workstep.出料完成:
                    if (下料完成)
                    {
                        WorkStep_Int = (int)Workstep.接料条件判断;
                        AutoFunction += 进料流程;
                    }
                    break;
            }
        }
        #endregion 自动流程

        #region 点位名称

        private enum PosName
        {
            接料盘位, // X轴
            出料盘位, // X轴
            //机械手放料位,
            //避让位
        }

        #endregion 点位名称

        #region 私有方法

        public void Clear()
        {
            给上料要料盘信号 = false;
            给下料有料盘信号 = false;
            mGlobal.进料时间.Clear();
            mGlobal.出料时间.Clear();
        }

        public abstract void 放料日志分割();
        #endregion 私有方法
    }
}