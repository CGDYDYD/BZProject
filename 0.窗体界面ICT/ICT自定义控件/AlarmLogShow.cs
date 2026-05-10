using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BoTech
{
    public partial class AlarmLogShow : UserControl
    {
        public AlarmLogShow()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(211, 211, 211);
            this.dataGridView1.BackgroundColor = Color.FromArgb(211, 211, 211);
        }

        [Description("控件刷新完事件")]
        public event Action<DataTable> Refreshed_event;

        #region 属性

        [Description("数据源")]
        public DataTable DataSourceTable { get; set; }

        [Description("要显示的列")]
        public int[] ShowColumn { get; set; }

        [Description("报错信息")]
        public string ErrorMessage { get; private set; }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 有源刷新
        /// </summary>
        /// <param name="SourceData">数据源</param>
        public void Refresh(DataTable SourceData)
        {
            InternalDGVRefresh(SourceData);
        }

        private void InternalDGVRefresh(DataTable SourceData)
        {
            try
            {
                DataTable tem = new DataTable();
                if (ShowColumn == null || ShowColumn.Length < 4)
                {
                    tem = SourceData;
                }
                else
                {
                    for (int i = 0; i < ShowColumn.Length; i++)
                    {
                        DataColumn dc1 = new DataColumn(SourceData.Columns[ShowColumn[i]].Caption, SourceData.Columns[ShowColumn[i]].DataType);
                        tem.Columns.Add(dc1);
                    }
                    for (int i = 0; i < SourceData.Rows.Count; i++)
                    {
                        tem.Rows.Add(tem.NewRow());
                        for (int j = 0; j < ShowColumn.Length; j++)
                        {
                            tem.Rows[i][j] = SourceData.Rows[i][ShowColumn[j]];
                        }
                    }
                }
                dataGridView1.DataSource = tem;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToOrderColumns = false;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.ScrollBars = ScrollBars.Vertical;
                dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(211, 211, 211);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 211, 211);
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ClearSelection();
                ErrorMessage = "";
                Refreshed_event?.Invoke(SourceData);
            }
            catch (Exception e)
            {
                ErrorMessage = e.ToString();
            }
        }

        #endregion 方法

        #region 事件

        #endregion 事件
    }
}