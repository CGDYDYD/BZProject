using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using UserHelper;

namespace BoTech
{
    internal class DataSave
    {
        private static DataSave _instance;

        public static DataSave Instance => _instance ?? (_instance = new DataSave());

        #region"CSV"

        private object objCSVWrite = new object();

        //写入CSV文件
        public void CSVWrite(string filePath, string str, string headStr, string fileName = "\\testdata.csv")
        {
            try
            {
                lock (objCSVWrite)
                {
                    bool writeHeadStr = false;
                    if (!Directory.Exists(filePath))//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    if (!File.Exists(filePath + fileName))
                    {
                        writeHeadStr = true;
                    }
                    else if (!open_close(filePath + fileName))
                    {
                        Kill();
                    }
                    StreamWriter t = new StreamWriter(filePath + fileName, true, Encoding.UTF8);
                    if (writeHeadStr)
                    {
                        t.WriteLine(headStr);
                    }
                    t.WriteLine(str);
                    t.Close();
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        public bool open_close(string mypath)//判断是否打开
        {
            bool myboo = false;
            FileStream fs = null;
            try
            {
                fs = new FileStream(mypath, FileMode.Open);
                myboo = true;
            }
            catch
            {
            }
            finally
            {
                fs?.Close();
            }
            return myboo;
        }

        private void Kill()
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.ToUpper() == "ET" || p.ProcessName.ToUpper() == "EXCEL")
                {
                    p.CloseMainWindow();
                    p.WaitForExit();
                }
            }
        }

        #endregion
    }
}