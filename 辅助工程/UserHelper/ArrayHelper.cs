using System.Linq;

namespace UserHelper
{
    public class ArrayHelper
    {
        /// <summary>
        /// 生成含相同项的数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="count"></param>
        public static T[] CreatRepeatArray<T>(T item, int count)
        {
            return Enumerable.Repeat(item, count).ToArray();
        }
    }
}