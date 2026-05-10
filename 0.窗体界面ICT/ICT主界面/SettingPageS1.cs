using BoTech.User_Control;
using Help;
using Microsoft.VisualBasic;
using ParName;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using UserHelper;
using Zcm;
using 运动模块;
using static CoreFunction.mFunction;
using static FilePath.mFilePath;

namespace BoTech
{
    public partial class SettingPage : MyControl
    {
        #region 实例化

        private static SettingPage instance;

        public static SettingPage Instance
        {
            get
            {
                if (instance?.IsDisposed != false)
                {
                    instance = new SettingPage();
                }
                return instance;
            }
        }

        public SettingPage()
        {
            InitializeComponent();

            AudioLoginManager.Instance.UserLogin_event += UserLevelChange;
            AudioLoginManager.Instance.Logout_event += UserLogout;
        }

        private void UserLogout()
        {
            this.BeginInvoke(new Action(() =>
            {
                panel_HardWare.Enabled = false;
                groupBox23.Enabled = false;
                userManager1.ButtonShow(false);
            }));
        }

        private void UserLevelChange(AccountInfo obj)
        {
            this.BeginInvoke(new Action(() =>
            {
                panel_HardWare.Enabled = false;
                groupBox23.Enabled = false;
                if (obj.UserLevel >= LoginLevel.Level3)
                {
                    panel_HardWare.Enabled = true;
                    groupBox23.Enabled = true;
                }
                userManager1.ButtonShow();
            }));
        }

        #endregion 实例化

        #region 功能：变量定义

        private bool FormLoad;
        private Thread LedStatuesThrd;
        private Thread ButtonLedStatuesThrd;

        #endregion 功能：变量定义

        #region 功能：窗体加载

        /// <summary>
        /// 调试界面加载；
        /// </summary>
        private void me_Load(object sender, EventArgs e)
        {
            this.Location = mGlobal.ChildFrmOffsetPoint;
            this.Size = new Size(Frm_ICT_Main.Instance.Main_ChildPage.Width, Frm_ICT_Main.Instance.Main_ChildPage.Height);
            SetTag(this, Convert.ToInt32(this.Tag), true);
            SetControls(mGlobal.NewX, mGlobal.NewY, this, Convert.ToInt32(this.Tag), true);

            窗体加载.me_Initial();
            ExeIsRun = true;
            机种加载();
            // 三色灯线程
            LedStatuesThrd = new Thread(() => LightStatues_Refresh()) { IsBackground = true };
            LedStatuesThrd.Start();

            // 按钮灯线程
            ButtonLedStatuesThrd = new Thread(() => ButtonLightStatues_Refresh()) { IsBackground = true };
            ButtonLedStatuesThrd.Start();

            FormLoad = true;
            cbLanguage.SelectedIndex = GlobalVar.language.StringToInt();
            //this.Cob_PalletPx.Items.Clear();
            // 如果需要动态添加，请在此处添加项，例如：
            // this.Cob_PalletPx.Items.AddRange(...);
            //if (this.Cob_PalletPx.Items.Count > 0)
            //{
            //    this.Cob_PalletPx.SelectedIndex = 0;
            //}
            //else
            //{
            //    this.Cob_PalletPx.SelectedIndex = -1; // 明确置为无选中
            //}
            //this.comboBox_Type.SelectedIndex = 0;
            if (ParHelper.当前为右机)
            {
                this.teachS6.YExchange = false;
                this.teachS3.YExchange = false;
            }
            this.teachS1.mBtnClick += 委托响应.mMotorRun;
            this.teachS2.mBtnClick += 委托响应.mMotorRun;
            this.teachS3.mBtnClick += 委托响应.mMotorRun;
            this.teachS4.mBtnClick += 委托响应.mMotorRun;
            this.teachS5.mBtnClick += 委托响应.mMotorRun;
            this.teachS6.mBtnClick += 委托响应.mMotorRun;

            this.cylinder1.mBtnClick += 委托响应.ActionControl;
            this.cylinder2.mBtnClick += 委托响应.ActionControl;
            this.cylinder3.mBtnClick += 委托响应.ActionControl;
            this.cylinder4.mBtnClick += 委托响应.ActionControl;
            this.cylinder5.mBtnClick += 委托响应.ActionControl;
            this.cylinder6.mBtnClick += 委托响应.ActionControl;
            this.cylinder7.mBtnClick += 委托响应.ActionControl;
            this.cylinder8.mBtnClick += 委托响应.ActionControl;
            this.cylinder9.mBtnClick += 委托响应.ActionControl;

            this.cylinder10.mBtnClick += 委托响应.ActionControl;
            this.cylinder11.mBtnClick += 委托响应.ActionControl;
            this.cylinder12.mBtnClick += 委托响应.ActionControl;
            this.cylinder13.mBtnClick += 委托响应.ActionControl;
            this.cylinder14.mBtnClick += 委托响应.ActionControl;

            this.mBtn_Out1.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out2.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out3.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out4.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out5.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out6.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out7.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out8.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out9.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out10.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out11.mBtnClick += 委托响应.ActionControl;
            this.mBtn_Out12.mBtnClick += 委托响应.ActionControl;


            FileInfo fileInfo = new FileInfo(Application.ExecutablePath);
            label5.Text = fileInfo.LastWriteTime.ToString("yyyy_MM_dd_HH_mm_ss");

            mGlobal.开机读取每小时产量();
            mGlobal.开机读取每小时CT();
            mGlobal.开机读取每小时报警数();
            mGlobal.开机启动Alarm定时器();
            timer1.Enabled = true;
        }

