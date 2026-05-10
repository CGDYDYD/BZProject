using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BoTech
{
    public partial class MachineStateChanges : UserControl
    {
        #region 变量；

        [Description("控件刷新完事件")]
        public Action<DataTable> Refreshed_event;

        private Dictionary<string, double[]> _dicBarData = new Dictionary<string, double[]>();
        private const int DaysNum = 7; //保存7天的数据；
        private Color ControlColor = Color.FromArgb(211, 211, 211);//控件背景色；

        #endregion 变量；

        #region 属性；

        /// <summary>
        /// 设备状态数据表；
        /// </summary>
        [Description("数据源")]
        public DataTable DataSourceTable { get; set; }

        [Description("报错信息")]
        public string ErrorMessage { get; private set; }

        #endregion 属性；

        public MachineStateChanges()
        {
            InitializeComponent();

            this.chart1.BackColor = ControlColor;
            this.chart1.ChartAreas[0].BackColor = ControlColor;
            ChartSet();
            this.chart1.MouseHover += Chart1_MouseHover;
        }

        private void Chart1_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if (DataSourceTable != null)
                {
                    for (int i = 0; i < DataSourceTable.Rows.Count; i++)
                    {
                        string strValue = "";
                        for (int j = 0; j < DataSourceTable.Columns.Count; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    strValue += $"{DataSourceTable.Rows[i][j]}\r\n ";
                                    break;

                                case 1:
                                    strValue += $"Running:{Convert.ToDouble(DataSourceTable.Rows[i][j]):F2}&{Convert.ToDouble(DataSourceTable.Rows[i][j]) * 100 / 1440:F2}%\r\n";
                                    break;

                                case 2:
                                    strValue += $"Idle:{Convert.ToDouble(DataSourceTable.Rows[i][j]):F2}&{Convert.ToDouble(DataSourceTable.Rows[i][j]) * 100 / 1440:F2}%\r\n";
                                    break;

                                case 3:
                                    strValue += $"Engineering:{Convert.ToDouble(DataSourceTable.Rows[i][j]):F2}&{Convert.ToDouble(DataSourceTable.Rows[i][j]) * 100 / 1440:F2}%\r\n";
                                    break;

                                case 4:
                                    strValue += $"Planned_downtime:{Convert.ToDouble(DataSourceTable.Rows[i][j]):F2}&{Convert.ToDouble(DataSourceTable.Rows[i][j]) * 100 / 1440:F2}%\r\n";
                                    break;

                                case 5:
                                    strValue += $"Down:{Convert.ToDouble(DataSourceTable.Rows[i][j]):F2}&{Convert.ToDouble(DataSourceTable.Rows[i][j]) * 100 / 1440:F2}%";
                                    break;
                            }
                        }
                        this.chart1.Series[0].Points[i].ToolTip = strValue;
                        this.chart1.Series[1].Points[i].ToolTip = strValue;
                        this.chart1.Series[2].Points[i].ToolTip = strValue;
                        this.chart1.Series[3].Points[i].ToolTip = strValue;
                        this.chart1.Series[4].Points[i].ToolTip = strValue;
                    }
                }
            }
            catch { }
        }

        #region 方法：

        /// <summary>
        /// chart 坐标轴设置；
        /// </summary>
        private void ChartSet()
        {
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "0%";
            chart1.Series[0].Color = HiveColor.HiveColorRunning_Green;
            chart1.Series[1].Color = HiveColor.HiveColorIdle_Blue;
            chart1.Series[2].Color = HiveColor.HiveColorEngineering_Purple;
            chart1.Series[3].Color = HiveColor.HiveColorPlannedDT_Orange;
            chart1.Series[4].Color = HiveColor.HiveColorDowntime_Red;

            chart1.Series[0].Name = "Running";
            chart1.Series[1].Name = "Idle";
            chart1.Series[2].Name = "Engineering";
            chart1.Series[3].Name = "Planned_downtime";
            chart1.Series[4].Name = "Down";
            chart1.Legends.Add("Legends1");
            chart1.Legends[0].Docking = Docking.Top;
            chart1.Legends[0].BackColor = Color.Transparent;
        }

        /// <summary>
        /// 有源刷新
        /// </summary>
        /// <param name="SourceData">数据源</param>
        public void Refresh(DataTable SourceData)
        {
            this.DataSourceTable = SourceData;
            InternalRefreshChart();
        }

        private void InternalRefreshChart()
        {
            _dicBarData.Clear();
            double[] dTemp = new double[5] { 0, 0, 0, 0, 0 };
            int rowNum = DataSourceTable.Rows.Count;
            try
            {
                #region 读表处理；

                /*没有行数的情况；*/
                if (DataSourceTable.Rows.Count == 0)
                {
                    //假如一行数据都没有为空；那就空数据；
                    for (int i = 0; i < DaysNum; i++)
                    {
                        _dicBarData.Add(DateTime.Now.AddDays(1 - DaysNum + i).ToString(), dTemp);
                    }
                    return;
                }

                for (int i = 0; i < rowNum; i++)
                {
                    string key = DataSourceTable.Rows[i][0].ToString();//日期；
                    //第1/2/3/4/5列分别代表running/idle/Eng/PlannedDown/Down;
                    double[] db1 = new double[5];
                    for (int j = 1; j < DataSourceTable.Columns.Count; j++)
                    {
                        double d1 = 0.0;
                        double d2 = 0.0;
                        d1 = (double)DataSourceTable.Rows[i][j];
                        d2 = Math.Round(d1 / 1440, 3);
                        if (d2 > 1)
                        { d2 = 1; }
                        if (d2 < 0)
                        { d2 = 0; }
                        db1[j - 1] = d2;
                    }

                    double rowSum = 0;
                    rowSum = (double)DataSourceTable.Rows[i][1] + (double)DataSourceTable.Rows[i][2] + (double)DataSourceTable.Rows[i][3] + (double)DataSourceTable.Rows[i][4] + (double)DataSourceTable.Rows[i][5];

                    DateTime dtTemp2 = Convert.ToDateTime(key);

                    if (rowSum > 1440 && dtTemp2 < DateTime.Now.Date)
                    {
                        db1[0] = (double)DataSourceTable.Rows[i][1] / rowSum;
                        db1[1] = (double)DataSourceTable.Rows[i][2] / rowSum;
                        db1[2] = (double)DataSourceTable.Rows[i][3] / rowSum;
                        db1[3] = (double)DataSourceTable.Rows[i][4] / rowSum;
                        db1[4] = (double)DataSourceTable.Rows[i][5] / rowSum;
                    }
                    else if (rowSum <= 1440 && rowSum > 0 && dtTemp2 < DateTime.Now.Date)
                    {
                        db1[0] = (double)DataSourceTable.Rows[i][1] / 1440;
                        db1[2] = (double)DataSourceTable.Rows[i][3] / 1440;
                        db1[3] = (double)DataSourceTable.Rows[i][4] / 1440;
                        db1[4] = (double)DataSourceTable.Rows[i][5] / 1440;
                        db1[1] = (double)DataSourceTable.Rows[i][2] / 1440;
                    }
                    _dicBarData.Add(key, db1);
                }

                #endregion 读表处理；

                #region 图表显示

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                chart1.Series[3].Points.Clear();
                chart1.Series[4].Points.Clear();

                foreach (KeyValuePair<string, double[]> kvp in _dicBarData)
                {
                    chart1.Series[0].Points.AddXY(kvp.Key, kvp.Value[0]);
                    chart1.Series[1].Points.AddXY(kvp.Key, kvp.Value[1]);
                    chart1.Series[2].Points.AddXY(kvp.Key, kvp.Value[2]);
                    chart1.Series[3].Points.AddXY(kvp.Key, kvp.Value[3]);
                    chart1.Series[4].Points.AddXY(kvp.Key, kvp.Value[4]);
                }

                #endregion 图表显示

                Refreshed_event?.Invoke(DataSourceTable);
                ErrorMessage = "";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
            }
        }

        #endregion 方法：
    }

    /// <summary>
    /// hive 的五种颜色；
    /// </summary>
    public class HiveColor
    {
        /// <summary>
        /// running，绿色
        /// </summary>
        public static Color HiveColorRunning_Green = Color.FromArgb(211, 235, 115);

        /// <summary>
        /// idle,蓝色
        /// </summary>
        public static Color HiveColorIdle_Blue = Color.FromArgb(235, 255, 254);

        /// <summary>
        /// engineering,紫色
        /// </summary>
        public static Color HiveColorEngineering_Purple = Color.FromArgb(204, 171, 216);

        /// <summary>
        /// planned dt, 橘色
        /// </summary>
        public static Color HiveColorPlannedDT_Orange = Color.FromArgb(255, 215, 212);

        /// <summary>
        /// downtime,宕机
        /// </summary>
        public static Color HiveColorDowntime_Red = Color.FromArgb(235, 115, 115);
    }
}