using LogsHelper;

namespace BoTech
{
    public class GlobalVoid
    {
        public static void MachineWriteLog(string WriteLog)
        {
            try
            {
                mGlobal._Logs.AddLog(GlobalUserInfoGet.GetLoginString, WriteLog, LogsType.MachineLog);
            }
            catch
            {
            }
        }
    }
}