namespace BoTech
{
    partial class MachineErrorStatistics
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.doubleTrackBar1 = new DoubleTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Empty;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.LightGray;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Color = System.Drawing.Color.Tomato;
            series1.IsValueShownAsLabel = true;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(885, 370);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Machine Error Statistics(Top10)";
            this.chart1.Titles.Add(title1);
            this.chart1.DoubleClick += new System.EventHandler(this.chart1_DoubleClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("宋体", 8F);
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(385, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.Enter += new System.EventHandler(this.dateTimePicker2_Enter);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("宋体", 8F);
            this.dateTimePicker2.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(591, 7);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker2.TabIndex = 6;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            this.dateTimePicker2.Enter += new System.EventHandler(this.dateTimePicker2_Enter);
            // 
            // doubleTrackBar1
            // 
            this.doubleTrackBar1.AutoSize = false;
            this.doubleTrackBar1.CheckDays = 7;
            this.doubleTrackBar1.ControlHeight = 10;
            this.doubleTrackBar1.DataTableNewestTime = "08/14/2023 16:29:18";
            this.doubleTrackBar1.DateEndValue2 = new System.DateTime(2023, 8, 14, 16, 29, 18, 0);
            this.doubleTrackBar1.DateStartValue1 = new System.DateTime(2023, 8, 7, 16, 29, 18, 0);
            this.doubleTrackBar1.IsSlider2Enable = true;
            this.doubleTrackBar1.LabelPlaces = ((uint)(1u));
            this.doubleTrackBar1.Location = new System.Drawing.Point(387, 22);
            this.doubleTrackBar1.MinimumSize = new System.Drawing.Size(10, 10);
            this.doubleTrackBar1.Name = "doubleTrackBar1";
            this.doubleTrackBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.doubleTrackBar1.SelectTrackColor = System.Drawing.Color.DarkGray;
            this.doubleTrackBar1.Size = new System.Drawing.Size(404, 40);
            this.doubleTrackBar1.TabIndex = 4;
            this.doubleTrackBar1.Text = "doubleTrackBar1";
            this.doubleTrackBar1.TickColor = System.Drawing.Color.Black;
            this.doubleTrackBar1.TickCount = 5;
            this.doubleTrackBar1.TickLabelVisible = false;
            this.doubleTrackBar1.TrackBarFontSize = 8;
            this.doubleTrackBar1.TrackButtonClickColor = System.Drawing.Color.Green;
            this.doubleTrackBar1.TrackButtonColor1 = System.Drawing.Color.LightGray;
            this.doubleTrackBar1.TrackButtonColor2 = System.Drawing.Color.LightGray;
            this.doubleTrackBar1.TrackButtonSize = new System.Drawing.Size(12, 12);
            this.doubleTrackBar1.TrackColor = System.Drawing.Color.White;
            this.doubleTrackBar1.TrackSelectedMode = DoubleTrackBar.emTrackBarSelectedMode.Inner;
            this.doubleTrackBar1.Value1 = 0D;
            this.doubleTrackBar1.Value2 = 100D;
            // 
            // MachineErrorStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.doubleTrackBar1);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MachineErrorStatistics";
            this.Size = new System.Drawing.Size(885, 370);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private DoubleTrackBar doubleTrackBar1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}
