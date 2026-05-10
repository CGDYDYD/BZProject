using FilePath;
using Help;
using LogsHelper;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 运动模块;
using static CoreFunction.mFunction;
using static MotionFunction.MotionDll;
using static ParName.名称枚举;

namespace BoTech
{
    public class FailTipShow
    {
        private static FailTipShow instance;

        public static FailTipShow Instance
        {
            get => instance ?? (instance = new FailTipShow());
            set => instance = value;
        }

        public ManualResetEvent mre = new ManualResetEvent(false);

        public FailTipShow()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    mre.WaitOne();
                    if (!mGlobal.isManaul)
                    {
                        if (SysState == State.ALARM || SysState == State.ESTOP || SysState == State.PAUSE || 蜂鸣器报警)
                        {
                            WriteDo(OutNo.蜂鸣器.EnumToShort(), (short)(ParHelper.勾上屏蔽蜂鸣器 ? 0 : 1));
                            Thread.Sleep(3000);
                            WriteDo(OutNo.蜂鸣器.EnumToShort(), 0);
                            Thread.Sleep(1000);
                        }
                    }
                }
            });
        }

        private readonly object obj = new object();

        public bool 蜂鸣器报警;
        public FailTip tipnew;
        private bool rtn;
        private string selectString = "";

        public bool myFailTip(mWorkShare wk, string AlarmMessage, AlarmInfomation _alarm, eErrCode errorCode = eErrCode.Null, LogsType LogT = LogsType._Auto, bool beef = false)
        {
            lock (obj)
            {
                AlarmInfo _hiveerrorinfo = GlobalVar.appHiveControl.ErrorInfoList?.FirstOrDefault(s => s.Index == _alarm.ErrorCode.EnumToInt());
                string Messagetext = _hiveerrorinfo.MessageE + "/" + _hiveerrorinfo.MessageVN;
                wk.AddLog(AlarmMessage, LogT, wk.StaInfo.步序号);//保存LOG
                DateTime startTime = DateTime.Now;
                if (beef)
                {
                    mre.Set();
                }
                蜂鸣器报警 = true;
                SysState = State.PAUSE;
                lock (obj)
                {
                    if (tipnew == null)
                    {
                        tipnew = new FailTip(Messagetext, false);
                    }
                    else if (tipnew.IsDisposed)
                    {
                        tipnew = new FailTip(Messagetext, false);
                    }
                }
                if (tipnew.Visible)
                {
                    tipnew.TopMost = true;
                    return true;
                }
                tipnew.SetStationText(wk.TaskName + $"[步序号:{wk.StaInfo.步序号}]");
                tipnew.SetSubmitErrorInfo(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), _hiveerrorinfo?.ErrorCode, AlarmMessage);
                tipnew.ErrorCFO = (int)errorCode;//保存报警code
                tipnew.ErrorInfo = AlarmMessage;
                tipnew.TopMost = true;
                tipnew.ShowDialog();
                tipnew.WaitOne();
                //步序号赋值
                if (tipnew.DialogResult == DialogResult.Yes)
                {
                    selectString = "重新执行";
                    SysState = mGlobal.isManaul ? State.MANUAL : State.RUNNING;
                    蜂鸣器报警 = false;
                    rtn = true;
                }
                else if (tipnew.DialogResult == DialogResult.No)
                {
                    selectString = "跳过";
                    SysState = mGlobal.isManaul ? State.MANUAL : State.RUNNING;
                    蜂鸣器报警 = false;
                    rtn = false;
                }
                mGlobal.IsOnAlarm = false;
                DateTime endTime = DateTime.Now;
                mGlobal.更新每小时报警数();
                string totalData = $"{startTime:yyyy-MM-dd HH:mm:ss:fff},{endTime:yyyy-MM-dd HH:mm:ss:fff},{wk.TaskName}[步序号:{wk.StaInfo.步序号}]{AlarmMessage.Replace(",", " ")},{selectString},{(endTime - startTime).TotalMilliseconds / 1000:0.000}";
                string path = $"{mFilePath.BZ_LogPath}{DateTime.Now:yyyyMMdd}\\{DateTime.Now:yyyyMMdd}_Fails.csv";
                string errorpath = $"{mFilePath.BZ_LogPath}{DateTime.Now:yyyyMMdd}\\设备异常日志.txt";
                if (!File.Exists(path))
                {
                    CsvServer_ICT.Instance.WriteLine(path, "StartTime,EndTime,AlarmMessage,SelectString,TotalTime");
                }
                CsvServer_ICT.Instance.WriteLine(path, totalData);//保存CSV
                CsvServer_ICT.Instance.WriteLine(errorpath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}[步序号:{wk.StaInfo.步序号}]{AlarmMessage}");//保存txt

                AlarmMessage AM = new AlarmMessage
                {
                    HappenTime = startTime,
                    EndTime = endTime,
                    Duration = (endTime - startTime).TotalMinutes,
                    Code = _hiveerrorinfo.ErrorCode,
                    ErrorMessageE = errorCode.ToString(),
                    ErrorMessageC = errorCode.ToString(),
                    DealtMethod = "[" + wk.TaskName + "]" + errorCode.ToString(),
                    ErrorCategory = errorCode.ToString(),
                };
                DataServerManager.Instance.InsertAlarmON(AM);
                mre.Reset();
                //AlarmPage.Instance.btn_Query_Click(null, null);
                tipnew = null;
                return rtn;
            }
        }

        public bool myFailTip(AlarmInfomation _alarm, eErrCode errorCode = eErrCode.Null, bool beef = false)
        {
            lock (obj)
            {
                AlarmInfo _hiveerrorinfo = GlobalVar.appHiveControl.ErrorInfoList?.FirstOrDefault(s => s.Index == _alarm.ErrorCode.EnumToInt());
                string Messagetext = _hiveerrorinfo.MessageE + "/" + _hiveerrorinfo.MessageVN;
                Task00_空站.Instance.AddLog(errorCode.ToString(), LogsType._Auto);//保存LOG
                DateTime startTime = DateTime.Now;
                if (beef)
                {
                    mre.Set();
                }
                蜂鸣器报警 = true;
                SysState = State.PAUSE;
                lock (obj)
                {
                    if (tipnew == null)
                    {
                        tipnew = new FailTip(Messagetext, false);
                    }
                    else if (tipnew.IsDisposed)
                    {
                        tipnew = new FailTip(Messagetext, false);
                    }
                }
                if (tipnew.Visible)
                {
                    tipnew.TopMost = true;
                    return true;
                }
                tipnew.SetSubmitErrorInfo(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), _hiveerrorinfo?.ErrorCode, errorCode.ToString());
                tipnew.ErrorCFO = (int)errorCode;//保存报警code
                tipnew.TopMost = true;
                tipnew.ShowDialog();
                tipnew.WaitOne();
                //步序号赋值
                if (tipnew.DialogResult == DialogResult.Yes)
                {
                    selectString = "重新执行";
                    SysState = mGlobal.isManaul ? State.MANUAL : State.RUNNING;
                    蜂鸣器报警 = false;
                    rtn = true;
                }
                else if (tipnew.DialogResult == DialogResult.No)
                {
                    selectString = "跳过";
                    SysState = mGlobal.isManaul ? State.MANUAL : State.RUNNING;
                    蜂鸣器报警 = false;
                    rtn = false;
                }
                mGlobal.IsOnAlarm = false;
                DateTime endTime = DateTime.Now;
                mGlobal.更新每小时报警数();
                string totalData = $"{startTime:yyyy-MM-dd HH:mm:ss:fff},{endTime:yyyy-MM-dd HH:mm:ss:fff},{errorCode},{selectString},{(endTime - startTime).TotalMilliseconds / 1000:0.000}";
                string path = $"{mFilePath.BZ_LogPath}{DateTime.Now:yyyyMMdd}\\{DateTime.Now:yyyyMMdd}_Fails.csv";
                string errorpath = $"{mFilePath.BZ_LogPath}{DateTime.Now:yyyyMMdd}\\设备异常日志.txt";
                if (!File.Exists(path))
                {
                    CsvServer_ICT.Instance.WriteLine(path, "StartTime,EndTime,AlarmMessage,SelectString,TotalTime");
                }
                CsvServer_ICT.Instance.WriteLine(path, totalData);//保存CSV
                CsvServer_ICT.Instance.WriteLine(errorpath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}{errorCode}");//保存txt
                AlarmMessage AM = new AlarmMessage
                {
                    HappenTime = startTime,
                    EndTime = endTime,
                    Duration = (endTime - startTime).TotalMinutes,
                    Code = _hiveerrorinfo.ErrorCode,
                    ErrorMessageE = errorCode.ToString(),
                    ErrorMessageC = errorCode.ToString(),
                    DealtMethod = errorCode.ToString(),
                    ErrorCategory = errorCode.ToString(),
                };
                DataServerManager.Instance.InsertAlarmON(AM);
                mre.Reset();
                //AlarmPage.Instance.btn_Query_Click(null, null);
                tipnew = null;
                return rtn;
            }
        }

        public FailTip不锁定界面 tipnew不锁定界面;
        public DateTime startTime;

        public void myFailTip(string AlarmMessage, AlarmInfomation _alarm, eErrCode errorCode = eErrCode.Null, bool beef = false)
        {
            lock (obj)
            {
                AlarmInfo _hiveerrorinfo = GlobalVar.appHiveControl.ErrorInfoList?.FirstOrDefault(s => s.Index == _alarm.ErrorCode.EnumToInt());
                string Messagetext = _hiveerrorinfo.MessageE + "/" + _hiveerrorinfo.MessageVN;
                mGlobal._Logs.AddLog(GlobalUserInfoGet.GetLoginString, AlarmMessage);
                startTime = DateTime.Now;
                if (beef)
                {
                    mre.Set();
                }
                蜂鸣器报警 = true;
                SysState = State.PAUSE;
                lock (obj)
                {
                    if (tipnew不锁定界面 == null)
                    {
                        tipnew不锁定界面 = new FailTip不锁定界面(Messagetext);
                    }
                    else if (tipnew不锁定界面.IsDisposed)
                    {
                        tipnew不锁定界面 = new FailTip不锁定界面(Messagetext);
                    }
                }
                if (tipnew不锁定界面.Visible)
                {
                    tipnew不锁定界面.TopMost = true;
                    return;
                }
                tipnew不锁定界面.SetSubmitErrorInfo(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), SErrCode.Default.GetCode((int)errorCode).ErrorCode, AlarmMessage);
                tipnew不锁定界面.ErrorCFO = (int)errorCode;//保存报警code
                tipnew不锁定界面.ErrorInfo = AlarmMessage;
                tipnew不锁定界面.TopMost = true;
                tipnew不锁定界面.Show();
            }
        }
    }
}