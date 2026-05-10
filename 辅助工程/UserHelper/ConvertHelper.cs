using System;

namespace UserHelper
{
    public class ConvertHelper
    {
        public static string ByteArrayToHexString(byte[] buf)
        {
            return BitConverter.ToString(buf).Replace("-", "");
        }
    }
}