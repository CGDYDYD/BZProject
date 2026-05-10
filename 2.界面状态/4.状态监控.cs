using CoreFunction;
using Help;
using System.Threading;
using XStation;
using 运动模块;
using static CoreFunction.mFunction;
using static MotionFunction.MotionDll;
using static ParName.名称枚举;

namespace BoTech

{
    public sealed class 状态更新
    {
        public static void AlarmCheck() //侦测设备状态及界面数据及状态刷新用，定时器持续扫描
        {
            if (ReadDiS(SysPar.EMC_In_Index) == 0 && !mGlobal.OffLine_VirtualRun脱机空跑)
            {
                if (SysState != State.ESTOP)
                {
                    MacStop();
                    Task00_空站.Instance.myTipNew(eErrCode.急停按钮按下, true);
                }
            }
            else if (SysState == State.ESTOP)
            {
                SysState = State.WAITRESET;
            }

            if (!ParHelper.OffLine_VirtualRun脱机空跑 && !AxisHelper.GetDI(InNo.总气压信号))
            {
                Task00_空站.Instance.myTipNew(eErrCode.总气压信号异常, true);
            }

            if (GoHome.Home_OK)
            {
                if (ParHelper.启用安全门功能 && SysState == State.RUNNING)    //安全门功能勾选
                {
                    if (!AxisHelper.GetDI(InNo.前安全门信号))
                    {
                        Task00_空站.Instance.myTipNew(eErrCode.前安全门信号异常);
                    }
                    
                    if (!AxisHelper.GetDI(InNo.后安全门信号))
                    {
                        Task00_空站.Instance.myTipNew(eErrCode.后安全门信号异常);
                    }
                }
            }
        }

        public static void MacStop() //急停时调用代码
        {
            if (SysState == State.ESTOP)
            {
                return;
            }

            WkManager.Cancel();
            SysState = State.ESTOP; //停止标志置位
            for (int i = 1; i <= SysPar.AxisNum; i++) //所有轴回原点步序号清0
            {
                HomeStep[AxisIndex[i].CardNum, AxisIndex[i].AxisNum] = 0;
                HomeOk[AxisIndex[i].CardNum, AxisIndex[i].AxisNum] = false;
                mAxisOff((short)i);
            }

            GoHome.Home_OK = false;

            foreach (AutoConv.nConveyor tConveyor in WkManager.mConvList)
            {
                tConveyor.ConvStop();
            }

            mGlobal.IsStartAutoRun = false;
            Frm_ICT_Main.Instance.Btn_Run.ButtonStateChange(NewButtonState.Deenergized);
            Frm_ICT_Main.Instance.Btn_Pause.ButtonStateChange(NewButtonState.Disabled);
            Frm_ICT_Main.Instance.Btn_Stop.ButtonStateChange(NewButtonState.Energized);
        }

        public static void LightStatus() //三色灯控制及界面状态切换，刷新频率较低（500ms）
        {
            switch ((LightEnum)mFunction.LightStatus)
            {
                case LightEnum.设备初始化中:
                    WriteDo(OutNo.三色灯红.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯黄.EnumToShort(), 1);
                    WriteDo(OutNo.三色灯绿.EnumToShort(), 0);
                    Thread.Sleep(500);
                    WriteDo(OutNo.三色灯黄.EnumToShort(), 0);
                    WriteDo(OutNo.蜂鸣器.EnumToShort(), 0);
                    break;

                case LightEnum.软件未启动:
                    WriteDo(OutNo.三色灯绿.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯黄.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯红.EnumToShort(), 0);
                    WriteDo(OutNo.蜂鸣器.EnumToShort(), 0);

                    break;

                case LightEnum.自动运行中:
                    WriteDo(OutNo.三色灯绿.EnumToShort(), 1);
                    WriteDo(OutNo.三色灯黄.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯红.EnumToShort(), 0);
                    WriteDo(OutNo.蜂鸣器.EnumToShort(), 0);
                    break;

                case LightEnum.运行中报警:
                    WriteDo(OutNo.三色灯绿.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯黄.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯红.EnumToShort(), 1);
                    break;

                case LightEnum.手动模式故障报警:
                    WriteDo(OutNo.三色灯绿.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯黄.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯红.EnumToShort(), 1);
                    WriteDo(OutNo.蜂鸣器.EnumToShort(), 0);
                    Thread.Sleep(500);
                    break;

                case LightEnum.手动模式调试状态:
                    WriteDo(OutNo.三色灯绿.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯黄.EnumToShort(), 1);
                    WriteDo(OutNo.三色灯红.EnumToShort(), 0);
                    WriteDo(OutNo.蜂鸣器.EnumToShort(), 0);
                    Thread.Sleep(1000);
                    WriteDo(OutNo.三色灯黄.EnumToShort(), 0);
                    Thread.Sleep(500);
                    break;

                case LightEnum.自动模式等待启动状态:
                    WriteDo(OutNo.三色灯绿.EnumToShort(), 1);
                    WriteDo(OutNo.三色灯黄.EnumToShort(), 0);
                    WriteDo(OutNo.三色灯红.EnumToShort(), 0);
                    WriteDo(OutNo.蜂鸣器.EnumToShort(), 0);
                    Thread.Sleep(1000);
                    WriteDo(OutNo.三色灯绿.EnumToShort(), 0);
                    break;
            }
        }

        public static void ButtonLightStatus()//按钮灯状态
        {
            if (AxisHelper.GetDI(InNo.启动按钮信号))
            {
                WriteDo(OutNo.启动按钮灯.EnumToShort(), 1);
                return;
            }
            if (AxisHelper.GetDI(InNo.复位按钮信号))
            {
                WriteDo(OutNo.复位按钮灯.EnumToShort(), 1);
                return;
            }
            if (AxisHelper.GetDI(InNo.停止按钮信号))
            {
                WriteDo(OutNo.停止按钮灯.EnumToShort(), 1);
                return;
            }
            switch ((LightEnum)mFunction.LightStatus)
            {
                case LightEnum.软件未启动:
                    WriteDo(OutNo.启动按钮灯.EnumToShort(), 0);
                    WriteDo(OutNo.复位按钮灯.EnumToShort(), 0);
                    WriteDo(OutNo.停止按钮灯.EnumToShort(), 0);
                    break;

                case LightEnum.自动运行中:
                    WriteDo(OutNo.启动按钮灯.EnumToShort(), 1);
                    WriteDo(OutNo.复位按钮灯.EnumToShort(), 0);
                    WriteDo(OutNo.停止按钮灯.EnumToShort(), 0);
                    break;

                case LightEnum.手动模式调试状态:
                case LightEnum.自动模式等待启动状态:
                case LightEnum.设备初始化中:

                    WriteDo(OutNo.启动按钮灯.EnumToShort(), 0);
                    WriteDo(OutNo.复位按钮灯.EnumToShort(), 1);
                    WriteDo(OutNo.停止按钮灯.EnumToShort(), 0);
                    Thread.Sleep(500);
                    WriteDo(OutNo.复位按钮灯.EnumToShort(), 0);
                    break;

                case LightEnum.运行中报警:
                case LightEnum.手动模式故障报警:

                    WriteDo(OutNo.启动按钮灯.EnumToShort(), 0);
                    WriteDo(OutNo.复位按钮灯.EnumToShort(), 0);
                    WriteDo(OutNo.停止按钮灯.EnumToShort(), 1);
                    Thread.Sleep(500);
                    WriteDo(OutNo.停止按钮灯.EnumToShort(), 0);
                    break;
            }
        }
    }
}