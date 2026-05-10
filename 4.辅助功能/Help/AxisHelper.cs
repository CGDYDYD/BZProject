using System;
using System.Threading;
using 运动模块;
using static CoreFunction.mFunction;
using static MotionFunction.MotionDll;
using static ParName.名称枚举;

namespace Help
{
    public static class AxisHelper
    {
        #region 输入信号

        /// <summary>
        /// 获取输入
        /// </summary>
        /// <param name="inputIndex">输入枚举</param>
        public static bool GetDI(InNo inputIndex) => ReadDi((short)inputIndex) == 1 || ParHelper.OffLine_VirtualRun脱机空跑;

        #endregion 输入信号

        #region 输出信号

        /// <summary>
        /// 设置输出
        /// </summary>
        public static bool SetDO(OutNo outputIndex, short Value) => WriteDo((short)outputIndex, Value);

        /// <summary>
        /// 设置输出
        /// </summary>
        public static bool SetDO(OutNo outputIndex, bool Value) => Value ? WriteDo((short)outputIndex, 1) : WriteDo((short)outputIndex, 0);

        #endregion 输出信号

        #region 使能

        /// <summary>
        /// 打开使能
        /// </summary>
        /// <param name="axisIndex">轴号</param>
        public static void SeverON(AxisID axisIndex)
        {
            if (!GetServoState(axisIndex))
            {
                mAxisOn(AxisIndex[(int)axisIndex].CardNum, AxisIndex[(int)axisIndex].AxisNum);
            }
        }

        /// <summary>
        /// 关闭使能
        /// </summary>
        /// <param name="axisIndex">轴号</param>
        public static void SeverOFF(AxisID axisIndex)
        {
            if (GetServoState(axisIndex))
            {
                mAxisOff(AxisIndex[(int)axisIndex].CardNum, AxisIndex[(int)axisIndex].AxisNum);
            }
        }

        /// <summary>
        /// 判断轴使能状态
        /// </summary>
        /// <param name="axisIndex">轴号</param>
        public static bool GetServoState(AxisID axisIndex) => GetServoOnSts(AxisIndex[(int)axisIndex].CardNum, AxisIndex[(int)axisIndex].AxisNum) == 1;

        #endregion 使能

        #region 到位判断

        public static bool AxisIsArrived(AxisID axisIndex, double pos)
        {
            double encMm = 获取编码器位置((short)axisIndex);
            return ZSPD(axisIndex) && Math.Abs(encMm - pos) <= 0.04;
        }

        public static bool AxisIsArrived(AxisID axisIndex, StationID station, int posID, Axis axis)
        {
            double pos = PosHelper.获取点位信息(station, posID, axis);
            return AxisIsArrived(axisIndex, pos);
        }

        #endregion 到位判断

        #region 轴运动
        // 轴运动到点位
        // 工位信息 轴枚举 轴方向
        public static bool AxisGoPoint(StationID station, AxisID axisIndex, int posID, Axis axis, bool isEnable)
        {
            if (ParHelper.OffLine_VirtualRun脱机空跑)
            {
                Thread.Sleep(200);
                return true;
            }
            double pos = PosHelper.获取点位信息(station, posID, axis);
            if (isEnable)
            {
                if (AxisIsArrived(axisIndex, station, posID, axis))
                {
                    return true;
                }
                double speed = GetAxisWorkSpeed(axisIndex);

                AxisMove((short)axisIndex, pos, speed);
            }
            else
            {
                AxisStop((short)axisIndex, 1);
            }
            return false;
        }

        #endregion 轴运动

        #region 回零

        // 指定轴回原点
        public static bool AxisGoHome(mWorkShare task, AxisID axisIndex, bool isEnable)
        {
            if (isEnable)
            {
                task.mHome.WaitDone(axisIndex);

                return true;
            }
            return false;
        }

        // 判断回原点是否完成
        public static bool IsHomeFinished(AxisID axisIndex) => HomeOk[AxisIndex[(int)axisIndex].CardNum, AxisIndex[(int)axisIndex].AxisNum];

        #endregion 回零

        // 根据轴ID 获取轴的工作速度
        public static double GetAxisWorkSpeed(AxisID axisIndex) => AxisIndex[(int)axisIndex].WorkSpeed;

        public enum Axis
        {
            X,
            Y,
            Z,
            R
        }
    }

    [Serializable]
    public class XYZR
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double R { get; set; }
    }
}