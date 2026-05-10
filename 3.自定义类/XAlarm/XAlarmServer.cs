using System;

namespace BoTech
{
    public class XAlarmServer
    {
        public static XAlarmServer Instance { get; } = new XAlarmServer();

        public Action<short> OnStationRestToClearAlarm;
    }
}