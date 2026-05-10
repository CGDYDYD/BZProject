using System.Collections.Generic;

namespace BoTech
{
    public class TaskAlarmFailTipInfo
    {
        private static TaskAlarmFailTipInfo mInstance;

        public static TaskAlarmFailTipInfo Instance => mInstance ?? (mInstance = new TaskAlarmFailTipInfo());

        public AlarmInfomation Find(eErrCode errorcode)
        {
            return GetAlarmDic.ContainsKey(errorcode) ? GetAlarmDic[errorcode] : null;
        }

        public Dictionary<eErrCode, AlarmInfomation> GetAlarmDic { get; } = new Dictionary<eErrCode, AlarmInfomation>();
    }
}