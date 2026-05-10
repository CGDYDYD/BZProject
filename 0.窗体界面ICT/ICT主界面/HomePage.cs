using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UserHelper;
using static CoreFunction.mFunction;
using static FilePath.mFilePath;

namespace BoTech
{
    /// <summary>
    /// home界面；
    /// </summary>
    public partial class HomePage : MyControl
    {
        private static HomePage instance;

        public static HomePage Instance
        {
            get
            {
                if (instance?.IsDisposed != false)
                {
                    instance = new HomePage();
                }

                return instance;
            }
        }

        public bool IsLoad;

        public HomePage()
        {
            InitializeComponent();

            this.stn1.MachineLogCLick += MachineLogShow;
            this.stn1.HiveLogCLick += HiveLogShow;
            this.stn1.MainSWPathCLick += MainSWPathShow;
            AudioLoginManager.Instance.UserLogin_event += UserLevelChange;
            AudioLoginManager.Instance.Logout_event += UserLogout;
            this.machineErrorStatistics1.DoubleBarCurrentTime = DateTime.Now;
            //this.machineErrorStatistics1.DoubleTrackValueChange += RefreshMESS;
            IsLoad = true;
            StatusRefreshTimer.Enabled = true;
        }

        private void MainSWPathShow(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath);
        }

        public override void StartRefreshPage()
        {
            this.StatusRefreshTimer.Start();
        }

        public override void StopRefreshPage()
        {
            this.StatusRefreshTimer.Stop();
        }

        private void StatusRefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //this.StatusRefreshTimer.Stop();
                //this.machineErrorStatistics1.DoubleBarCurrentTime = DateTime.Parse($"{DateTime.Now:yyyy-MM-dd} 23:59:59");
                //RefreshMSC();
                //RefreshMESS(this.machineErrorStatistics1.TrackStartTime, this.machineErrorStatistics1.TrackEndTime);
                //this.StatusRefreshTimer.Start();
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        private void RefreshMESS(DateTime start, DateTime end)
        {
            DataTable mesTable = DataServerManager.Instance.SelectDT_Statistic(start, end, false);

            #region 创建接口数据表格

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("ErrorCode", typeof(string));
            DataColumn dc1 = new DataColumn("Count", typeof(double));
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            #endregion 创建接口数据表格

            #region 数据转换

            int allCount = mesTable.Rows.Count;
            allCount = allCount >= 10 ? 10 : allCount;

            for (int i = 0; i < allCount; i++)
            {
                dt.Rows.Add(dt.NewRow());
                dt.Rows[i][0] = mesTable.Rows[i][0];
                dt.Rows[i][1] = double.Parse(mesTable.Rows[i][2].ToString());
            }

            #region 补齐报警条数；

            dt = AlarmAdd(dt);

            #endregion 补齐报警条数；

            this.machineErrorStatistics1.Refresh(dt);

            #endregion 数据转换
        }

        private DataTable AlarmAdd(DataTable dt)
        {
            DataTable dtTemp = new DataTable();
            DataColumn dc_0 = new DataColumn("ErrorCode", typeof(string));
            DataColumn dc_1 = new DataColumn("时间", typeof(double));
            dtTemp.Columns.Add(dc_0);
            dtTemp.Columns.Add(dc_1);

            return dt;
        }

        #region CriticalPameterDashBoard

        #endregion CriticalPameterDashBoard

        #region STN控件

        private void IniSTN()
        {
            this.stn1.SW_Version = Application.ProductVersion;
            this.stn1.STNName = $"{GlobalVar.SCUD机种名} #{GlobalVar.MachineNo}";
            this.stn1.SiteName = GlobalVar.MachineTimeZone.ToString();
            this.stn1.MS_Hash = GlobalVar.MS_Hash;
            this.stn1.Vender = "BZ";
            string[] tem = $"{Application.ExecutablePath}".Split('\\');
            this.stn1.Main_SW_Path = tem.Length > 3 ? $"{tem[0]}\\{tem[1]}\\...\\{tem[tem.Length - 1]}" : $"{Application.ExecutablePath}";
        }

