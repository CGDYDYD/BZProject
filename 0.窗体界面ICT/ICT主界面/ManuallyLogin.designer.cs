namespace BoTech
{
    partial class ManuallyLogin
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
            this.labTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel_UserName = new System.Windows.Forms.Panel();
            this.btn_OK = new BoTech.AudioButton();
            this.btn_Cancel = new BoTech.AudioButton();
            this.panel_UserName.SuspendLayout();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.labTitle.Location = new System.Drawing.Point(29, 14);
            this.labTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(485, 52);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Lable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Operator：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(151, 21);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(253, 25);
            this.txtName.TabIndex = 2;
            // 
            // panel_UserName
            // 
            this.panel_UserName.Controls.Add(this.txtName);
            this.panel_UserName.Controls.Add(this.label2);
            this.panel_UserName.Location = new System.Drawing.Point(13, 166);
            this.panel_UserName.Margin = new System.Windows.Forms.Padding(4);
            this.panel_UserName.Name = "panel_UserName";
            this.panel_UserName.Size = new System.Drawing.Size(505, 58);
            this.panel_UserName.TabIndex = 10;
            // 
            // btn_OK
            // 
            this.btn_OK.Alarmed3 = null;
            this.btn_OK.BackColor = System.Drawing.Color.Transparent;
            this.btn_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OK.ButtonEnable = true;
            this.btn_OK.DeEnergized2 = null;
            this.btn_OK.Disabled0 = null;
            this.btn_OK.Energized1 = null;
            this.btn_OK.FlatAppearance.BorderSize = 0;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_OK.hiveAlarm5 = null;
            this.btn_OK.HiveEngineer4 = null;
            this.btn_OK.Location = new System.Drawing.Point(304, 352);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.NBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_OK.OnMouseColor = System.Drawing.Color.Empty;
            this.btn_OK.Radius = 10;
            this.btn_OK.RoundStyle = BoTech.AudioButton.RoundStyles.All;
            this.btn_OK.Size = new System.Drawing.Size(100, 29);
            this.btn_OK.TabIndex = 11;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseMouseOnOrLeave = false;
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Alarmed3 = null;
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancel.ButtonEnable = true;
            this.btn_Cancel.DeEnergized2 = null;
            this.btn_Cancel.Disabled0 = null;
            this.btn_Cancel.Energized1 = null;
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.hiveAlarm5 = null;
            this.btn_Cancel.HiveEngineer4 = null;
            this.btn_Cancel.Location = new System.Drawing.Point(93, 352);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.NBackColor = System.Drawing.Color.White;
            this.btn_Cancel.OnMouseColor = System.Drawing.Color.Empty;
            this.btn_Cancel.Radius = 10;
            this.btn_Cancel.RoundStyle = BoTech.AudioButton.RoundStyles.All;
            this.btn_Cancel.Size = new System.Drawing.Size(100, 29);
            this.btn_Cancel.TabIndex = 16;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseMouseOnOrLeave = false;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // ManuallyLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(535, 402);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.panel_UserName);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.labTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManuallyLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ManuallyLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManuallyLogin_FormClosing);
            this.Load += new System.EventHandler(this.ManuallyLogin_Load);
            this.panel_UserName.ResumeLayout(false);
            this.panel_UserName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private AudioButton btn_Cancel;
        private System.Windows.Forms.Panel panel_UserName;
        private AudioButton btn_OK;
    }
}