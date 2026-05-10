using CoreFunction;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace LogsHelper
{
    public static class LogWrite
    {
        /// <summary>
        /// 记录信息
        /// </summary>
        public struct LogInfo
        {
            /// <summary>
            /// 要记录的信息
            /// </summary>
            public string msg;

            /// <summary>
            /// 文件路径
            /// </summary>
            public string path;

            /// <summary>
            /// 记录的时间
            /// </summary>
            public string time;
        }

        private static ConcurrentQueue<LogInfo> infos = new ConcurrentQueue<LogInfo>();

        private static Thread logthread;

        private static object lockobj = new object();

        public static void LogMsg(string filepath, string logmsg, string logTime = null)
        {
            lock (lockobj)
            {
                LogInfo info = new LogInfo
                {
                    path = filepath,
                    msg = logmsg,
                    time = logTime ?? ""
                };
                infos.Enqueue(info);
            }
        }

        /// <summary>
        /// 开启写log线程
        /// </summary>
        public static void StartWriterMsg()
        {
            if (logthread?.IsAlive != true || logthread.ThreadState != ThreadState.Running)
            {
                logthread = new Thread(ProcessQueue)
                {
                    IsBackground = true
                };
                logthread.Start();
            }
        }

        private static object _lock = new object();

        private static void ProcessQueue()
        {
            try
            {
                while (true)
                {
                    if (infos.Count > 0)
                    {
                        lock (_lock)
                        {
                            infos.TryDequeue(out LogInfo info);
                            string msg = info.time + info.msg;
                            mFunction.WriteDattxt(info.path, msg);
                        }
                    }
                    Thread.Sleep(5);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                StartWriterMsg();
            }
        }
    }
}