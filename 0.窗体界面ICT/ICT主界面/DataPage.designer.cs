namespace BoTech
{
    partial class DataPage
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
            this.chartIO_Update_NoSQL1 = new BoTech.ChartIO_Update_NoSQL();
            this.SuspendLayout();
            // 
            // chartIO_Update_NoSQL1
            // 
            this.chartIO_Update_NoSQL1.AutoSize = true;
            this.chartIO_Update_NoSQL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartIO_Update_NoSQL1.IsSelectDay = true;
            this.chartIO_Update_NoSQL1.IsSelectIO = true;
            this.chartIO_Update_NoSQL1.IsSelectTime = false;
            this.chartIO_Update_NoSQL1.Location = new System.Drawing.Point(0, 0);
            this.chartIO_Update_NoSQL1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chartIO_Update_NoSQL1.Name = "chartIO_Update_NoSQL1";
            this.chartIO_Update_NoSQL1.Size = new System.Drawing.Size(1008, 625);
            this.chartIO_Update_NoSQL1.TabIndex = 8;
            // 
            // DataPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartIO_Update_NoSQL1);
            this.Name = "DataPage";
            this.Size = new System.Drawing.Size(1008, 625);
            this.Tag = "4";
            this.Load += new System.EventHandler(this.DataPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ChartIO_Update_NoSQL chartIO_Update_NoSQL1;
    }
}
