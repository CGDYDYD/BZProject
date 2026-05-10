using System.IO;
using System.Text;

namespace UserHelper
{
    public class CsvHelper
    {
        public static bool AppendLine(string path, string line)
        {
            DirectoryHelper.CreateDirectory(path);
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    sw.WriteLine(line);
                }
                return true;
            }
            catch { return false; }
        }
    }
}