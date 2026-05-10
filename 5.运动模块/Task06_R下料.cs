using System;
using static Help.AxisHelper;
using static ParName.名称枚举;

namespace 运动模块
{
    public class Task06_R下料 : 下料Base
    {
        #region 单例

        private static Task06_R下料 mInstance;

        public static Task06_R下料 Instance => mInstance ?? (mInstance = new Task06_R下料());

        #endregion 单例

        #region 私有变量

        internal override AxisID axisID => AxisID.R下料Z轴;
        internal override StationID stationID => StationID.R下料;
        internal override Task_ID task_ID => Task_ID.Task06_R下料;
        internal override Axis axis => Axis.Z;

        #endregion 私有变量

        #region 事件委托


        #endregion

        #region 输入信号
        public override bool 出料流线流入光电 => GetDI(InNo.右出料流线流入光电);
        public override bool 出料流线到位光电 => GetDI(InNo.右出料流线到位光电);
        public override bool 出料流线有料检测光电 => GetDI(InNo.右出料流线有料检测光电);
        public override bool 出料顶升气缸原点 => GetDI(InNo.右出料顶升气缸原点);
        public override bool 出料顶升气缸动点 => GetDI(InNo.右出料顶升气缸动点);
        public override bool 出料分盘气缸原点 => GetDI(InNo.右出料分盘气缸原点);
        public override bool 出料分盘气缸动点 => GetDI(InNo.右出料分盘气缸动点);

        public override bool 出料流线缺料对射 => GetDI(InNo.右出料流线缺料对射);
        public override bool 出料流线满料对射 => GetDI(InNo.右出料流线满料对射);

        // ***********************************************************************

        public override bool 操作按钮 => GetDI(InNo.右出料流线到位光电);
        public override bool 进料感应 => GetDI(InNo.右出料流线流入光电);
        public override bool 出料感应 => GetDI(InNo.右出料流线有料检测光电);
        public override bool 分盘感应 => GetDI(InNo.右出料分盘气缸动点);
        public override bool 满料感应 => GetDI(InNo.右出料流线满料对射);
        public override bool 分盘气缸伸出位 => GetDI(InNo.右出料分盘气缸动点);
        public override bool 分盘气缸缩回位 => GetDI(InNo.右出料分盘气缸原点);

        #endregion 输入信号

        #region 输出信号
        public override bool 出料流线正转
        {
            set
            {
                SetDO(OutNo.右出料流线反转, false);
                SetDO(OutNo.右出料流线正转, value);
            }
        }
        public override bool 出料流线反转
        {
            set
            {
                SetDO(OutNo.右出料流线正转, false);
                SetDO(OutNo.右出料流线反转, value);
            }
        }
        public override bool 出料流线停止
        {
            set
            {
                SetDO(OutNo.右出料流线正转, false);
                SetDO(OutNo.右出料流线反转, false);
            }
        }

        public override bool 出料顶升气缸缩回
        {
            set
            {
                SetDO(OutNo.右出料顶升气缸伸出, false);
                SetDO(OutNo.右出料顶升气缸缩回, value);
            }
        }

        public override bool 出料顶升气缸伸出
        {
            set
            {
                SetDO(OutNo.右出料顶升气缸缩回, false);
                SetDO(OutNo.右出料顶升气缸伸出, value);
            }
        }

        public override bool 出料分盘气缸缩回
        {
            set
            {
                SetDO(OutNo.右出料分盘气缸伸出, false);
                SetDO(OutNo.右出料分盘气缸缩回, value);
            }
        }

        public override bool 出料分盘气缸伸出
        {
            set
            {
                SetDO(OutNo.右出料分盘气缸缩回, false);
                SetDO(OutNo.右出料分盘气缸伸出, value);
            }
        }
        // *******************************

        public override bool 流线进料
        {
            set
            {
                SetDO(OutNo.右出料流线正转, value);
            }
        }

        public override bool 流线出料
        {
            set
            {
                // 假设左出料没有反转，若有请替换OutNo
                // SetDO(OutNo.左出料流线反转, value);
            }
        }

        public override bool 流线停止
        {
            set
            {
                SetDO(OutNo.右出料流线正转, false);
                // SetDO(OutNo.左出料流线反转, false);
            }
        }

        public override bool 分盘气缸伸出
        {
            set => SetDO(OutNo.右出料分盘气缸伸出, value);
        }

        public override bool 按钮灯
        {
            set => SetDO(OutNo.启动按钮灯, value);
        }

        #endregion 输出信号

        #region 交互信号

        public override bool 给移载平台要料盘信号 { get; set; }

        public override bool 移载平台有料盘信号 => Task04_R移载平台.Instance.给下料有料盘信号;

        public override bool 给移载平台下料完成信号 { get; set; }

        #endregion 交互信号
    }
}