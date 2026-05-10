using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UserHelper;
using static FilePath.mFilePath;

namespace BoTech
{
    public partial class UserManager : UserControl
    {
        public UserManager()
        {
            InitializeComponent();
            dataGridView1.Enabled = false;
        }

        private string path_user = $"{BZ_ParPath}ParXlsx\\Users.csv";
        private Dictionary<int, int> CardIDError = new Dictionary<int, int>();
        private Dictionary<int, int> StationError = new Dictionary<int, int>();
        private List<string[]> User_InportUID = new List<string[]>(); //正常的信息

        private int index_Site;//ITKS
        private int index_Project = 1;//H38
        private int index_Vendor_Name = 2;//ITKS_E03 - 4FT - 01B_1_STATION
        private int index_Name = 3;//Name1
        private int index_Access_Level = 4;//1
        private int index_Card_UID = 5;//20240815224
        private int index_Function = 6;//Vendor_OSS
        private int index_Process_Station_ID = 7;//Vendor_OSS

        /// <summary>
        /// 导入这里要逐条导入,剔除异常项,重复项
        /// </summary>
        private void btn_Import_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "*.csv|*.CSV",
                    RestoreDirectory = true,
                    FilterIndex = 1
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    List<string[]> data = new List<string[]>();
                    List<string[]> dataGrid = new List<string[]>();
                    List<string[]> dataGridCard = new List<string[]>();

                    List<string[]> csvData = readCSVFile(openFileDialog.FileName);

                    for (int i = 1; i < csvData.Count; i++)
                    {
                        //去表头
                        data.Add(csvData[i]);
                    }
                    if (CheckImportUser(csvData, out string CardID))
                    {
                        for (int i = 0; i < User_InportUID.Count; i++)
                        {
                            dataGridCard.Add(User_InportUID[i]);
                        }
                        RefreshDGV(dataGridCard);
                        btn_Save_Click(sender, e);

                        MessageBox.Show($"导入成功;已剔除重复卡号信息{CardID}", "Info");
                    }
                    else
                    {
                        for (int i = 0; i < csvData.Count; i++)
                        {
                            dataGrid.Add(csvData[i]);
                        }
                        RefreshDGV(dataGrid);
                        btn_Save_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);

