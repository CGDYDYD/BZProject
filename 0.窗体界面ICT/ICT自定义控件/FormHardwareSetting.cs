using System;
using System.Windows.Forms;

namespace BoTech
{
    public partial class FormHardwareSetting : Form
    {
        public FormHardwareSetting()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            SettingPage.Instance.BeginInvoke(new Action(() => SettingPage.Instance.btn_GeneralSave_Click()));
            if (!string.IsNullOrEmpty(SettingPage.Instance.cbStation.Text))
            {
                GlobalVar.SCUD机种名 = SettingPage.Instance.cbStation.Text;
            }
            GlobalVar.ProductType = SettingPage.Instance.comboBox1.Text;
            this.Dispose();
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}