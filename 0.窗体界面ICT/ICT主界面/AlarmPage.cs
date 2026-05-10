using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CoreFunction.mFunction;

namespace BoTech
{
    public partial class AlarmPage : MyControl
    {
        private static AlarmPage instance;

        public static AlarmPage Instance
        {
            get
            {
                if (instance?.IsDisposed != false)
                {
                    instance = new AlarmPage();
                }

                return instance;
            }
        }

        public AlarmPage()
        {
            InitializeComponent();
            this.Visible = true;
        }

        private DataTable DT_StatisticsTable;
        private DataTable AlarmDurationTable;
        private DataTable AlarmLogTable;

        public override void StartRefreshPage()
        {
            this.dTP_EndTime.Value = DateTime.Now;
            this.dTP_StartTime.Value = DateTime.Now.AddHours(-48);
        }

        public override void StopRefreshPage()
        {
        }

        private DataTable AlarmCountAdd(DataTable dt)
        {
            DataTable dtTemp = new DataTable();
            DataColumn dc_0 = new DataColumn("Error", typeof(string));
            DataColumn dc_1 = new DataColumn("TotalTime(Min)", typeof(double));
            DataColumn dc_2 = new DataColumn("CountTotal", typeof(int));
            dtTemp.Columns.Add(dc_0);
            dtTemp.Columns.Add(dc_1);
            dtTemp.Columns.Add(dc_2);
            return dt;
        }

        private void AlarmPage_VisibleChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dTP_EndTime.Value = now;
            dTP_StartTime.Value = now.AddHours(-48);
        }

        #region DownTime Statistics

        private void RefreshDowntimeStatistics(DateTime start, DateTime end)
        {
            DataTable dt = DataServerManager.Instance.SelectDT_Statistic(start, end);
            dt = AlarmCountAdd(dt);
            DT_StatisticsTable = dt;
            DT_StatisticsTable.TableName = "DownTime Statistics";
            this.dT_Statiistic1.Refresh(dt);
        }

        #endregion DownTime Statistics

        #region AlarmDuration

        private void RefreshAlarmDuration(DateTime start, DateTime end)
        {
            DataTable dt = DataServerManager.Instance.SelectAlarmDurationCategory(start, end);

            this.alarm_Duration1.Refresh(dt);
        }

        #endregion AlarmDuration

        #region AlarmLog

        private DataTable dt2;

        private void RefreshAlarmLog(DateTime start, DateTime end)
        {
            if (dt2 == null)
            {
                dt2 = new DataTable();
            }
            if (dt2.Columns.Count <= 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    dt2.Columns.Add();
                }
                dt2.Columns[0].ColumnName = GlobalVar.LanguageDataTable.Select("CN='Date' or EN='Date' or VN='Date'")[0][int.Parse(GlobalVar.language)].ToString();
                dt2.Columns[1].ColumnName = GlobalVar.LanguageDataTable.Select("CN='Start Time' or EN='Start Time' or VN='Start Time'")[0][int.Parse(GlobalVar.language)].ToString();
                dt2.Columns[2].ColumnName = GlobalVar.LanguageDataTable.Select("CN='End Time' or EN='End Time' or VN='End Time'")[0][int.Parse(GlobalVar.language)].ToString();
                dt2.Columns[3].ColumnName = GlobalVar.LanguageDataTable.Select("CN='Time in State (Min)' or EN='Time in State (Min)' or VN='Time in State (Min)'")[0][int.Parse(GlobalVar.language)].ToString();
                dt2.Columns[4].ColumnName = GlobalVar.LanguageDataTable.Select("CN='Error Code' or EN='Error Code' or VN='Error Code'")[0][int.Parse(GlobalVar.language)].ToString();
                dt2.Columns[5].ColumnName = GlobalVar.LanguageDataTable.Select("CN='Error Message' or EN='Error Message' or VN='Error Message'")[0][int.Parse(GlobalVar.language)].ToString();
                dt2.Columns[6].ColumnName = GlobalVar.LanguageDataTable.Select("CN='Error Detail' or EN='Error Detail' or VN='Error Detail'")[0][int.Parse(GlobalVar.language)].ToString();
            }
            DataTable dt = DataServerManager.Instance.SelectAlarmAll(start, end);
            dt2.BeginLoadData();
            List<string[]> dataToLoad = new List<string[]>(dt.Rows.Count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] item = new string[7];
                item[0] = Convert.ToDateTime(dt.Rows[i][0]).ToString("yyyy-MM-dd");
                item[1] = Convert.ToDateTime(dt.Rows[i][1]).ToString("HH:mm:ss");
                item[2] = Convert.ToDateTime(dt.Rows[i][2]).ToString("HH:mm:ss");
                item[3] = (Convert.ToDateTime(dt.Rows[i][2]) - Convert.ToDateTime(dt.Rows[i][1])).TotalMinutes.ToString("f3");
                item[4] = dt.Rows[i][4].ToString();
                item[5] = EnglishMode ? (GlobalVar.appHiveControl.ErrorInfoList?.FirstOrDefault(s => s.ErrorCode == dt.Rows[i][4].ToString())?.MessageE) : dt.Rows[i][5].ToString();
                item[6] = dt.Rows[i][6].ToString();
                dataToLoad.Add(item);
            }
            try
            {
                foreach (string[] rowData in dataToLoad)
                {
                    dt2.LoadDataRow(rowData, true);
                }
            }
            finally
            {
                dt2.EndLoadData();
            }
            this.alarmLogShow1.Refresh(dt2.Copy());
            dt2.Rows.Clear();
        }

        #endregion

        public void btn_Query_Click(object sender, EventArgs e)
        {
            DateTime before = dTP_StartTime.Value;
            DateTime now = dTP_EndTime.Value;
            if (now > before)
            {
                //RefreshDowntimeStatistics(before, now);
                //RefreshAlarmDuration(before, now);
                //RefreshAlarmLog(before, now);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (DT_StatisticsTable != null)
            {
                ds.Tables.Add(DT_StatisticsTable.Copy());
            }

            if (AlarmDurationTable != null)
            {
                ds.Tables.Add(AlarmDurationTable.Copy());
            }

            if (AlarmLogTable != null)
            {
                ds.Tables.Add(AlarmLogTable.Copy());
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "请选择保存路径"
            };

            string filePath;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                filePath = fbd.SelectedPath;
            }
            else
            {
                return;
            }
            filePath += $"\\Alarm{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            EPPlusHelper.DataSetToExcel(ds, filePath);
        }

        private void AlarmPage_Load(object sender, EventArgs e)
        {
            this.Location = mGlobal.ChildFrmOffsetPoint;
            this.Size = new Size(Frm_ICT_Main.Instance.Main_ChildPage.Width, Frm_ICT_Main.Instance.Main_ChildPage.Height);
            SetTag(this, Convert.ToInt32(this.Tag), true);
            SetControls(mGlobal.NewX, mGlobal.NewY, this, Convert.ToInt32(this.Tag), true);
            this.dTP_EndTime.Value = DateTime.Now;
            this.dTP_StartTime.Value = DateTime.Now.AddHours(-48);
            btn_Query_Click(null, null);
        }
    }
}