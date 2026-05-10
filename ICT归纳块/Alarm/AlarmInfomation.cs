using System.Threading;

namespace BoTech
{
    public class AlarmInfomation
    {
        public eErrCode ErrorCode { get; set; }

        public string ErrMsg { get; set; }

        /// <summary>
        /// 每个Task报警阻塞事件,等待报警框给Set信号后在继续运行
        /// </summary>
        public AutoResetEvent Are;

        /// <summary>
        /// 重新运动 step
        /// </summary>
        public int RetryStep { get; set; }

        public int TaskID { get; set; }
        public AlarmMessage AlarmMsg;
    }
}