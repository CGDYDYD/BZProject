using System;

namespace BoTech
{
    public class AlarmMessage
    {
        public DateTime HappenTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ErrorCategory { get; set; }
        public double Duration { get; set; }
        public int DurationCatigory { get; set; }
        public string ErrorMessageE { get; set; }
        public string ErrorMessageC { get; set; }
        public string DealtMethod { get; set; }

        //是否移除
        public bool IsRemove { get; set; }

        public string Code { get; set; }
    }
}