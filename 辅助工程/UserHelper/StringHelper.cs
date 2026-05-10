using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UserHelper
{
    public class StringHelper
    {
        /// <summary>
        /// 按照中文,英文分割字符串
        /// </summary>
        /// <param name="text"></param>
        public static List<string> SplitByLanguage(string text)
        {
            // 匹配中文、英文、数字、空格等
            var pattern = @"([\u4e00-\u9fff]+)|([^\u4e00-\u9fff]+)";
            var matches = Regex.Matches(text, pattern);
            return matches.Cast<Match>()
                          .Where(m => m.Success && !string.IsNullOrEmpty(m.Value))
                          .Select(m => m.Value.Trim())
                          .Where(s => !string.IsNullOrEmpty(s))
                          .ToList();
        }
    }
}