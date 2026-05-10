namespace BoTech
{
    partial class HomePage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.StatusRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.iO_Summary_NoSQL1 = new BoTech.IO_Summary_NoSQL();
            this.machineErrorStatistics1 = new BoTech.MachineErrorStatistics();
            this.machineStateChanges1 = new BoTech.MachineStateChanges();
            this.stn1 = new BoTech.STN();
            this.criticalPameterDashBoard1 = new BoTech.CriticalPameterDashBoard();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SplitList_LB = new System.Windows.Forms.SplitContainer();
            this.PictureBox25 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitList_LB)).BeginInit();
            this.SplitList_LB.Panel1.SuspendLayout();
            this.SplitList_LB.Panel2.SuspendLayout();
            this.SplitList_LB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusRefreshTimer
            // 
            this.StatusRefreshTimer.Enabled = true;
            this.StatusRefreshTimer.Interval = 5000;
            this.StatusRefreshTimer.Tick += new System.EventHandler(this.StatusRefreshTimer_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 647);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.iO_Summary_NoSQL1);
            this.tabPage1.Controls.Add(this.machineErrorStatistics1);
            this.tabPage1.Controls.Add(this.machineStateChanges1);
            this.tabPage1.Controls.Add(this.stn1);
            this.tabPage1.Controls.Add(this.criticalPameterDashBoard1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 621);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // iO_Summary_NoSQL1
            // 
            this.iO_Summary_NoSQL1.CT = null;
            this.iO_Summary_NoSQL1.Input_Output = null;
            this.iO_Summary_NoSQL1.Location = new System.Drawing.Point(669, 0);
            this.iO_Summary_NoSQL1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iO_Summary_NoSQL1.Name = "iO_Summary_NoSQL1";
            this.iO_Summary_NoSQL1.NGColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(93)))), ((int)(((byte)(87)))));
            this.iO_Summary_NoSQL1.OKColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(249)))), ((int)(((byte)(0)))));
            this.iO_Summary_NoSQL1.Pass_Fail = null;
            this.iO_Summary_NoSQL1.Size = new System.Drawing.Size(330, 200);
            this.iO_Summary_NoSQL1.SN = null;
            this.iO_Summary_NoSQL1.TabIndex = 8;
            this.iO_Summary_NoSQL1.UnitStatus = true;
            this.iO_Summary_NoSQL1.Yield = null;
            this.iO_Summary_NoSQL1.报警率 = null;
            // 
            // machineErrorStatistics1
            // 
            this.machineErrorStatistics1.BackColor = System.Drawing.Color.LightGray;
            this.machineErrorStatistics1.CheckDays = 7;
            this.machineErrorStatistics1.DataSourceTable = null;
            this.machineErrorStatistics1.DoubleBarCurrentTime = new System.DateTime(2023, 8, 22, 17, 19, 8, 49);
            this.machineErrorStatistics1.IsSelectTime = false;
            this.machineErrorStatistics1.Location = new System.Drawing.Point(2, 300);
            this.machineErrorStatistics1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.machineErrorStatistics1.Name = "machineErrorStatistics1";
            this.machineErrorStatistics1.Size = new System.Drawing.Size(664, 317);
            this.machineErrorStatistics1.TabIndex = 7;
            this.machineErrorStatistics1.TrackEndTime = new System.DateTime(2023, 8, 22, 17, 19, 8, 0);
            this.machineErrorStatistics1.TrackStartTime = new System.DateTime(2023, 8, 15, 17, 19, 8, 0);
            this.machineErrorStatistics1.Click += new System.EventHandler(this.machineErrorStatistics1_Click_1);
            // 
            // machineStateChanges1
            // 
            this.machineStateChanges1.DataSourceTable = null;
            this.machineStateChanges1.Location = new System.Drawing.Point(2, 1);
            this.machineStateChanges1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.machineStateChanges1.Name = "machineStateChanges1";
            this.machineStateChanges1.Size = new System.Drawing.Size(664, 295);
            this.machineStateChanges1.TabIndex = 5;
            // 
            // stn1
            // 
            this.stn1.BackColor = System.Drawing.Color.LightGray;
            this.stn1.HIVEConnected = false;
            this.stn1.Location = new System.Drawing.Point(669, 403);
            this.stn1.Main_SW_Path = "cfgvjhkbjlk";
            this.stn1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stn1.MESConnected = false;
            this.stn1.MS_Hash = "tdftgyhujlik;l84523613";
            this.stn1.Name = "stn1";
            this.stn1.PDCAConnected = false;
            this.stn1.SensorPageButtonVisible = false;
            this.stn1.SiteName = "XX";
            this.stn1.Size = new System.Drawing.Size(330, 211);
            this.stn1.stnBackColor = System.Drawing.Color.Empty;
            this.stn1.STNName = "STN# 01";
            this.stn1.SW_Version = "xxxxxxxxxxxxx";
            this.stn1.TabIndex = 2;
            this.stn1.Vender = "XX";
            // 
            // criticalPameterDashBoard1
            // 
            this.criticalPameterDashBoard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.criticalPameterDashBoard1.DataSourceTable = null;
            this.criticalPameterDashBoard1.Location = new System.Drawing.Point(669, 201);
            this.criticalPameterDashBoard1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.criticalPameterDashBoard1.Name = "criticalPameterDashBoard1";
            this.criticalPameterDashBoard1.ShowColumn = null;
            this.criticalPameterDashBoard1.Size = new System.Drawing.Size(330, 200);
            this.criticalPameterDashBoard1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 621);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(994, 615);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.SplitList_LB);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabPage4.Size = new System.Drawing.Size(986, 589);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "运行信息";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(714, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(208, 70);
            this.button7.TabIndex = 286;
            this.button7.Text = "mes信息";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(500, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 70);
            this.button4.TabIndex = 286;
            this.button4.Text = "Offset";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // SplitList_LB
            // 
            this.SplitList_LB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitList_LB.Font = new System.Drawing.Font("宋体", 9F);
            this.SplitList_LB.Location = new System.Drawing.Point(6, 5);
            this.SplitList_LB.Margin = new System.Windows.Forms.Padding(4);
            this.SplitList_LB.Name = "SplitList_LB";
            this.SplitList_LB.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitList_LB.Panel1
            // 
            this.SplitList_LB.Panel1.Controls.Add(this.PictureBox25);
            this.SplitList_LB.Panel1MinSize = 20;
            // 
            // SplitList_LB.Panel2
            // 
            this.SplitList_LB.Panel2.Controls.Add(this.splitContainer1);
            this.SplitList_LB.Panel2.Font = new System.Drawing.Font("宋体", 9F);
            this.SplitList_LB.Size = new System.Drawing.Size(462, 565);
            this.SplitList_LB.SplitterDistance = 40;
            this.SplitList_LB.SplitterWidth = 5;
            this.SplitList_LB.TabIndex = 285;
            // 
            // PictureBox25
            // 
            this.PictureBox25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox25.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox25.Image")));
            this.PictureBox25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox25.Location = new System.Drawing.Point(0, 0);
            this.PictureBox25.Name = "PictureBox25";
            this.PictureBox25.Size = new System.Drawing.Size(460, 38);
            this.PictureBox25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox25.TabIndex = 83;
            this.PictureBox25.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(462, 520);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 287;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 38);
            this.label4.TabIndex = 286;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(1008, 645);
            this.Tag = "1";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.SplitList_LB.Panel1.ResumeLayout(false);
            this.SplitList_LB.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitList_LB)).EndInit();
            this.SplitList_LB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox25)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private CriticalPameterDashBoard criticalPameterDashBoard1;
        private MachineStateChanges machineStateChanges1;
        private System.Windows.Forms.Timer StatusRefreshTimer;
        private MachineErrorStatistics machineErrorStatistics1;
        public STN stn1;
        private IO_Summary_NoSQL iO_Summary_NoSQL1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        internal System.Windows.Forms.SplitContainer SplitList_LB;
        internal System.Windows.Forms.PictureBox PictureBox25;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
    }
}
