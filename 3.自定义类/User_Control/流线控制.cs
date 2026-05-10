using System;
using System.ComponentModel;
using System.Windows.Forms;
using 运动模块;
using static ParName.名称枚举;

namespace BoTech.User_Control
{
    public partial class 流线控制 : UserControl
    {
        public 流线控制() => InitializeComponent();

        [Description("流线名称")]
        public StationID 流线名称 { get; set; }

        private void button_流线动作_Click(object sender, EventArgs e)
        {
            switch (流线名称)
            {
                case StationID.L移载平台:
                    if (this.radioButton_进料.Checked)
                    {
                        Task03_L移载平台.Instance.移栽流线正转 = true;
                    }
                    else if (this.radioButton_出料.Checked)
                    {
                        Task03_L移载平台.Instance.移栽流线反转 = true;
                    }
                    else
                    {
                        Task03_L移载平台.Instance.移栽流线停止 = true;
                    }
                    break;

                case StationID.R移载平台:
                    if (this.radioButton_进料.Checked)
                    {
                        Task04_R移载平台.Instance.移栽流线正转 = true;
                    }
                    else if (this.radioButton_出料.Checked)
                    {
                        Task04_R移载平台.Instance.移栽流线反转 = true;
                    }
                    else
                    {
                        Task04_R移载平台.Instance.移栽流线停止 = true;
                    }
                    break;

                case StationID.L上料:
                    if (this.radioButton_进料.Checked)
                    {
                        Task01_L上料.Instance.进料流线正转 = true;
                    }
                    else if (this.radioButton_出料.Checked)
                    {
                        Task01_L上料.Instance.进料流线反转 = true;
                    }
                    else
                    {
                        Task01_L上料.Instance.进料流线停止 = true;
                    }
                    break;

                case StationID.L下料:
                    if (this.radioButton_进料.Checked)
                    {
                        Task05_L下料.Instance.流线进料 = true;
                    }
                    else if (this.radioButton_出料.Checked)
                    {
                        Task05_L下料.Instance.流线出料 = true;
                    }
                    else
                    {
                        Task05_L下料.Instance.流线停止 = true;
                    }
                    break;

                case StationID.R上料:
                    if (this.radioButton_进料.Checked)
                    {
                        Task02_R上料.Instance.进料流线正转 = true;
                    }
                    else if (this.radioButton_出料.Checked)
                    {
                        Task02_R上料.Instance.进料流线反转 = true;
                    }
                    else
                    {
                        Task02_R上料.Instance.进料流线停止 = true;
                    }
                    break;

                case StationID.R下料:
                    if (this.radioButton_进料.Checked)
                    {
                        Task06_R下料.Instance.流线进料 = true;
                    }
                    else if (this.radioButton_出料.Checked)
                    {
                        Task06_R下料.Instance.流线出料 = true;
                    }
                    else
                    {
                        Task06_R下料.Instance.流线停止 = true;
                    }
                    break;
            }
        }
    }
}