        private void 机种加载()
        {
            this.comboBox1.Items.Clear();
            this.cbSite.Items.Clear();
            this.cbLine.Items.Clear();
            this.cbStation.Items.Clear();
            this.cbMachineNum.Items.Clear();
            this.cbLanguage.Items.Clear();

            for (int i = 0; i < mFileJson.settingjson.General_Config.Prod_Type.Length; i++)
            {
                this.comboBox1.Items.Add(mFileJson.settingjson.General_Config.Prod_Type[i]);
            }

            for (int i = 0; i < mFileJson.settingjson.General_Config.Site.Length; i++)
            {
                this.cbSite.Items.Add(mFileJson.settingjson.General_Config.Site[i]);
            }

            for (int i = 0; i < mFileJson.settingjson.General_Config.Line.Length; i++)
            {
                this.cbLine.Items.Add(mFileJson.settingjson.General_Config.Line[i]);
            }

            for (int i = 0; i < mFileJson.settingjson.General_Config.Station.Length; i++)
            {
                this.cbStation.Items.Add(mFileJson.settingjson.General_Config.Station[i]);
            }

            for (int i = 0; i < mFileJson.settingjson.General_Config.Machine.Length; i++)
            {
                this.cbMachineNum.Items.Add(mFileJson.settingjson.General_Config.Machine[i]);
            }

            for (int i = 0; i < mFileJson.settingjson.General_Config.Language.Length; i++)
            {
                this.cbLanguage.Items.Add(mFileJson.settingjson.General_Config.Language[i]);
            }

            try
            {
                this.cbStation.SelectedIndex = cbStation.FindString(GlobalVar.SCUD机种名);
                this.cbSite.SelectedIndex = cbSite.FindString(GlobalVar.MachineTimeZone.ToString());
                this.comboBox1.SelectedIndex = comboBox1.FindString(GlobalVar.ProductType);
                this.cbLine.SelectedIndex = cbLine.FindString(GlobalVar.Line);
                this.cbMachineNum.SelectedIndex = cbMachineNum.FindString(GlobalVar.MachineNo);
                this.cbLanguage.SelectedIndex = int.Parse(GlobalVar.language);
            }
            catch
            {
                this.cbLanguage.SelectedIndex = 0;
            }
        }

        #endregion 功能：窗体加载

        #region 功能：定时器

        #endregion 功能：定时器

        #region UI界面操作

        /// <summary>
        /// 界面切换运行切换控制
        /// </summary>
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e) //I/O输出界面 和 手动调试界面 进入跳转管理
        {
            tb_ProductSN.Enabled = false;
            switch (TabControl1.SelectedTab.Name)
            {
                case "tP_DO":
                case "tP_Manual":
                    tb_ProductSN.Enabled = true;
                    break;
            }
        }

        #endregion UI界面操作

        #region 主界面操作

        #endregion 主界面操作

        private FormHardwareSetting FHS;

