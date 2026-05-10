using Reader;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using UserHelper;

namespace BoTech
{
    /// <summary>
    /// 读卡器
    /// </summary>
    public class BardCodeHooK
    {
        #region 定义

        public delegate void CardReadDeletegate(string str);

        public event CardReadDeletegate CardReadEvent;

        private int _hKeyboardHook;

        private System.Timers.Timer timer = new System.Timers.Timer(100);

        #endregion 定义

        public static IntPtr handle;
        private int st;
        public bool 读卡器连接Flag;

        public bool Start()
        {
            st = DllMethod.mwDevOpen("USB", "", out handle);
            if (st < 0)
            {
                读卡器连接Flag = false;
                MessageBox.Show("读卡器连接失败!");
                return false;
            }
            读卡器连接Flag = true;
            DllMethod.mwDevBeep(handle, 1, 2, 2);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            return true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if ((int)handle > 0)
                {
                    byte[] cardUid = new byte[10];
                    int st = DllMethod.mwOpenCard(handle, 1, cardUid); //打开卡片
                    if (st > 0)
                    {
                        StringBuilder cardUidStr = new StringBuilder();
                        DllMethod.BinToHex(cardUid, cardUidStr, st);//将卡号转换为16进制字符串
                        DllMethod.mwDevBeep(handle, 1, 1, 1);
                        string s = cardUidStr.ToString();
                        CardReadEvent?.Invoke(s);
                    }
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        public bool Stop()
        {
            timer.Stop();
            return _hKeyboardHook == 0 || UnhookWindowsHookEx(_hKeyboardHook);
        }

        #region DllImport

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        #endregion DllImport
    }
}