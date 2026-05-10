using XStation;
using 运动模块;

namespace BoTech
{
    internal sealed class StaLoad
    {
        /// <summary>
        /// 加载所有工位及流水线
        /// </summary>
        public static void TaskLoad()
        {
            WkManager.mConvList.Clear();
            WkManager.TaskMap.Clear();

            Task00_空站.Instance.Initialize();
            Task03_L移载平台.Instance.Initialize();
            Task04_R移载平台.Instance.Initialize();
            Task01_L上料.Instance.Initialize();
            Task05_L下料.Instance.Initialize();
            Task02_R上料.Instance.Initialize();
            Task06_R下料.Instance.Initialize();
        }
    }
}