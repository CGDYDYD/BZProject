using System;
using System.IO;

namespace UserHelper
{
    public class DirectoryHelper
    {
        public static void CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }
    }
}