        private void button7_Click(object sender, EventArgs e)
        {
            if (AudioLoginManager.Instance.LoggedInAccount.UserLevel >= LoginLevel.Level3)
            {
                if (FHS?.IsDisposed != false)
                {
                    FHS = new FormHardwareSetting();
                }

                FHS.Show();
            }
        }

        public void btn_GeneralSave_Click()
        {
            string SelectMachineName = cbStation.SelectedItem.ToString();
            string SelectTimeZone = cbSite.SelectedItem.ToString();
            string SelectLine = cbLine.SelectedItem.ToString();
            string SelectMachineNum = cbMachineNum.SelectedItem.ToString();
            int SelectLanuage = cbLanguage.SelectedIndex;
            string SelectProductType = comboBox1.SelectedItem.ToString();
            mFileJson.settingjson.Site = SelectTimeZone;
            mFileJson.settingjson.Prod_Type = SelectProductType;
            mFileJson.settingjson.Line = SelectLine;
            mFileJson.settingjson.Station = SelectMachineName;
            mFileJson.settingjson.Machine = SelectMachineNum;
            if (Set_MachineSubName(SelectMachineName, SelectTimeZone, SelectLine, SelectMachineNum, SelectLanuage.ToString(), SelectProductType))
            {
                if (mFileJson.WriteJsonFile(mFileJson.settingjson))
                {
                    GlobalVar.MachineTimeZone = (ETimeZone)Enum.Parse(typeof(ETimeZone), MachineTimeZone);
                    GlobalVar.SCUD机种名 = MachineSubName;
                    GlobalVar.Line = MachineLine;
                    GlobalVar.MachineNo = MachineMachineNo;
                    GlobalVar.ProductType = ProductType;
                    GlobalVar.ProjectCode = Project_Code;
                    MessageBox.Show("Sucess!");
                }
                else
                {
                    Interaction.MsgBox("Fail！！！", Constants.vbOKOnly, "提示");
                }
            }
            else
            {
                Interaction.MsgBox("Fail！！！", Constants.vbOKOnly, "提示");
            }
        }

        private int i = 0;

