using Newtonsoft.Json;
using System;
using System.IO;
using UserHelper;
using static FilePath.mFilePath;

namespace BoTech
{
    public struct General_Config
    {
        public string[] Site;
        public string[] Prod_Type;
        public string[] Line;
        public string[] Station;
        public string[] Machine;
        public string[] Language;
    }

    public class SettingData
    {
        public string Access_Control_with_MES { get; set; }//手动录入
        public string Project_Code { get; set; }//手动录入
        public string Automatically_Sign_out { get; set; }//手动录入
        public string Site { get; set; }
        public string Prod_Type { get; set; }
        public string Line { get; set; }
        public string Station { get; set; }
        public string Machine { get; set; }
        public string Language { get; set; }
        public General_Config General_Config { get; set; }
    }

    public class mFileJson
    {
        public static SettingData settingjson = new SettingData();
        public static string dir = $"{BZ_ParPath}AccessControl";
        public static string jsonpath = $"{dir}\\MachineSubName.json";

        public static string ReadJsonFile()
        {
            string result = "";
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                if (!File.Exists(jsonpath))
                {
                    InitJsonFile();
                }
                result = File.ReadAllText(jsonpath);
                settingjson = JsonConvert.DeserializeObject<SettingData>(result);
                BindData();
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);

                throw;
            }
            return result;
        }

        public static bool WriteJsonFile(SettingData json)
        {
            string str = JsonConvert.SerializeObject(json, Formatting.Indented);
            File.WriteAllText(jsonpath, str);
            BindData();
            return true;
        }

        public static void InitJsonFile()
        {
            General_Config temp = new General_Config
            {
                Site = new string[] { "ITKS", "ITJX", "ITBG" },
                Prod_Type = new string[] { "E-SKU", "M-SKU", "Normal(E/M)", "Common" },
                Line = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" },
                Station = new string[] { "RH920", "LH920", "SK025" },
                Machine = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" },
                Language = new string[] { "简体中文", "English", "Tiếng Việt" }
            };

            settingjson.Access_Control_with_MES = "FALSE";//手动录入
            settingjson.Project_Code = "H39";//手动录入
            settingjson.Automatically_Sign_out = "5";//手动录入
            settingjson.Site = "ITKS";
            settingjson.Prod_Type = "Common";
            settingjson.Line = "1";
            settingjson.Station = "TE010";
            settingjson.Machine = "1";
            settingjson.Language = "简体中文";
            settingjson.General_Config = temp;

            WriteJsonFile(settingjson);
        }

        public static void BindData()
        {
            Project_Code = settingjson.Project_Code;
            MachineSubName = settingjson.Station;
            MachineTimeZone = settingjson.Site;
            MachineLine = settingjson.Line;
            MachineMachineNo = settingjson.Machine;
            MachineLanguage = settingjson.Language;
            ProductType = settingjson.Prod_Type;
        }
    }
}