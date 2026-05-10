using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserHelper;
using static FilePath.mFilePath;

namespace BoTech
{
    public class AudioLoginManager
    {
        private static AudioLoginManager instance;

        public static AudioLoginManager Instance => instance ?? (instance = new AudioLoginManager());

        public AudioLoginManager() => LoginDataReaderFromCSV();

        private string path_user = $"{BZ_ParPath}ParXlsx\\Users.csv";

        private void LoginDataReaderFromCSV()
        {
            try
            {
                #region 定义索引

                int index_Name = 3;//Name1
                int index_Access_Level = 4;//1
                int index_Card_UID = 5;//Card_UID
                int index_Function = 6;//Function
                int index_Process_Station_ID = 7;//Process_Station_ID

                #endregion 定义索引

                #region readformCSV

                List<string[]> csvData = new List<string[]>();
                using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(path_user, Encoding.GetEncoding("gb2312")))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    csvReader.TrimWhiteSpace = true;

                    while (!csvReader.EndOfData)
                    {
                        string[] arrayline = csvReader.ReadFields();
                        csvData.Add(arrayline);
                    }
                }

                #endregion readformCSV

                #region 更新信息

                loginData.AllAccount_List.Clear();
                for (int i = 1; i < csvData.Count; i++)
                {
                    AccountInfo ai = new AccountInfo
                    {
                        UserID = csvData[i][index_Card_UID].Trim(),
                        UserName = csvData[i][index_Name].Trim(),
                        EmployeeID = csvData[i][index_Function].Trim(),
                        Password = "********",
                        index_Process_Station_ID = csvData[i][index_Process_Station_ID].Trim()
                    };
                    LoginLevel ll = LoginLevel.NoLogin;
                    string temsStr = csvData[i][index_Access_Level].Trim();
                    if (temsStr == "1")
                    {
                        ll = LoginLevel.Level1;
                    }
                    else if (temsStr == "2")
                    {
                        ll = LoginLevel.Level2;
                    }
                    else if (temsStr == "3")
                    {
                        ll = LoginLevel.Level3;
                    }

                    ai.UserLevel = ll;
                    ai.Company = "BZ";
                    ai.JobTitle = "BZ";
                    ai.EstablishmentTime = DateTime.Now;
                    ai.LatestModificationTime = DateTime.Now;

                    loginData.AllAccount_List.Add(ai);
                }

                #endregion 更新信息
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        #region 私有字段

        public LoginData loginData = new LoginData();
        private Login_Page audioLoginPage;

        private static CancellationTokenSource cts = new CancellationTokenSource();
        private Stopwatch Stopwh = new Stopwatch();

        #endregion 私有字段

        #region 属性

        /// <summary>
        /// 读 当前已登录的账户
        /// </summary>
        public AccountInfo LoggedInAccount { get; private set; } = new AccountInfo();

        #endregion 属性

        #region 公有事件

        public event Action UserValidationOK_event;

        public event Action AdminValidationOK_event;

        public event Action SuperAdminValidationOK_event;

        public event Action Logout_event;

        public event Action<AccountInfo> Logouting_event;

        public event Action<AccountInfo> UserLogin_event;

        #endregion 公有事件

        #region 公有方法

        #region WatchDog

