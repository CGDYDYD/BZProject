using BoTech.User_Control;
using LogsHelper;
using System;
using System.Collections.Generic;
using static Help.AxisHelper;
using static ParName.名称枚举;

namespace 运动模块
{
    public class Task04_R移载平台 : 移载平台Base
    {
        #region 单例

        private static Task04_R移载平台 mInstance;

        public static Task04_R移载平台 Instance => mInstance ?? (mInstance = new Task04_R移载平台());

        #endregion 单例

        #region 公共变量

        //public override Action 顶升气缸伸出 { get; set; }
        //public override Action 顶升气缸缩回 { get; set; }

        #endregion 公共变量

        #region 私有变量

        internal override AxisID axisID => AxisID.R移载平台X轴;
        internal override StationID stationID => StationID.R移载平台;
        internal override Task_ID task_ID => Task_ID.Task04_R移载平台;
        internal override Axis axis => Axis.X;

        #endregion 私有变量

        #region 输入信号
        public override bool 移栽流入光电检测 => GetDI(InNo.右移栽流入光电检测);
        public override bool 移栽到位光电检测 => GetDI(InNo.右移栽到位光电检测);
        public override bool 移栽顶升气缸缩回位 => GetDI(InNo.右移栽顶升气缸缩回位);
        public override bool 移栽顶升气缸伸出位 => GetDI(InNo.右移栽顶升气缸伸出位);
        public override bool 移栽夹紧气缸缩回位 => GetDI(InNo.右移栽夹紧气缸缩回位);
        public override bool 移栽夹紧气缸伸出位 => GetDI(InNo.右移栽夹紧气缸伸出位);

        // ************************************************************

        #endregion 输入信号

        #region 输出信号
        public override bool 移栽流线正转
        {
            set
            {
                SetDO(OutNo.左移栽流线反转, false);
                SetDO(OutNo.左移栽流线正转, value);
            }
        }
        public override bool 移栽流线反转
        {
            set
            {
                SetDO(OutNo.左移栽流线正转, false);
                SetDO(OutNo.左移栽流线反转, value);
            }
        }
        public override bool 移栽流线停止
        {
            set
            {
                SetDO(OutNo.左移栽顶升气缸伸出, false);
                SetDO(OutNo.左移栽顶升气缸缩回, false);
            }
        }

        public override bool 移栽顶升气缸缩回
        {
            set
            {
                SetDO(OutNo.左移栽顶升气缸伸出, false);
                SetDO(OutNo.左移栽顶升气缸缩回, value);
            }
        }

        public override bool 移栽顶升气缸伸出
        {
            set
            {
                SetDO(OutNo.左移栽顶升气缸缩回, false);
                SetDO(OutNo.左移栽顶升气缸伸出, value);
            }
        }

        public override bool 移栽夹紧气缸缩回
        {
            set
            {
                SetDO(OutNo.左移栽夹紧气缸伸出, false);
                SetDO(OutNo.左移栽夹紧气缸缩回, value);
            }
        }

        public override bool 移栽夹紧气缸伸出
        {
            set
            {
                SetDO(OutNo.左移栽夹紧气缸缩回, false);
                SetDO(OutNo.左移栽夹紧气缸伸出, value);
            }
        }

        #endregion 输出信号

        #region 交互信号
        public override bool 机械手取料中 => GetDI(InNo.右机械手取料中);

        public override bool 流线左有料信号 // // 交互信号
        {
            set
            {
                SetDO(OutNo.左流线左有料信号, value);
            }
        }
        public override bool 流线右有料信号 // // 交互信号
        {
            set
            {
                SetDO(OutNo.左流线右有料信号, value);
            }
        }
        public override bool 给上料进料盘完成信号 { get; set; } // 移栽光电到位
        public override bool 给上料要料盘信号 { get; set; }
        public override bool 上料有料盘信号 => Task02_R上料.Instance.给移载平台有料盘信号;

        public override bool 给下料有料盘信号 { get; set; } // 移载平台有料盘信号
        public override bool 下料要料盘信号 => Task06_R下料.Instance.给移载平台要料盘信号; // 给移载平台要料盘信号
        public override bool 下料完成
        {
            get => Task06_R下料.Instance.给移载平台下料完成信号;
            set => Task06_R下料.Instance.给移载平台下料完成信号 = false;
        }

        public override void 放料日志分割()
        {
            AddLog("=======================================================================================\r\n", LogsType.OKTray, StaInfo.步序号, true);
        }

        #endregion 交互信号
    }
}