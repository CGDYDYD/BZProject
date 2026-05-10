using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace BoTech
{
    /// <summary>
    /// 干涉区工厂类
    /// </summary>
    /// <typeparam name="T">所有干涉区的枚举</typeparam>
    public class InterferenceZoneFactory<T> where T : struct
    {
        /// <summary>
        /// 干涉区缓存, key为干涉区id, value为干涉区对象
        /// </summary>
        private Dictionary<int, InterferenceZone> interferenceZonesDic = new Dictionary<int, InterferenceZone>();

        /// <summary>
        /// 线程安全锁
        /// </summary>
        private object lockObj = new object();

        /// <summary>
        /// 单例
        /// </summary>
        public static InterferenceZoneFactory<T> Instance = new InterferenceZoneFactory<T>();

        public InterferenceZoneFactory()
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("泛型类不是枚举类型!");
            }
            RegeditEvent();
        }

        private void RegeditEvent()
        {
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                int index = (int)value;
                AddEvent(index, new InterferenceZone());
            }
        }

        // 添加一个 BooleanEvent 实例到工厂中
        private void AddEvent(int key, InterferenceZone booleanEvent)
        {
            lock (lockObj)
            {
                interferenceZonesDic.Add(key, booleanEvent);
            }
        }

        // 获取工厂中指定索引的 BooleanEvent 实例
        public InterferenceZone FindZone(T index)
        {
            lock (lockObj)
            {
                int indexTemp = (int)(object)index;
                if (interferenceZonesDic.ContainsKey(indexTemp))
                {
                    return interferenceZonesDic[indexTemp];
                }
            }

            return null;
        }
    }

    public class InterferenceZone
    {
        private const int maxThreadCount = 1;

        private SemaphoreSlim interferenceEvent = new SemaphoreSlim(1, maxThreadCount);

        private ConcurrentDictionary<int, int> concurrentDict = new ConcurrentDictionary<int, int>();

        /// <summary>
        /// 进入干涉区
        /// </summary>
        public void EnterInterferenceZone(int taskid)
        {
            if (!concurrentDict.ContainsKey(taskid))
            {
                concurrentDict.TryAdd(taskid, taskid);
            }
            // 等待其他模组离开干涉区
            interferenceEvent.Wait();
            // 模组进入干涉区
        }

        /// <summary>
        /// 离开干涉区
        /// </summary>
        public void ExitInterferenceZone(int taskid)
        {
            // 模组离开干涉区 信号其他模组可以进入干涉区
            if (concurrentDict.ContainsKey(taskid))
            {
                concurrentDict.TryRemove(taskid, out int val);
                if (interferenceEvent.CurrentCount < maxThreadCount)
                {
                    interferenceEvent.Release();
                }
            }
        }
    }
}