using static CoreFunction.mFunction;
using static ParName.名称枚举;

namespace BoTech
{
    public sealed partial class mGlobal
    {
        #region 函数

        /// <summary>
        /// 写几句操作的Log，什么时候点的按钮
        /// </summary>
        public static LogsHelper.cLogs _Logs = new LogsHelper.cLogs("MachineLog", 0);

        #endregion 函数

        #region 自定义函数

        public static void mHomeStep(short index, short Value)
        {
            HomeStep[AxisIndex[index].CardNum, AxisIndex[index].AxisNum] = Value;
        }

        public static void mHomeOk(short index, bool Value)
        {
            HomeOk[AxisIndex[index].CardNum, AxisIndex[index].AxisNum] = Value;
        }

        public static bool OffLine_VirtualRun脱机空跑 => GetParValue<string>(UserPar.机器运行模式) == "OffLine_VirtualRun脱机空跑";

        public static bool FuncCheck(FuncChk func) => mParList[(short)func].CheckSts;

        #endregion 自定义函数
    }
}