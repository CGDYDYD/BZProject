using CoreFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static CoreFunction.mFunction;
using static FilePath.mFilePath;
using static LogsHelper.LogWrite;

namespace LogsHelper
{
    public enum LogsType
    {
        _Logs = 0,
        _Calibration,
        _ErrorCode,
        _Auto,
        MachineLog,
        _other,
        OKTray,
        NGTray,
    }

    public class cLogs
    {
        /// <summary>
        /// 构造函数 StationName:站别名称，不需要显示 StaInfo：为了把此站的Log信息，在"启动停止复位暂停"这个控件上
        /// </summary>
        public cLogs(string StationName, int taskId)
        {
            _taskId = taskId;

            Sta_Name = StationName;

            if (FormLogShow?.IsDisposed != false)
            {
                FormLogShow = new Frm_show(Sta_Name);
            }

            Read_dn_English();
        }

        private Frm_show FormLogShow;
        private int _taskId;

        public static event Action<string, LogsType, int> OnStep;

        /// <summary>
        /// log函数
        /// </summary>
        public DialogResult AddLog(string userinfo, string MsgStr, LogsType model = LogsType._Logs, int 步序号 = 0, bool dn界面提示 = false, bool dn是否弹框 = false, bool dn是否等待 = false, MessageBoxButtons msgboxBtn = MessageBoxButtons.RetryCancel)
        {
            if (EnglishMode)
            {
                MsgStr = Ch_English(MsgStr);
            }
            Write_Log(userinfo, MsgStr, Sta_Name, 步序号, model);
            if (dn界面提示)
            {
                OnStep?.Invoke(MsgStr, model, _taskId);//在list控件上显示中英文信息，根据中英文切换
            }

            if (dn是否弹框)
            {
                if (dn是否等待)
                {
                    Frm_show sdf = new Frm_show(MsgStr, msgboxBtn, Sta_Name);
                    return sdf.ShowDialog();
                }
                FormLogShow.AddMsg(MsgStr);

                return 0;
            }

            return 0;
        }

        #region Hint

        public string Sta_Name { get; set; }

        /// <summary>
        /// 保存Log
        /// </summary>
        private void Write_Log(string userinfo, string Str, string Sta_Name, int dn步序号, LogsType model = LogsType._Logs)
        {
            try
            {
                string dmContent, dn英文 = "";
                string dmPath;
                switch (model)
                {
                    case LogsType.OKTray:
                        dmPath = $"{MachineLog}OK放料记录\\{DateTime.Now:yyyyMMdd}\\hour_{DateTime.Now:HH}.txt";
                        break;

                    case LogsType.NGTray:
                        dmPath = $"{MachineLog}NG放料记录\\{DateTime.Now:yyyyMMdd}\\hour_{DateTime.Now:HH}.txt";
                        break;

                    default:
                        dmPath = $"{MachineLog}{DateTime.Now:yyyyMMdd}\\hour_{DateTime.Now:HH}.txt";
                        break;
                }
                CreatePath(dmPath);
                if (EnglishMode || LanguageState == 语言设定.ENG)
                {
                    dn英文 = Ch_English(Str);
                    dmContent = $"{userinfo},{Sta_Name},Step:{dn步序号},{dn英文}";
                    LogMsg(dmPath, dmContent);
                }
                else
                {
                    dmContent = $"{userinfo},{Sta_Name},Step:{dn步序号},{Str}";
                    LogMsg(dmPath, dmContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private static Dictionary<string, string> dn_English = new Dictionary<string, string>();

        private static bool b读Excel;

        private static DataTable dt;

        private static BaseFunc baseFunc = new BaseFunc();

        private static string Path;

        /// <summary>
        /// 读EXCEL，只读一次，这个类要被实例化很多次 不想外面单独去读这个函数:静态的函数可以
        /// </summary>
        private static void Read_dn_English()
        {
            if (b读Excel)//静态的可以这样做，保证只读一次：  这个类会被实例化很多次
            {
                return;
            }

            Path = $"{Application.StartupPath}\\Data\\English_Log_Name.xlsx";

            try
            {
                if (!File.Exists(Path))
                {
                    MessageBox.Show($"{Path} file is not Exists!!");
                    return;
                }

                dt = baseFunc.ReadExcelToDataTable(Path);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //保证重复的东西不添加，即使实例化的时候每个都会读这里
                    if (!dn_English.ContainsKey(dt.Rows[i].ItemArray[0].ToString()))
                    {
                        dn_English.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString());
                    }
                }

                b读Excel = true;
            }
            catch (Exception ex)
            {
                dn_English.Add("异常", ex.ToString());
            }
        }

        public string Ch_English(string str)
        {
            try
            {
                if (dn_English.ContainsKey(str))
                {
                    return dn_English.Count <= 3 ? dn_English["异常"] : dn_English[str];
                }
                return $"{str}";//找不到就显示本身的 中文
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return $"{str}";//找不到就显示本身的 中文
            }
        }

        #endregion Hint
    }
}