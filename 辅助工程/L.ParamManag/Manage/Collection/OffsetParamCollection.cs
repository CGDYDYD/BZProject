using LParamManag.Interface;
using LParamManag.Manage.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LParamManag.Manage.Collection
{
    public class OffsetParamCollection : IGenericParam<OffsetCompenParam, OffsetCompenParam>
    {
        public static Dictionary<string, List<OffsetCompenParam>> PARAM_Offset_Parameter = new Dictionary<string, List<OffsetCompenParam>>();

        private static object _lock = new object();

        private static string LocalParamPath;
        private static OffsetParamCollection formInstance;

        public OffsetParamCollection(string path)
        {
            if (File.Exists(path))
            {
                Clear();
                string jsonData1 = File.ReadAllText(path, Encoding.UTF8);
                PARAM_Offset_Parameter = JsonConvert.DeserializeObject<Dictionary<string, List<OffsetCompenParam>>>(jsonData1);
            }
            else
            {
                Clear();
                //CreatingDefaultParam();
            }
        }

        public static OffsetParamCollection GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                formInstance = new OffsetParamCollection(LocalParamPath);
                return formInstance;
            }
        }

        public static OffsetParamCollection LoadingLocalParam(string path)
        {
            LocalParamPath = path + "\\OffsetCompenParam.json";
            return GetIntance;
        }

        public OffsetCompenParam GetValue(string Key, int index)
        {
            return this[Key, index];
        }

        public bool SetValue(string Key, int index, OffsetCompenParam value)
        {
            this[Key, index] = value;
            return true;
        }

        /// <summary>
        /// 根据字典Key 和字典Value 集合的索引 获取数据/写入数据
        /// </summary>
        /// <param name="Key">键</param>
        /// <param name="index">索引号</param>
        public OffsetCompenParam this[string Key, int index]
        {
            get
            {
                lock (_lock)
                {
                    return PARAM_Offset_Parameter.ContainsKey(Key) && PARAM_Offset_Parameter[Key].Count > index
                        ? PARAM_Offset_Parameter[Key][index]
                        : new OffsetCompenParam();
                }
            }
            set
            {
                lock (_lock)
                {
                    if (PARAM_Offset_Parameter.ContainsKey(Key) && PARAM_Offset_Parameter[Key].Count > index)
                    {
                        PARAM_Offset_Parameter[Key][index] = value;
                    }
                }
            }
        }

        /// <summary>
        /// 根据字典Key 和字典Value 集合元素的名称获取数据
        /// </summary>
        /// <param name="Key">键</param>
        /// <param name="Name">名称</param>
        public OffsetCompenParam this[string Key, string Name]
        {
            get
            {
                lock (_lock)
                {
                    if (PARAM_Offset_Parameter.ContainsKey(Key))
                    {
                        try
                        {
                            var sss = PARAM_Offset_Parameter[Key].Find(p => p.Name == Name);
                            return PARAM_Offset_Parameter[Key].Contains(sss) ? PARAM_Offset_Parameter[Key].First(p => p.Name == Name) : new OffsetCompenParam();
                        }
                        catch
                        {
                            return new OffsetCompenParam();
                        }
                    }
                    return new OffsetCompenParam();
                }
            }
        }

        /// <summary>
        /// 保存数据到本地
        /// </summary>
        public void Save()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented, // 设置缩进格式
                ContractResolver = new CamelCasePropertyNamesContractResolver() // 使用驼峰规则
            };
            JsonConvert.DefaultSettings = () => settings;
            File.WriteAllText(LocalParamPath, JsonConvert.SerializeObject(PARAM_Offset_Parameter));
        }

        public void Clear()
        {
            PARAM_Offset_Parameter.Clear();
        }
    }
}