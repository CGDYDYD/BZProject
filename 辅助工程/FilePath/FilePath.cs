using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FilePath
{
    public static class mFilePath
    {
        /// <summary>
        /// MachineName--改机种名称或左右机
        /// </summary>
        public const string MachineName = "PCBA_Unloading";

        public static string BZ_ParPath = $"D:\\BZ-Parameter\\{MachineName}\\";
        public static string BZ_DataPath = $"D:\\BZ-Data\\{MachineName}\\";

        /// <summary>
        /// 一下一般建议不修改
        /// </summary>
        public static string BZ_ExePath = $"{Application.StartupPath}\\{MachineName}\\";

        public static string IniFileName = $"{BZ_ParPath}\\Setting.dll";
        public static string BZ_LogPath = $"{BZ_DataPath}Logs\\";

        /*******************************ICT 新增需求*******************************/
        public static string BZ_LogPath_AddData = $"D:\\BZ-Data\\{MachineName}_{MachineSubName}_Log\\{DateTime.Now:yyyy-MM-dd}";
        public static string MachineLog;
        public static string MachineSubName = "H37_SK105";// Station 工站  当前工站机种名称
        public static string MachineTimeZone = "ICT_KS"; //Site;      //  地区  根据地区切换时区
        public static string MachineLine = "Line1";      //  线体
        public static string MachineMachineNo = "1";   //  machine Num
        public static string MachineLanguage = "1";    //  语言   由于语言切换会变  此处代表序列号
        public static string ProductType = "Normal(E/M)";
        public static string Project_Code = "H39";

        public static string BZ_NewPar = $"{BZ_ExePath}New_Config\\";
        public static string 产量ini = $"D:\\BZ-Parameter\\{MachineName}\\产量.ini";

        public static bool Initial_mFilePath()
        {
            try
            {
                MachineSubName = "P28";

                string IniPath = $"D:\\BZ-Parameter\\{MachineName}\\MachineSubName.ini";
                if (!File.Exists(IniPath))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(IniPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(IniPath));
                    }
                    Set_MachineSubName(MachineSubName, MachineTimeZone, MachineLine, MachineMachineNo, MachineLanguage, ProductType);
                }
                IniFileName = $"D:\\BZ-Parameter\\{MachineName}\\{MachineSubName}\\Setting.dll";
                BZ_ParPath = $"D:\\BZ-Parameter\\{MachineName}\\{MachineSubName}\\";
                BZ_LogPath = $"D:\\BZ-Data\\{MachineName}_{MachineSubName}_Log\\";
                BZ_LogPath_AddData = $"D:\\BZ-Data\\{MachineName}_{MachineSubName}_Log\\{DateTime.Now:yyyyMM}\\{DateTime.Now:yyyyMMdd}";
                MachineLog = $"{BZ_LogPath}Machine Log\\";
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Set_MachineSubName(string subName, string strTimeZone, string Line, string strMachineNo, string strLanguage, string ProductType)
        {
            try
            {
                string IniPath = $"D:\\BZ-Parameter\\{MachineName}\\MachineSubName.ini";
                INI.SetIni("SubName", "Name", subName, IniPath);
                INI.SetIni("SubName", "TimeZone", strTimeZone, IniPath);
                INI.SetIni("SubName", "Line", Line, IniPath);
                INI.SetIni("SubName", "MachineNo", strMachineNo, IniPath);
                INI.SetIni("SubName", "Language", strLanguage, IniPath);
                INI.SetIni("SubName", "ProductType", ProductType, IniPath);
                INI.SetIni("SubName", "ChangeTime", DateTime.Now.ToString(), IniPath);

                Initial_mFilePath();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// ***.ini文件的读写操作，包含GetIni和SetIni两个静态方法
    /// </summary>
    public class INI
    {
        /// <summary>
        /// 从自定义路径读取INI文件
        /// </summary>
        /// <param name="strKey">段名</param>
        /// <param name="strItem">键名</param>
        /// <param name="strIniPath">自定义路径</param>
        /// <returns>键值</returns>
        public static string GetIni(string strKey, string strItem, string strIniPath)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(strKey, strItem, "", temp, 255, strIniPath);
            return temp.ToString();
        }

        /// <summary>
        /// 向自定义路径写入INI文件
        /// </summary>
        /// <param name="strKey">段名</param>
        /// <param name="strItem">键名</param>
        /// <param name="Value">键值</param>
        /// <param name="strIniPath">自定义路径</param>
        public static void SetIni(string strKey, string strItem, string Value, string strIniPath)
        {
            string directory = Path.GetDirectoryName(strIniPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            WritePrivateProfileString(strKey, strItem, Value, strIniPath);
        }

        // 以下操作需引用 using System.Runtime.InteropServices;
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32.dll")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}