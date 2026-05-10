namespace LogsHelper
{
    partial class Frm_show
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
            this.info_name = new System.Windows.Forms.Label();
            this.btn_02 = new System.Windows.Forms.Button();
            this.btn_03 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_01 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // info_name
            // 
            this.info_name.AutoSize = true;
            this.info_name.Location = new System.Drawing.Point(48, 9);
            this.info_name.Name = "info_name";
            this.info_name.Size = new System.Drawing.Size(90, 21);
            this.info_name.TabIndex = 1;
            this.info_name.Text = "info_name";
            // 
            // btn_02
            // 
            this.btn_02.BackColor = System.Drawing.SystemColors.Control;
            this.btn_02.Location = new System.Drawing.Point(192, 225);
            this.btn_02.Name = "btn_02";
            this.btn_02.Size = new System.Drawing.Size(101, 39);
            this.btn_02.TabIndex = 3;
            this.btn_02.Text = "Stop";
            this.btn_02.UseVisualStyleBackColor = false;
            this.btn_02.Click += new System.EventHandler(this.btn_02_Click);
            // 
            // btn_03
            // 
            this.btn_03.BackColor = System.Drawing.SystemColors.Control;
            this.btn_03.Location = new System.Drawing.Point(367, 225);
            this.btn_03.Name = "btn_03";
            this.btn_03.Size = new System.Drawing.Size(101, 39);
            this.btn_03.TabIndex = 4;
            this.btn_03.Text = "Cancel";
            this.btn_03.UseVisualStyleBackColor = false;
            this.btn_03.Click += new System.EventHandler(this.btn_03_Click);
            // 
            // listBox1
            // 
            this.listBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listBox1.BackColor = System.Drawing.SystemColors.Control;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalExtent = 1000;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(17, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(454, 172);
            this.listBox1.TabIndex = 1;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // btn_01
            // 
            this.btn_01.BackColor = System.Drawing.SystemColors.Control;
            this.btn_01.Location = new System.Drawing.Point(21, 225);
            this.btn_01.Name = "btn_01";
            this.btn_01.Size = new System.Drawing.Size(101, 39);
            this.btn_01.TabIndex = 10;
            this.btn_01.Text = "Continue";
            this.btn_01.UseVisualStyleBackColor = false;
            this.btn_01.Click += new System.EventHandler(this.btn_01_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(17, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Frm_show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(487, 275);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_01);
            this.Controls.Add(this.info_name);
            this.Controls.Add(this.btn_03);
            this.Controls.Add(this.btn_02);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Frm_show";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_info";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_show_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Frm_show_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Frm_show_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label info_name;
        private System.Windows.Forms.Button btn_02;
        private System.Windows.Forms.Button btn_03;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_01;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}