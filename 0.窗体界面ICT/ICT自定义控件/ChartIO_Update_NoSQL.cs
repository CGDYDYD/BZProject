using FilePath;
using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using UserHelper;

namespace BoTech
{
    public partial class ChartIO_Update_NoSQL : UserControl
    {
        public ChartIO_Update_NoSQL() => InitializeComponent();

        #region 属性

        public bool IsSelectIO { get; set; } = true;

        public bool IsSelectDay { get; set; } = true;

        #endregion 属性

        private void InternalRefreshChart(double[] OK数组, double[] NG数组, double[] CT列表, double[] 报警数组)
        {
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < 24; i++)
            {
                chart2.Series[0].Points.AddXY(i, OK数组[i]);
                chart2.Series[1].Points.AddXY(i, NG数组[i]);
                chart2.Series[2].Points.AddXY(i, 报警数组[i]);
                chart1.Series[0].Points.AddXY(i, CT列表[i]);
            }
        }

        #region 时间选择功能；

        public bool IsSelectTime
        {
            get; set;
        }

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            IsSelectTime = false;
        }

        #endregion 时间选择功能；

        private void 查询_Click(object sender, EventArgs e)
        {
            mGlobal.读取指定日期产量(日期.Value, out double[] OK数组_查询用, out double[] NG数组_查询用);
            mGlobal.读取指定日期CT(日期.Value, out double[] CT列表_查询用);
            mGlobal.读取指定日期报警数(日期.Value, out double[] 每小时报警数_查询用);

            InternalRefreshChart(OK数组_查询用, NG数组_查询用, CT列表_查询用, 每小时报警数_查询用);
        }

        private DateTime _lastResetDate;

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime today = DateTime.Today;

                if (today > _lastResetDate)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        double.TryParse(INI.GetIni("OK_UPH", $"OK_{i}", mGlobal.BZ_UPHPath), out mGlobal.OK数组[i]);
                        double.TryParse(INI.GetIni("NG_UPH", $"NG_{i}", mGlobal.BZ_UPHPath), out mGlobal.NG数组[i]);
                        double.TryParse(INI.GetIni("报警数", $"报警数_{i}", mGlobal.BZ_AlarmPath), out mGlobal.报警数组[i]);
                        double.TryParse(INI.GetIni("报警分钟数", "报警分钟数", mGlobal.BZ_AlarmPath), out mGlobal.报警分钟数);
                    }
                    _lastResetDate = today;
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }
    }

    public partial class mGlobal
    {
        #region UPH

        public static string BZ_UPHPath => $"{mFilePath.BZ_LogPath}UPH\\{DateTime.Now:yyyyMMdd}\\UPH.ini";
        public static double[] OK数组 = new double[24];
        public static double[] NG数组 = new double[24];

        public static void 开机读取每小时产量()
        {
            for (int i = 0; i < 24; i++)
            {
                double.TryParse(INI.GetIni("OK_UPH", $"OK_{i}", BZ_UPHPath), out OK数组[i]);
                double.TryParse(INI.GetIni("NG_UPH", $"NG_{i}", BZ_UPHPath), out NG数组[i]);
            }
        }

        public static void 更新每小时产量(string state, int num = 1)
        {
            try
            {
                int hour = DateTime.Now.Hour;
                switch (state)
                {
                    case "OK":
                        OK数组[hour] += num;
                        INI.SetIni("OK_UPH", $"OK_{hour}", OK数组[hour].ToString(), BZ_UPHPath);
                        break;

                    case "NG":
                        NG数组[hour] += num;
                        INI.SetIni("NG_UPH", $"NG_{hour}", NG数组[hour].ToString(), BZ_UPHPath);
                        break;
                }
                YelidHelper.SaveYelidCsv();
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        public static void 读取指定日期产量(DateTime dateTime, out double[] OK数组_查询用, out double[] NG数组_查询用)
        {
            OK数组_查询用 = new double[24];
            NG数组_查询用 = new double[24];
            string path = $"{mFilePath.BZ_LogPath}UPH\\{dateTime:yyyyMMdd}\\UPH.ini";
            for (int i = 0; i < 24; i++)
            {
                double.TryParse(INI.GetIni("OK_UPH", $"OK_{i}", path), out OK数组_查询用[i]);
                double.TryParse(INI.GetIni("NG_UPH", $"NG_{i}", path), out NG数组_查询用[i]);
            }
        }

        #endregion

        #region CT

        public static string BZ_CTPath => $"{mFilePath.BZ_LogPath}UPH\\{DateTime.Now:yyyyMMdd}\\CT.ini";
        public static List<double>[] CT数组 = ArrayHelper.CreatRepeatArray(new List<double>(), 24);
        public static double[] 每小时CT = new double[24];

        public static void 开机读取每小时CT()
        {
            for (int i = 0; i < 24; i++)
            {
                double.TryParse(INI.GetIni("CT", $"CT_{i}", BZ_CTPath), out 每小时CT[i]);
            }
        }

        public static void 更新每小时CT(double ct)
        {
            try
            {
                int hour = DateTime.Now.Hour;
                CT数组[hour].Add(ct);
                每小时CT[hour] = Math.Round(CT数组[hour].Average(), 2);
                INI.SetIni("CT", $"CT_{hour}", 每小时CT[hour].ToString(), BZ_CTPath);
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        public static void 读取指定日期CT(DateTime dateTime, out double[] 每小时CT_查询用)
        {
            每小时CT_查询用 = new double[24];
            string path = $"{mFilePath.BZ_LogPath}UPH\\{dateTime:yyyyMMdd}\\CT.ini";
            for (int i = 0; i < 24; i++)
            {
                double.TryParse(INI.GetIni("CT", $"CT_{i}", path), out 每小时CT_查询用[i]);
            }
        }

        #endregion

        #region 报警

        public static string BZ_AlarmPath => $"{mFilePath.BZ_LogPath}UPH\\{DateTime.Now:yyyyMMdd}\\Alarm.ini";
        public static double 报警分钟数;

        public static double[] 报警数组 = new double[24];
        public static System.Timers.Timer AlarmTimer = new System.Timers.Timer() { AutoReset = true, Interval = 60 * 1000, Enabled = true };

        public static void 开机启动Alarm定时器()
        {
            AlarmTimer.Elapsed += AlarmTimer_Elapsed;
            AlarmTimer.Start();
        }

        private static void AlarmTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (IsOnAlarm)
            {
                报警分钟数++;
            }
        }

        public static void 开机读取每小时报警数()
        {
            for (int i = 0; i < 24; i++)
            {
                double.TryParse(INI.GetIni("报警数", $"报警数_{i}", BZ_AlarmPath), out 报警数组[i]);
                double.TryParse(INI.GetIni("报警分钟数", "报警分钟数", BZ_AlarmPath), out 报警分钟数);
            }
        }

        public static void 更新每小时报警数(int num = 1)
        {
            try
            {
                int hour = DateTime.Now.Hour;
                报警数组[hour] += num;
                INI.SetIni("报警数", $"报警数_{hour}", 报警数组[hour].ToString(), BZ_AlarmPath);
                INI.SetIni("报警分钟数", "报警分钟数", 报警分钟数.ToString(), BZ_AlarmPath);
                YelidHelper.SaveYelidCsv();
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        public static void 读取指定日期报警数(DateTime dateTime, out double[] 每小时报警数_查询用)
        {
            每小时报警数_查询用 = new double[24];
            string path = $"{mFilePath.BZ_LogPath}UPH\\{dateTime:yyyyMMdd}\\Alarm.ini";
            for (int i = 0; i < 24; i++)
            {
                double.TryParse(INI.GetIni("报警数", $"报警数_{i}", path), out 每小时报警数_查询用[i]);
            }
        }

        #endregion
    }
}