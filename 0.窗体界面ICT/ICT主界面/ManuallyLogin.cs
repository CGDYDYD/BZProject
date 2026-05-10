using System;
using System.Windows.Forms;

namespace BoTech
{
    public partial class ManuallyLogin : Form
    {
        public ManuallyLogin(string strTitle)
        {
            InitializeComponent();
            labTitle.Text = strTitle;
            this.StartPosition = FormStartPosition.CenterScreen;
            txtName.Focus();
            this.TopMost = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("工号不能为空！请扫码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            this.DialogResult = DialogResult.OK;
            GlobalVar.loginUser.Badage = txtName.Text; //GlobalVar.strBadge;

            this.Close();
            this.Dispose();
        }

        private void ManuallyLogin_Load(object sender, EventArgs e)
        {
            InitBarcode();
            txtName.ReadOnly = false;//true
            this.Focus();
        }

        private readonly BardCodeHooK _barCode = new BardCodeHooK();

        private void InitBarcode()
        {
            _barCode.CardReadEvent += CardReader;
            _barCode.Start();
        }

        private void CardReader(string str) => this.Invoke(new Action(() => txtName.Text = str.Replace("\0", "")));

        private void ManuallyLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            _barCode.Stop();
        }
    }
}