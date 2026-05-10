using CoreFunction;
using Help;
using LogsHelper;
using MotionFunction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserHelper;
using XStation;
using 运动模块;
using static CoreFunction.mFunction;
using static FilePath.mFilePath;
using static Help.AxisHelper;
using static LogsHelper.LogWrite;
using static ParName.名称枚举;

namespace BoTech
{
    public partial class Frm_ICT_Main : Form
    {
        #region 窗体加载

        private static Frm_ICT_Main instance;

        public static Frm_ICT_Main Instance
        {
            get
            {
                if (instance?.IsDisposed != false)
                {
                    instance = new Frm_ICT_Main();
                }

                return instance;
            }
        }

        private Dictionary<AudioButton, Control> pagesDic = new Dictionary<AudioButton, Control>();
        private List<AudioButton> mainPageButton = new List<AudioButton>();

        /// <summary>
        /// 构造函数 加载数据库；加载参数；界面text设置；登录事件、登出事件、登录事件hive；登出事件hive
        /// </summary>
        public Frm_ICT_Main()
        {
            InitializeComponent();
            mFileJson.ReadJsonFile();
            Initial_mFilePath();
            StartWriterMsg();
            GlobalVar.SCUD机种名 = MachineSubName;
            GlobalVar.Line = MachineLine;
            GlobalVar.MachineNo = MachineMachineNo;
            if (MachineLanguage.Contains("中文"))
            {
                EnglishMode = false;
                GlobalVar.language = "0";
            }
            else if (MachineLanguage.Contains("English"))
            {
                EnglishMode = true;

                GlobalVar.language = "1";
            }
            else if (MachineLanguage.Contains("Tiếng Việt"))
            {
                EnglishMode = true;

                GlobalVar.language = "2";
            }
            LanguageState = (语言设定)Enum.Parse(typeof(语言设定), GlobalVar.language);
            窗体加载.ReadAlarmMessage();
            GlobalVar.ProductType = ProductType;
            GlobalVar.ProjectCode = Project_Code;
            GlobalVar.MaxFeedingDogMinutes = Convert.ToInt32(mFileJson.settingjson.Automatically_Sign_out);
            GlobalVar.LanguageDataTable = iExcel.ReadExcelToDataTable($"{Application.StartupPath}\\Languages\\DScudLanguage.xlsx");
            //DataServerManager.Instance.Load();
            this.TextChanged += TextChange;
            this.Resize += TextChange;
            IniPages();
            IniPageBtn();
            AudioLoginManager.Instance.UserLogin_event += UserLevelChange;
            AudioLoginManager.Instance.Logout_event += UserLogout;
            this.Main_ChildPage.Controls.Clear();
            this.Main_ChildPage.Controls.Add(SettingPage.Instance);
        }

        private void TextChange(object sender, EventArgs e)
        {
            ChangeTitlePosition();
        }

        private void ChangeTitlePosition()  //名称居中
        {
            Graphics g = this.CreateGraphics();
            double startingPoint = (this.Width / 2.0) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            double ws = g.MeasureString(" ", this.Font).Width;
            string temp = " ";
            double tw = 0;
            while ((tw + ws) < startingPoint)
            {
                temp += " ";
                tw += ws;
            }
            this.Text = temp + this.Text.Trim();
        }

        private bool Form_Load;

