using System;
using System.Windows.Forms;
using 运动模块;

namespace BoTech
{
    public partial class Form1 : Form
    {
        #region 单例

        private static Form1 mInstance;

        public static Form1 Instance => mInstance ?? (mInstance = new Form1());

        #endregion 单例

        public Form1() => InitializeComponent();

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}