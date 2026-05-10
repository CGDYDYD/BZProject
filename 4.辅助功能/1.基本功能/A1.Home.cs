using System;
using System.Drawing;
using System.Windows.Forms;
using UserHelper;
using XStation;
using static CoreFunction.mFunction;

namespace BoTech
{
    internal sealed class GoHome
    {
        public static bool Home_OK; //设备回原点完成标志

        public static void HomeStatus(short StaID)
        {
            object obj = new object();
            lock (obj)
            {
                if (WkManager.AllHomeOK())
                {
                    if (Home_OK)
                    {
                        return;
                    }

                    Home_OK = true;
                    try
                    {
                        if (SysState != State.WAITRUN && SysState != State.RUNNING)
                        {
                            Frm_ICT_Main.Instance.Invoke((Action)delegate
                            {
                                Frm_ICT_Main.Instance.Btn_Stop.ButtonStateChange(NewButtonState.Energized);
                                Frm_ICT_Main.Instance.Btn_Run.ButtonStateChange(NewButtonState.Deenergized);
                            });
                            LightStatus = (short)LightEnum.自动模式等待启动状态;
                            SysState = State.WAITRUN;
                            GlobalVoid.MachineWriteLog("整机复位结束");
                            MessageBox.Show("整机复位结束");
                            Frm_ICT_Main.Instance.Btn_ProductType.BackColor = Color.Yellow;
                            Frm_ICT_Main.Instance.runbutton = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Frm_ICT_Main.Instance.Btn_ProductType.BackColor = Color.Transparent;
                        DebugHelper.WriteLine(ex);
                        GlobalVoid.MachineWriteLog("整机复位失败");
                    }
                }
            }
        }
    }
}