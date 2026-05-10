namespace BoTech
{
    partial class FailTip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FailTip));
            this.button_CloseArm = new System.Windows.Forms.Button();
            this.label_Name = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.重新执行 = new GUI.New_Button();
            this.跳过 = new GUI.New_Button();
            this.终止 = new GUI.New_Button();
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
            this.button_CloseArm.Location = new System.Drawing.Point(465, 5);
            this.button_CloseArm.Margin = new System.Windows.Forms.Padding(2);
            this.button_CloseArm.Name = "button_CloseArm";
            this.button_CloseArm.Size = new System.Drawing.Size(83, 33);
            this.button_CloseArm.TabIndex = 11;
            this.button_CloseArm.Text = "关闭蜂鸣器";
            this.button_CloseArm.UseVisualStyleBackColor = true;
            this.button_CloseArm.Click += new System.EventHandler(this.button_CloseArm_Click);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Name.Location = new System.Drawing.Point(255, 17);
            this.label_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(57, 12);
            this.label_Name.TabIndex = 10;
            this.label_Name.Text = "当前工站";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.richTextBox1.Location = new System.Drawing.Point(138, 135);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(410, 118);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // 重新执行
            // 
            this.重新执行.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.重新执行.ForeColor = System.Drawing.Color.Black;
            this.重新执行.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.重新执行.Location = new System.Drawing.Point(34, 270);
            this.重新执行.Name = "重新执行";
            this.重新执行.New_BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.重新执行.New_OnMouseColor = System.Drawing.Color.LightGreen;
            this.重新执行.New_Radius = 11;
            this.重新执行.New_RoundStyle = GUI.New_Button.RoundStyle.All;
            this.重新执行.Size = new System.Drawing.Size(108, 45);
            this.重新执行.TabIndex = 71;
            this.重新执行.Text = "重新执行";
            this.重新执行.UseVisualStyleBackColor = true;
            this.重新执行.Click += new System.EventHandler(this.重新执行_Click);
            // 
            // 跳过
            // 
            this.跳过.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.跳过.ForeColor = System.Drawing.Color.Black;
            this.跳过.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.跳过.Location = new System.Drawing.Point(226, 270);
            this.跳过.Name = "跳过";
            this.跳过.New_BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.跳过.New_OnMouseColor = System.Drawing.Color.LightGreen;
            this.跳过.New_Radius = 11;
            this.跳过.New_RoundStyle = GUI.New_Button.RoundStyle.All;
            this.跳过.Size = new System.Drawing.Size(108, 45);
            this.跳过.TabIndex = 72;
            this.跳过.Text = "跳过";
            this.跳过.UseVisualStyleBackColor = true;
            this.跳过.Click += new System.EventHandler(this.跳过_Click);
            // 
            // 终止
            // 
            this.终止.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.终止.ForeColor = System.Drawing.Color.Black;
            this.终止.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.终止.Location = new System.Drawing.Point(415, 270);
            this.终止.Name = "终止";
            this.终止.New_BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.终止.New_OnMouseColor = System.Drawing.Color.Yellow;
            this.终止.New_Radius = 11;
            this.终止.New_RoundStyle = GUI.New_Button.RoundStyle.All;
            this.终止.Size = new System.Drawing.Size(108, 45);
            this.终止.TabIndex = 73;
            this.终止.Text = "跳过";
            this.终止.UseVisualStyleBackColor = true;
            this.终止.Click += new System.EventHandler(this.确定_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 24);
            this.label4.TabIndex = 80;
            this.label4.Text = "Error Detail：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_ErrorMessage
            // 
            this.text_ErrorMessage.Font = new System.Drawing.Font("宋体", 10.5F);
            this.text_ErrorMessage.Location = new System.Drawing.Point(139, 105);
            this.text_ErrorMessage.Name = "text_ErrorMessage";
            this.text_ErrorMessage.ReadOnly = true;
            this.text_ErrorMessage.Size = new System.Drawing.Size(409, 23);
            this.text_ErrorMessage.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 78;
            this.label3.Text = "Error Message：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_ErrorCode
            // 
            this.text_ErrorCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.text_ErrorCode.Location = new System.Drawing.Point(139, 76);
            this.text_ErrorCode.Name = "text_ErrorCode";
            this.text_ErrorCode.ReadOnly = true;
            this.text_ErrorCode.Size = new System.Drawing.Size(409, 23);
            this.text_ErrorCode.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 76;
            this.label2.Text = "Error Code：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_StartTime
            // 
            this.text_StartTime.Font = new System.Drawing.Font("宋体", 10.5F);
            this.text_StartTime.Location = new System.Drawing.Point(139, 47);
            this.text_StartTime.Name = "text_StartTime";
            this.text_StartTime.ReadOnly = true;
            this.text_StartTime.Size = new System.Drawing.Size(409, 23);
            this.text_StartTime.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 74;
            this.label1.Text = "Start Time：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FailTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(194)))), ((int)(((byte)(187)))));
            this.ClientSize = new System.Drawing.Size(554, 319);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_ErrorMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_ErrorCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_StartTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.终止);
            this.Controls.Add(this.跳过);
            this.Controls.Add(this.重新执行);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_CloseArm);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FailTip";
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
        internal GUI.New_Button 重新执行;
        internal GUI.New_Button 跳过;
        internal GUI.New_Button 终止;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_ErrorMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_ErrorCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_StartTime;
        private System.Windows.Forms.Label label1;
    }
}