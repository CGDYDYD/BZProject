using System.Collections.Generic;

namespace BoTech
{
    public sealed class HaveSerciceBLL
    {
        public List<AlarmInfo> ErrorInfoList { get; set; }

        private static HaveSerciceBLL haveSerciceBLL;

        public static HaveSerciceBLL GetInstance()
        {
            return haveSerciceBLL ?? (haveSerciceBLL = new HaveSerciceBLL());
        }
    }
}