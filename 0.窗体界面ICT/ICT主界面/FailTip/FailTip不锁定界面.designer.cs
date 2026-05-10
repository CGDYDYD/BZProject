namespace BoTech
{
    partial class FailTip不锁定界面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FailTip不锁定界面));
            this.button_CloseArm = new System.Windows.Forms.Button();
            this.label_Name = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.确定 = new GUI.New_Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_ErrorMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_ErrorCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_StartTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_CloseArm
            // 
            this.button_CloseArm.Location = new System.Drawing.Point(620, 6);
            this.button_CloseArm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_CloseArm.Name = "button_CloseArm";
            this.button_CloseArm.Size = new System.Drawing.Size(111, 41);
            this.button_CloseArm.TabIndex = 11;
            this.button_CloseArm.Text = "关闭蜂鸣器";
            this.button_CloseArm.UseVisualStyleBackColor = true;
            this.button_CloseArm.Click += new System.EventHandler(this.button_CloseArm_Click);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Name.Location = new System.Drawing.Point(340, 21);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(71, 15);
            this.label_Name.TabIndex = 10;
            this.label_Name.Text = "当前工站";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.richTextBox1.Location = new System.Drawing.Point(184, 169);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(545, 146);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // 确定
            // 
            this.确定.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.确定.ForeColor = System.Drawing.Color.Black;
            this.确定.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.确定.Location = new System.Drawing.Point(301, 338);
            this.确定.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.确定.Name = "确定";
            this.确定.New_BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.确定.New_OnMouseColor = System.Drawing.Color.LightGreen;
            this.确定.New_Radius = 11;
            this.确定.New_RoundStyle = GUI.New_Button.RoundStyle.All;
            this.确定.Size = new System.Drawing.Size(144, 56);
            this.确定.TabIndex = 72;
            this.确定.Text = "确定";
            this.确定.UseVisualStyleBackColor = true;
            this.确定.Click += new System.EventHandler(this.确定_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(16, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 30);
            this.label4.TabIndex = 80;
            this.label4.Text = "Error Detail：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_ErrorMessage
            // 
            this.text_ErrorMessage.Font = new System.Drawing.Font("宋体", 10.5F);
            this.text_ErrorMessage.Location = new System.Drawing.Point(185, 131);
            this.text_ErrorMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_ErrorMessage.Name = "text_ErrorMessage";
            this.text_ErrorMessage.ReadOnly = true;
            this.text_ErrorMessage.Size = new System.Drawing.Size(544, 27);
            this.text_ErrorMessage.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(16, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 30);
            this.label3.TabIndex = 78;
            this.label3.Text = "Error Message：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_ErrorCode
            // 
            this.text_ErrorCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.text_ErrorCode.Location = new System.Drawing.Point(185, 95);
            this.text_ErrorCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_ErrorCode.Name = "text_ErrorCode";
            this.text_ErrorCode.ReadOnly = true;
            this.text_ErrorCode.Size = new System.Drawing.Size(544, 27);
            this.text_ErrorCode.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(16, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 30);
            this.label2.TabIndex = 76;
            this.label2.Text = "Error Code：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_StartTime
            // 
            this.text_StartTime.Font = new System.Drawing.Font("宋体", 10.5F);
            this.text_StartTime.Location = new System.Drawing.Point(185, 59);
            this.text_StartTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_StartTime.Name = "text_StartTime";
            this.text_StartTime.ReadOnly = true;
            this.text_StartTime.Size = new System.Drawing.Size(544, 27);
            this.text_StartTime.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 30);
            this.label1.TabIndex = 74;
            this.label1.Text = "Start Time：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FailTip不锁定界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(194)))), ((int)(((byte)(187)))));
            this.ClientSize = new System.Drawing.Size(739, 399);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_ErrorMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_ErrorCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_StartTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.确定);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_CloseArm);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FailTip不锁定界面";
            this.Opacity = 0.95D;
            this.Text = "FailTip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FailTip_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FailTip_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FailTip_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FailTip_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_CloseArm;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal GUI.New_Button 确定;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_ErrorMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_ErrorCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_StartTime;
        private System.Windows.Forms.Label label1;
    }
}