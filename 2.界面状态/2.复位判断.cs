using Help;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using XStation;
using 运动模块;
using static CoreFunction.mFunction;
using static FilePath.mFilePath;
using static MotionFunction.MotionDll;
using static ParName.名称枚举;

namespace BoTech
{
    internal sealed class 初始化
    {
        public static void Initialization()   //回原点前的初始动作
        {
            if (!mGlobal.isManaul && !ParHelper.OffLine_VirtualRun脱机空跑 && MessageBox.Show("只有手动模式才能进行整机复位", "提示", MessageBoxButtons.OK) == DialogResult.OK)
            {
                return;
            }
            if (ParHelper.启用安全门功能)
            {
                if (!AxisHelper.GetDI(InNo.前安全门信号))
                {
                    Task00_空站.Instance.myTipNew(eErrCode.前安全门信号异常);
                    return;
                }

                if (!AxisHelper.GetDI(InNo.后安全门信号))
                {
                    Task00_空站.Instance.myTipNew(eErrCode.后安全门信号异常);
                    return;
                }
            }
            if (MessageBox.Show("是否整机初始化?", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            mGlobal.IsAllStationReset = true;
            SysState = State.WAITRESET;
            GlobalVoid.MachineWriteLog($"整机复位开始。  SW Version:{File.GetLastWriteTime($"{Application.StartupPath}\\{MachineName}.exe")}--{Assembly.GetExecutingAssembly().GetName().Version}");
            LightStatus = (short)LightEnum.设备初始化中;
            if (!ParHelper.OffLine_VirtualRun脱机空跑)
            {
                mGEN.EcatReComm();
            }
            Thread.Sleep(2000);
            GlobalVar.FailTipAlarmAllClose.Reset();
            mGlobal.hivestateselecttimelock = true;

            for (short i = 1; i <= Axis_Num; i++)
            {
                mGlobal.mHomeOk(i, false);
                mGlobal.mHomeStep(i, 10);
            }

            Task03_L移载平台.Instance.Ready();
            Task04_R移载平台.Instance.Ready();
            Task01_L上料.Instance.Ready();
            Task05_L下料.Instance.Ready();
            Task02_R上料.Instance.Ready();
            Task06_R下料.Instance.Ready();

            Task03_L移载平台.Instance.回零步序 = 0;
            Task04_R移载平台.Instance.回零步序 = 0;
            Task01_L上料.Instance.回零步序 = 0;
            Task05_L下料.Instance.回零步序 = 0;
            Task02_R上料.Instance.回零步序 = 0;
            Task06_R下料.Instance.回零步序 = 0;

            Task03_L移载平台.Instance.WorkStep_Int = 10;
            Task04_R移载平台.Instance.WorkStep_Int = 10;
            Task01_L上料.Instance.WorkStep_Int = 10;
            Task05_L下料.Instance.WorkStep_Int = 10;
            Task02_R上料.Instance.WorkStep_Int = 10;
            Task06_R下料.Instance.WorkStep_Int = 10;

            if (mGlobal.OffLine_VirtualRun脱机空跑)
            {
                VirtualMode = true; //不带硬件虚拟空跑用,在设备通电正常条件下禁止使用
                ConvVitMode = true; //流水线虚拟空跑用,在设备通电正常条件下禁止使用
                goto Jumpline;
            }

            for (short i = 1; i <= Axis_Num; i++)
            {
                mClrSts(i);
                Thread.Sleep(20);
                mAxisOn(i);
                Thread.Sleep(20);
                mClrSts(i);
                Thread.Sleep(20);
                mAxisOn(i);
                Thread.Sleep(20);
                SynchAxisPos(i);
                Thread.Sleep(5);
                mGlobal.mHomeOk(i, false);
                Thread.Sleep(5);
                mGlobal.mHomeStep(i, 10);
                Thread.Sleep(5);
            }

            Frm_ICT_Main.Instance.Btn_Pause.ButtonStateChange(NewButtonState.Deenergized);
            Frm_ICT_Main.Instance.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
            Frm_ICT_Main.Instance.Btn_Run.ButtonStateChange(NewButtonState.Energized);
        Jumpline:

            SysState = State.RESETTING;

            WkManager.HomeRtn += GoHome.HomeStatus;           //工位回原点成功后调用

            WkManager.Reset(WkManager.TaskRunType.mThread); //所有工位同时初始化

            Frm_ICT_Main.Instance.Btn_Run.Enabled = true;
        }
    }
}