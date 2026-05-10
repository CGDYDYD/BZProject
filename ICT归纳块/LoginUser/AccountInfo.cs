using System;

namespace BoTech
{
    [Serializable]
    public class AccountInfo
    {
        public AccountInfo()
        {
            UserID = "";
            UserName = "";
            UserLevel = LoginLevel.NoLogin;
            EmployeeID = "";
            Company = "";
            JobTitle = "";
            Password = "";
            LoginTime = DateTime.Now;
            EstablishmentTime = LoginTime;
            LatestModificationTime = LoginTime;
            AdditionalInfo = "NoLogin";
            index_Process_Station_ID = "";
        }

        public string UserID { get; set; }
        public string UserName { get; set; }
        public string EmployeeID { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
        public LoginLevel UserLevel { get; set; }
        public string JobTitle { get; set; }

        /// <summary>
        /// 账户建立时间 格式：YYYYMMDD HH:mm:ss
        /// </summary>
        public DateTime EstablishmentTime { get; set; }

        /// <summary>
        /// 账户信息修改时间 格式：YYYYMMDD HH:mm:ss
        /// </summary>
        public DateTime LatestModificationTime { get; set; }

        /// <summary>
        /// 账户登录的时间点 数据类型：DateTime
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 账户附加备注信息
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// 站点信息
        /// </summary>
        public string index_Process_Station_ID { get; set; }
    }

    public enum LoginLevel
    {
        // 权限的范围从低到高
        NoLogin = 1,

        Level1,
        Level2,
        Level3,

        SuperAdmin = 9,
    }
}