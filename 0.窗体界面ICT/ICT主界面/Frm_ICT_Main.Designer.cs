namespace BoTech
{
    partial class Frm_ICT_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ICT_Main));
            this.label1 = new System.Windows.Forms.Label();
            this.Main_ChildPage = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Btn_Vision = new BoTech.AudioButton();
            this.Btn_Home = new BoTech.AudioButton();
            this.Btn_Config = new BoTech.AudioButton();
            this.Btn_Alarm = new BoTech.AudioButton();
            this.Btn_Setting = new BoTech.AudioButton();
            this.Btn_Data = new BoTech.AudioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Btn_ProductType = new BoTech.AudioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Login = new BoTech.AudioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.outLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Pause = new BoTech.AudioButton();
            this.Btn_Run = new BoTech.AudioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btn_Hive = new BoTech.AudioButton();
            this.Btn_Stop = new BoTech.AudioButton();
            this.Btn_Sensor = new BoTech.AudioButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(630, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 75);
            this.label1.TabIndex = 0;
            // 
            // Main_ChildPage
            // 
            this.Main_ChildPage.BackColor = System.Drawing.SystemColors.Control;
            this.Main_ChildPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_ChildPage.Location = new System.Drawing.Point(0, 3);
            this.Main_ChildPage.Name = "Main_ChildPage";
            this.Main_ChildPage.Size = new System.Drawing.Size(1512, 737);
            this.Main_ChildPage.TabIndex = 1;
            this.Main_ChildPage.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_ChildPage_Paint);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1512, 3);
            this.label3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Btn_Vision);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Btn_Home);
            this.panel2.Controls.Add(this.Btn_Config);
            this.panel2.Controls.Add(this.Btn_Alarm);
            this.panel2.Controls.Add(this.Btn_Setting);
            this.panel2.Controls.Add(this.Btn_Data);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 100);
            this.panel2.TabIndex = 0;
            // 
            // Btn_Vision
            // 
            this.Btn_Vision.Alarmed3 = null;
            this.Btn_Vision.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Vision.BackgroundImage = global::My.Resources.Resources.Vision_Energized;
            this.Btn_Vision.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Vision.ButtonEnable = true;
            this.Btn_Vision.DeEnergized2 = global::My.Resources.Resources.Vision_De_energized;
            this.Btn_Vision.Disabled0 = global::My.Resources.Resources.Vision_Disabled;
            this.Btn_Vision.Energized1 = global::My.Resources.Resources.Vision_Energized;
            this.Btn_Vision.FlatAppearance.BorderSize = 0;
            this.Btn_Vision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Vision.hiveAlarm5 = null;
            this.Btn_Vision.HiveEngineer4 = null;
            this.Btn_Vision.Location = new System.Drawing.Point(426, 15);
            this.Btn_Vision.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Vision.Name = "Btn_Vision";
            this.Btn_Vision.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Vision.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Vision.Radius = 11;
            this.Btn_Vision.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Vision.Size = new System.Drawing.Size(90, 96);
            this.Btn_Vision.TabIndex = 0;
            this.Btn_Vision.Tag = "相机";
            this.Btn_Vision.UseMouseOnOrLeave = true;
            this.Btn_Vision.UseVisualStyleBackColor = false;
            this.Btn_Vision.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn_Home
            // 
            this.Btn_Home.Alarmed3 = null;
            this.Btn_Home.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Home.BackgroundImage = global::My.Resources.Resources.Home_Energized;
            this.Btn_Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Home.ButtonEnable = true;
            this.Btn_Home.DeEnergized2 = global::My.Resources.Resources.Home_De_energized;
            this.Btn_Home.Disabled0 = global::My.Resources.Resources.Home_Disabled;
            this.Btn_Home.Energized1 = global::My.Resources.Resources.Home_Energized;
            this.Btn_Home.FlatAppearance.BorderSize = 0;
            this.Btn_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Home.hiveAlarm5 = null;
            this.Btn_Home.HiveEngineer4 = null;
            this.Btn_Home.Location = new System.Drawing.Point(14, 15);
            this.Btn_Home.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Home.Name = "Btn_Home";
            this.Btn_Home.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Home.OnMouseColor = System.Drawing.Color.White;
            this.Btn_Home.Radius = 11;
            this.Btn_Home.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Home.Size = new System.Drawing.Size(90, 96);
            this.Btn_Home.TabIndex = 0;
            this.Btn_Home.Tag = "主页";
            this.Btn_Home.UseMouseOnOrLeave = true;
            this.Btn_Home.UseVisualStyleBackColor = false;
            this.Btn_Home.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn_Config
            // 
            this.Btn_Config.Alarmed3 = null;
            this.Btn_Config.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Config.BackgroundImage = global::My.Resources.Resources.Config_Energized;
            this.Btn_Config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Config.ButtonEnable = true;
            this.Btn_Config.DeEnergized2 = global::My.Resources.Resources.Config_De_energized;
            this.Btn_Config.Disabled0 = global::My.Resources.Resources.Config_Disabled;
            this.Btn_Config.Energized1 = global::My.Resources.Resources.Config_Energized;
            this.Btn_Config.FlatAppearance.BorderSize = 0;
            this.Btn_Config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Config.hiveAlarm5 = null;
            this.Btn_Config.HiveEngineer4 = null;
            this.Btn_Config.Location = new System.Drawing.Point(219, 15);
            this.Btn_Config.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Config.Name = "Btn_Config";
            this.Btn_Config.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Config.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Config.Radius = 11;
            this.Btn_Config.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Config.Size = new System.Drawing.Size(90, 96);
            this.Btn_Config.TabIndex = 0;
            this.Btn_Config.Tag = "规格设置";
            this.Btn_Config.UseMouseOnOrLeave = true;
            this.Btn_Config.UseVisualStyleBackColor = false;
            this.Btn_Config.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn_Alarm
            // 
            this.Btn_Alarm.Alarmed3 = global::My.Resources.Resources.Alarm_Alerted;
            this.Btn_Alarm.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Alarm.BackgroundImage = global::My.Resources.Resources.Alarm_Energized;
            this.Btn_Alarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Alarm.ButtonEnable = true;
            this.Btn_Alarm.DeEnergized2 = global::My.Resources.Resources.Alarm_De_energized;
            this.Btn_Alarm.Disabled0 = global::My.Resources.Resources.Alarm_Disabled;
            this.Btn_Alarm.Energized1 = global::My.Resources.Resources.Alarm_Energized;
            this.Btn_Alarm.FlatAppearance.BorderSize = 0;
            this.Btn_Alarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Alarm.hiveAlarm5 = null;
            this.Btn_Alarm.HiveEngineer4 = null;
            this.Btn_Alarm.Location = new System.Drawing.Point(116, 15);
            this.Btn_Alarm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Alarm.Name = "Btn_Alarm";
            this.Btn_Alarm.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Alarm.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Alarm.Radius = 11;
            this.Btn_Alarm.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Alarm.Size = new System.Drawing.Size(90, 96);
            this.Btn_Alarm.TabIndex = 0;
            this.Btn_Alarm.Tag = "报警";
            this.Btn_Alarm.UseMouseOnOrLeave = true;
            this.Btn_Alarm.UseVisualStyleBackColor = false;
            this.Btn_Alarm.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn_Setting
            // 
            this.Btn_Setting.Alarmed3 = null;
            this.Btn_Setting.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Setting.BackgroundImage = global::My.Resources.Resources.Setting_Energized;
            this.Btn_Setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Setting.ButtonEnable = true;
            this.Btn_Setting.DeEnergized2 = global::My.Resources.Resources.Setting_De_energized;
            this.Btn_Setting.Disabled0 = global::My.Resources.Resources.Setting_Disabled;
            this.Btn_Setting.Energized1 = global::My.Resources.Resources.Setting_Energized;
            this.Btn_Setting.FlatAppearance.BorderSize = 0;
            this.Btn_Setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Setting.hiveAlarm5 = null;
            this.Btn_Setting.HiveEngineer4 = null;
            this.Btn_Setting.Location = new System.Drawing.Point(528, 15);
            this.Btn_Setting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Setting.Name = "Btn_Setting";
            this.Btn_Setting.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Setting.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Setting.Radius = 11;
            this.Btn_Setting.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Setting.Size = new System.Drawing.Size(90, 96);
            this.Btn_Setting.TabIndex = 0;
            this.Btn_Setting.Tag = "参数设置及调试";
            this.Btn_Setting.UseMouseOnOrLeave = true;
            this.Btn_Setting.UseVisualStyleBackColor = false;
            this.Btn_Setting.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn_Data
            // 
            this.Btn_Data.Alarmed3 = null;
            this.Btn_Data.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Data.BackgroundImage = global::My.Resources.Resources.Data_Energized;
            this.Btn_Data.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Data.ButtonEnable = true;
            this.Btn_Data.DeEnergized2 = global::My.Resources.Resources.Data_De_energized;
            this.Btn_Data.Disabled0 = global::My.Resources.Resources.Data_Disabled;
            this.Btn_Data.Energized1 = global::My.Resources.Resources.Data_Energized;
            this.Btn_Data.FlatAppearance.BorderSize = 0;
            this.Btn_Data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Data.hiveAlarm5 = null;
            this.Btn_Data.HiveEngineer4 = null;
            this.Btn_Data.Location = new System.Drawing.Point(321, 15);
            this.Btn_Data.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Data.Name = "Btn_Data";
            this.Btn_Data.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Data.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Data.Radius = 11;
            this.Btn_Data.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Data.Size = new System.Drawing.Size(90, 96);
            this.Btn_Data.TabIndex = 0;
            this.Btn_Data.Tag = "数据";
            this.Btn_Data.UseMouseOnOrLeave = true;
            this.Btn_Data.UseVisualStyleBackColor = false;
            this.Btn_Data.Click += new System.EventHandler(this.Btn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Btn_ProductType);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(16, 18, 16, 18);
            this.splitContainer1.Panel1MinSize = 5;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Main_ChildPage);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2MinSize = 5;
            this.splitContainer1.Size = new System.Drawing.Size(1512, 842);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // Btn_ProductType
            // 
            this.Btn_ProductType.Alarmed3 = null;
            this.Btn_ProductType.BackColor = System.Drawing.Color.Transparent;
            this.Btn_ProductType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_ProductType.ButtonEnable = true;
            this.Btn_ProductType.DeEnergized2 = null;
            this.Btn_ProductType.Disabled0 = null;
            this.Btn_ProductType.Energized1 = null;
            this.Btn_ProductType.FlatAppearance.BorderSize = 0;
            this.Btn_ProductType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ProductType.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ProductType.hiveAlarm5 = null;
            this.Btn_ProductType.HiveEngineer4 = null;
            this.Btn_ProductType.Location = new System.Drawing.Point(642, 15);
            this.Btn_ProductType.Margin = new System.Windows.Forms.Padding(4, 24, 4, 24);
            this.Btn_ProductType.Name = "Btn_ProductType";
            this.Btn_ProductType.NBackColor = System.Drawing.Color.Empty;
            this.Btn_ProductType.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_ProductType.Radius = 20;
            this.Btn_ProductType.RoundStyle = BoTech.AudioButton.RoundStyles.All;
            this.Btn_ProductType.Size = new System.Drawing.Size(214, 112);
            this.Btn_ProductType.TabIndex = 1;
            this.Btn_ProductType.Tag = "设备信息";
            this.Btn_ProductType.Text = "UA-B";
            this.Btn_ProductType.UseMouseOnOrLeave = false;
            this.Btn_ProductType.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.Btn_Login);
            this.panel3.Controls.Add(this.Btn_Pause);
            this.panel3.Controls.Add(this.Btn_Run);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.Btn_Hive);
            this.panel3.Controls.Add(this.Btn_Stop);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(861, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(651, 100);
            this.panel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(3, 75);
            this.label4.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(326, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 75);
            this.label2.TabIndex = 1;
            // 
            // Btn_Login
            // 
            this.Btn_Login.Alarmed3 = global::My.Resources.Resources.No_login;
            this.Btn_Login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Login.BackgroundImage = global::My.Resources.Resources.No_login;
            this.Btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Login.ButtonEnable = true;
            this.Btn_Login.ContextMenuStrip = this.contextMenuStrip1;
            this.Btn_Login.DeEnergized2 = global::My.Resources.Resources.Level1;
            this.Btn_Login.Disabled0 = global::My.Resources.Resources.Level2;
            this.Btn_Login.Energized1 = global::My.Resources.Resources.Level3;
            this.Btn_Login.FlatAppearance.BorderSize = 0;
            this.Btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Login.hiveAlarm5 = null;
            this.Btn_Login.HiveEngineer4 = null;
            this.Btn_Login.Location = new System.Drawing.Point(346, 18);
            this.Btn_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Login.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Login.Radius = 11;
            this.Btn_Login.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Login.Size = new System.Drawing.Size(214, 39);
            this.Btn_Login.TabIndex = 0;
            this.Btn_Login.UseMouseOnOrLeave = true;
            this.Btn_Login.UseVisualStyleBackColor = false;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outLoginToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 34);
            // 
            // outLoginToolStripMenuItem
            // 
            this.outLoginToolStripMenuItem.Name = "outLoginToolStripMenuItem";
            this.outLoginToolStripMenuItem.Size = new System.Drawing.Size(158, 30);
            this.outLoginToolStripMenuItem.Text = "out login";
            this.outLoginToolStripMenuItem.Click += new System.EventHandler(this.outLoginToolStripMenuItem_Click);
            // 
            // Btn_Pause
            // 
            this.Btn_Pause.Alarmed3 = null;
            this.Btn_Pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Pause.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Pause.BackgroundImage = global::My.Resources.Resources.Paused_Energized;
            this.Btn_Pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Pause.ButtonEnable = true;
            this.Btn_Pause.DeEnergized2 = global::My.Resources.Resources.Paused_De_energized;
            this.Btn_Pause.Disabled0 = global::My.Resources.Resources.Paused_Disabled;
            this.Btn_Pause.Energized1 = global::My.Resources.Resources.Paused_Energized;
            this.Btn_Pause.FlatAppearance.BorderSize = 0;
            this.Btn_Pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Pause.hiveAlarm5 = null;
            this.Btn_Pause.HiveEngineer4 = null;
            this.Btn_Pause.Location = new System.Drawing.Point(124, 15);
            this.Btn_Pause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Pause.Name = "Btn_Pause";
            this.Btn_Pause.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Pause.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Pause.Radius = 11;
            this.Btn_Pause.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Pause.Size = new System.Drawing.Size(90, 96);
            this.Btn_Pause.TabIndex = 0;
            this.Btn_Pause.Tag = "暂停";
            this.Btn_Pause.UseMouseOnOrLeave = true;
            this.Btn_Pause.UseVisualStyleBackColor = false;
            this.Btn_Pause.Click += new System.EventHandler(this.Btn_Pause_Click);
            // 
            // Btn_Run
            // 
            this.Btn_Run.Alarmed3 = null;
            this.Btn_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Run.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Run.BackgroundImage = global::My.Resources.Resources.Running_Energized;
            this.Btn_Run.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Run.ButtonEnable = true;
            this.Btn_Run.DeEnergized2 = global::My.Resources.Resources.Running_De_energized;
            this.Btn_Run.Disabled0 = global::My.Resources.Resources.Running_Disabled;
            this.Btn_Run.Energized1 = global::My.Resources.Resources.Running_Energized;
            this.Btn_Run.FlatAppearance.BorderSize = 0;
            this.Btn_Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Run.hiveAlarm5 = null;
            this.Btn_Run.HiveEngineer4 = null;
            this.Btn_Run.Location = new System.Drawing.Point(22, 15);
            this.Btn_Run.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Run.Name = "Btn_Run";
            this.Btn_Run.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Run.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Run.Radius = 11;
            this.Btn_Run.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Run.Size = new System.Drawing.Size(90, 96);
            this.Btn_Run.TabIndex = 0;
            this.Btn_Run.Tag = "启动";
            this.Btn_Run.UseMouseOnOrLeave = true;
            this.Btn_Run.UseVisualStyleBackColor = false;
            this.Btn_Run.Click += new System.EventHandler(this.Btn_Run_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::My.Resources.Resources.Audio_Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(566, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 90);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Btn_Hive
            // 
            this.Btn_Hive.Alarmed3 = global::My.Resources.Resources.HIVE_Engineering;
            this.Btn_Hive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Hive.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Hive.BackgroundImage = global::My.Resources.Resources.HIVE_Idle;
            this.Btn_Hive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Hive.ButtonEnable = true;
            this.Btn_Hive.DeEnergized2 = global::My.Resources.Resources.HIVE_Idle;
            this.Btn_Hive.Disabled0 = global::My.Resources.Resources.HIVE_Disabled;
            this.Btn_Hive.Energized1 = global::My.Resources.Resources.HIVE_Running;
            this.Btn_Hive.FlatAppearance.BorderSize = 0;
            this.Btn_Hive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Hive.hiveAlarm5 = global::My.Resources.Resources.HIVE_DT;
            this.Btn_Hive.HiveEngineer4 = global::My.Resources.Resources.HIVE_Plan_DT;
            this.Btn_Hive.Location = new System.Drawing.Point(346, 68);
            this.Btn_Hive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Hive.Name = "Btn_Hive";
            this.Btn_Hive.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Hive.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Hive.Radius = 11;
            this.Btn_Hive.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Hive.Size = new System.Drawing.Size(214, 42);
            this.Btn_Hive.TabIndex = 0;
            this.Btn_Hive.UseMouseOnOrLeave = true;
            this.Btn_Hive.UseVisualStyleBackColor = false;
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Alarmed3 = null;
            this.Btn_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Stop.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Stop.BackgroundImage = global::My.Resources.Resources.Stopped_Energized;
            this.Btn_Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Stop.ButtonEnable = true;
            this.Btn_Stop.DeEnergized2 = global::My.Resources.Resources.Stopped_De_energized;
            this.Btn_Stop.Disabled0 = global::My.Resources.Resources.Stopped_Disabled;
            this.Btn_Stop.Energized1 = global::My.Resources.Resources.Stopped_Energized;
            this.Btn_Stop.FlatAppearance.BorderSize = 0;
            this.Btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Stop.hiveAlarm5 = null;
            this.Btn_Stop.HiveEngineer4 = null;
            this.Btn_Stop.Location = new System.Drawing.Point(228, 15);
            this.Btn_Stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Stop.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Stop.Radius = 11;
            this.Btn_Stop.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Stop.Size = new System.Drawing.Size(90, 96);
            this.Btn_Stop.TabIndex = 0;
            this.Btn_Stop.Tag = "停止";
            this.Btn_Stop.UseMouseOnOrLeave = true;
            this.Btn_Stop.UseVisualStyleBackColor = false;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // Btn_Sensor
            // 
            this.Btn_Sensor.Alarmed3 = null;
            this.Btn_Sensor.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Sensor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Sensor.ButtonEnable = true;
            this.Btn_Sensor.DeEnergized2 = null;
            this.Btn_Sensor.Disabled0 = null;
            this.Btn_Sensor.Energized1 = null;
            this.Btn_Sensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Sensor.hiveAlarm5 = null;
            this.Btn_Sensor.HiveEngineer4 = null;
            this.Btn_Sensor.Location = new System.Drawing.Point(0, 0);
            this.Btn_Sensor.Name = "Btn_Sensor";
            this.Btn_Sensor.NBackColor = System.Drawing.Color.Empty;
            this.Btn_Sensor.OnMouseColor = System.Drawing.Color.Empty;
            this.Btn_Sensor.Radius = 0;
            this.Btn_Sensor.RoundStyle = BoTech.AudioButton.RoundStyles.None;
            this.Btn_Sensor.Size = new System.Drawing.Size(75, 23);
            this.Btn_Sensor.TabIndex = 0;
            this.Btn_Sensor.UseMouseOnOrLeave = true;
            this.Btn_Sensor.UseVisualStyleBackColor = false;
            // 
            // Frm_ICT_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 842);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ICT_Main";
            this.Tag = "0";
            this.Text = "Frm_ICT_Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ICT_Main_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ICT_Main_Load);
            this.Resize += new System.EventHandler(this.Frm_ICT_Main_Resize);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AudioButton Btn_Home;
        public AudioButton Btn_Alarm;
        public AudioButton Btn_Data;
        private AudioButton Btn_Setting;
        private AudioButton Btn_Config;
        private AudioButton Btn_Vision;
        public AudioButton Btn_Sensor;
        private System.Windows.Forms.PictureBox pictureBox1;
        public AudioButton Btn_Hive;
        private AudioButton Btn_Login;
        public System.Windows.Forms.Panel Main_ChildPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public AudioButton Btn_Pause;
        public AudioButton Btn_Run;
        public AudioButton Btn_Stop;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel3;
        public AudioButton Btn_ProductType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem outLoginToolStripMenuItem;
    }
}