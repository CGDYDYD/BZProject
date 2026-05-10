using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BoTech
{
    public partial class MachineErrorStatistics : UserControl
    {
        #region 变量

        private static List<ErrorStatistics> _listError = new List<ErrorStatistics>();
        private const int Top10Error = 10;
        private Color ControlColor = Color.FromArgb(211, 211, 211);//控件背景色；
        private DateTime _BarEndTime;

        [Description("控件刷新完事件")]
        public Action<DataTable> Refreshed_event;

        [Description("BarValueChange事件")]
        public event Action<DateTime, DateTime> DoubleTrackValueChange;

        private struct ErrorStatistics
        {
            public string ErrorCode;
            public double ErrorNum;
        }

        #endregion 变量

        #region 属性；

        [Description("数据源")]
        public DataTable DataSourceTable { get; set; }

        [Description("报错信息")]
        public string ErrorMessage { get; private set; }

        [Description("最新时间")]
        public DateTime DoubleBarCurrentTime
        {
            get
            {
                if (_BarEndTime.ToString(DateTimeFormate).Contains("0001"))
                {
                    _BarEndTime = DateTime.Now;
                }
                return _BarEndTime;
            }
            set
            {
                _BarEndTime = value;
                this.doubleTrackBar1.DataTableNewestTime = _BarEndTime.ToString("MM/dd/yyyy HH:mm:ss");
            }
        }

        [Description("BarStart时间")]
        public DateTime TrackStartTime
        {
            get
            {
                dateTimePicker1.Text = this.doubleTrackBar1.DateStartValue1.AddSeconds(1).ToString(DateTimeFormate);
                return this.doubleTrackBar1.DateStartValue1;
            }
            set
            {
                if (dateTimePicker1.Value >= DoubleBarCurrentTime.AddDays(-7) && dateTimePicker1.Value <= TrackEndTime)
                {
                    this.doubleTrackBar1.DateStartValue1 = dateTimePicker1.Value;
                }
            }
        }

        [Description("BarEndtime时间")]
        public DateTime TrackEndTime
        {
            get
            {
                dateTimePicker2.Text = this.doubleTrackBar1.DateEndValue2.ToString(DateTimeFormate);
                return this.doubleTrackBar1.DateEndValue2;
            }
            set
            {
                if (dateTimePicker2.Value < dateTimePicker1.Value || dateTimePicker2.Value > DoubleBarCurrentTime)
                {
                    dateTimePicker2.Value = DoubleBarCurrentTime;
                    this.doubleTrackBar1.DateEndValue2 = DoubleBarCurrentTime;
                }
                else
                {
                    dateTimePicker2.Value = value;
                    this.doubleTrackBar1.DateEndValue2 = dateTimePicker2.Value;
                }
            }
        }

        public bool IsSelectTime
        {
            get; set;
        }

        [Description("Bar时间跨度，天")]
        public int CheckDays
        {
            get => this.doubleTrackBar1.CheckDays;
            set => this.doubleTrackBar1.CheckDays = value;
        }

        #endregion 属性；

        public MachineErrorStatistics()
        {
            InitializeComponent();
            this.chart1.BackColor = ControlColor;
            this.chart1.ChartAreas[0].BackColor = ControlColor;
            this.doubleTrackBar1.Value1Changed += DoubleTrackChange;
            this.doubleTrackBar1.Value2Changed += DoubleTrackChange;

            this.doubleTrackBar1.UpdateDT += UpdateDTPick;
        }

        #region 方法

        private const string DateTimeFormate = "MM/dd/yyyy HH:mm:ss";//定义时间格式；

        public void UpdateDTPick(DateTime dtStart, DateTime dtEnd)
        {
            dateTimePicker1.Text = dtStart.ToString(DateTimeFormate);
            dateTimePicker2.Text = dtEnd.ToString(DateTimeFormate);
        }

        /// <summary>
        /// 有源刷新
        /// </summary>
        /// <param name="SourceData">数据源</param>
        public void Refresh(DataTable SourceData)
        {
            this.DataSourceTable = SourceData;
            InternalRefreshChart(DataSourceTable);
        }

        /// <summary>
        /// 内部刷新表格；
        /// </summary>
        private void InternalRefreshChart(DataTable SourceData)
        {
            chart1.Series[0].Points.Clear();
            if (_listError.Count > 0)
            {
                _listError.Clear();
            }

            if (SourceData == null || SourceData.Rows.Count == 0)
            {
                //数据表为空；
                return;
            }
            try
            {
                for (int i = 0; i < SourceData.Rows.Count; i++)
                {
                    ErrorStatistics es = new ErrorStatistics
                    {
                        ErrorCode = SourceData.Rows[i][0].ToString(),//日期
                        ErrorNum = double.Parse(SourceData.Rows[i][1].ToString())//值；
                    };

                    _listError.Add(es);
                }

                for (int i = 0; i < Top10Error; i++)
                {
                    string key;
                    double value;
                    if (i < _listError.Count)
                    {
                        value = double.Parse(_listError[i].ErrorNum.ToString("F2"));
                        key = value == 0 ? "-" : _listError[i].ErrorCode;
                        chart1.Series[0].Points.AddXY(key, value);
                    }
                }

                Refreshed_event?.Invoke(DataSourceTable);
                ErrorMessage = "";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
            }
        }

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);

            IsSelectTime = false;
        }

        private void DoubleTrackChange()
        {
            DoubleTrackValueChange?.Invoke(this.doubleTrackBar1.DateStartValue1, this.doubleTrackBar1.DateEndValue2);
        }

        #endregion 方法

        public event Action<DateTime, DateTime> UpdateMachineErrorEvent;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtTemp = dateTimePicker1.Value;
            if (dtTemp <= doubleTrackBar1.DateEndValue2 && dtTemp >= DoubleBarCurrentTime.AddDays(7.5))
            {
                doubleTrackBar1.DateStartValue1 = dateTimePicker1.Value;
                UpdateMachineErrorEvent?.Invoke(doubleTrackBar1.DateStartValue1, doubleTrackBar1.DateEndValue2);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtTemp = dateTimePicker2.Value;
            if (dtTemp <= DoubleBarCurrentTime && dtTemp >= doubleTrackBar1.DateStartValue1)
            {
                doubleTrackBar1.DateEndValue2 = dateTimePicker2.Value;
                UpdateMachineErrorEvent?.Invoke(doubleTrackBar1.DateStartValue1, doubleTrackBar1.DateEndValue2);
            }
        }

        private void dateTimePicker2_Enter(object sender, EventArgs e)
        {
            IsSelectTime = true;
        }
    }
}