        private void Frm_ICT_Main_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 768);
            this.Location = new Point(0, 0);
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            X1 = (short)splitContainer1.Panel2.Width;
            Y1 = (short)splitContainer1.Panel2.Height;
            SetTag(splitContainer1.Panel2, 0, true);
            if (this.FormBorderStyle == FormBorderStyle.FixedSingle)
            {
                splitContainer1.Panel2.Size = new Size(1008, 629);
                SetControls((float)((double)splitContainer1.Panel2.Width / 1008), (float)((double)splitContainer1.Panel2.Height / 629), splitContainer1.Panel2, Convert.ToInt32(splitContainer1.Panel2.Tag), true);
            }
            mGlobal.NewX = (float)((double)splitContainer1.Panel2.Width / X1);
            mGlobal.NewY = (float)((double)splitContainer1.Panel2.Height / Y1);
            mGlobal.ChildFrmOffsetPoint = new Point(0, 0);
            this.Btn_ProductType.Location = new Point(((this.Width - Btn_ProductType.Width) / 2) - 8, this.Btn_ProductType.Location.Y);
            splitContainer1.SplitterDistance = 80;
            this.Main_ChildPage.Width = this.splitContainer1.Panel2.Width;
            this.Main_ChildPage.Height = this.splitContainer1.Panel2.Height;
            this.Main_ChildPage.Location = this.splitContainer1.Location;
            this.Text = ParHelper.当前为右机 ? "M03-FLEX-PSA-R-PCBA Unloading" : "M03-FLEX-PSA-L-PCBA Unloading";
            Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
            Btn_Click(this.Btn_Home, e);
            this.Btn_Pause.ButtonStateChange(NewButtonState.Disabled);
            Btn_Stop.ButtonStateChange(NewButtonState.Disabled);
            this.Btn_Stop.ButtonStateChange(NewButtonState.Disabled);
            mGlobal.IsOpenFrmEngineering = false;
            mGlobal.IsOpenFrmProduction = false;

            #region datasource delete over 30 days

            //DataServerManager.Instance.DeleteAlarmStaleData(30);
            //DataServerManager.Instance.DeleteMachineStateStaleData(30);

            #endregion datasource delete over 30 days

