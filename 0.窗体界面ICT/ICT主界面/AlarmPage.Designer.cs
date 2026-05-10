namespace BoTech
{
    partial class AlarmPage
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Query = new System.Windows.Forms.Button();
            this.dTP_EndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dTP_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.alarmLogShow1 = new BoTech.AlarmLogShow();
            this.alarm_Duration1 = new BoTech.Alarm_Duration();
            this.dT_Statiistic1 = new BoTech.DT_Statiistic();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(785, 9);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(84, 29);
            this.btn_Save.TabIndex = 12;
            this.btn_Save.Text = "Save All";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(703, 9);
            this.btn_Query.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(76, 29);
            this.btn_Query.TabIndex = 11;
            this.btn_Query.Text = "Query";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // dTP_EndTime
            // 
            this.dTP_EndTime.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.dTP_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTP_EndTime.Location = new System.Drawing.Point(493, 10);
            this.dTP_EndTime.Margin = new System.Windows.Forms.Padding(4);
            this.dTP_EndTime.Name = "dTP_EndTime";
            this.dTP_EndTime.ShowUpDown = true;
            this.dTP_EndTime.Size = new System.Drawing.Size(201, 25);
            this.dTP_EndTime.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(357, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Time:";
            // 
            // dTP_StartTime
            // 
            this.dTP_StartTime.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.dTP_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTP_StartTime.Location = new System.Drawing.Point(145, 10);
            this.dTP_StartTime.Margin = new System.Windows.Forms.Padding(4);
            this.dTP_StartTime.Name = "dTP_StartTime";
            this.dTP_StartTime.ShowUpDown = true;
            this.dTP_StartTime.Size = new System.Drawing.Size(201, 25);
            this.dTP_StartTime.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start Time:";
            // 
            // alarmLogShow1
            // 
            this.alarmLogShow1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.alarmLogShow1.DataSourceTable = null;
            this.alarmLogShow1.Location = new System.Drawing.Point(7, 429);
            this.alarmLogShow1.Margin = new System.Windows.Forms.Padding(5);
            this.alarmLogShow1.Name = "alarmLogShow1";
            this.alarmLogShow1.ShowColumn = null;
            this.alarmLogShow1.Size = new System.Drawing.Size(1333, 350);
            this.alarmLogShow1.TabIndex = 4;
            // 
            // alarm_Duration1
            // 
            this.alarm_Duration1.AD_Label = null;
            this.alarm_Duration1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.alarm_Duration1.ColumnColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(127)))), ((int)(((byte)(126)))));
            this.alarm_Duration1.DataSourceTable = null;
            this.alarm_Duration1.Location = new System.Drawing.Point(673, 49);
            this.alarm_Duration1.Margin = new System.Windows.Forms.Padding(5);
            this.alarm_Duration1.Name = "alarm_Duration1";
            this.alarm_Duration1.Size = new System.Drawing.Size(667, 375);
            this.alarm_Duration1.TabIndex = 1;
            // 
            // dT_Statiistic1
            // 
            this.dT_Statiistic1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.dT_Statiistic1.DataSourceTable = null;
            this.dT_Statiistic1.DT_Label = null;
            this.dT_Statiistic1.ErrorMessage = null;
            this.dT_Statiistic1.Location = new System.Drawing.Point(0, 49);
            this.dT_Statiistic1.Margin = new System.Windows.Forms.Padding(5);
            this.dT_Statiistic1.Name = "dT_Statiistic1";
            this.dT_Statiistic1.PieStyle = BoTech.PieStyles.Time;
            this.dT_Statiistic1.Size = new System.Drawing.Size(667, 375);
            this.dT_Statiistic1.TabIndex = 0;
            this.dT_Statiistic1.Top10 = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(121)))), ((int)(((byte)(128))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(151)))), ((int)(((byte)(193))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(172)))), ((int)(((byte)(122))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(195)))), ((int)(((byte)(92))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(150)))), ((int)(((byte)(91))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(94)))), ((int)(((byte)(105))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(114)))), ((int)(((byte)(187))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(170)))), ((int)(((byte)(233))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(217)))), ((int)(((byte)(56))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(72)))), ((int)(((byte)(134)))))};
            // 
            // AlarmPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Query);
            this.Controls.Add(this.dTP_EndTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dTP_StartTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.alarmLogShow1);
            this.Controls.Add(this.alarm_Duration1);
            this.Controls.Add(this.dT_Statiistic1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AlarmPage";
            this.Size = new System.Drawing.Size(1344, 781);
            this.Tag = "2";
            this.Load += new System.EventHandler(this.AlarmPage_Load);
            this.VisibleChanged += new System.EventHandler(this.AlarmPage_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DT_Statiistic dT_Statiistic1;
        private Alarm_Duration alarm_Duration1;
        private AlarmLogShow alarmLogShow1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dTP_StartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DateTimePicker dTP_EndTime;
    }
}
