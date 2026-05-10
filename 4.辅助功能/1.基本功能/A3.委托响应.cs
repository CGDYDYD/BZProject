using System.Windows.Forms;
using static CoreFunction.mFunction;
using static Help.AxisHelper;
using static ParName.名称枚举;

namespace BoTech
{
    public sealed class 委托响应
    {
        #region 模组事件

        public static void mMotorRun()
        {
            if (mStaData.CMD.Contains("Servo") || mStaData.CMD.Contains("HomeOK"))
            {
                return;
            }
            if (mStaData.CMD.Contains("X") || mStaData.CMD.Contains("Y") || mStaData.CMD.Contains("Z") || mStaData.CMD.Contains("Home") || mStaData.CMD.Contains("R") || mStaData.CMD == "Btn_Go")
            {
                switch ((StationID)mStaData.Index)
                {
                    case StationID.L移载平台:
                        MessageBox.Show("L移载平台");
                        break;

                    case StationID.R移载平台:
                        MessageBox.Show("R移载平台");
                        break;

                    case StationID.L上料:
                        MessageBox.Show("L上料");
                        break;

                    case StationID.L下料:
                        MessageBox.Show("L下料");
                        break;

                    case StationID.R上料:
                        MessageBox.Show("R上料");
                        break;

                    case StationID.R下料:
                        MessageBox.Show("R下料");
                        break;
                }
            }
        }


        #endregion 模组事件

        #region 气缸动作防呆

        public static void ActionControl()
        {
            switch ((OutNo)mStaData.Index)
            {

                case OutNo.左进料流线正转:
                //case OutNo.OK上料流线反转:

                case OutNo.左出料流线正转:
                //case OutNo.OK下料流线反转:

                    break;

                case OutNo.左移栽流线正转:
                //case OutNo.OK移载流线反转:

                    if (!GetDI(InNo.左移栽顶升气缸缩回位))
                    {
                        MessageBox.Show("左移载顶升不在缩回位,运动不安全");
                        mStaData.StepStop = true;
                    }
                    break;

                case OutNo.右进料流线正转:
                //case OutNo.NG上料流线反转:

                case OutNo.右出料流线正转:
                //case OutNo.NG下料流线反转:

                    break;

                case OutNo.右移栽流线正转:
                //case OutNo.NG移载流线反转:

                    if (!GetDI(InNo.右移栽顶升气缸缩回位))
                    {
                        MessageBox.Show("右移载顶升不在缩回位,运动不安全");
                        mStaData.StepStop = true;
                    }
                    break;

                case OutNo.左移栽顶升气缸伸出:

                case OutNo.左移栽顶升气缸缩回:

                case OutNo.右移栽顶升气缸伸出:

                case OutNo.右移栽顶升气缸缩回:

                case OutNo.左进料分盘气缸伸出:

                case OutNo.左出料分盘气缸伸出:

                case OutNo.右进料分盘气缸伸出:

                case OutNo.右出料分盘气缸伸出:

                //case OutNo.OK移载阻挡伸出:

                //case OutNo.NG移载阻挡伸出:

                    break;
            }
        }

        #endregion 气缸动作防呆
    }
}