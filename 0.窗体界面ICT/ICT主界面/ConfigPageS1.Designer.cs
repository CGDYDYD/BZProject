// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using BoTech;

namespace BoTech
{
    
    partial class ConfigPage
    {

        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
      
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

         
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigPage));
            this.pa_Level3 = new System.Windows.Forms.Panel();
            this.nB_Save = new BoTech.AudioButton();
            this.nB_Edit = new BoTech.AudioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SpecLimit = new System.Windows.Forms.DataGridView();
            this.pa_Level2 = new System.Windows.Forms.Panel();
            this.gb_Laser = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pa_Level3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SpecLimit)).BeginInit();
            this.pa_Level2.SuspendLayout();
            this.gb_Laser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pa_Level3
            // 
            resources.ApplyResources(this.pa_Level3, "pa_Level3");
            this.pa_Level3.BackColor = System.Drawing.Color.LightGray;
            this.pa_Level3.Controls.Add(this.nB_Save);
            this.pa_Level3.Controls.Add(this.nB_Edit);
            this.pa_Level3.Controls.Add(this.label1);
            this.pa_Level3.Controls.Add(this.DGV_SpecLimit);
            this.pa_Level3.Name = "pa_Level3";
            this.pa_Level3.Tag = "3";
            // 
            // nB_Save
            // 
            this.nB_Save.Alarmed3 = null;
            this.nB_Save.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.nB_Save, "nB_Save");
            this.nB_Save.ButtonEnable = true;
            this.nB_Save.DeEnergized2 = null;
            this.nB_Save.Disabled0 = null;
            this.nB_Save.Energized1 = null;
            this.nB_Save.FlatAppearance.BorderSize = 0;
            this.nB_Save.ForeColor = System.Drawing.Color.White;
            this.nB_Save.hiveAlarm5 = null;
            this.nB_Save.HiveEngineer4 = null;
            this.nB_Save.Name = "nB_Save";
            this.nB_Save.NBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.nB_Save.OnMouseColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.nB_Save.Radius = 11;
            this.nB_Save.RoundStyle = BoTech.AudioButton.RoundStyles.All;
            this.nB_Save.UseMouseOnOrLeave = false;
            this.nB_Save.UseVisualStyleBackColor = false;
            // 
            // nB_Edit
            // 
            this.nB_Edit.Alarmed3 = null;
            this.nB_Edit.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.nB_Edit, "nB_Edit");
            this.nB_Edit.ButtonEnable = true;
            this.nB_Edit.DeEnergized2 = null;
            this.nB_Edit.Disabled0 = null;
            this.nB_Edit.Energized1 = null;
            this.nB_Edit.FlatAppearance.BorderSize = 0;
            this.nB_Edit.ForeColor = System.Drawing.Color.White;
            this.nB_Edit.hiveAlarm5 = null;
            this.nB_Edit.HiveEngineer4 = null;
            this.nB_Edit.Name = "nB_Edit";
            this.nB_Edit.NBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.nB_Edit.OnMouseColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.nB_Edit.Radius = 11;
            this.nB_Edit.RoundStyle = BoTech.AudioButton.RoundStyles.All;
            this.nB_Edit.UseMouseOnOrLeave = false;
            this.nB_Edit.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DGV_SpecLimit
            // 
            this.DGV_SpecLimit.BackgroundColor = System.Drawing.Color.LightGray;
            this.DGV_SpecLimit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.DGV_SpecLimit, "DGV_SpecLimit");
            this.DGV_SpecLimit.Name = "DGV_SpecLimit";
            this.DGV_SpecLimit.RowHeadersVisible = false;
            this.DGV_SpecLimit.RowTemplate.Height = 23;
            // 
            // pa_Level2
            // 
            this.pa_Level2.BackColor = System.Drawing.Color.LightGray;
            this.pa_Level2.Controls.Add(this.gb_Laser);
            resources.ApplyResources(this.pa_Level2, "pa_Level2");
            this.pa_Level2.Name = "pa_Level2";
            this.pa_Level2.Tag = "3";
            // 
            // gb_Laser
            // 
            this.gb_Laser.Controls.Add(this.dataGridView1);
            resources.ApplyResources(this.gb_Laser, "gb_Laser");
            this.gb_Laser.Name = "gb_Laser";
            this.gb_Laser.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            // 
            // ConfigPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pa_Level3);
            this.Controls.Add(this.pa_Level2);
            this.Name = "ConfigPage";
            this.Tag = "3";
            this.Load += new System.EventHandler(this.Frm_Par_Load);
            this.pa_Level3.ResumeLayout(false);
            this.pa_Level3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SpecLimit)).EndInit();
            this.pa_Level2.ResumeLayout(false);
            this.gb_Laser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        private System.ComponentModel.IContainer components;
        private AudioButton nB_Edit;
        private DataGridView DGV_SpecLimit;
        private AudioButton nB_Save;
        private Panel pa_Level3;
        private Label label1;
        private Panel pa_Level2;
        private GroupBox gb_Laser;
        private DataGridView dataGridView1;
    }

}