        private void ChangeLab(Control control)
        {
            try
            {
                foreach (Control item in control.Controls)
                {
                    if (!(item is InputClass) && !(item is OutputClass) && !(item is UserManager) && !(item is TCP_IP) && !(item is TeachS) && !(item is PropertyParS) && !(item is UserChk) &&  !(item is Cylinder) )
                    {
                        if (item != null && (!(item is TextBox) || !(item is RichTextBox)))
                        {
                            System.Diagnostics.Debug.WriteLine($"{i++},{item?.Text},{item?.Name},{item?.GetType()}");
                            if (!string.IsNullOrEmpty(item.Text))
                            {
                                DataRow[] drs = GlobalVar.LanguageDataTable.Select($"EN='{item?.Text}' or CN='{item?.Text}' or VN='{item?.Text}'");
                                if (drs.Length > 0)
                                {
                                    item.Text = drs[0][cbLanguage.SelectedIndex].ToString();
                                }
                            }
                            else if (item is DataGridView dgv)
                            {
                                if (dgv?.Tag == null)
                                {
                                    dgv.Tag = "XXX";
                                    dgv.Paint += Dgv_Paint;
                                }
                            }
                        }
                        if (item.HasChildren)
                        {
                            ChangeLab(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        private void Dgv_Paint(object sender, PaintEventArgs e)
        {
            // 表头
            DataGridView dgv = (DataGridView)sender;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                DataRow[] drs = GlobalVar.LanguageDataTable.Select($"EN='{dgv.Columns[i].HeaderText}' or CN='{dgv.Columns[i].HeaderText}' or VN='{dgv.Columns[i].HeaderText}'");
                if (drs.Length > 0)
                {
                    dgv.Columns[i].HeaderText = drs[0][cbLanguage.SelectedIndex].ToString();
                }
            }
        }

        public async Task MyMethodAsync(Control control, int DelayTime = 60)
        {
            // 异步操作
            await Task.Delay(DelayTime);
            ChangeLab(control);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SysState == State.RUNNING)
            {
                MessageBox.Show("正在运行过程中不允许点击系统设置按钮！");
                return;
            }
            Form_Set SysPar_Set = new Form_Set();
            SysPar_Set.mForms.Clear();
            SysPar_Set.nPassword = "";  //加这一句就不用输密码
            SysPar_Set.Show();
        }

        /// <summary>
        /// 三色灯状态
        /// </summary>
        public void LightStatues_Refresh()
        {
            while (true)
            {
                Application.DoEvents();
                状态更新.LightStatus();
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 按钮灯状态
        /// </summary>
        public void ButtonLightStatues_Refresh()
        {
            while (true)
            {
                Application.DoEvents();
                状态更新.ButtonLightStatus();
                Thread.Sleep(100);
            }
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            if (!FormLoad)
            {
                return;
            }
            if (mGlobal.isManaul)
            {
                LightStatus = mGlobal.IsOnAlarm ? (short)LightEnum.手动模式故障报警 : (short)LightEnum.手动模式调试状态;
            }
            else if (mGlobal.IsOnAlarm)
            {
                LightStatus = (short)LightEnum.运行中报警;
            }
            else if (SysState == State.RUNNING)
            {
                LightStatus = (short)LightEnum.自动运行中;
            }
            else if (SysState == State.PAUSE)
            {
                LightStatus = (short)LightEnum.自动模式等待启动状态;
            }
            else if (SysState == State.WAITRUN)
            {
                LightStatus = (short)LightEnum.自动模式等待启动状态;
            }
            StatusTimer.Enabled = true;
            CheckAlarm.Enabled = true;
        }

        private void CheckAlarm_Tick(object sender, EventArgs e)
        {
            if (!ParHelper.OffLine_VirtualRun脱机空跑)
            {
                CheckAlarm.Enabled = false;
                状态更新.AlarmCheck();
                CheckAlarm.Enabled = true;
            }
        }

        #region 每天定时删除数据库

        /// <summary>
        /// 删除数据库定时器
        /// </summary>
        public static void setTaskAtFixedTime()
        {
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today.AddHours(12.00); //设置时间  小时
            oneOClock = oneOClock.AddMinutes(30);//设置时间  分钟 ，即每天12:30 执行一次过期查询， 如果设置整点时间 ，就屏蔽这句
            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1.0);//加一天
            }
            int msUntilFour = (int)(oneOClock - now).TotalMilliseconds;//

            System.Threading.Timer t = new System.Threading.Timer(doAt1AM);
            t.Change(msUntilFour, Timeout.Infinite);
        }

        //要执行的任务
        private static void doAt1AM(object state)
        {
            setTaskAtFixedTime();
        }

        #endregion 每天定时删除数据库

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    this.label4.Text = SysState.ToString();
                    //this.label_手自动.Text = EnglishMode ? mGlobal.isManaul ? "Manual" : "Auto" : mGlobal.isManaul ? "手动模式" : "自动模式";
                    //this.label_手自动.BackColor = mGlobal.isManaul ? Color.Red : Color.LightGreen;
                    this.label13.Text = EnglishMode ? "" : ((LightEnum)LightStatus).ToString();
                    //this.panel_点位调试.Visible = !EnglishMode;
                    Label_MachineStatus.Text = StringHelper.SplitByLanguage(GetParValue<string>(名称枚举.UserPar.机器运行模式))[EnglishMode ? 0 : 1];
                }));
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }




        private void cbLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox btn = (ComboBox)sender;
            if (btn.Text == "Tiếng Việt")
            {
                GlobalVar.language = "2";
                LanguageState = 语言设定.OTH;
                EnglishMode = true;
            }
            else if (btn.Text == "English")
            {
                GlobalVar.language = "1";
                LanguageState = 语言设定.ENG;
                EnglishMode = true;
            }
            else
            {
                GlobalVar.language = "0";
                LanguageState = 语言设定.CHN;
                EnglishMode = false;
            }
            mFileJson.settingjson.Language = btn.Text;
            if (mFileJson.WriteJsonFile(mFileJson.settingjson))
            {
                MessageBox.Show("Sucess!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool a = tcP_IP20.TcpClient.IsConnected;
        }


        private void Axis_Setting_Click(object sender, EventArgs e)
        {
            Form_Axis_Set Axis_Set = new Form_Axis_Set();
            Axis_Set.Show();
        }

        private void IOLanguage_Click(object sender, EventArgs e)
        {
            LangHelper.WriteIOLanguageXml();
            Thread.Sleep(1000);
            LangHelper.ReadIOLanguage();
        }
    }
}