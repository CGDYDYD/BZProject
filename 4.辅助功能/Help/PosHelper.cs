using System;
using UserHelper;
using static CoreFunction.mFunction;
using static Help.AxisHelper;
using static ParName.名称枚举;

namespace Help
{
    public static class PosHelper
    {
        #region 私有变量

        #endregion 私有变量

        #region 获取点位信息

        public static XYZR 获取点位信息(StationID StationID, int PosID)
        {
            XYZR Point = new XYZR();
            try
            {
                Point.X = Pos.X[(int)StationID, PosID];
                Point.Y = Pos.Y[(int)StationID, PosID];
                Point.Z = Pos.Z[(int)StationID, PosID];
                Point.R = Pos.R[(int)StationID, PosID];
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
                return Point;
            }
            return Point;
        }

        public static double 获取点位信息(StationID StationID, int PosID, Axis axis)
        {
            switch (axis)
            {
                case Axis.X:
                    return 获取点位信息(StationID, PosID).X;

                case Axis.Y:
                    return 获取点位信息(StationID, PosID).Y;

                case Axis.Z:
                    return 获取点位信息(StationID, PosID).Z;

                case Axis.R:
                    return 获取点位信息(StationID, PosID).R;
            }
            return 0;
        }

        #endregion 获取点位信息
    }
}