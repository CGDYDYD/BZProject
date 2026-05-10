using BoTech;
using BoTech.User_Control;
using LogsHelper;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using UserHelper;
using XStation;
using static ParName.名称枚举;

namespace 运动模块
{
    public class mWorkShare : WorkShare
    {
        public AutoResetEvent FailTipAre = new AutoResetEvent(false);
        public bool IsStationWork { get; set; }

        #region 报警提示框

        private bool rst;

        private static readonly object obj = new object();

        public T myTipNew<T>(T 重试步序, T 跳过步序, eErrCode errorcode = eErrCode.Null) where T : Enum
        {
            lock (obj)
            {
                FailTipAre = new AutoResetEvent(false);
                AlarmInfomation _alarm = new AlarmInfomation
                {
                    AlarmMsg = new AlarmMessage(),
                    Are = this.FailTipAre,
                    ErrorCode = errorcode,
                    ErrMsg = errorcode.ToString(),
                    RetryStep = 0,
                    TaskID = TaskID
                };
                _alarm.AlarmMsg.IsRemove = true;
                if (TaskAlarmFailTipInfo.Instance.Find(errorcode) == null)
                {
                    mGlobal.IsOnAlarm = true;
                    try
                    {
                        Frm_ICT_Main.Instance.Btn_Alarm.ButtonStateChange(NewButtonState.Alarm);
                        rst = FailTipShow.Instance.myFailTip(this, "[" + this.TaskName + "]" + errorcode.ToString(), _alarm, errorcode, LogsType._ErrorCode, !mGlobal.FuncCheck(FuncChk.勾上屏蔽蜂鸣器));
                    }
                    catch (Exception ex)
                    {
                        DebugHelper.WriteLine(ex);
                    }
                }
                return rst ? 重试步序 : 跳过步序;
            }
        }

