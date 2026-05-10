using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BoTech
{
    public partial class Alarm_Duration : UserControl
    {
        public Alarm_Duration()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(211, 211, 211);
            this.Chart_Duration.ChartAreas[0].BackColor = Color.Transparent;
            this.Chart_Duration.BackColor = Color.Transparent;
            this.ColumnColor = Color.FromArgb(239, 127, 126);
        }

        private string _adLabel;

        [Description("控件刷新完事件")]
        public event Action<DataTable> Refreshed_event;

        #region 属性

        [Description("数据源")]
        public DataTable DataSourceTable { get; set; }

        [Description("条形图条颜色")]
        public Color ColumnColor { get; set; }

        [Description("报错信息")]
        public string ErrorMessage { get; private set; }

        [Description("控件标签名")]
        public string AD_Label
        {
            get => _adLabel;
            set
            {
                if (value?.Length > 5)
                {
                    _adLabel = value;
                    this.label1.Text = value;
                }
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 有源刷新
        /// </summary>
        /// <param name="SourceData">数据源</param>
        public void Refresh(DataTable SourceData)
        {
            this.DataSourceTable = SourceData;
            InternalRefreshChart(DataSourceTable);
        }

        private void InternalRefreshChart(DataTable SourceData)
        {
            try
            {
                DataTable Tem = new DataTable();
                DataColumn dc = new DataColumn("Alarm Duration", typeof(string));
                DataColumn dc1 = new DataColumn("Count Total", typeof(int));
                Tem.Columns.Add(dc);
                Tem.Columns.Add(dc1);
                string[] temStr = new string[] { "0-4", "5-9", "10-14", "15-19", "20-24", "25+" };
                int[] temint = new int[6];
                for (int i = 0; i < SourceData.Rows.Count; i++)
                {
                    int tt = (int)SourceData.Rows[i][0];
                    if (tt >= 0 && tt < 5)
                    {
                        temint[0] += Convert.ToInt32(SourceData.Rows[i][1]);
                    }
                    else if (tt < 10)
                    {
                        temint[1] += Convert.ToInt32(SourceData.Rows[i][1]);
                    }
                    else if (tt < 15)
                    {
                        temint[2] += Convert.ToInt32(SourceData.Rows[i][1]);
                    }
                    else if (tt < 20)
                    {
                        temint[3] += Convert.ToInt32(SourceData.Rows[i][1]);
                    }
                    else if (tt < 25)
                    {
                        temint[4] += Convert.ToInt32(SourceData.Rows[i][1]);
                    }
                    else
                    {
                        temint[5] += Convert.ToInt32(SourceData.Rows[i][1]);
                    }
                }
                for (int i = 0; i < temint.Length; i++)
                {
                    Tem.Rows.Add(Tem.NewRow());
                    Tem.Rows[i][0] = temStr[i];
                    Tem.Rows[i][1] = temint[i];
                }

                #region Chart

                Chart_Duration.Series[0].IsVisibleInLegend = false;
                Chart_Duration.Series[0].Points.Clear();
                for (int i = 0; i < Tem.Rows.Count; i++)
                {
                    DataPoint dp = new DataPoint();

                    double temD = (int)Tem.Rows[i][1];
                    dp.YValues = new double[] { temD };
                    dp.Label = ((int)Tem.Rows[i][1]).ToString();
                    dp.AxisLabel = (string)Tem.Rows[i][0];

                    dp.Color = ColumnColor;
                    Chart_Duration.Series[0].Points.Add(dp);
                }
                Chart_Duration.Series[0]["LabelStyle"] = "Bottom";
                Chart_Duration.Series[0].LabelForeColor = Color.White;
                Chart_Duration.Series[0].Font = new Font("Times New Roman", 16f);

                //调整网格线

                #endregion Chart

                Refreshed_event?.Invoke(DataSourceTable);
                ErrorMessage = "";
            }
            catch (Exception e)
            {
                ErrorMessage = e.ToString();
            }
        }

        #endregion 方法
    }
}