using static CoreFunction.mFunction;
using static ParName.名称枚举;

namespace Help
{
    public static class ParHelper
    {
        #region 设备模式

        public static bool Production生产模式 => GetParValue<string>(UserPar.机器运行模式) == "Production生产模式";

        /// <summary>
        /// 不带硬件虚拟空跑用,在设备通电正常条件下禁止使用
        /// </summary>
        public static bool OffLine_VirtualRun脱机空跑 => GetParValue<string>(UserPar.机器运行模式) == "OffLine_VirtualRun脱机空跑";

        /// <summary>
        /// 调试时空跑，模拟设备动作
        /// </summary>
        public static bool VirtualRunWithCarrier带载具空跑 => GetParValue<string>(UserPar.机器运行模式) == "RunWithCarrier带载具空跑";

        public static bool 不带载具空跑 => GetParValue<string>(UserPar.机器运行模式) == "RunWithoutCarrier不带载具空跑";

        public static bool 当前为右机 => GetParValue<string>(UserPar.左机或右机) == "Right右机";

        #endregion 设备模式

        #region 功能设置

        public static bool 勾上屏蔽蜂鸣器 => mParList[(short)FuncChk.勾上屏蔽蜂鸣器].CheckSts;

        public static bool 启用安全门功能 => mParList[(short)FuncChk.启用安全门功能].CheckSts;

        #endregion 功能设置

        public static int 气缸信号报警超时 => mParList[(short)UserPar.气缸信号报警超时].DataInt * 1000;

        #region Andon

        public static string Andon网址 => mParList[(short)UserPar.Andon网址].DataStr;
        public static bool 启用Andon => mParList[(short)FuncChk.启用Andon].CheckSts;
        public static string Token => mParList[(short)UserPar.Token].DataStr;

        /// <summary>
        /// 设备编码
        /// </summary>
        public static string device_code => mParList[(short)UserPar.device_code].DataStr;

        /// <summary>
        /// 线别编码
        /// </summary>
        public static string md_line_code => mParList[(short)UserPar.md_line_code].DataStr;

        /// <summary>
        /// 工序编码
        /// </summary>
        public static string md_process_code => mParList[(short)UserPar.md_process_code].DataStr;

        /// <summary>
        /// 工站编码
        /// </summary>
        public static string md_section_code => mParList[(short)UserPar.md_section_code].DataStr;

        /// <summary>
        /// 工位编码
        /// </summary>
        public static string md_station_code => mParList[(short)UserPar.md_station_code].DataStr;

        /// <summary>
        /// 项目编码
        /// </summary>
        public static string mes_instance => mParList[(short)UserPar.mes_instance].DataStr;

        public static string UserCode => mParList[(short)UserPar.UserCode].DataStr;

        public static string Userpassword => mParList[(short)UserPar.Userpassword].DataStr;

        #endregion
    }
}