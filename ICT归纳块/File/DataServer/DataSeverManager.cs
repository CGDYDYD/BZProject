using DataBaseManager;
using System;
using System.Data;
using static FilePath.mFilePath;

namespace BoTech
{
    /// <summary>
    /// 此类用于相应项目软件调用 数据库资源， 具体项目与 《数据库》 断开直接连接 ，方便切换不同数据库 中间类，
    /// </summary>
    public class DataServerManager
    {
        #region 单例

        private static DataServerManager instance;

        public static DataServerManager Instance => instance ?? (instance = new DataServerManager());

        //public DataServerManager() => DBH = new SQLiteHelper($"{BZ_ParPath}machinedata.db");

        #endregion 单例

        #region 字符串

        private const string timestr = "yyyy-MM-dd HH:mm:ss";
        private const string datestr = "yyyy-MM-dd";

        #endregion 字符串

        #region 表名

        private const string alarmTableName = "alarmhistory";
        private const string machineStateTableName = "machinestate";

        #endregion 表名

        #region 列名

        private string[] AlarmDataBaseTableColName => new string[] { "HappenTime", "EndTime", "Days", "ErrorCode", "ErrorCategory", "Duration", "DurationCategory", "ErrorMessageE", "ErrorMessageC", "DealtMethod" };

        private string[] MachineStateDataBaseTableColName => new string[] { "HappenTime", "Days", "MachineState", "PreviousState", "TimeSpan" };

        #endregion 列名

        #region 初始化表

        private void IniAlarmDataBsaseTable()
        {
            string[] colTypes = new string[] { "DATETIME", "DATETIME", "date", "varchar(45)", "varchar(45)", "double ", "int", "varchar(45)", "varchar(45)", "varchar(45)" };
            DBH.CreateStandardTable(alarmTableName, AlarmDataBaseTableColName, colTypes);
        }

        private void IniMachineStateDataBsaseTable()
        {
            string[] colTypes = new string[] { "DATETIME", "date", "int", "int", "BIGINT " };
            DBH.CreateStandardTable(machineStateTableName, MachineStateDataBaseTableColName, colTypes);
        }

        #endregion 初始化表

        #region 插入

        public void InsertAlarmON(AlarmMessage AM)
        {
            string[] colValues = new string[]
            {
                AM.HappenTime.ToString(timestr),
                AM.EndTime.ToString(timestr),
                AM.EndTime.ToString(datestr),
                AM.Code ?? "NULL",
                AM.ErrorCategory,
                AM.Duration.ToString("f3"),
                AM.DurationCatigory.ToString(),
                AM.ErrorMessageE,
                AM.ErrorMessageC,
                AM.DealtMethod
            };

            DBH.InsertStandardValues(alarmTableName, AlarmDataBaseTableColName, colValues);
        }

        #endregion 插入

        #region 查询

        public DataTable SelectDT_Statistic(DateTime start, DateTime end, bool DP = true)
        {
            string Command = DP
                ? $"select ErrorCategory,sum(Duration),count(*) from {alarmTableName} where HappenTime between '{start.ToString(timestr)}' and '{end.ToString(timestr)}' group by ErrorCategory order by sum(Duration)  "
                : $"select ErrorCategory,sum(Duration),count(*) from {alarmTableName} where HappenTime between '{start.ToString(timestr)}' and '{end.ToString(timestr)}' group by ErrorCategory order by count(*) ";
            return DBH.SelectValues(alarmTableName, Command).Tables[0];
        }

        public DataTable SelectAlarmDurationCategory(DateTime start, DateTime end)
        {
            string Command = $"select DurationCategory,count(*) from {alarmTableName} where HappenTime between '{start.ToString(timestr)}' and '{end.ToString(timestr)}' group by Days,DurationCategory order by Days,DurationCategory  ";
            return DBH.SelectValues(alarmTableName, Command).Tables[0];
        }

        public DataTable SelectAlarmAll(DateTime start, DateTime end)
        {
            string Command = $"select Days,HappenTime,EndTime,Duration, ErrorCode,ErrorMessageE,DealtMethod from {alarmTableName} where HappenTime between '{start.ToString(timestr)}'and '{end.ToString(timestr)}' order by  HappenTime ";
            return DBH.SelectValues(alarmTableName, Command).Tables[0];
        }

        public DataTable SelectMachineState(DateTime start, DateTime end)
        {
            string Command = $"select Days,PreviousState,count(*),sum(TimeSpan) from {machineStateTableName} where HappenTime between '{start.ToString(timestr)}' and '{end.ToString(timestr)}' group by Days,PreviousState order by Days";
            return DBH.SelectValues(machineStateTableName, Command).Tables[0];
        }

        #endregion 查询

        #region 删除

        public void DeleteAlarmStaleData(double StaleDays = 7.0)
        {
            DBH.DeleteValues(alarmTableName, "HappenTime", "<=", DateTime.Now.AddDays(-StaleDays).ToString(timestr));
        }

        public void DeleteMachineStateStaleData(double StaleDays = 7.0)
        {
            DBH.DeleteValues(machineStateTableName, "HappenTime", "<=", DateTime.Now.AddDays(-StaleDays).ToString(timestr));
        }

        #endregion 删除

        #region 内部变量

        private DataBaseHelper DBH;

        #endregion 内部变量

        public void Load()
        {
            //IniAlarmDataBsaseTable();

            //IniMachineStateDataBsaseTable();
        }
    }
}