            FunctionButtonCheck();
            this.Btn_Stop.ButtonStateChange(NewButtonState.Energized);
            Form_Load = true;
        }

        public void IniPages()
        {
            //此处初始化相应界面，到时可依据项目差异，根据不同项目或设备机型变更某些界面

            pagesDic.Add(this.Btn_Home, HomePage.Instance);
            pagesDic.Add(this.Btn_Alarm, AlarmPage.Instance);
            pagesDic.Add(this.Btn_Config, ConfigPage.Instance);
            pagesDic.Add(this.Btn_Data, DataPage.Instance);
            pagesDic.Add(this.Btn_Setting, SettingPage.Instance);
            pagesDic.Add(this.Btn_Vision, VisionPage.Instacne);
        }

        public void IniPageBtn()
        {
            mainPageButton.Add(this.Btn_Home);
            mainPageButton.Add(this.Btn_Alarm);
            mainPageButton.Add(this.Btn_Data);
            mainPageButton.Add(this.Btn_Setting);
            mainPageButton.Add(this.Btn_Config);
            mainPageButton.Add(this.Btn_Vision);

            this.Btn_Setting.ButtonStateChange(NewButtonState.Disabled);
            this.Btn_Config.ButtonStateChange(NewButtonState.Disabled);
            this.Btn_Vision.ButtonStateChange(NewButtonState.Deenergized);
            this.Btn_Data.ButtonStateChange(NewButtonState.Deenergized);
            this.Btn_Run.ButtonStateChange(NewButtonState.Deenergized);
            this.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
            this.Btn_Pause.ButtonStateChange(NewButtonState.Deenergized);
        }

        #endregion 窗体加载

        #region 语言切换

        #endregion 语言切换

        #region 界面切换

        /// <summary>
        /// 按钮单击事件； 设置选择的按钮；设置选择的界面；向数据库写入当前登录者信息（登录发生时间，登录名称、登录权限级别、登录按钮）
        /// </summary>
        public void Btn_Click(object sender, EventArgs e)
        {
            AudioButton btn = (AudioButton)sender;
            //验证权限
            if (btn != this.Btn_Alarm && btn != this.Btn_Home && btn != this.Btn_Vision && btn != this.Btn_Data && btn != this.Btn_Sensor && AudioLoginManager.Instance.GetCurrentLevel() <= LoginLevel.NoLogin)
            {
                return;
            }
            if (SetSelectButton(btn))
            {
                SetMainPanelPage(btn);
            }
        }

        /// <summary>
        /// 设置选择的按钮； 当按钮可用，按钮状态切换；
        /// </summary>
        public bool SetSelectButton(AudioButton btn)
        {
            foreach (AudioButton item in mainPageButton)
            {
                if (item.Enabled && item.ButtonEnable)
                { item.ButtonStateChange(NewButtonState.Deenergized); }
            }
            btn.ButtonStateChange(NewButtonState.Energized);
            return true;
        }

        /// <summary>
        /// 设置选择界面； 当前容器清空，填入； 刷新界面；
        /// </summary>
        public void SetMainPanelPage(AudioButton btn)
        {
            try
            {
                this.Main_ChildPage.Controls.Clear();
                this.Main_ChildPage.Controls.Add(pagesDic[btn]);
                pagesDic[btn].Dock = DockStyle.Fill;
                this.BeginInvoke(new Action(async () => await SettingPage.Instance.MyMethodAsync(pagesDic[btn])));
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
            this.Invalidate();
        }

        #endregion 界面切换

        #region 权限管理

        /// <summary>
        /// 登录按钮时间； 显示登录界面；
        /// </summary>
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (AudioLoginManager.Instance.LoggedInAccount.UserLevel <= LoginLevel.NoLogin)
            {
                AudioLoginManager.Instance.ShowLoginPage();
            }
        }

        /// <summary>
        /// 用户登录， 按照登录级别，对应不同界面按钮的状态切换；
        /// </summary>
        private void UserLevelChange(AccountInfo AI)
        {
            Log($"UserID:{AudioLoginManager.Instance.LoggedInAccount.UserID}Name:{AudioLoginManager.Instance.LoggedInAccount.UserName}   LoginIn");
            EventArgs e = EventArgs.Empty;
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    if (AI.UserLevel == LoginLevel.NoLogin)
                    {
                        this.Btn_Login.ButtonStateChange(NewButtonState.Alarm);
                        this.Btn_Setting.ButtonStateChange(NewButtonState.Disabled);
                        this.Btn_Config.ButtonStateChange(NewButtonState.Disabled);
                    }
                    else if (AI.UserLevel == LoginLevel.Level1)
                    {
                        this.Btn_Login.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Setting.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Vision.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Config.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Data.ButtonStateChange(NewButtonState.Deenergized);
                    }
                    else if (AI.UserLevel == LoginLevel.Level2)
                    {
                        this.Btn_Login.BackgroundImage = global::My.Resources.Resources.Level2;
                        this.Btn_Setting.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Vision.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Config.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Data.ButtonStateChange(NewButtonState.Deenergized);
                    }
                    else if (AI.UserLevel == LoginLevel.Level3)
                    {
                        this.Btn_Login.ButtonStateChange(NewButtonState.Energized);
                        this.Btn_Setting.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Vision.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Config.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Data.ButtonStateChange(NewButtonState.Deenergized);
                    }
                    Btn_Click(this.Btn_Home, e);
                }));
            }
        }

        /// <summary>
        /// 用户登出； 各个按钮状态切换，以及按钮事件；
        /// </summary>
        private void UserLogout()
        {
            Log($"UserID:{AudioLoginManager.Instance.LoggedInAccount.EmployeeID}  NoUser(LoginOut)");
            EventArgs e = EventArgs.Empty;
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    this.Btn_Login.ButtonStateChange(NewButtonState.Alarm);
                    this.Btn_Setting.ButtonStateChange(NewButtonState.Disabled);
                    //this.Btn_Vision.ButtonStateChange(NewButtonState.Disabled);
                    this.Btn_Config.ButtonStateChange(NewButtonState.Disabled);
                    //this.Btn_Data.ButtonStateChange(NewButtonState.Disabled);
                    Btn_Click(this.Btn_Home, e);
                }));
            }
        }

        #endregion 权限管理

        #region 运行管理

        /// <summary>
        /// 运行按钮； 如果回零标志位为true； 执行自动运行； 否则，初始化设备；
        /// </summary>
        public void Btn_Run_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeMachineOperation_Btn((AudioButton)sender);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 因SettingPageS1里面有一个界面刷新函数，需要调用这个Btn_Pause_Click暂停事件； 因此把Btn_Pause_Click定义为Public，原为Private;
        /// </summary>
        public void Btn_Pause_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeMachineOperation_Btn((AudioButton)sender);
            }
            catch
            { }
        }

        public void Btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeMachineOperation_Btn((AudioButton)sender);
            }
            catch
            { }
        }

        private ManuallyLogin ml;
        private DialogResult m_show;

        /// <summary>
        /// 设备操作事件；运行、暂停、停止、其他，对应的按钮状态切换；
        /// </summary>
        public void ChangeMachineOperation_Btn(AudioButton NB)
        {
            try
            {
                #region 运行按钮功能

                if (NB == this.Btn_Run)
                {
                    if (!GoHome.Home_OK && mGlobal.IsLoadFrmEngineering)
                    {
                        初始化.Initialization();
                    }
                    else if (GoHome.Home_OK && mGlobal.IsLoadFrmEngineering && !mGlobal.IsStartAutoRun)
                    {
                        Log($"当前设备设定模式为：{GetParValue<string>(UserPar.机器运行模式)}");
                        Task.Run(() =>
                        {
                            Application.DoEvents();
                            自动运行.RunClick();
                        });
                        resetbutton = false;
                    }
                    else
                    {
                        SysState = State.RUNNING;
                        IsSysStop = false;
                        mGlobal.IsStartAutoRun = false;
                        WkManager.Resume();
                        this.Btn_Run.ButtonStateChange(NewButtonState.Energized);
                        this.Btn_Pause.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                        Log("暂停后点击继续运行！");
                    }
                }

                #endregion 运行按钮功能

                #region 暂停按钮功能

                else if (NB == this.Btn_Pause)
                {
                    if (GoHome.Home_OK)
                    {
                        if (SysState == State.RUNNING)
                        {
                            SysState = State.PAUSE;
                            WkManager.Pause();
                            mGlobal.IsStartAutoRun = true;
                            resetbutton = true;
                            this.Btn_Run.ButtonStateChange(NewButtonState.Disabled);
                            this.Btn_Pause.ButtonStateChange(NewButtonState.Energized);
                            this.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                            Log("点击暂停!");
                        }
                        else
                        {
                            if (mGlobal.isManaul)
                            {
                                GlobalVoid.MachineWriteLog("请切换到自动模式运行!!!");
                                MessageBox.Show("请切换到自动模式运行!!!");
                                return;
                            }
                            if (mGlobal._Logs.AddLog(GlobalUserInfoGet.GetLoginString, "开始自动运行?", LogsType.MachineLog, 0, true, true, true, MessageBoxButtons.OKCancel) != DialogResult.OK)
                            {
                                return;
                            }
                            if (SysState == State.PAUSE || SysState == State.WAITRUN)
                            {
                                if (SysState == State.PAUSE && ParHelper.启用安全门功能)
                                {
                                    if (!GetDI(InNo.前安全门信号))
                                    {
                                        Task00_空站.Instance.myTipNew(eErrCode.前安全门信号异常);
                                        return;
                                    }

                                    if (!GetDI(InNo.后安全门信号))
                                    {
                                        Task00_空站.Instance.myTipNew(eErrCode.后安全门信号异常);
                                        return;
                                    }
                                }

                                if (IsSysStop)
                                {
                                    if (SysState == State.PAUSE)
                                    {
                                        SysState = State.WAITRUN;
                                        WkManager.Resume();

                                        this.Btn_Run.ButtonStateChange(NewButtonState.Energized);
                                        this.Btn_Pause.ButtonStateChange(NewButtonState.Deenergized);
                                        this.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                                        Log("暂停后点击继续运行！");
                                    }
                                    else
                                    {
                                        State[] Sts = WkManager.CheckSts();
                                        for (short i = 0; i <= Sts.Length - 1; i++)
                                        {
                                            if (Sts[i] == State.RUNNING)
                                            {
                                                SysState = State.PAUSE;
                                                WkManager.Pause();
                                                this.Btn_Run.ButtonStateChange(NewButtonState.Deenergized);
                                                this.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                                                return;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    SysState = State.RUNNING;
                                    IsSysStop = false;
                                    WkManager.Resume();
                                    this.Btn_Run.ButtonStateChange(NewButtonState.Energized);
                                    this.Btn_Pause.ButtonStateChange(NewButtonState.Deenergized);
                                    this.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                                    Btn_ProductType.BackColor = Color.Lime;

                                    Log("暂停后点击继续运行！");
                                }
                            }
                        }
                    }
                    else
                    {
                        this.Btn_Run.ButtonStateChange(NewButtonState.Deenergized);
                        this.Btn_Pause.ButtonStateChange(NewButtonState.Disabled);
                        this.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                    }
                }

                #endregion 暂停按钮功能

                #region 停止按钮功能

                else if (NB == this.Btn_Stop)
                {
                    WkManager.Pause();
                    if (ml?.IsDisposed != false)
                    {
                        ml = new ManuallyLogin("停止按钮按下");
                        m_show = ml.ShowDialog();
                        ml = null;
                    }

                    if (m_show == DialogResult.OK)
                    {

                        Btn_ProductType.BackColor = Color.Transparent;
                        ConveyorHelper.StopAll();
                        resetbutton = false;
                        mGlobal.IsStartAutoRun = false;
                        WkManager.Cancel();
                        GoHome.Home_OK = false;
                        SysState = State.WAITRESET;
                        this.Btn_Stop.ButtonStateChange(NewButtonState.Energized);
                        this.Btn_Pause.ButtonStateChange(NewButtonState.Disabled);
                        this.Btn_Run.ButtonStateChange(NewButtonState.Deenergized);
                        Task03_L移载平台.Instance.Clear();
                        Task04_R移载平台.Instance.Clear();
                        Task01_L上料.Instance.Clear();
                        Task05_L下料.Instance.Clear();
                        Task02_R上料.Instance.Clear();
                        Task06_R下料.Instance.Clear();
                        Task03_L移载平台.Instance.回零步序 = 0;
                        Task04_R移载平台.Instance.回零步序 = 0;
                        Task01_L上料.Instance.回零步序 = 0;
                        Task05_L下料.Instance.回零步序 = 0;
                        Task02_R上料.Instance.回零步序 = 0;
                        Task06_R下料.Instance.回零步序 = 0;
                        Log("点击停止！");
                    }
                }

                #endregion 停止按钮功能

                else
                {
                    this.Btn_Run.ButtonStateChange(NewButtonState.Deenergized);
                    this.Btn_Pause.ButtonStateChange(NewButtonState.Deenergized);
                    this.Btn_Stop.ButtonStateChange(NewButtonState.Deenergized);
                }
            }
            catch { }
        }

        #endregion 运行管理

        public bool resetbutton;
        public bool runbutton;

        /// <summary>
        /// 界面按钮监控
        /// </summary>
        private void FunctionButtonCheck()
        {
            Task.Run(new Action(() =>
            {
                while (true)
                {
                    if (!resetbutton && SysState == State.WAITRESET && !GoHome.Home_OK &&
                     MotionDll.ReadDi(InNo.复位按钮信号) == 1)
                    {
                        resetbutton = true;

                        this.BeginInvoke(new Action(() => ChangeMachineOperation_Btn(this.Btn_Run)));
                    }
                    else if (resetbutton && (SysState == State.WAITRUN || SysState == State.PAUSE) && GoHome.Home_OK &&
                             MotionDll.ReadDi(InNo.启动按钮信号) == 1)
                    {
                        runbutton = false;
                        resetbutton = false;
                        this.BeginInvoke(new Action(() => ChangeMachineOperation_Btn(this.Btn_Run)));
                    }
                    else if (SysState == State.RUNNING && GoHome.Home_OK &&
                             MotionDll.ReadDi(InNo.停止按钮信号) == 1)
                    {
                        runbutton = false;
                        resetbutton = false;
                        this.BeginInvoke(new Action(() => ChangeMachineOperation_Btn(this.Btn_Pause)));
                    }
                    Thread.Sleep(50);
                }
            }));
        }

        private void Frm_ICT_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult.OK == MessageBox.Show("确定退出程序吗？？？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    LightStatus = (short)LightEnum.软件未启动;

                    SetDO(OutNo.启动按钮灯, 0);
                    SetDO(OutNo.停止按钮灯, 0);
                    SetDO(OutNo.复位按钮灯, 0);
                    //SetDO(OutNo.OK上料按钮灯, 0);
                    //SetDO(OutNo.OK下料按钮灯, 0);
                    //SetDO(OutNo.NG上料按钮灯, 0);
                    //SetDO(OutNo.NG下料按钮灯, 0);

                    SetDO(OutNo.三色灯红, 0);
                    SetDO(OutNo.三色灯绿, 0);
                    SetDO(OutNo.三色灯黄, 0);
                    SetDO(OutNo.蜂鸣器, 0);
                }
                else
                {
                    e.Cancel = true;
                    return;
                }

                ////关闭进程
                Process.GetCurrentProcess().Kill();
            }
            catch
            {
                Process.GetCurrentProcess().Kill();
            }
            this.Dispose();
            this.Close();
        }

        protected static void Log(string str)
        {
            GlobalVoid.MachineWriteLog(str);  //machine Log\\日期\\内容
        }

        private void Frm_ICT_Main_Resize(object sender, EventArgs e)
        {
            if (Form_Load)
            {
                mGlobal.NewX = (float)((double)splitContainer1.Panel2.Width / X1);
                mGlobal.NewY = (float)((double)splitContainer1.Panel2.Height / Y1);
                this.Main_ChildPage.Width = this.splitContainer1.Panel2.Width;
                this.Main_ChildPage.Height = this.splitContainer1.Panel2.Height;
                splitContainer1.SplitterDistance = 80;
                this.Btn_ProductType.Width = this.Width - (panel2.Width + panel3.Width) - 16;
                this.Btn_ProductType.Location = new Point(((this.Width - Btn_ProductType.Width) / 2) - 8, this.Btn_ProductType.Location.Y);
                SetControls(mGlobal.NewX, mGlobal.NewY, this.Main_ChildPage, Convert.ToInt32(this.Main_ChildPage.Tag), true);
                if (AlarmPage.Instance.Handle != null)
                {
                    AlarmPage.Instance.Location = mGlobal.ChildFrmOffsetPoint;
                    AlarmPage.Instance.Size = Main_ChildPage.Size;
                    SetControls(mGlobal.NewX, mGlobal.NewY, AlarmPage.Instance, 2, true);
                }
                if (ConfigPage.Instance.Handle != null)
                {
                    ConfigPage.Instance.Location = mGlobal.ChildFrmOffsetPoint;
                    ConfigPage.Instance.Size = Main_ChildPage.Size;
                    SetControls(mGlobal.NewX, mGlobal.NewY, ConfigPage.Instance, 3, true);
                }
                if (DataPage.Instance.Handle != null)
                {
                    DataPage.Instance.Location = mGlobal.ChildFrmOffsetPoint;
                    DataPage.Instance.Size = Main_ChildPage.Size;
                    SetControls(mGlobal.NewX, mGlobal.NewY, DataPage.Instance, 4, true);
                }
                if (HomePage.Instance.Handle != null)
                {
                    HomePage.Instance.Location = mGlobal.ChildFrmOffsetPoint;
                    HomePage.Instance.Size = Main_ChildPage.Size;
                    SetControls(mGlobal.NewX, mGlobal.NewY, HomePage.Instance, 1, true);
                }
                if (SettingPage.Instance.Handle != null)
                {
                    SettingPage.Instance.Location = mGlobal.ChildFrmOffsetPoint;
                    SettingPage.Instance.Size = Main_ChildPage.Size;
                    SetControls(mGlobal.NewX, mGlobal.NewY, SettingPage.Instance, 6, true);
                }
                if (VisionPage.Instacne.Handle != null)
                {
                    VisionPage.Instacne.Location = mGlobal.ChildFrmOffsetPoint;
                    VisionPage.Instacne.Size = Main_ChildPage.Size;
                    SetControls(mGlobal.NewX, mGlobal.NewY, VisionPage.Instacne, 5, true);
                }
            }
        }

        private FrmLogOut fLogOut;

        private void outLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AudioLoginManager.Instance.GetCurrentLevel() == LoginLevel.NoLogin)
            {
                return;
            }
            if (fLogOut?.IsDisposed != false)
            {
                fLogOut = new FrmLogOut();
            }

            fLogOut.Show();
        }

        private bool auto;

        private void Main_ChildPage_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}