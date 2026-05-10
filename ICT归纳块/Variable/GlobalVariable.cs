using System.Data;
using System.Threading;

namespace BoTech
{
    /// <summary>
    /// 变量定义类
    /// </summary>
    public class GlobalVar
    {
        /// <summary>
        /// 报警 整机阻塞用
        /// </summary>
        public static ManualResetEvent FailTipAlarmAllClose = new ManualResetEvent(false);

        /// <summary>
        /// 当前登录用户存储
        /// </summary>
        public static LoginUser[] CurrentLoginUser = new LoginUser[] { new LoginUser(), new LoginUser() };

        /// <summary>
        /// 登录用户
        /// </summary>
        public static LoginUser loginUser = new LoginUser();

        /// <summary>
        /// 机种名
        /// </summary>
        public static string SCUD机种名;

        /// <summary>
        /// 项目地区
        /// </summary>
        public static ETimeZone MachineTimeZone = ETimeZone.ITKS;

        /// <summary>
        /// 设置时间差没有人操作电脑，自动注销当前登录账户
        /// </summary>
        public static int MaxFeedingDogMinutes = 5;

        /// <summary>
        /// 语言切换表格库
        /// </summary>
        public static DataTable LanguageDataTable;

        /// <summary>
        /// 线体
        /// </summary>
        public static string Line { get; set; }

        /// <summary>
        /// machine Num
        /// </summary>
        public static string MachineNo { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public static string language { get; set; }

        /// <summary>
        /// 生产类型
        /// </summary>
        public static string ProductType { get; set; }

        public static string ProjectCode { get; set; }

        /// <summary>
        /// SW 软件哈希值
        /// </summary>
        public static string MS_Hash { get; set; }

        /// <summary>
        /// Hive
        /// </summary>
        public static HaveSerciceBLL appHiveControl = HaveSerciceBLL.GetInstance();
    }

    public class LoginUser
    {
        public string Badage { get; set; } = "";  //ID
        public string Name { get; set; } = "";    //姓名
        public LoginLevel Access_Level { get; set; } = LoginLevel.NoLogin; //权限
        public string Function { get; set; } = "";    //部门
        public bool IsActive { get; set; }
    }
}