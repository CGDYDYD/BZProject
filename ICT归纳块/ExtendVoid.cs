using System;

namespace BoTech
{
    /// <summary>
    /// 自定义扩展方法
    /// </summary>
    public static class ExtendVoid
    {
        /// <summary>
        /// 枚举类型转short类型
        /// </summary>
        public static short EnumToShort(this Enum value) => Convert.ToInt16(value);

        /// <summary>
        /// 枚举类型转int32类型
        /// </summary>
        public static int EnumToInt(this Enum value) => Convert.ToInt32(value);

        /// <summary>
        /// 字符串类型转int类型
        /// </summary>
        public static int StringToInt(this string value)
        { try { return Convert.ToInt32(value); } catch { return 0; } }
    }
}