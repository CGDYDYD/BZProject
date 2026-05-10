using System;
using System.Windows.Forms;

namespace BoTech
{
    public partial class FrmLogOut : Form
    {
        public FrmLogOut() => InitializeComponent();

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            if (AudioLoginManager.Instance.GetCurrentLevel() > LoginLevel.NoLogin)
            {
                AudioLoginManager.Instance.LoginoutAccount();
            }
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e) => this.Close();
    }
}