        private void MachineLogShow(object sender, EventArgs e)
        {
            //打开MachineLog指定目录
            try
            {
                string strPath = $"{MachineLog}";
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                Process.Start(strPath);
            }
            catch { }
        }

        private void HiveLogShow(object sender, EventArgs e)
        {
            try
            {
                string strPath = $"{BZ_LogPath}UPH\\";
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                Process.Start(strPath);
            }
            catch { }
        }

        private void UserLevelChange(AccountInfo AI)
        {
            if (AI.UserLevel >= LoginLevel.NoLogin)
            {
                this.stn1.SensorPageButtonVisible = true;
            }
        }

        private void UserLogout()
        {
            this.BeginInvoke(new Action(() => this.stn1.SensorPageButtonVisible = false));
        }

        #endregion STN控件

        #region MachineStateChange

        private void RefreshMSC()
        {
            //获取数据库 数据
            DateTime now = DateTime.Now;
            DateTime before = now.AddDays(-7).AddHours(-1);
            DataTable mscTable = DataServerManager.Instance.SelectMachineState(before, now);

            #region //控件需要的数据表

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("日期", typeof(string));
            DataColumn dc1 = new DataColumn("Running", typeof(double));
            DataColumn dc2 = new DataColumn("Idle", typeof(double));
            DataColumn dc3 = new DataColumn("Engineering", typeof(double));
            DataColumn dc4 = new DataColumn("PlannedDT", typeof(double));
            DataColumn dc5 = new DataColumn("Downtime", typeof(double));
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            for (int i = 0; i < 7; i++)
            {
                dt.Rows.Add(dt.NewRow());
                dt.Rows[i][0] = now.AddDays(i - 6).ToString("yyyy/MM/dd");
                dt.Rows[i][1] = 0;
                dt.Rows[i][2] = 0;
                dt.Rows[i][3] = 0;
                dt.Rows[i][4] = 0;
                dt.Rows[i][5] = 0;
            }

            #endregion //控件需要的数据表

            #region 数据转换

            for (int i = 0; i < mscTable.Rows.Count; i++)
            {
                DateTime rowTime = (DateTime)mscTable.Rows[i][0];
                int row = 6 - (now - rowTime).Days;
                int colum = (int)mscTable.Rows[i][1];
                if (row >= 0)
                {
                    dt.Rows[row][colum] = TimeSpan.FromTicks(Convert.ToInt64(mscTable.Rows[i][3])).TotalMinutes;
                }
            }

            #endregion 数据转换

            this.machineStateChanges1.Refresh(dt);
        }

        #endregion MachineStateChange

        private void machineErrorStatistics1_Click_1(object sender, EventArgs e)
        {
            Frm_ICT_Main.Instance.BeginInvoke(new Action(() => Frm_ICT_Main.Instance.Btn_Click(Frm_ICT_Main.Instance.Btn_Alarm, e)));
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            this.Location = mGlobal.ChildFrmOffsetPoint;
            this.Size = new Size(Frm_ICT_Main.Instance.Main_ChildPage.Width, Frm_ICT_Main.Instance.Main_ChildPage.Height);
            SetTag(this, Convert.ToInt32(this.Tag), true);
            SetControls(mGlobal.NewX, mGlobal.NewY, this, Convert.ToInt32(this.Tag), true);
            IniSTN();
            Help.YelidHelper.ReadYelid();
            //StatusRefreshTimer_Tick(null, null);
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    double 产量 = mGlobal.OK数组.Sum() + mGlobal.NG数组.Sum();
                    this.iO_Summary_NoSQL1.Yield = 产量.ToString();
                    this.iO_Summary_NoSQL1.Pass_Fail = mGlobal.OK数组.Sum().ToString() + "/" + mGlobal.NG数组.Sum().ToString();
                    this.iO_Summary_NoSQL1.CT = mGlobal.CT < 0 ? "0.00" : mGlobal.CT.ToString("f2");
                    this.iO_Summary_NoSQL1.报警率 = 产量 == 0 ? "0.00" : (mGlobal.报警数组.Sum() / 产量).ToString("f2");
                }));
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }
    }
}