using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BoTech
{
    public partial class CriticalPameterDashBoard : UserControl
    {
        public CriticalPameterDashBoard()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(211, 211, 211);
            this.dataGridView1.BackgroundColor = Color.FromArgb(211, 211, 211);
        }

        #region 属性

        [Description("数据源")]
        public DataTable DataSourceTable { get; set; }

        [Description("要显示的列")]
        public int[] ShowColumn { get; set; }

        #endregion 属性

        #region 方法

        #endregion 方法
    }
}