        public void myTipNew(eErrCode errorcode = eErrCode.Null, bool 锁定界面 = false)
        {
            lock (obj)
            {
                FailTipAre = new AutoResetEvent(false);
                AlarmInfomation _alarm = new AlarmInfomation
                {
                    AlarmMsg = new AlarmMessage(),
                    Are = this.FailTipAre,
                    ErrorCode = errorcode,
                    ErrMsg = errorcode.ToString(),
                    RetryStep = 0,
                    TaskID = TaskID
                };
                _alarm.AlarmMsg.IsRemove = true;
                if (TaskAlarmFailTipInfo.Instance.Find(errorcode) == null)
                {
                    mGlobal.IsOnAlarm = true;
                    try
                    {
                        WkManager.Pause();
                        Frm_ICT_Main.Instance.Invoke(new Action(() =>
                        {
                            Frm_ICT_Main.Instance.Btn_Alarm.ButtonStateChange(NewButtonState.Alarm);
                            Frm_ICT_Main.Instance.Btn_Run.ButtonStateChange(NewButtonState.Disabled);
                            Frm_ICT_Main.Instance.Btn_Pause.ButtonStateChange(NewButtonState.Disabled);
                            Frm_ICT_Main.Instance.Btn_Stop.ButtonStateChange(NewButtonState.Disabled);
                            if (锁定界面)
                            {
                                FailTipShow.Instance.myFailTip(_alarm, errorcode, !mGlobal.FuncCheck(FuncChk.勾上屏蔽蜂鸣器));
                            }
                            else
                            {
                                FailTipShow.Instance.myFailTip(errorcode.ToString(), _alarm, errorcode, !mGlobal.FuncCheck(FuncChk.勾上屏蔽蜂鸣器));
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        DebugHelper.WriteLine(ex);
                    }
                }
            }
        }

        #endregion 报警提示框

        #region Log&显示功能

        //log定义(增加默认值外部定义)
        public cLogs _Logs;

        private string logStrhold;

        public DialogResult AddLog(string MsgStr, LogsType model = LogsType._Logs, int 步序号 = 0, bool dn界面提示 = false, bool dn是否弹框 = false, bool dn是否等待 = false, MessageBoxButtons msgboxBtn = MessageBoxButtons.RetryCancel)
        {
            if (MsgStr == logStrhold)
            {
                return DialogResult.OK;
            }
            logStrhold = MsgStr;
            StaInfo.提示信息 = MsgStr;//在“启动停止暂停复位”处显示Log信息
            StaInfo.提示信息En = MsgStr;

            return _Logs.AddLog(GlobalUserInfoGet.GetLoginString, MsgStr, model, 步序号, dn界面提示, dn是否弹框, dn是否等待, msgboxBtn);
        }

        #endregion Log&显示功能

        #region "基础功能"

        public override void Initialize()
        {
            Mre.Reset();
            mTaskManager.Instance.BindTask((short)TaskID, this);
        }

        public override void Homing()
        {
            XAlarmServer.Instance.OnStationRestToClearAlarm?.Invoke((short)TaskID);
            StaHomeOK = false;
            IsStationWork = false;
        }

        public override void Err(string CtrName, string ErrInfo)
        {
        }

        public override void AutoRun()
        {
        }

        public override bool Ready()
        {
            return true;
        }

        public virtual short mReady()
        { return 0; }

        #endregion "基础功能"

        #region 自定义功能

        #endregion 自定义功能

        #region 程序需要定义文件

        #region 变量相关

        public Action<int> manualFinishTimes;
        public short ManualTimes;//手动次数，传递进来

        /// <summary>
        /// 自动运行函数委托
        /// </summary>
        public delegate void AutoFunctionDelegate();

        public AutoFunctionDelegate AutoFunction;

        /// <summary>
        /// 自动运行和手动运行做区分 True为手动,False为自动
        /// </summary>
        public bool ManaulRun;

        #endregion 变量相关

        #region 方法相关

        public void OnManualTimes(short Times)
        {
            ManualTimes = Times;
        }

        public virtual void OnTaskManual()
        { }

        #endregion 方法相关

        #endregion 程序需要定义文件

        #region 干涉区操作

        /// <summary>
        /// 进入干涉区
        /// </summary>
        /// <param name="id">干涉区 枚举</param>
        public void EnterInterferenceZone(InterferenceZone_干涉区 id, int ThreadId = 0)
        {
            string taskname = Enum.GetName(typeof(Task_ID), TaskID);
            string zoneName = Enum.GetName(typeof(InterferenceZone_干涉区), id);
            AddLog($"Task:{taskname}可否进入干涉区?{zoneName}", LogsType._Auto, StaInfo.步序号, true);
            InterferenceZoneFactory<InterferenceZone_干涉区>.Instance.FindZone(id).EnterInterferenceZone(ThreadId == 0 ? TaskID : ThreadId);
            AddLog($"Task:{taskname}进入干涉区{zoneName}", LogsType._Auto, StaInfo.步序号, true);
        }

        /// <summary>
        /// 离开干涉区
        /// </summary>
        /// <param name="id">干涉区 枚举</param>
        /// <param name="threadId">默认线程Id,一般不用传此参数</param>
        public void ExitInterferenceZone(InterferenceZone_干涉区 id, int threadId = 0)
        {
            InterferenceZoneFactory<InterferenceZone_干涉区>.Instance.FindZone(id).ExitInterferenceZone(threadId == 0 ? TaskID : threadId);
            string taskname = Enum.GetName(typeof(Task_ID), TaskID);
            string zoneName = Enum.GetName(typeof(InterferenceZone_干涉区), id);
            AddLog(string.Format("任务:{0}离开干涉区{1}", taskname, zoneName), LogsType._Auto, StaInfo.步序号, true);
        }

        #endregion 干涉区操作

        #region 日志记录

        public void AutoLog<TEnum>([CallerMemberName] string name = "") where TEnum : Enum
        {
            AddLog(name + ',' + Enum.ToObject(typeof(TEnum), StaInfo.步序号).ToString(), LogsType._Auto, StaInfo.步序号, true);
        }

        public void AutoLog<TEnum>(string msg, LogsType model = LogsType._Auto) where TEnum : Enum
        {
            AddLog(msg, model, StaInfo.步序号, true);
        }

        #endregion

        private int _workStep_Int;

        /// <summary>
        /// 运行步序
        /// </summary>
        public int WorkStep_Int
        {
            get => _workStep_Int;
            set
            {
                if (value != _workStep_Int)
                {
                    StaInfo.步序号 = _workStep_Int;
                    SetStep(ref StaInfo, _workStep_Int, true);
                    _workStep_Int = value;
                }
            }
        }
    }
}