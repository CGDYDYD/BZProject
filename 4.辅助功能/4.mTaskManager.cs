using System.Collections.Generic;

namespace 运动模块
{
    public class mTaskManager
    {
        public Dictionary<short, mWorkShare> mTaskMap = new Dictionary<short, mWorkShare>();

        public static mTaskManager Instance { get; } = new mTaskManager();

        public void BindTask(short id, mWorkShare MmWorkShare)
        {
            if (!mTaskMap.ContainsKey(id))
            {
                mTaskMap.Add(id, MmWorkShare);
            }
        }

        public mWorkShare FindTaskByID(short id)
        {
            return mTaskMap[id];
        }
    }
}