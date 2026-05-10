using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BoTech
{
    public partial class DT_Statiistic : UserControl
    {
        public DT_Statiistic()
        {
            InitializeComponent();
            Top10_DefaultColor();
            this.BackColor = Color.FromArgb(211, 211, 211);
            Chart_DT.BackColor = Color.Transparent;
            Chart_DT.ChartAreas[0].BackColor = Color.Transparent;
            this.Chart_DT.MouseHover += Chart_DT_MouseHover;
        }

        private void Chart_DT_MouseHover(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < DataSourceTable.Rows.Count; i++)
                {
                    this.Chart_DT.Series[0].Points[i].ToolTip = $"{DataSourceTable.Rows[i].ItemArray[0]}";
                }
            }
            catch
            {
            }
        }

        private Color[] _top10;
        private string _dtLabel;

        [Description("控件刷新完事件")]
        public event Action<DataTable> Refreshed_event;

        #region 属性

        [Description("设置Top10颜色数组")]
        public Color[] Top10
        {
            get => _top10;
            set
            {
                if (value?.Length >= 10)
                {
                    _top10 = value;
                }
            }
        }

        [Description("设置数据源")]
        public DataTable DataSourceTable { get; set; }

        [Description("设置饼形图形式")]
        public PieStyles PieStyle { get; set; }

        [Description("内部错误信息")]
        public string ErrorMessage { get; set; }

        [Description("控件标签名")]
        public string DT_Label
        {
            get => _dtLabel;
            set
            {
                if (value?.Length > 5)
                {
                    _dtLabel = value;
                    this.label1.Text = value;
                }
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 有源刷新控件表格、扇图
        /// </summary>
        /// <param name="SourceData">数据表格</param>
        /// <param name="pieStyle">扇图数据源</param>
        public void Refresh(DataTable SourceData, PieStyles pieStyle = PieStyles.Time)
        {
            DataSourceTable = SourceData;
            InternalRefreshChartAndDGV(SourceData, pieStyle);
        }

        private void InternalRefreshChartAndDGV(DataTable SourceData, PieStyles pieStyle = PieStyles.Time)
        {
            double allTime = 0;
            int allCount = 0;
            try
            {
                DataTable Tem = new DataTable();     //数据转换数据表

                #region DataGrideView

                DataView dv = SourceData.DefaultView;
                dv.Sort = pieStyle == PieStyles.Time ? SourceData.Columns[1].Caption : SourceData.Columns[2].Caption;
                SourceData = dv.ToTable();
                DataColumn color = new DataColumn(" ", typeof(string));
                Tem.Columns.Add(color);

                for (int i = 0; i < SourceData.Columns.Count; i++)
                {
                    DataColumn dc1 = new DataColumn(SourceData.Columns[i].Caption, SourceData.Columns[i].DataType);
                    Tem.Columns.Add(dc1);
                }

                for (int i = 0; i < SourceData.Rows.Count; i++)
                {
                    allCount += Convert.ToInt32(SourceData.Rows[SourceData.Rows.Count - 1 - i][2]);
                    allTime += (double)SourceData.Rows[SourceData.Rows.Count - 1 - i][1];
                    Tem.Rows.Add(Tem.NewRow());
                    Tem.Rows[i][0] = null;
                    Tem.Rows[i][1] = SourceData.Rows[SourceData.Rows.Count - 1 - i][0];
                    Tem.Rows[i][2] = SourceData.Rows[SourceData.Rows.Count - 1 - i][1];
                    Tem.Rows[i][3] = SourceData.Rows[SourceData.Rows.Count - 1 - i][2];
                }
                Tem.Columns[1].ColumnName = "Error";
                Tem.Columns[2].ColumnName = "TotalTime (Min)";
                Tem.Columns[3].ColumnName = "Count Total";

                dataGridView1.DataSource = Tem;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToOrderColumns = false;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.ScrollBars = ScrollBars.None;
                dataGridView1.Enabled = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns[0].FillWeight = 10; //百分比列宽
                dataGridView1.Columns[1].FillWeight = 40;
                dataGridView1.Columns[2].FillWeight = 30;
                dataGridView1.Columns[3].FillWeight = 20;
                int sourceRows = Tem.Rows.Count;
                sourceRows = sourceRows > _top10.Length ? _top10.Length : sourceRows;
                for (int i = 0; i < sourceRows; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Style.BackColor = _top10[i];
                }

                dataGridView1.ClearSelection();

                #endregion DataGrideView

                #region ChartPie

                Chart_DT.Series[0].Points.Clear();
                Chart_DT.Series[0].ChartType = SeriesChartType.Pie;
                Chart_DT.Series[0].IsVisibleInLegend = false;
                Chart_DT.BackColor = Color.Transparent;

                for (int i = 0; i < Tem.Rows.Count; i++)
                {
                    DataPoint dp = new DataPoint();
                    if (pieStyle == PieStyles.Time)
                    {
                        double temD = Convert.ToDouble(Tem.Rows[i][2]);
                        dp.YValues = new double[] { temD };
                        dp.Label = $"{((allTime == 0) ? "0%" : $"{temD / allTime * 100:f0}%")}";
                    }
                    else
                    {
                        double temI = Convert.ToDouble(Tem.Rows[i][3]);
                        dp.YValues = new double[] { temI };
                        dp.Label = (allCount == 0) ? "0%" : $"{temI / allCount * 100:f0}%";
                    }
                    dp.Color = _top10[i];
                    Chart_DT.Series[0].Points.Add(dp);
                }

                Chart_DT.Series[0]["PieStartAngle"] = "270";  //设置起始角度
                Chart_DT.Series[0].LabelForeColor = Color.White;
                Chart_DT.Series[0].Font = new Font("Times New Roman", 16f);
                Chart_DT.BackColor = Color.Transparent;
                Chart_DT.ChartAreas[0].BackColor = Color.Transparent;

                #endregion ChartPie

                Refreshed_event?.Invoke(SourceData);
                ErrorMessage = "";
            }
            catch (Exception e)
            {
                ErrorMessage = e.ToString();
            }
        }

        #endregion 方法

        private void Top10_DefaultColor()
        {
            _top10 = new Color[10];
            _top10[0] = Color.FromArgb(111, 121, 128);
            _top10[1] = Color.FromArgb(84, 151, 193);
            _top10[2] = Color.FromArgb(83, 172, 122);
            _top10[3] = Color.FromArgb(248, 195, 92);
            _top10[4] = Color.FromArgb(243, 150, 91);
            _top10[5] = Color.FromArgb(228, 94, 105);
            _top10[6] = Color.FromArgb(125, 114, 187);
            _top10[7] = Color.FromArgb(76, 170, 233);
            _top10[8] = Color.FromArgb(102, 217, 56);
            _top10[9] = Color.FromArgb(194, 72, 134);
        }
    }

    public enum PieStyles
    {
        Time,
        Count,
    }
}