                MessageBox.Show("用户文件格式错误", "ERR");
            }
        }

        private void RefreshDGV(List<string[]> csvData)
        {
            try
            {
                DataTable dt = new DataTable();
                if (csvData.Count > 0)
                {
                    for (int i = 0; i < csvData[0].Length; i++)
                    {
                        dt.Columns.Add(csvData[0][i]);
                    }
                    for (int i = 1; i < csvData.Count; i++)
                    {
                        dt.Rows.Add(dt.NewRow());
                        for (int j = 0; j < csvData[i].Length; j++)
                        {
                            dt.Rows[i - 1][j] = csvData[i][j];
                        }
                    }
                }
                this.dataGridView1.DataSource = dt;
                this.dataGridView1.Enabled = false;
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);

                throw;
            }
        }

        private void RefreshDGVCellColor(Dictionary<int, int> CellColor, Dictionary<int, int> StationColor)
        {
            foreach (KeyValuePair<int, int> item in CellColor)
            {
                DataGridViewCell dataGridCell = dataGridView1.Rows[item.Key].Cells[item.Value];
                dataGridCell.Style.ForeColor = Color.Red;
            }
            foreach (KeyValuePair<int, int> item in StationColor)
            {
                DataGridViewCell dataGridCell = dataGridView1.Rows[item.Key].Cells[item.Value];
                dataGridCell.Style.ForeColor = Color.Red;
            }
        }

        private void ResetDataGrid(int row, int cell)
        {
            DataGridViewCell dataGridCell = dataGridView1.Rows[row].Cells[cell];
            dataGridCell.Style.ForeColor = Color.Black;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btn_Delete.Visible = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            btn_Delete.Visible = false;
            string strLine = "";
            string strData = "";

            if (dataGridView1.Rows.Count <= 0)
            {
                return;
            }

            List<string[]> data = new List<string[]>();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string[] temp = new string[dataGridView1.ColumnCount];
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    temp[j] = dataGridView1.Rows[i].Cells[j].Value.ToString().Trim();
                    if (temp[j].Length == 0)
                    {
                        MessageBox.Show("存在空值;请确认用户信息", "ERR");
                        return;
                    }
                }
                data.Add(temp);
            }

            if (CheckUsers(data))
            {
                RefreshDGVCellColor(CardIDError, StationError);
                MessageBox.Show("保存失败", "ERR");
                return;
            }

            #region Write to CSV

            string Path = $"{BZ_ParPath}ParXlsx\\Users.csv";
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                strLine = i > 0 ? $"{strLine},{dataGridView1.Columns[i].HeaderText}" : dataGridView1.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    strData = j > 0
                        ? $"{strData},{dataGridView1.Rows[i].Cells[j].Value.ToString().Trim()}"
                        : dataGridView1.Rows[i].Cells[j].Value.ToString().Trim();
                    ResetDataGrid(i, j);
                }

                DataSave.Instance.CSVWrite($"{BZ_ParPath}ParXlsx\\", strData, strLine, "Users.csv");
            }

            #endregion Write to CSV

            MessageBox.Show("Save OK", "Meaasge");

            #region 刷新用户

            refreshUserMessage();

            #endregion 刷新用户
        }

        public bool CheckUsers(List<string[]> Data)
        {
            try
            {
                #region Check UID

                CardIDError.Clear();
                StationError.Clear();
                List<string[]> User_UID = new List<string[]>();
                User_UID.Clear();
                bool result = false;
                for (int i = 0; i < Data.Count; i++)
                {
                    string site = Data[i][index_Site];
                    string Project = Data[i][index_Project];
                    string Vendor_Name = Data[i][index_Vendor_Name];
                    string Card_UID = Data[i][index_Card_UID];
                    string Process_Station_ID = Data[i][index_Process_Station_ID];
                    string[] temp = new string[] { site, Project, Vendor_Name, Card_UID, Process_Station_ID };
                    if (User_UID.Count == 0)
                    {
                        User_UID.Add(temp);
                    }
                    else
                    {
                        foreach (string[] element in User_UID)       //遍历
                        {
                            if (element[3] == temp[3] && element[4] == temp[4])
                            {
                                //MessageBox.Show("用户卡号" + temp[3] + "重复，请确认", "User Manager");
                                result = true;
                                if (!CardIDError.ContainsKey(i) && !CardIDError.ContainsKey(User_UID.IndexOf(element)))
                                {
                                    CardIDError.Add(i, index_Card_UID);
                                    CardIDError.Add(User_UID.IndexOf(element), index_Card_UID);
                                }
                                if (!StationError.ContainsKey(i) && !StationError.ContainsKey(User_UID.IndexOf(element)))
                                {
                                    StationError.Add(i, index_Process_Station_ID);
                                    StationError.Add(User_UID.IndexOf(element), index_Process_Station_ID);
                                }
                            }
                            else
                            {
                                if (i < dataGridView1.Rows.Count)
                                {
                                    ResetDataGrid(i, index_Card_UID);
                                    ResetDataGrid(i, index_Process_Station_ID);
                                }
                                if (User_UID.IndexOf(element) < dataGridView1.Rows.Count)
                                {
                                    ResetDataGrid(User_UID.IndexOf(element), index_Card_UID);
                                    ResetDataGrid(User_UID.IndexOf(element), index_Process_Station_ID);
                                }
                            }
                        }
                        if (!result)
                        {
                            User_UID.Add(temp);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERR");
                return true;
            }

            #endregion Check UID
        }

        public bool CheckImportUser(List<string[]> Data, out string CardID)
        {
            try
            {
                CardID = string.Empty;

                User_InportUID.Clear();
                bool result = false;
                for (int i = 0; i < Data.Count; i++)
                {
                    string site = Data[i][index_Site];
                    string Project = Data[i][index_Project];
                    string Vendor_Name = Data[i][index_Vendor_Name];
                    string Name = Data[i][index_Name];
                    string Access_Level = Data[i][index_Access_Level];
                    string Card_UID = Data[i][index_Card_UID];
                    string Function = Data[i][index_Function];
                    string Process_Station_ID = Data[i][index_Process_Station_ID];
                    string[] temp = new string[] { site, Project, Vendor_Name, Name, Access_Level, Card_UID, Function, Process_Station_ID };
                    if (User_InportUID.Count == 0)
                    {
                        User_InportUID.Add(temp);
                    }
                    else
                    {
                        foreach (string[] element in User_InportUID)       //遍历
                        {
                            if (element[5] == temp[5] && element[7] == temp[7])
                            {
                                if (CardID != string.Empty)
                                {
                                    if (!CardID.Contains(temp[5]))
                                    {
                                        CardID = $"{CardID};{temp[5]}";
                                    }
                                }
                                else
                                {
                                    CardID = temp[5];
                                }
                                result = true;
                            }
                        }
                        if (!result)
                        {
                            User_InportUID.Add(temp);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);

                CardID = string.Empty;
                return true;
            }
        }

        private List<string[]> readCSVFile(string csvPath)
        {
            try
            {
                List<string[]> csvData = new List<string[]>();
                using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csvPath, Encoding.GetEncoding("gb2312")))
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

                return csvData;
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);

                return null;
            }
        }

        private void refreshUserMessage()
        {
            try
            {
                AudioLoginManager.Instance.loginData.AllAccount_List.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    AccountInfo ai = new AccountInfo
                    {
                        UserID = (string)dataGridView1[index_Card_UID, i].Value,
                        UserName = (string)dataGridView1[index_Name, i].Value,
                        EmployeeID = (string)dataGridView1[index_Function, i].Value,
                        Password = "********"
                    };
                    LoginLevel ll = LoginLevel.NoLogin;
                    string temsStr = (string)dataGridView1[index_Access_Level, i].Value;
                    ai.index_Process_Station_ID = (string)dataGridView1[index_Process_Station_ID, i].Value;
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
                    AudioLoginManager.Instance.loginData.AllAccount_List.Add(ai);
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);

                MessageBox.Show("用户更新失败", "ERR");
            }
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            btn_Delete.Visible = false;

            if (this.Created && !this.DesignMode)
            {
                List<string[]> csvData = readCSVFile(path_user);
                if (csvData != null)
                {
                    RefreshDGV(csvData);
                }
            }
        }

        public void ButtonShow(bool values = true)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (!values)
                {
                    btn_Import.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = false;
                    dataGridView1.Enabled = false;
                }
                else
                {
                    if (AudioLoginManager.Instance.LoggedInAccount.UserLevel >= LoginLevel.Level1)
                    {
                        btn_Import.Visible = false;
                        btn_Edit.Visible = false;
                        btn_Save.Visible = false;
                    }
                    if (AudioLoginManager.Instance.LoggedInAccount.UserLevel >= LoginLevel.Level2)
                    {
                        btn_Import.Visible = true;
                        btn_Edit.Visible = false;
                        btn_Save.Visible = false;
                    }
                    if (AudioLoginManager.Instance.LoggedInAccount.UserLevel >= LoginLevel.Level3)
                    {
                        btn_Import.Visible = true;
                        btn_Edit.Visible = true;
                        btn_Save.Visible = true;
                    }
                }
            }));
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
        }
    }
}