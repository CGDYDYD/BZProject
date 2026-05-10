using System;

namespace BoTech
{
    public class GlobalUserInfoGet
    {
        public static string GetLoginString => $"{DateTime.Now:yyyy/MM/dd},{DateTime.Now:HH:mm:ss.fff}";
    }
}