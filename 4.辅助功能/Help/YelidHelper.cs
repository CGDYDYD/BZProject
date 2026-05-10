using BoTech;
using FilePath;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UserHelper;

namespace Help
{
    public class YelidHelper
    {
        public static void WriteYelid()
        {
            INI.SetIni("产量", "CT", mGlobal.CT.ToString(), mFilePath.产量ini);
        }

        public static void ReadYelid()
        {
            double.TryParse(INI.GetIni("产量", "CT", mFilePath.产量ini), out mGlobal.CT);
        }

        public static void SaveYelidCsv()
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            double OK数 = mGlobal.OK数组.Sum();
            double NG数 = mGlobal.NG数组.Sum();
            double 产量 = OK数 + NG数;
            double 报警数 = mGlobal.报警数组.Sum();
            double Yield = 产量 == 0 ? 0 : OK数 / 产量;
            double DT_rate = mGlobal.报警分钟数 / 1200;
            double Alarm_rate = 产量 == 0 ? 0 : 报警数 / 产量;
            SaveYelidCsv(date, 产量.ToString(), OK数.ToString(), NG数.ToString(), 报警数.ToString(), Yield.ToString("P2"), DT_rate.ToString("P2"), Alarm_rate.ToString("P2"));
        }

        private static void SaveYelidCsv(string Date, string 产量, string OK数, string NG数, string 报警数, string Yield, string DT_rate, string Alarm_rate)
        {
            try
            {
                string path = $"{mFilePath.BZ_LogPath}UPH\\UPH.csv";
                if (!File.Exists(path))
                {
                    string 表头 = "Date,产量,OK数,NG数,报警数,Yield(%),DT rate(%),Alarm rate(%)\r\n";
                    File.WriteAllText(path, 表头, Encoding.Default);
                }
                List<string> lines = File.ReadLines(path, Encoding.Default).Where(o => o != "").ToList();
                if (lines.Any(o => o.Contains(Date)))
                {
                    lines[lines.Count - 1] = $"{Date},{产量},{OK数},{NG数},{报警数},{Yield},{DT_rate},{Alarm_rate}\r\n";
                }
                else
                {
                    lines.Add($"{Date},{产量},{OK数},{NG数},{报警数},{Yield},{DT_rate},{Alarm_rate}");
                }
                File.WriteAllLines(path, lines, Encoding.Default);
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }
    }
}