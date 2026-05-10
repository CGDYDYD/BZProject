using System.IO;
using System.Security.Cryptography;

namespace UserHelper
{
    public class HashHelper
    {
        public static string GetFileHash(string strFileName)
        {
            if (!File.Exists(strFileName))
            {
                return string.Empty;
            }
            FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
            byte[] hashBytes = HashData(fs);
            fs.Close();
            return ConvertHelper.ByteArrayToHexString(hashBytes);
        }

        private static byte[] HashData(Stream stream)
        {
            return SHA1.Create().ComputeHash(stream);
        }
    }
}