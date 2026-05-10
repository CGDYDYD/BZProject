using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UserHelper
{
    public partial class SystemHelper
    {
        public static long GetLastInputTime()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            return !GetLastInputInfo(ref vLastInputInfo) ? 0 : Environment.TickCount - vLastInputInfo.dwTime;
        }

        /// <summary>
        /// 判断Windows系统是否为旧版本
        /// </summary>
        public static bool IsOldOsVersion()
        {
            OperatingSystem os = Environment.OSVersion;
            return os.Platform != PlatformID.Win32NT || os.Version.Major < 6;
        }

        /// <summary>
        /// 关闭屏幕键盘
        /// </summary>
        public static bool CloseOSK()
        {
            Process[] sProcess = Process.GetProcessesByName("OSK");
            try
            {
                return sProcess.Length > 0 && sProcess[0].CloseMainWindow();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 打开屏幕键盘
        /// </summary>
        public static void OpenOSK()
        {
            Process.Start("osk.exe");
        }
    }

    public partial class SystemHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            // 设置结构体块容量
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;

            // 捕获的时间
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
    }
}