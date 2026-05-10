using BoTech.User_Control;
using LogsHelper;
using System;
using System.Collections.Generic;
using static Help.AxisHelper;
using static ParName.名称枚举;

namespace 运动模块
{
    public class Task03_L移载平台 : 移载平台Base
    {
        #region 单例

        private static Task03_L移载平台 mInstance;

        public static Task03_L移载平台 Instance => mInstance ?? (mInstance = new Task03_L移载平台());

        #endregion 单例

        #region 公共变量

        //public override Action 顶升气缸伸出 { get; set; }
        //public override Action 顶升气缸缩回 { get; set; }

        #endregion 公共变量

        #region 私有变量

        internal override AxisID axisID => AxisID.L移载平台X轴;
        internal override StationID stationID => StationID.L移载平台;
        internal override Task_ID task_ID => Task_ID.Task03_L移载平台;
        internal override Axis axis => Axis.X;

        #endregion 私有变量

        #region 输入信号 
        public override bool 移栽流入光电检测 => GetDI(InNo.左移栽流入光电检测);
        public override bool 移栽到位光电检测 => GetDI(InNo.左移栽到位光电检测);
        public override bool 移栽顶升气缸缩回位 => GetDI(InNo.左移栽顶升气缸缩回位);
        public override bool 移栽顶升气缸伸出位 => GetDI(InNo.左移栽顶升气缸伸出位);
        public override bool 移栽夹紧气缸缩回位 => GetDI(InNo.左移栽夹紧气缸缩回位);
        public override bool 移栽夹紧气缸伸出位 => GetDI(InNo.左移栽夹紧气缸伸出位);

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

        public override bool 机械手取料中 => GetDI(InNo.左机械手取料中);

        public override bool 流线左有料信号
        {
            set
            {
                SetDO(OutNo.左流线左有料信号, value);
            }
        }
        public override bool 流线右有料信号
        {
            set
            {
                SetDO(OutNo.左流线右有料信号, value);
            }
        }


        public override bool 给上料进料盘完成信号 { get; set; } // 移栽光电到位
        public override bool 给上料要料盘信号 { get; set; }
        public override bool 上料有料盘信号 => Task01_L上料.Instance.给移载平台有料盘信号;

        public override bool 给下料有料盘信号 { get; set; } // 移载平台有料盘信号

        public override bool 下料要料盘信号 => Task05_L下料.Instance.给移载平台要料盘信号; // 给移载平台要料盘信号
        public override bool 下料完成
        {
            get => Task05_L下料.Instance.给移载平台下料完成信号;
            set => Task05_L下料.Instance.给移载平台下料完成信号 = false;
        }

        public override void 放料日志分割()
        {
            AddLog("=======================================================================================\r\n", LogsType.OKTray, StaInfo.步序号, true);
        }

        #endregion 交互信号
    }
}