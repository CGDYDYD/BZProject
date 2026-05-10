using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using UserHelper;

namespace BoTech
{
    public partial class FailTip : Form
    {
        private Color Green = Color.FromArgb(0xAE, 0xDA, 0x97);

        public bool waitProcess;//报警等待处理标志位

        public int ErrorCFO;
        public string ErrorInfo;
        public int RtnStep = -999999;
        public int OKStep = -99999999, NGStep = -99999999;

        public AutoResetEvent Are = new AutoResetEvent(false);//给单个线程发送信号

        public FailTip(string Information, bool Isvisible = false)
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            this.重新执行.BackColor = Green;
            this.richTextBox1.Text = Information;
            this.跳过.Visible = Isvisible;
            waitProcess = true;
        }

        public void SetSubmitErrorInfo(string startTime, string errorcode, string errormessage)
        {
            this.text_StartTime.Text = startTime;
            this.text_ErrorCode.Text = errorcode;
            this.text_ErrorMessage.Text = errormessage;
        }

        public void SetStationText(string text)
        {
            this.label_Name.Text = text;
        }

        public void WaitOne()
        {
            Are.WaitOne();
        }

        private void 重新执行_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            waitProcess = false;
            RtnStep = OKStep;
            FailTipShow.Instance.mre.Reset();
            Are.Set();
            this.Close();
        }

        private void 跳过_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            waitProcess = false;
            RtnStep = OKStep;
            FailTipShow.Instance.mre.Reset();
            Are.Set();
            this.Close();
        }

        private void 确定_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            waitProcess = false;
            RtnStep = NGStep;
            FailTipShow.Instance.mre.Reset();
            Are.Set();
            this.Close();
        }

        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键

        private void FailTip_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void FailTip_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void FailTip_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void FailTip_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    Frm_ICT_Main.Instance.Btn_Alarm.ButtonStateChange(NewButtonState.Deenergized);
                    Frm_ICT_Main.Instance.Btn_Run.ButtonStateChange(NewButtonState.Energized);
                    Frm_ICT_Main.Instance.Btn_Pause.ButtonStateChange(NewButtonState.Deenergized);
                    Frm_ICT_Main.Instance.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                }));
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        private void button_CloseArm_Click(object sender, EventArgs e)
        {
            FailTipShow.Instance.mre.Reset();//关闭蜂鸣器
        }
    }
}