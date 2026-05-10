using Help;
using MotionFunction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using XStation;
using 运动模块;
using static CoreFunction.mFunction;
using static ParName.名称枚举;

namespace BoTech
{
    internal sealed class 自动运行
    {
        #region "点击自动运行调用代码"

        public static void RunClick() //点击自动运行调用代码
        {
            if (mGlobal.isManaul)
            {
                GlobalVoid.MachineWriteLog("请切换到自动模式运行!!!");
                MessageBox.Show("请切换到自动模式运行!!!");
                return;
            }
            if (mGlobal.OffLine_VirtualRun脱机空跑) // 模式判定放在READY的前面
            {
                MotionDll.VirtualMode = true; //不带硬件虚拟空跑用,在设备通电正常条件下禁止使用
                MotionDll.ConvVitMode = true; //流水线虚拟空跑用,在设备通电正常条件下禁止使用
            }
            else
            {
                MotionDll.ConvVitMode = false;
                MotionDll.VirtualMode = false; //不带硬件虚拟空跑用,在设备通电正常条件下禁止使用
            }

            if (ParHelper.启用安全门功能)    //安全门功能勾选
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

            foreach (KeyValuePair<short, mWorkShare> key in mTaskManager.Instance.mTaskMap)
            {
                key.Value.ManaulRun = false;
            }
            if (!CheckTaskReady())
            {
                Frm_ICT_Main.Instance.runbutton = true;
                return;
            }

            WkManager.StepSave = false;  //关闭步序自动存储,默认开启
            IsSysStop = false;
            GlobalVar.FailTipAlarmAllClose.Set();
            if (WkManager.Start(WkManager.TaskRunType.mThread, 500, true))  //切换运行状态是否成功
            {
                SysState = State.RUNNING;
                Frm_ICT_Main.Instance.Btn_ProductType.BeginInvoke(new Action(() =>
                {
                    // 界面相关按钮切换
                    Frm_ICT_Main.Instance.Btn_Run.ButtonStateChange(NewButtonState.Energized);
                    Frm_ICT_Main.Instance.Btn_Pause.ButtonStateChange(NewButtonState.Deenergized);
                    Frm_ICT_Main.Instance.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                }));

                mGlobal.IsStartAutoRun = true;
                mGlobal.IdleFlag = false;
            }
            else
            {
                SysState = State.ALARM;
                IsSysStop = true;

                if (!WkManager.AllHomeOK())  //所有工位回原点完成
                {
                    GoHome.Home_OK = false;
                    Frm_ICT_Main.Instance.Btn_ProductType.BeginInvoke(new Action(() =>
                    {
                        // 界面相关按钮切换
                        Frm_ICT_Main.Instance.Btn_Pause.ButtonStateChange(NewButtonState.Disabled);
                        Frm_ICT_Main.Instance.Btn_Stop.ButtonStateChange(NewButtonState.Disabled);
                    }));
                }
            }
        }

        #endregion "点击自动运行调用代码"

        public static bool CheckTaskReady()
        {
            Task<short>[] TaskArray = new Task<short>[6];
            TaskArray[0] = Task.Run(() => mTaskManager.Instance.mTaskMap[(short)Task_ID.Task01_L上料].mReady());
            TaskArray[1] = Task.Run(() => mTaskManager.Instance.mTaskMap[(short)Task_ID.Task02_R上料].mReady());
            TaskArray[2] = Task.Run(() => mTaskManager.Instance.mTaskMap[(short)Task_ID.Task03_L移载平台].mReady());
            TaskArray[3] = Task.Run(() => mTaskManager.Instance.mTaskMap[(short)Task_ID.Task04_R移载平台].mReady());
            TaskArray[4] = Task.Run(() => mTaskManager.Instance.mTaskMap[(short)Task_ID.Task05_L下料].mReady());
            TaskArray[5] = Task.Run(() => mTaskManager.Instance.mTaskMap[(short)Task_ID.Task06_R下料].mReady());

            Task.WaitAll(TaskArray);

            foreach (Task<short> item in TaskArray)
            {
                if (item.Result == -1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}