        public void WatchDogStart()
        {
            Stopwh.Restart();
            cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                #region Task-循环体

                while (!cts.IsCancellationRequested)//判断任务是否被取消
                {
                    if (MouseHelper.GetLastInputTime() >= (GlobalVar.MaxFeedingDogMinutes * 60 * 1000))
                    {
                        GlobalVar.CurrentLoginUser = new LoginUser[] { new LoginUser(), new LoginUser() };
                        Logouting_event?.Invoke(LoggedInAccount);
                        this.LoggedInAccount = new AccountInfo();
                        Logout_event?.Invoke();
                        WatchDogStop();
                    }
                    if (LoggedInAccount.UserLevel == LoginLevel.Level1 || LoggedInAccount.UserLevel == LoginLevel.NoLogin)
                    {
                        //在登陆LEVEL1的账户或未登陆时，程序自己喂狗
                        Stopwh.Restart();
                    }
                    Thread.Sleep(500);
                }

                #endregion Task-循环体
            }, cts.Token);
        }

        public void WatchDogStop()
        {
            Stopwh.Stop();
            cts.Cancel();
        }

        #endregion WatchDog

        /// <summary>
        /// 登出账户
        /// </summary>
        public void LoginoutAccount()
        {
            if (LoggedInAccount.UserLevel != LoginLevel.NoLogin)
            {
                Logouting_event?.Invoke(LoggedInAccount);
                LoggedInAccount = new AccountInfo();
                Logout_event?.Invoke();
                GlobalVar.CurrentLoginUser = new LoginUser[] { new LoginUser(), new LoginUser() };
                WatchDogStop();
            }
        }

        public bool CheckNameIsExists(string userID, out AccountInfo AI)
        {
            foreach (AccountInfo element in loginData.AllAccount_List)       //遍历
            {
                if (element.UserID == userID && element.index_Process_Station_ID == GlobalVar.SCUD机种名)
                {
                    AI = element;
                    return true;
                }
            }
            AI = null;
            return false;
        }

        public bool LoginConfirmPassword(string userID, bool login = true)
        {
            ConfirmPassword(userID, login);
            AccountInfo ai = new AccountInfo()
            {
                EmployeeID = LoggedInAccount.EmployeeID,
                UserName = LoggedInAccount.UserName,
                UserLevel = LoginLevel.Level3,
                Company = LoggedInAccount.Company,
                UserID = LoggedInAccount.UserID
            };
            if (ai != null)
            {
                if (login)
                {
                    if (ai.UserLevel == LoginLevel.Level1)
                    {
                        UserValidationOK_event?.Invoke();
                    }
                    if (ai.UserLevel == LoginLevel.Level2)
                    {
                        AdminValidationOK_event?.Invoke();
                    }
                    if (ai.UserLevel == LoginLevel.Level3)
                    {
                        SuperAdminValidationOK_event?.Invoke();
                    }
                    UserLogin_event?.Invoke(LoggedInAccount);
                    if (ai.UserLevel >= LoginLevel.Level2)
                    {
                        WatchDogStart();
                    }
                    GlobalVar.CurrentLoginUser[0].IsActive = true;
                    GlobalVar.CurrentLoginUser[0].Function = ai.Company;
                    GlobalVar.CurrentLoginUser[0].Name = ai.UserName;
                    GlobalVar.CurrentLoginUser[0].Access_Level = ai.UserLevel;
                    GlobalVar.CurrentLoginUser[0].Badage = ai.UserID;
                    if (!string.IsNullOrEmpty(GlobalVar.CurrentLoginUser[1].Name))
                    {
                        GlobalVar.CurrentLoginUser[1].IsActive = true;
                    }
                }
                return true;
            }

            return false;
        }

        public LoginLevel GetCurrentLevel()
        {
            return LoggedInAccount.UserLevel;
        }

        public void ShowLoginPage()
        {
            if (audioLoginPage?.IsDisposed != false)
            {
                audioLoginPage = new Login_Page(this);
            }

            audioLoginPage.StartPosition = FormStartPosition.CenterScreen;

            audioLoginPage.TopMost = true;
            audioLoginPage.Show();
        }

        #endregion 公有方法

        #region 私有方法

        private AccountInfo ConfirmPassword(string userID, bool login = true)
        {
            foreach (AccountInfo element in this.loginData.AllAccount_List)  //遍历
            {
                if (element.UserID == userID /*&& element.index_Process_Station_ID == GlobalVar.SCUD机种名.ToString()*/)
                {
                    if (login)
                    {
                        element.LoginTime = DateTime.Now;
                        LoggedInAccount = element;
                    }
                    return element;
                }
            }
            return null;
        }

        #endregion 私有方法
    }
}