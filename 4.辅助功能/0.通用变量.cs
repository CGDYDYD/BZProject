using FilePath;
using LParamManag.Manage;
using LParamManag.Manage.Model;
using System;
using System.Collections.Concurrent;
using System.Drawing;

namespace BoTech
{
    public sealed partial class mGlobal
    {
        #region 变量

        public static bool IsOnAlarm { get; set; }
        public static ConcurrentQueue<DateTime> 进料时间 = new ConcurrentQueue<DateTime>();
        public static ConcurrentQueue<DateTime> 出料时间 = new ConcurrentQueue<DateTime>();
        public static ParamContext<OffsetCompenParam, OffsetCompenParam> 机械手放料补偿 = new ParamContext<OffsetCompenParam, OffsetCompenParam>("offset", mFilePath.BZ_ParPath);

        #region 系统变量

        public static bool IdleFlag;

        public static bool IsStartAutoRun;

        /// <summary>
        /// 整机复位标志
        /// </summary>
        public static bool IsAllStationReset;

        public static float NewX = 1; //窗体缩放系数X
        public static float NewY = 1; //窗体缩放系数X

        public static Point ChildFrmOffsetPoint; //各子界面在主界面中位置定位点

        public static bool IsOpenFrmEngineering;
        public static bool IsOpenFrmProduction;
        public static bool IsLoadFrmEngineering;

        #endregion 系统变量

        #region 自定义变量




        /// <summary>
        /// 指示手自动旋钮状态
        /// </summary>
        public static bool isManaul;

        public static bool hivestateselecttimelock = true;

        #endregion 自定义变量

        public static double CT;

        #endregion 变量
    }
}