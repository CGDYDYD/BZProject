using System;
using System.Windows.Forms;

namespace BoTech
{
    public partial class Login_Page : Form
    {
        public Login_Page(AudioLoginManager alm)
        {
            InitializeComponent();
            ALM = alm;
            if (ALM.GetCurrentLevel() > LoginLevel.NoLogin)
            {
                this.btnCancel.Visible = true;
                this.btnLogin.Visible = false;
            }
            else
            {
                this.btnCancel.Visible = false;
                this.btnLogin.Visible = true;
            }
        }

        private void Login_Page_Load(object sender, EventArgs e)
        {
            InitBarcode();
            txtUserID.ReadOnly = false;
            panel_PassWord.Visible = true;
            btnLogin.Enabled = true;
        }

        private void Login_Page_FormClosing(object sender, FormClosingEventArgs e)
        {
            _barCode.Stop();
        }

        private AudioLoginManager ALM;

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            if (ALM.CheckNameIsExists(txtUserID.Text.Trim(), out AccountInfo ai))
            {
                this.txtUserName.Text = ai.UserName;
                this.txtEmployeeID.Text = ai.EmployeeID;
                labLevel.Text = ai.UserLevel.ToString();
                btnLogin.Enabled = true;
            }
            else
            {
                this.txtUserName.Text = "";
                this.txtEmployeeID.Text = "";
                btnLogin.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ALM.LoginoutAccount();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ALM.LoginConfirmPassword(this.txtUserID.Text.Trim());
            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtEmployeeID.Text == "Vendor_OSS" && labLevel.Text == "LEVEL 3")
                {
                    txtEmployeeID.Text = "";
                    labLevel.Text = "NULL";
                    txtUserName.Text = "";
                    txtUserID.Text = "";
                    labSecondConfirm.Visible = true;
                    btnLogin.Enabled = false;
                }
                else
                {
                    ALM.LoginConfirmPassword(this.txtUserID.Text.Trim());
                    this.Close();
                }
            }
        }

        // 处理 IC刷卡信息************************************20230408 FLB*******************************************

        private readonly BardCodeHooK _barCode = new BardCodeHooK();

        private void InitBarcode()
        {
            _barCode.CardReadEvent += CardReader;
            _barCode.Start();
        }

        private void CardReader(string str)
        {
            this.Invoke(new Action(() => txtUserID.Text = str.Replace("\0", "")));
        }
    }
}