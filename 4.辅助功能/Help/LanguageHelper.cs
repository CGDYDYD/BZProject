using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static CoreFunction.mFunction;
using static FilePath.mFilePath;
namespace Help
{
    public class LangHelper
    {
        /// <summary>
        /// 写IO翻译文件
        /// </summary>
        public static void WriteIOLanguageXml()
        {
            try
            {
                List<IOLanguage> list = new List<IOLanguage>();

                foreach (var item in m_Input.Where(o => o.Name != null))
                {
                    IOLanguage iOLanguage = new IOLanguage
                    {
                        CH = item.Name
                    };
                    if (item.NameEn.Contains(','))
                    {
                        iOLanguage.EN = item.NameEn.Split(',')[0];
                        iOLanguage.VN = item.NameEn.Split(',')[1];
                    }
                    else
                    {
                        iOLanguage.EN = item.NameEn;
                    }
                    list.Add(iOLanguage);
                }

                foreach (var item in m_Output.Where(o => o.Name != null))
                {
                    IOLanguage iOLanguage = new IOLanguage
                    {
                        CH = item.Name
                    };
                    if (item.NameEn.Contains(','))
                    {
                        iOLanguage.EN = item.NameEn.Split(',')[0];
                        iOLanguage.VN = item.NameEn.Split(',')[1];
                    }
                    else
                    {
                        iOLanguage.EN = item.NameEn;
                    }
                    list.Add(iOLanguage);
                }
                WriteXml("IOLanguage.xml", ref list);
                MessageBox.Show("IOLanguage.xml写入完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"IOLanguage.xml写入失败{ex.Message}");
            }
        }

        /// <summary>
        /// 读取IO翻译文件,并且写入ParInput.xml和ParOutput.xml"
        /// </summary>           
        public static void ReadIOLanguage()
        {
            List<IOLanguage> list = new List<IOLanguage>();
            ReadXml("IOLanguage.xml", ref list);
            for (int i = 0; i < m_Input.Length; i++)
            {
                string name = m_Input[i].Name;
                if (name != null)
                {
                    IOLanguage Language = list.Find(o => o.CH == name);
                    m_Input[i].Name = Language.CH;
                    m_Input[i].NameEn = Language.EN;
                    m_Input[i].NameOt = Language.VN;
                }
            }
            for (int i = 0; i < m_Output.Length; i++)
            {
                string name = m_Output[i].Name;
                if (name != null)
                {
                    IOLanguage Language = list.Find(o => o.CH == name);
                    m_Output[i].Name = Language.CH;
                    m_Output[i].NameEn = Language.EN;
                    m_Output[i].NameOt = Language.VN;
                }
            }
            WriteXml($"{BZ_ParPath}ParInput.xml", ref m_Input);
            WriteXml($"{BZ_ParPath}ParOutput.xml", ref m_Output);

            WriteXml($"{BZ_ExePath}ParInput.xml", ref m_Input);
            WriteXml($"{BZ_ExePath}ParOutput.xml", ref m_Output);
        }
    }

    [Serializable]
    public class IOLanguage
    {
        public string CH { get; set; } = "";
        public string EN { get; set; } = "";
        public string VN { get; set; } = "";
    }
}