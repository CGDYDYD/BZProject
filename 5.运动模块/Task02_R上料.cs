using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using static Help.AxisHelper;
using static ParName.名称枚举;

namespace 运动模块
{
    public class Task02_R上料 : 上料Base
    {
        #region 单例

        private static Task02_R上料 mInstance;

        public static Task02_R上料 Instance => mInstance ?? (mInstance = new Task02_R上料());

        #endregion 单例

        #region 私有变量
        internal override AxisID axisID => AxisID.R上料Z轴; //轴 枚 举
        internal override StationID stationID => StationID.R上料; // 工位信息
        internal override Task_ID task_ID => Task_ID.Task02_R上料; // 工站枚举
        internal override Axis axis => Axis.Z; // 轴方向

        #endregion 私有变量

        #region 输入信号
        public override bool 进料流线流入光电 => GetDI(InNo.右进料流线流入光电);

        public override bool 进料流线到位光电 => GetDI(InNo.右进料流线到位光电);

        public override bool 进料流线有料检测光电 => GetDI(InNo.右进料流线有料检测光电);

        public override bool 进料顶升气缸原点 => GetDI(InNo.右进料顶升气缸原点);

        public override bool 进料顶升气缸动点 => GetDI(InNo.右进料顶升气缸动点);

        public override bool 进料分盘气缸原点 => GetDI(InNo.右进料分盘气缸原点);

        public override bool 进料分盘气缸动点 => GetDI(InNo.右进料分盘气缸动点);

        public override bool 进料流线缺料对射 => GetDI(InNo.右进料流线缺料对射);

        public override bool 进料流线满料对射 => GetDI(InNo.右进料流线满料对射);

        public override bool 移栽到位光电检测 => GetDI(InNo.右移栽到位光电检测);

        public override bool 出料流线有料检测光电 => GetDI(InNo.右出料流线有料检测光电);


        #endregion 输入信号

        #region 输出信号
        public override bool 进料流线正转
        {
            set
            {
                SetDO(OutNo.右进料流线反转, false);
                SetDO(OutNo.右进料流线正转, value);
            }
            
        }

        public override bool 进料流线反转
        {
            set
            {
                SetDO(OutNo.右进料流线正转, false);
                SetDO(OutNo.右进料流线反转, value);
            }
        }
        public override bool 进料流线停止
        {
            set
            {
                SetDO(OutNo.右进料流线正转, false);
                SetDO(OutNo.右进料流线反转, false);
            }
        }

        public override bool 移栽流线正转
        {
            set
            {
                SetDO(OutNo.右移栽流线正转, value);
                SetDO(OutNo.右移栽流线反转, false);
            }
            
        }

        public override bool 移栽流线反转
        {
            set
            {
                SetDO(OutNo.右移栽流线正转, false);
                SetDO(OutNo.右移栽流线反转, value);
            }
        }
        public override bool 移栽流线停止
        {
            set
            {
                SetDO(OutNo.右移栽流线正转, false);
                SetDO(OutNo.右移栽流线反转, false);
            }
        }

        public override bool 进料顶升气缸缩回
        {
            set
            {
                SetDO(OutNo.右进料顶升气缸伸出, false);
                SetDO(OutNo.右进料顶升气缸缩回, value);
            }
        }

        public override bool 进料顶升气缸伸出
        {
            set
            {
                SetDO(OutNo.右进料顶升气缸缩回, false);
                SetDO(OutNo.右进料顶升气缸伸出, value);
            }
        }

        public override bool 进料分盘气缸缩回
        {
            set
            {
                SetDO(OutNo.右进料分盘气缸伸出, false);
                SetDO(OutNo.右进料分盘气缸缩回, value);
            }
        }

        public override bool 进料分盘气缸伸出
        {
            set
            {
                SetDO(OutNo.右进料分盘气缸缩回, false);
                SetDO(OutNo.右进料分盘气缸伸出, value);
            }
        }

        public override bool 按钮灯
        {
            set => SetDO(OutNo.启动按钮灯, value);
        }

        #endregion 输出信号

        #region 交互信号

        public override bool 给移载平台有料盘信号 { get; set; }

        public override bool 移载平台要料盘信号 => Task04_R移载平台.Instance.给上料要料盘信号;

        public override bool 移载平台进料盘完成信号
        {
            get => Task04_R移载平台.Instance.给上料进料盘完成信号;
            set => Task04_R移载平台.Instance.给上料进料盘完成信号 = value;
        }

        #endregion 交互信号
    }
}