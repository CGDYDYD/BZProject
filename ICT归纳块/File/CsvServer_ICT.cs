using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using UserHelper;

namespace BoTech
{
    /// <summary>
    /// 平台已经开启，一直运行的CsvServer，可以直接用里面的函数 比如 IProject.IManager.Instance.csvServer.WriteLine(path,csvFormatString);
    /// </summary>
    public sealed class CsvServer_ICT
    {
        private Thread _thread;
        private ConcurrentQueue<CsvInfo> queue = new ConcurrentQueue<CsvInfo>();
        public object obj = new object();

        private CsvServer_ICT() => Start();

        public static CsvServer_ICT Instance { get; } = new CsvServer_ICT();

        public void Start()
        {
            Stop();
            _thread = new Thread(new ThreadStart(ProcessEventQueue))
            {
                IsBackground = true
            };
            _thread.Start();
        }

        public void Stop()
        {
            this._thread?.Abort();
        }

        private void ProcessEventQueue()
        {
            while (true)
            {
                if (queue.Count > 0)
                {
                    queue.TryDequeue(out CsvInfo csvInfo);
                    try
                    {
                        lock (obj)
                        {
                            FileStream fs = null;
                            StreamWriter sw = null;
                            fs = new FileStream(csvInfo.Path, FileMode.Append, FileAccess.Write);
                            sw = new StreamWriter(fs, Encoding.Default);
                            sw.WriteLine(csvInfo.Line);
                            sw.Close();
                            fs.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                Thread.Sleep(5);
            }
        }

        /// <summary>
        /// 写Log
        /// </summary>
        public void WriteLine(string path, string line)
        {
            CsvInfo csvInfo = new CsvInfo();
            DirectoryHelper.CreateDirectory(path);
            csvInfo.Path = path;
            csvInfo.Line = line;
            queue.Enqueue(csvInfo);
        }
    }

    /// <summary>
    /// csv格式
    /// </summary>
    public class CsvInfo
    {
        public string Path { get; set; }
        public string Line { get; set; }
    }
}