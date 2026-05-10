using 运动模块;

namespace Help
{
    public static class ConveyorHelper
    {
        public static void StopAll()
        {
            Task03_L移载平台.Instance.移栽流线停止 = true;
            Task04_R移载平台.Instance.移栽流线停止 = true;
            Task01_L上料.Instance.进料流线停止 = true;
            //Task04_L下料.Instance.出料流线停止 = true;
            Task02_R上料.Instance.进料流线停止 = true;
            //Task06_R下料.Instance.出料流线停止 = true;
        }
    }
}