using System;

namespace UserHelper
{
    public class RandomHelper
    {
        public static int[] CreateRandomArray(int count, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] randomArray = new int[count];
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue);
            }
            return randomArray;
        }
    }
}