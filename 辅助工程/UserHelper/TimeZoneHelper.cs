using System;
using System.Runtime.InteropServices;

namespace UserHelper
{
    public static class TimeZoneHelper
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetTimeZoneInformation(ref TimeZoneInformation lpTimeZoneInformation);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetTimeZoneInformation(ref TimeZoneInformation lpTimeZoneInformation);

        // 针对于新Windows系统，如Windows 7, Windows8, Windows10
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetDynamicTimeZoneInformation(ref DynamicTimeZoneInformation lpDynamicTimeZoneInformation);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetDynamicTimeZoneInformation(ref DynamicTimeZoneInformation lpDynamicTimeZoneInformation);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();

        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccesss, out IntPtr TokenHandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean CloseHandle(IntPtr hObject);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, [MarshalAs(UnmanagedType.Struct)] ref LUID lpLuid);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, [MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges, [MarshalAs(UnmanagedType.Struct)] ref TOKEN_PRIVILEGES NewState, uint BufferLength, IntPtr PreviousState, uint ReturnLength);

        public const uint TOKEN_QUERY = 0x0008;
        public const uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
        public const uint SE_PRIVILEGE_ENABLED = 0x00000002;

        // 授予权限
        public static bool grantTimeZonePrivilege()
        {
            LUID locallyUniqueIdentifier = new LUID();
            LookupPrivilegeValue(null, "SeTimeZonePrivilege", ref locallyUniqueIdentifier);
            TOKEN_PRIVILEGES tokenPrivileges = new TOKEN_PRIVILEGES
            {
                PrivilegeCount = 1
            };
            tokenPrivileges.Privilege = new LUID_AND_ATTRIBUTES
            {
                Attributes = SE_PRIVILEGE_ENABLED,
                Luid = locallyUniqueIdentifier
            };
            IntPtr tokenHandle = IntPtr.Zero;
            OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out tokenHandle);
            AdjustTokenPrivileges(tokenHandle, false, ref tokenPrivileges, 1024, IntPtr.Zero, 0);
            return CloseHandle(tokenHandle);
        }

        // 撤销权限
        public static bool revokeTimeZonePrivilege()
        {
            LUID locallyUniqueIdentifier = new LUID();
            LookupPrivilegeValue(null, "SeTimeZonePrivilege", ref locallyUniqueIdentifier);
            TOKEN_PRIVILEGES tokenPrivileges = new TOKEN_PRIVILEGES
            {
                PrivilegeCount = 1
            };
            tokenPrivileges.Privilege = new LUID_AND_ATTRIBUTES
            {
                Luid = locallyUniqueIdentifier
            };
            IntPtr tokenHandle = IntPtr.Zero;
            OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out tokenHandle);
            AdjustTokenPrivileges(tokenHandle, false, ref tokenPrivileges, 1024, IntPtr.Zero, 0);
            return CloseHandle(tokenHandle);
        }

        /// <summary>
        /// 获取本地时区
        /// </summary>
        public static string getLocalTimeZone()
        {
            // 检测当前系统是否为旧系统
            if (SystemHelper.IsOldOsVersion())
            {
                TimeZoneInformation tzi = new TimeZoneInformation();
                GetTimeZoneInformation(ref tzi);
                return TimeZoneInfo2CustomString(tzi);
            }
            DynamicTimeZoneInformation dtzi = new DynamicTimeZoneInformation();
            GetDynamicTimeZoneInformation(ref dtzi);
            return DynamicTimeZoneInfo2CustomString(dtzi);
        }

        /// <summary>
        /// 设置本地时区
        /// 参数取值"China Standard Time"，即可设置为中国时区
        /// </summary>
        /// <param name="strSate"></param>
        public static bool setLocalTimeZone(string strSate)
        {
            try
            {
                if (strSate == TimeZoneInfo.Local.Id)
                {
                    return true;
                }
                bool success = false;
                if (grantTimeZonePrivilege())
                {
                    DynamicTimeZoneInformation dtzi = timeZoneName2DynamicTimeZoneInformation(strSate);
                    // 检测当前系统是否为旧系统
                    if (SystemHelper.IsOldOsVersion())
                    {
                        TimeZoneInformation tzi = DynamicTimeZoneInformation2TimeZoneInformation(dtzi);
                        success = SetTimeZoneInformation(ref tzi);
                    }
                    else
                    {
                        success = SetDynamicTimeZoneInformation(ref dtzi);
                    }
                    if (success)
                    {
                        TimeZoneInfo.ClearCachedData();  // 清除缓存
                    }
                    if (revokeTimeZonePrivilege())
                    {
                        success = true;
                    }
                }

                return success;
            }
            catch
            {
                // 授权失败
                return false;
            }
        }

        /// <summary>
        /// 将TimeZoneInformation转换为自定义string
        /// </summary>
        /// <param name="tzi"></param>
        private static string TimeZoneInfo2CustomString(TimeZoneInformation tzi)
        {
            return tzi.standardName + "(" + tzi.bias + ")";
        }

        /// <summary>
        /// 将DynamicTimeZoneInformation转换为自定义string
        /// </summary>
        /// <param name="dtzi"></param>
        private static string DynamicTimeZoneInfo2CustomString(DynamicTimeZoneInformation dtzi)
        {
            return dtzi.standardName + "(" + dtzi.bias + ")";
        }

        /// <summary>
        /// 根据时区名获取对应的DynamicTimeZoneInformation
        /// </summary>
        /// <param name="timeZoneName"></param>
        private static DynamicTimeZoneInformation timeZoneName2DynamicTimeZoneInformation(string timeZoneName)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);
            return new DynamicTimeZoneInformation
            {
                standardName = timeZoneInfo.StandardName,
                standardDate = new SystemTime(),
                daylightName = timeZoneInfo.DaylightName,
                daylightDate = new SystemTime(),
                timeZoneKeyName = timeZoneInfo.Id,
                dynamicDaylightTimeDisabled = false,
                bias = -Convert.ToInt32(timeZoneInfo.BaseUtcOffset.TotalMinutes)
            };
        }

        /// <summary>
        /// 将DynamicTimeZoneInformation转换为TimeZoneInformation
        /// </summary>
        /// <param name="dtzi"></param>
        private static TimeZoneInformation DynamicTimeZoneInformation2TimeZoneInformation(DynamicTimeZoneInformation dtzi)
        {
            return new TimeZoneInformation
            {
                bias = dtzi.bias,
                standardName = dtzi.standardName,
                standardDate = dtzi.standardDate,
                standardBias = dtzi.standardBias,
                daylightName = dtzi.daylightName,
                daylightDate = dtzi.daylightDate,
                daylightBias = dtzi.daylightBias
            };
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TimeZoneInformation
    {
        [MarshalAs(UnmanagedType.I4)]
        internal int bias; // 以分钟为单位

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        internal string standardName; // 标准时间的名称

        internal SystemTime standardDate;

        [MarshalAs(UnmanagedType.I4)]
        internal int standardBias; // 标准偏移

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        internal string daylightName; // 夏令时的名称

        internal SystemTime daylightDate;

        [MarshalAs(UnmanagedType.I4)]
        internal int daylightBias; // 夏令时偏移
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DynamicTimeZoneInformation
    {
        [MarshalAs(UnmanagedType.I4)]
        internal int bias; // 偏移，以分钟为单位

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        internal string standardName; // 标准时间的名称

        internal SystemTime standardDate;

        [MarshalAs(UnmanagedType.I4)]
        internal int standardBias; // 标准偏移

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        internal string daylightName; // 夏令时的名称

        internal SystemTime daylightDate;

        [MarshalAs(UnmanagedType.I4)]
        internal int daylightBias; // 夏令时偏移

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x80)]
        internal string timeZoneKeyName; // 时区名

        [MarshalAs(UnmanagedType.Bool)]
        internal bool dynamicDaylightTimeDisabled; // 是否自动调整时钟的夏令时
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        [MarshalAs(UnmanagedType.U2)]
        internal ushort year; // 年

        [MarshalAs(UnmanagedType.U2)]
        internal ushort month; // 月

        [MarshalAs(UnmanagedType.U2)]
        internal ushort dayOfWeek; // 星期

        [MarshalAs(UnmanagedType.U2)]
        internal ushort day; // 日

        [MarshalAs(UnmanagedType.U2)]
        internal ushort hour; // 时

        [MarshalAs(UnmanagedType.U2)]
        internal ushort minute; // 分

        [MarshalAs(UnmanagedType.U2)]
        internal ushort second; // 秒

        [MarshalAs(UnmanagedType.U2)]
        internal ushort milliseconds; // 毫秒
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LUID
    {
        public int LowPart;
        public uint HighPart;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LUID_AND_ATTRIBUTES
    {
        public LUID Luid;
        public uint Attributes;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TOKEN_PRIVILEGES
    {
        public int PrivilegeCount;
        public LUID_AND_ATTRIBUTES Privilege;
    }
}