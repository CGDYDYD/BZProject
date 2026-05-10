
namespace BoTech.User_Control
{
    partial class 流线控制
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radioButton_停止 = new System.Windows.Forms.RadioButton();
            this.radioButton_进料 = new System.Windows.Forms.RadioButton();
            this.radioButton_出料 = new System.Windows.Forms.RadioButton();
            this.button_流线动作 = new System.Windows.Forms.Button();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.radioButton_停止);
            this.groupBox8.Controls.Add(this.radioButton_进料);
            this.groupBox8.Controls.Add(this.radioButton_出料);
            this.groupBox8.Controls.Add(this.button_流线动作);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(287, 135);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "流线控制";
            // 
            // radioButton_停止
            // 
            this.radioButton_停止.AutoSize = true;
            this.radioButton_停止.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_停止.Location = new System.Drawing.Point(9, 96);
            this.radioButton_停止.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_停止.Name = "radioButton_停止";
            this.radioButton_停止.Size = new System.Drawing.Size(58, 19);
            this.radioButton_停止.TabIndex = 3;
            this.radioButton_停止.Text = "停止";
            this.radioButton_停止.UseVisualStyleBackColor = true;
            // 
            // radioButton_进料
            // 
            this.radioButton_进料.AutoSize = true;
            this.radioButton_进料.Checked = true;
            this.radioButton_进料.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_进料.Location = new System.Drawing.Point(9, 34);
            this.radioButton_进料.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_进料.Name = "radioButton_进料";
            this.radioButton_进料.Size = new System.Drawing.Size(58, 19);
            this.radioButton_进料.TabIndex = 2;
            this.radioButton_进料.TabStop = true;
            this.radioButton_进料.Text = "进料";
            this.radioButton_进料.UseVisualStyleBackColor = true;
            // 
            // radioButton_出料
            // 
            this.radioButton_出料.AutoSize = true;
            this.radioButton_出料.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_出料.Location = new System.Drawing.Point(8, 65);
            this.radioButton_出料.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_出料.Name = "radioButton_出料";
            this.radioButton_出料.Size = new System.Drawing.Size(58, 19);
            this.radioButton_出料.TabIndex = 1;
            this.radioButton_出料.Text = "出料";
            this.radioButton_出料.UseVisualStyleBackColor = true;
            // 
            // button_流线动作
            // 
            this.button_流线动作.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_流线动作.Location = new System.Drawing.Point(84, 34);
            this.button_流线动作.Margin = new System.Windows.Forms.Padding(4);
            this.button_流线动作.Name = "button_流线动作";
            this.button_流线动作.Size = new System.Drawing.Size(175, 84);
            this.button_流线动作.TabIndex = 0;
            this.button_流线动作.Text = "流线动作";
            this.button_流线动作.UseVisualStyleBackColor = true;
            this.button_流线动作.Click += new System.EventHandler(this.button_流线动作_Click);
            // 
            // 流线控制
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox8);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "流线控制";
            this.Size = new System.Drawing.Size(287, 135);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton radioButton_停止;
        private System.Windows.Forms.RadioButton radioButton_进料;
        private System.Windows.Forms.RadioButton radioButton_出料;
        private System.Windows.Forms.Button button_流线动作;
    }
}
