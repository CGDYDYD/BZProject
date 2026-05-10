using System;
using System.Diagnostics;

namespace UserHelper
{
    public class DebugHelper
    {
        public static void WriteLine(Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }
    }
}