using FilePath;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UserHelper;
using static CoreFunction.mFunction;

namespace BoTech
{
    public partial class FailTip不锁定界面 : Form
    {
        public bool waitProcess;//报警等待处理标志位
        public int ErrorCFO;
        public string ErrorInfo;

        public FailTip不锁定界面(string Information)
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.richTextBox1.Text = Information;
            waitProcess = true;
        }

        public void SetSubmitErrorInfo(string startTime, string errorcode, string errormessage)
        {
            this.text_StartTime.Text = startTime;
            this.text_ErrorCode.Text = errorcode;
            this.text_ErrorMessage.Text = errormessage;
        }

        private void 确定_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
                Frm_ICT_Main.Instance.Btn_Alarm.ButtonStateChange(NewButtonState.Deenergized);
                Frm_ICT_Main.Instance.Btn_Run.ButtonStateChange(NewButtonState.Disabled);
                Frm_ICT_Main.Instance.Btn_Pause.ButtonStateChange(NewButtonState.Energized);
                Frm_ICT_Main.Instance.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                FailTipShow.Instance.蜂鸣器报警 = false;
                SysState = mGlobal.isManaul ? State.MANUAL : State.RUNNING;
                mGlobal.IsOnAlarm = false;
                DateTime endTime = DateTime.Now;
                //保存报警数据
                mGlobal.更新每小时报警数();
                string totalData = $"{FailTipShow.Instance.startTime:yyyy-MM-dd HH:mm:ss:fff},{endTime:yyyy-MM-dd HH:mm:ss:fff},{ErrorInfo.Replace(",", " ")},确定,{(endTime - FailTipShow.Instance.startTime).TotalMilliseconds / 1000:0.000}";
                string path = $"{mFilePath.BZ_LogPath}{DateTime.Now:yyyyMMdd}\\{DateTime.Now:yyyyMMdd}_Fails.csv";
                string errorpath = $"{mFilePath.BZ_LogPath}{DateTime.Now:yyyyMMdd}\\设备异常日志.txt";
                if (!File.Exists(path))
                {
                    CsvServer_ICT.Instance.WriteLine(path, "StartTime,EndTime,AlarmMessage,SelectString,TotalTime");
                }
                CsvServer_ICT.Instance.WriteLine(path, totalData);//保存CSV
                CsvServer_ICT.Instance.WriteLine(errorpath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}{ErrorInfo}");//保存txt

                AlarmMessage AM = new AlarmMessage
                {
                    HappenTime = FailTipShow.Instance.startTime,
                    EndTime = endTime,
                    Duration = (endTime - FailTipShow.Instance.startTime).TotalMinutes,
                    Code = GlobalVar.appHiveControl.ErrorInfoList?.FirstOrDefault(s => s.Index == ErrorCFO).ErrorCode,
                    ErrorMessageE = Enum.GetName(typeof(eErrCode), ErrorCFO),
                    ErrorMessageC = ErrorCFO.ToString(),
                    DealtMethod = Enum.GetName(typeof(eErrCode), ErrorCFO),
                    ErrorCategory = ErrorCFO.ToString(),
                };
                DataServerManager.Instance.InsertAlarmON(AM);
                //AlarmPage.Instance.btn_Query_Click(null, null);
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