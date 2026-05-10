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

//using Zcm.Teach;
using BoTech;

namespace BoTech
{

    partial class SettingPage
    {

        //Form 重写 Dispose，以清理组件列表。
        [System.Diagnostics.DebuggerNonUserCode()]
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

        //注意: 以下过程是 Windows 窗体设计器所必需的
        //可以使用 Windows 窗体设计器修改它。
        //不要使用代码编辑器修改它。
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingPage));
            this.ComboBox_Robot1 = new System.Windows.Forms.ComboBox();
            this.Robot1_IO_清除错误 = new Zcm.mButton();
            this.mShp_Input36 = new Zcm.mShp_Input();
            this.Robot1_IO_继续 = new Zcm.mButton();
            this.mShp_Input35 = new Zcm.mShp_Input();
            this.Robot1_IO_暂停 = new Zcm.mButton();
            this.mShp_Input34 = new Zcm.mShp_Input();
            this.Robot1_IO_停止 = new Zcm.mButton();
            this.mShp_Input33 = new Zcm.mShp_Input();
            this.Robot1_IO_启动 = new Zcm.mButton();
            this.mButton9 = new Zcm.mButton();
            this.mShp_Input32 = new Zcm.mShp_Input();
            this.mButton7 = new Zcm.mButton();
            this.mShp_Input31 = new Zcm.mShp_Input();
            this.mButton5 = new Zcm.mButton();
            this.mShp_Input30 = new Zcm.mShp_Input();
            this.mButton4 = new Zcm.mButton();
            this.mShp_Input29 = new Zcm.mShp_Input();
            this.mButton3 = new Zcm.mButton();
            this.Cmd_Robot_Trigger1 = new System.Windows.Forms.Button();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.btnChangeConfig = new BoTech.AudioButton();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.panel_HardWare = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.cbLine = new System.Windows.Forms.ComboBox();
            this.label95 = new System.Windows.Forms.Label();
            this.cbStation = new System.Windows.Forms.ComboBox();
            this.label96 = new System.Windows.Forms.Label();
            this.cbMachineNum = new System.Windows.Forms.ComboBox();
            this.cbSite = new System.Windows.Forms.ComboBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.label97 = new System.Windows.Forms.Label();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Panel0 = new System.Windows.Forms.Panel();
            this.tabControl6 = new System.Windows.Forms.TabControl();
            this.tabPage20 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Label_MachineStatus = new System.Windows.Forms.Label();
            this.Label47 = new System.Windows.Forms.Label();
            this.tabPage24 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.stationRun4 = new XStation.StationRun();
            this.stationRun6 = new XStation.StationRun();
            this.stationRun2 = new XStation.StationRun();
            this.stationRun3 = new XStation.StationRun();
            this.stationRun5 = new XStation.StationRun();
            this.stationRun1 = new XStation.StationRun();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.inputClass12 = new Zcm.InputClass();
            this.InputClass1 = new Zcm.InputClass();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.inputClass4 = new Zcm.InputClass();
            this.inputClass5 = new Zcm.InputClass();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.inputClass7 = new Zcm.InputClass();
            this.inputClass3 = new Zcm.InputClass();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.inputClass2 = new Zcm.InputClass();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.inputClass9 = new Zcm.OutputClass();
            this.inputClass6 = new Zcm.OutputClass();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.inputClass13 = new Zcm.OutputClass();
            this.inputClass11 = new Zcm.OutputClass();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.outputClass1 = new Zcm.OutputClass();
            this.inputClass10 = new Zcm.OutputClass();
            this.tP_Manual = new System.Windows.Forms.TabPage();
            this.tb_ProductSN = new System.Windows.Forms.TabControl();
            this.TabPage_L移栽 = new System.Windows.Forms.TabPage();
            this.teachS6 = new Zcm.TeachS();
            this.流线控制1 = new BoTech.User_Control.流线控制();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mBtn_Out2 = new Zcm.mBtn_Out();
            this.mBtn_Out1 = new Zcm.mBtn_Out();
            this.cylinder3 = new Zcm.Cylinder();
            this.cylinder2 = new Zcm.Cylinder();
            this.cylinder1 = new Zcm.Cylinder();
            this.TabPage_R移栽 = new System.Windows.Forms.TabPage();
            this.teachS3 = new Zcm.TeachS();
            this.流线控制2 = new BoTech.User_Control.流线控制();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mBtn_Out3 = new Zcm.mBtn_Out();
            this.mBtn_Out4 = new Zcm.mBtn_Out();
            this.cylinder6 = new Zcm.Cylinder();
            this.cylinder5 = new Zcm.Cylinder();
            this.cylinder4 = new Zcm.Cylinder();
            this.TabPage_L料仓 = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.teachS2 = new Zcm.TeachS();
            this.流线控制3 = new BoTech.User_Control.流线控制();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mBtn_Out5 = new Zcm.mBtn_Out();
            this.mBtn_Out6 = new Zcm.mBtn_Out();
            this.cylinder8 = new Zcm.Cylinder();
            this.cylinder7 = new Zcm.Cylinder();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.teachS4 = new Zcm.TeachS();
            this.流线控制4 = new BoTech.User_Control.流线控制();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.mBtn_Out7 = new Zcm.mBtn_Out();
            this.mBtn_Out8 = new Zcm.mBtn_Out();
            this.cylinder10 = new Zcm.Cylinder();
            this.cylinder9 = new Zcm.Cylinder();
            this.tabPage_R料仓 = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.teachS1 = new Zcm.TeachS();
            this.流线控制5 = new BoTech.User_Control.流线控制();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.mBtn_Out9 = new Zcm.mBtn_Out();
            this.mBtn_Out10 = new Zcm.mBtn_Out();
            this.cylinder12 = new Zcm.Cylinder();
            this.cylinder11 = new Zcm.Cylinder();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.teachS5 = new Zcm.TeachS();
            this.流线控制6 = new BoTech.User_Control.流线控制();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.mBtn_Out11 = new Zcm.mBtn_Out();
            this.mBtn_Out12 = new Zcm.mBtn_Out();
            this.cylinder14 = new Zcm.Cylinder();
            this.cylinder13 = new Zcm.Cylinder();
            this.辅助功能 = new System.Windows.Forms.TabPage();
            this.IOLanguage = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage19 = new System.Windows.Forms.TabPage();
            this.tabControl7 = new System.Windows.Forms.TabControl();
            this.tabPage21 = new System.Windows.Forms.TabPage();
            this.Panel_ParList = new System.Windows.Forms.Panel();
            this.propertyParS2 = new Zcm.PropertyParS();
            this.propertyParS1 = new Zcm.PropertyParS();
            this.tabPage22 = new System.Windows.Forms.TabPage();
            this.Panel_Communication = new System.Windows.Forms.Panel();
            this.tcP_IP20 = new Zcm.TCP_IP();
            this.tcP_IP17 = new Zcm.TCP_IP();
            this.tcP_IP16 = new Zcm.TCP_IP();
            this.tcP_IP2 = new Zcm.TCP_IP();
            this.tcP_IP3 = new Zcm.TCP_IP();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage23 = new System.Windows.Forms.TabPage();
            this.Axis_Setting = new System.Windows.Forms.Button();
            this.UserChkSts1 = new Zcm.UserChk();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.offsetCompenControl1 = new LParamManag.Manage.Control.OffsetCompenControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tp_UserManagerNew = new System.Windows.Forms.TabPage();
            this.userManager1 = new BoTech.UserManager();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.CheckAlarm = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.panel_HardWare.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.Panel0.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tabPage20.SuspendLayout();
            this.tabPage24.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tP_Manual.SuspendLayout();
            this.tb_ProductSN.SuspendLayout();
            this.TabPage_L移栽.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TabPage_R移栽.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TabPage_L料仓.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage16.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage_R料仓.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.辅助功能.SuspendLayout();
            this.tabPage19.SuspendLayout();
            this.tabControl7.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.Panel_ParList.SuspendLayout();
            this.tabPage22.SuspendLayout();
            this.Panel_Communication.SuspendLayout();
            this.tabPage23.SuspendLayout();
            this.tabPage18.SuspendLayout();
            this.tp_UserManagerNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboBox_Robot1
            // 
            resources.ApplyResources(this.ComboBox_Robot1, "ComboBox_Robot1");
            this.ComboBox_Robot1.FormattingEnabled = true;
            this.ComboBox_Robot1.Items.AddRange(new object[] {
            resources.GetString("ComboBox_Robot1.Items"),
            resources.GetString("ComboBox_Robot1.Items1"),
            resources.GetString("ComboBox_Robot1.Items2"),
            resources.GetString("ComboBox_Robot1.Items3"),
            resources.GetString("ComboBox_Robot1.Items4"),
            resources.GetString("ComboBox_Robot1.Items5"),
            resources.GetString("ComboBox_Robot1.Items6"),
            resources.GetString("ComboBox_Robot1.Items7"),
            resources.GetString("ComboBox_Robot1.Items8"),
            resources.GetString("ComboBox_Robot1.Items9"),
            resources.GetString("ComboBox_Robot1.Items10"),
            resources.GetString("ComboBox_Robot1.Items11"),
            resources.GetString("ComboBox_Robot1.Items12"),
            resources.GetString("ComboBox_Robot1.Items13"),
            resources.GetString("ComboBox_Robot1.Items14"),
            resources.GetString("ComboBox_Robot1.Items15"),
            resources.GetString("ComboBox_Robot1.Items16"),
            resources.GetString("ComboBox_Robot1.Items17"),
            resources.GetString("ComboBox_Robot1.Items18")});
            this.ComboBox_Robot1.Name = "ComboBox_Robot1";
            // 
            // Robot1_IO_清除错误
            // 
            resources.ApplyResources(this.Robot1_IO_清除错误, "Robot1_IO_清除错误");
            this.Robot1_IO_清除错误.Name = "Robot1_IO_清除错误";
            this.Robot1_IO_清除错误.Tag = "3";
            this.Robot1_IO_清除错误.新名称 = null;
            this.Robot1_IO_清除错误.显示名称 = true;
            this.Robot1_IO_清除错误.脉冲宽度 = 0;
            this.Robot1_IO_清除错误.输出类型 = null;
            this.Robot1_IO_清除错误.输出编号 = ((short)(52));
            // 
            // mShp_Input36
            // 
            resources.ApplyResources(this.mShp_Input36, "mShp_Input36");
            this.mShp_Input36.Name = "mShp_Input36";
            this.mShp_Input36.新名称 = null;
            this.mShp_Input36.输入编号 = ((short)(48));
            // 
            // Robot1_IO_继续
            // 
            resources.ApplyResources(this.Robot1_IO_继续, "Robot1_IO_继续");
            this.Robot1_IO_继续.Name = "Robot1_IO_继续";
            this.Robot1_IO_继续.Tag = "3";
            this.Robot1_IO_继续.新名称 = null;
            this.Robot1_IO_继续.显示名称 = true;
            this.Robot1_IO_继续.脉冲宽度 = 0;
            this.Robot1_IO_继续.输出类型 = null;
            this.Robot1_IO_继续.输出编号 = ((short)(51));
            // 
            // mShp_Input35
            // 
            resources.ApplyResources(this.mShp_Input35, "mShp_Input35");
            this.mShp_Input35.Name = "mShp_Input35";
            this.mShp_Input35.新名称 = null;
            this.mShp_Input35.输入编号 = ((short)(49));
            // 
            // Robot1_IO_暂停
            // 
            resources.ApplyResources(this.Robot1_IO_暂停, "Robot1_IO_暂停");
            this.Robot1_IO_暂停.Name = "Robot1_IO_暂停";
            this.Robot1_IO_暂停.Tag = "3";
            this.Robot1_IO_暂停.新名称 = null;
            this.Robot1_IO_暂停.显示名称 = true;
            this.Robot1_IO_暂停.脉冲宽度 = 0;
            this.Robot1_IO_暂停.输出类型 = null;
            this.Robot1_IO_暂停.输出编号 = ((short)(50));
            // 
            // mShp_Input34
            // 
            resources.ApplyResources(this.mShp_Input34, "mShp_Input34");
            this.mShp_Input34.Name = "mShp_Input34";
            this.mShp_Input34.新名称 = null;
            this.mShp_Input34.输入编号 = ((short)(50));
            // 
            // Robot1_IO_停止
            // 
            resources.ApplyResources(this.Robot1_IO_停止, "Robot1_IO_停止");
            this.Robot1_IO_停止.Name = "Robot1_IO_停止";
            this.Robot1_IO_停止.Tag = "3";
            this.Robot1_IO_停止.新名称 = null;
            this.Robot1_IO_停止.显示名称 = true;
            this.Robot1_IO_停止.脉冲宽度 = 0;
            this.Robot1_IO_停止.输出类型 = null;
            this.Robot1_IO_停止.输出编号 = ((short)(49));
            // 
            // mShp_Input33
            // 
            resources.ApplyResources(this.mShp_Input33, "mShp_Input33");
            this.mShp_Input33.Name = "mShp_Input33";
            this.mShp_Input33.新名称 = null;
            this.mShp_Input33.输入编号 = ((short)(51));
            // 
            // Robot1_IO_启动
            // 
            resources.ApplyResources(this.Robot1_IO_启动, "Robot1_IO_启动");
            this.Robot1_IO_启动.Name = "Robot1_IO_启动";
            this.Robot1_IO_启动.Tag = "3";
            this.Robot1_IO_启动.新名称 = null;
            this.Robot1_IO_启动.显示名称 = true;
            this.Robot1_IO_启动.脉冲宽度 = 0;
            this.Robot1_IO_启动.输出类型 = null;
            this.Robot1_IO_启动.输出编号 = ((short)(48));
            // 
            // mButton9
            // 
            resources.ApplyResources(this.mButton9, "mButton9");
            this.mButton9.Name = "mButton9";
            this.mButton9.Tag = "3";
            this.mButton9.新名称 = null;
            this.mButton9.显示名称 = true;
            this.mButton9.脉冲宽度 = 0;
            this.mButton9.输出类型 = null;
            this.mButton9.输出编号 = ((short)(57));
            // 
            // mShp_Input32
            // 
            resources.ApplyResources(this.mShp_Input32, "mShp_Input32");
            this.mShp_Input32.Name = "mShp_Input32";
            this.mShp_Input32.新名称 = null;
            this.mShp_Input32.输入编号 = ((short)(54));
            // 
            // mButton7
            // 
            resources.ApplyResources(this.mButton7, "mButton7");
            this.mButton7.Name = "mButton7";
            this.mButton7.Tag = "3";
            this.mButton7.新名称 = null;
            this.mButton7.显示名称 = true;
            this.mButton7.脉冲宽度 = 0;
            this.mButton7.输出类型 = null;
            this.mButton7.输出编号 = ((short)(56));
            // 
            // mShp_Input31
            // 
            resources.ApplyResources(this.mShp_Input31, "mShp_Input31");
            this.mShp_Input31.Name = "mShp_Input31";
            this.mShp_Input31.新名称 = null;
            this.mShp_Input31.输入编号 = ((short)(53));
            // 
            // mButton5
            // 
            resources.ApplyResources(this.mButton5, "mButton5");
            this.mButton5.Name = "mButton5";
            this.mButton5.Tag = "3";
            this.mButton5.新名称 = null;
            this.mButton5.显示名称 = true;
            this.mButton5.脉冲宽度 = 0;
            this.mButton5.输出类型 = null;
            this.mButton5.输出编号 = ((short)(55));
            // 
            // mShp_Input30
            // 
            resources.ApplyResources(this.mShp_Input30, "mShp_Input30");
            this.mShp_Input30.Name = "mShp_Input30";
            this.mShp_Input30.新名称 = null;
            this.mShp_Input30.输入编号 = ((short)(52));
            // 
            // mButton4
            // 
            resources.ApplyResources(this.mButton4, "mButton4");
            this.mButton4.Name = "mButton4";
            this.mButton4.Tag = "3";
            this.mButton4.新名称 = null;
            this.mButton4.显示名称 = true;
            this.mButton4.脉冲宽度 = 0;
            this.mButton4.输出类型 = null;
            this.mButton4.输出编号 = ((short)(54));
            // 
            // mShp_Input29
            // 
            resources.ApplyResources(this.mShp_Input29, "mShp_Input29");
            this.mShp_Input29.Name = "mShp_Input29";
            this.mShp_Input29.新名称 = null;
            this.mShp_Input29.输入编号 = ((short)(55));
            // 
            // mButton3
            // 
            resources.ApplyResources(this.mButton3, "mButton3");
            this.mButton3.Name = "mButton3";
            this.mButton3.Tag = "3";
            this.mButton3.新名称 = null;
            this.mButton3.显示名称 = true;
            this.mButton3.脉冲宽度 = 0;
            this.mButton3.输出类型 = null;
            this.mButton3.输出编号 = ((short)(53));
            // 
            // Cmd_Robot_Trigger1
            // 
            resources.ApplyResources(this.Cmd_Robot_Trigger1, "Cmd_Robot_Trigger1");
            this.Cmd_Robot_Trigger1.Name = "Cmd_Robot_Trigger1";
            this.Cmd_Robot_Trigger1.Tag = "1";
            this.Cmd_Robot_Trigger1.UseVisualStyleBackColor = true;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tabPage3);
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.tabPage6);
            this.TabControl1.Controls.Add(this.tabPage7);
            this.TabControl1.Controls.Add(this.tP_Manual);
            this.TabControl1.Controls.Add(this.tabPage19);
            this.TabControl1.Controls.Add(this.tp_UserManagerNew);
            resources.ApplyResources(this.TabControl1, "TabControl1");
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Controls.Add(this.groupBox23);
            this.tabPage3.Controls.Add(this.groupBox22);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.btnChangeConfig);
            resources.ApplyResources(this.groupBox23, "groupBox23");
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.TabStop = false;
            // 
            // btnChangeConfig
            // 
            this.btnChangeConfig.Alarmed3 = null;
            this.btnChangeConfig.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnChangeConfig, "btnChangeConfig");
            this.btnChangeConfig.ButtonEnable = true;
            this.btnChangeConfig.DeEnergized2 = null;
            this.btnChangeConfig.Disabled0 = null;
            this.btnChangeConfig.Energized1 = null;
            this.btnChangeConfig.FlatAppearance.BorderSize = 0;
            this.btnChangeConfig.hiveAlarm5 = null;
            this.btnChangeConfig.HiveEngineer4 = null;
            this.btnChangeConfig.Name = "btnChangeConfig";
            this.btnChangeConfig.NBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnChangeConfig.OnMouseColor = System.Drawing.Color.Empty;
            this.btnChangeConfig.Radius = 10;
            this.btnChangeConfig.RoundStyle = BoTech.AudioButton.RoundStyles.All;
            this.btnChangeConfig.UseMouseOnOrLeave = false;
            this.btnChangeConfig.UseVisualStyleBackColor = false;
            this.btnChangeConfig.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.panel_HardWare);
            this.groupBox22.Controls.Add(this.cbLanguage);
            this.groupBox22.Controls.Add(this.label97);
            resources.ApplyResources(this.groupBox22, "groupBox22");
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.TabStop = false;
            // 
            // panel_HardWare
            // 
            this.panel_HardWare.Controls.Add(this.comboBox1);
            this.panel_HardWare.Controls.Add(this.label6);
            this.panel_HardWare.Controls.Add(this.label90);
            this.panel_HardWare.Controls.Add(this.label91);
            this.panel_HardWare.Controls.Add(this.cbLine);
            this.panel_HardWare.Controls.Add(this.label95);
            this.panel_HardWare.Controls.Add(this.cbStation);
            this.panel_HardWare.Controls.Add(this.label96);
            this.panel_HardWare.Controls.Add(this.cbMachineNum);
            this.panel_HardWare.Controls.Add(this.cbSite);
            resources.ApplyResources(this.panel_HardWare, "panel_HardWare");
            this.panel_HardWare.Name = "panel_HardWare";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2"),
            resources.GetString("comboBox1.Items3")});
            this.comboBox1.Name = "comboBox1";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label90
            // 
            resources.ApplyResources(this.label90, "label90");
            this.label90.Name = "label90";
            // 
            // label91
            // 
            resources.ApplyResources(this.label91, "label91");
            this.label91.Name = "label91";
            // 
            // cbLine
            // 
            this.cbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbLine, "cbLine");
            this.cbLine.FormattingEnabled = true;
            this.cbLine.Items.AddRange(new object[] {
            resources.GetString("cbLine.Items"),
            resources.GetString("cbLine.Items1"),
            resources.GetString("cbLine.Items2"),
            resources.GetString("cbLine.Items3"),
            resources.GetString("cbLine.Items4"),
            resources.GetString("cbLine.Items5"),
            resources.GetString("cbLine.Items6"),
            resources.GetString("cbLine.Items7"),
            resources.GetString("cbLine.Items8"),
            resources.GetString("cbLine.Items9"),
            resources.GetString("cbLine.Items10"),
            resources.GetString("cbLine.Items11")});
            this.cbLine.Name = "cbLine";
            // 
            // label95
            // 
            resources.ApplyResources(this.label95, "label95");
            this.label95.Name = "label95";
            // 
            // cbStation
            // 
            this.cbStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbStation, "cbStation");
            this.cbStation.FormattingEnabled = true;
            this.cbStation.Items.AddRange(new object[] {
            resources.GetString("cbStation.Items"),
            resources.GetString("cbStation.Items1"),
            resources.GetString("cbStation.Items2"),
            resources.GetString("cbStation.Items3")});
            this.cbStation.Name = "cbStation";
            // 
            // label96
            // 
            resources.ApplyResources(this.label96, "label96");
            this.label96.Name = "label96";
            // 
            // cbMachineNum
            // 
            this.cbMachineNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbMachineNum, "cbMachineNum");
            this.cbMachineNum.FormattingEnabled = true;
            this.cbMachineNum.Items.AddRange(new object[] {
            resources.GetString("cbMachineNum.Items"),
            resources.GetString("cbMachineNum.Items1"),
            resources.GetString("cbMachineNum.Items2"),
            resources.GetString("cbMachineNum.Items3")});
            this.cbMachineNum.Name = "cbMachineNum";
            // 
            // cbSite
            // 
            this.cbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbSite, "cbSite");
            this.cbSite.FormattingEnabled = true;
            this.cbSite.Items.AddRange(new object[] {
            resources.GetString("cbSite.Items"),
            resources.GetString("cbSite.Items1"),
            resources.GetString("cbSite.Items2")});
            this.cbSite.Name = "cbSite";
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            resources.GetString("cbLanguage.Items"),
            resources.GetString("cbLanguage.Items1"),
            resources.GetString("cbLanguage.Items2")});
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.SelectionChangeCommitted += new System.EventHandler(this.cbLanguage_SelectionChangeCommitted);
            // 
            // label97
            // 
            resources.ApplyResources(this.label97, "label97");
            this.label97.Name = "label97";
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TabPage1.Controls.Add(this.Panel0);
            resources.ApplyResources(this.TabPage1, "TabPage1");
            this.TabPage1.Name = "TabPage1";
            // 
            // Panel0
            // 
            this.Panel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel0.Controls.Add(this.tabControl6);
            resources.ApplyResources(this.Panel0, "Panel0");
            this.Panel0.Name = "Panel0";
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabPage20);
            this.tabControl6.Controls.Add(this.tabPage24);
            resources.ApplyResources(this.tabControl6, "tabControl6");
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            // 
            // tabPage20
            // 
            this.tabPage20.Controls.Add(this.label13);
            this.tabPage20.Controls.Add(this.label4);
            this.tabPage20.Controls.Add(this.label5);
            this.tabPage20.Controls.Add(this.Label_MachineStatus);
            this.tabPage20.Controls.Add(this.Label47);
            resources.ApplyResources(this.tabPage20, "tabPage20");
            this.tabPage20.Name = "tabPage20";
            this.tabPage20.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(218)))), ((int)(((byte)(150)))));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label13.Name = "label13";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(218)))), ((int)(((byte)(150)))));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(218)))), ((int)(((byte)(150)))));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Name = "label5";
            // 
            // Label_MachineStatus
            // 
            this.Label_MachineStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(218)))), ((int)(((byte)(150)))));
            resources.ApplyResources(this.Label_MachineStatus, "Label_MachineStatus");
            this.Label_MachineStatus.Name = "Label_MachineStatus";
            // 
            // Label47
            // 
            this.Label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(218)))), ((int)(((byte)(150)))));
            this.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.Label47, "Label47");
            this.Label47.Name = "Label47";
            // 
            // tabPage24
            // 
            this.tabPage24.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.tabPage24, "tabPage24");
            this.tabPage24.Name = "tabPage24";
            this.tabPage24.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.stationRun4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.stationRun6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.stationRun2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.stationRun3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.stationRun5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.stationRun1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // stationRun4
            // 
            resources.ApplyResources(this.stationRun4, "stationRun4");
            this.stationRun4.Name = "stationRun4";
            this.stationRun4.RunMode = XStation.WkManager.TaskRunType.mThread;
            this.stationRun4.StationID = new int[] {
        4};
            this.stationRun4.新名称 = "Task04_L移载平台";
            this.stationRun4.新名称En = "Task04";
            // 
            // stationRun6
            // 
            resources.ApplyResources(this.stationRun6, "stationRun6");
            this.stationRun6.Name = "stationRun6";
            this.stationRun6.RunMode = XStation.WkManager.TaskRunType.mThread;
            this.stationRun6.StationID = new int[] {
        6};
            this.stationRun6.新名称 = "Task06_R下料";
            this.stationRun6.新名称En = "Task06";
            // 
            // stationRun2
            // 
            resources.ApplyResources(this.stationRun2, "stationRun2");
            this.stationRun2.Name = "stationRun2";
            this.stationRun2.RunMode = XStation.WkManager.TaskRunType.mThread;
            this.stationRun2.StationID = new int[] {
        2};
            this.stationRun2.新名称 = "Task02_R上料";
            this.stationRun2.新名称En = "Task02";
            // 
            // stationRun3
            // 
            resources.ApplyResources(this.stationRun3, "stationRun3");
            this.stationRun3.Name = "stationRun3";
            this.stationRun3.RunMode = XStation.WkManager.TaskRunType.mThread;
            this.stationRun3.StationID = new int[] {
        3};
            this.stationRun3.新名称 = "Task03_L移载平台";
            this.stationRun3.新名称En = "Task03";
            // 
            // stationRun5
            // 
            resources.ApplyResources(this.stationRun5, "stationRun5");
            this.stationRun5.Name = "stationRun5";
            this.stationRun5.RunMode = XStation.WkManager.TaskRunType.mThread;
            this.stationRun5.StationID = new int[] {
        5};
            this.stationRun5.新名称 = "Task05_R下料";
            this.stationRun5.新名称En = "Task05";
            // 
            // stationRun1
            // 
            resources.ApplyResources(this.stationRun1, "stationRun1");
            this.stationRun1.Name = "stationRun1";
            this.stationRun1.RunMode = XStation.WkManager.TaskRunType.mThread;
            this.stationRun1.StationID = new int[] {
        1};
            this.stationRun1.新名称 = "Task01_L上料";
            this.stationRun1.新名称En = "Task01";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.TabControl2);
            resources.ApplyResources(this.tabPage6, "tabPage6");
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // TabControl2
            // 
            this.TabControl2.Controls.Add(this.tabPage8);
            this.TabControl2.Controls.Add(this.tabPage9);
            this.TabControl2.Controls.Add(this.tabPage10);
            this.TabControl2.Controls.Add(this.tabPage17);
            resources.ApplyResources(this.TabControl2, "TabControl2");
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.White;
            this.tabPage8.Controls.Add(this.inputClass12);
            this.tabPage8.Controls.Add(this.InputClass1);
            resources.ApplyResources(this.tabPage8, "tabPage8");
            this.tabPage8.Name = "tabPage8";
            // 
            // inputClass12
            // 
            resources.ApplyResources(this.inputClass12, "inputClass12");
            this.inputClass12.Name = "inputClass12";
            this.inputClass12.Tag = "固高通用,0";
            this.inputClass12.卡类型 = "固高通用";
            this.inputClass12.卡编号 = ((short)(0));
            this.inputClass12.控件编号 = ((short)(1));
            this.inputClass12.新名称 = "普通模块2";
            this.inputClass12.新名称En = "Input1";
            // 
            // InputClass1
            // 
            resources.ApplyResources(this.InputClass1, "InputClass1");
            this.InputClass1.Name = "InputClass1";
            this.InputClass1.Tag = "固高通用,0";
            this.InputClass1.卡类型 = "固高通用";
            this.InputClass1.卡编号 = ((short)(0));
            this.InputClass1.控件编号 = ((short)(0));
            this.InputClass1.新名称 = "普通模块1";
            this.InputClass1.新名称En = "Input1";
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.Controls.Add(this.inputClass4);
            this.tabPage9.Controls.Add(this.inputClass5);
            resources.ApplyResources(this.tabPage9, "tabPage9");
            this.tabPage9.Name = "tabPage9";
            // 
            // inputClass4
            // 
            resources.ApplyResources(this.inputClass4, "inputClass4");
            this.inputClass4.Name = "inputClass4";
            this.inputClass4.Tag = "固高通用,0";
            this.inputClass4.卡类型 = "固高通用";
            this.inputClass4.卡编号 = ((short)(0));
            this.inputClass4.控件编号 = ((short)(2));
            this.inputClass4.新名称 = "远程IO1";
            this.inputClass4.新名称En = "Input1";
            // 
            // inputClass5
            // 
            resources.ApplyResources(this.inputClass5, "inputClass5");
            this.inputClass5.Name = "inputClass5";
            this.inputClass5.Tag = "固高通用,0";
            this.inputClass5.卡类型 = "固高通用";
            this.inputClass5.卡编号 = ((short)(0));
            this.inputClass5.控件编号 = ((short)(3));
            this.inputClass5.新名称 = "远程IO2";
            this.inputClass5.新名称En = "Input1";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.inputClass7);
            this.tabPage10.Controls.Add(this.inputClass3);
            resources.ApplyResources(this.tabPage10, "tabPage10");
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // inputClass7
            // 
            resources.ApplyResources(this.inputClass7, "inputClass7");
            this.inputClass7.Name = "inputClass7";
            this.inputClass7.Tag = "固高通用,0";
            this.inputClass7.卡类型 = "固高通用";
            this.inputClass7.卡编号 = ((short)(0));
            this.inputClass7.控件编号 = ((short)(5));
            this.inputClass7.新名称 = "远程IO4";
            this.inputClass7.新名称En = "Input1";
            // 
            // inputClass3
            // 
            resources.ApplyResources(this.inputClass3, "inputClass3");
            this.inputClass3.Name = "inputClass3";
            this.inputClass3.Tag = "固高通用,0";
            this.inputClass3.卡类型 = "固高通用";
            this.inputClass3.卡编号 = ((short)(0));
            this.inputClass3.控件编号 = ((short)(4));
            this.inputClass3.新名称 = "远程IO3";
            this.inputClass3.新名称En = "Input1";
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.inputClass2);
            resources.ApplyResources(this.tabPage17, "tabPage17");
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // inputClass2
            // 
            resources.ApplyResources(this.inputClass2, "inputClass2");
            this.inputClass2.Name = "inputClass2";
            this.inputClass2.Tag = "固高通用,0";
            this.inputClass2.卡类型 = "固高通用";
            this.inputClass2.卡编号 = ((short)(0));
            this.inputClass2.控件编号 = ((short)(6));
            this.inputClass2.新名称 = "远程IO5";
            this.inputClass2.新名称En = "Input1";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tabControl3);
            resources.ApplyResources(this.tabPage7, "tabPage7");
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Controls.Add(this.tabPage11);
            this.tabControl3.Controls.Add(this.tabPage12);
            resources.ApplyResources(this.tabControl3, "tabControl3");
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.inputClass9);
            this.tabPage2.Controls.Add(this.inputClass6);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // inputClass9
            // 
            resources.ApplyResources(this.inputClass9, "inputClass9");
            this.inputClass9.Name = "inputClass9";
            this.inputClass9.Tag = "固高通用,0";
            this.inputClass9.卡类型 = "固高通用";
            this.inputClass9.卡编号 = ((short)(0));
            this.inputClass9.控件编号 = ((short)(0));
            this.inputClass9.新名称 = "普通模块1";
            this.inputClass9.新名称En = "Input1";
            // 
            // inputClass6
            // 
            resources.ApplyResources(this.inputClass6, "inputClass6");
            this.inputClass6.Name = "inputClass6";
            this.inputClass6.Tag = "固高通用,0";
            this.inputClass6.卡类型 = "固高通用";
            this.inputClass6.卡编号 = ((short)(0));
            this.inputClass6.控件编号 = ((short)(1));
            this.inputClass6.新名称 = "普通模块2";
            this.inputClass6.新名称En = "Input1";
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.Color.White;
            this.tabPage11.Controls.Add(this.inputClass13);
            this.tabPage11.Controls.Add(this.inputClass11);
            resources.ApplyResources(this.tabPage11, "tabPage11");
            this.tabPage11.Name = "tabPage11";
            // 
            // inputClass13
            // 
            resources.ApplyResources(this.inputClass13, "inputClass13");
            this.inputClass13.Name = "inputClass13";
            this.inputClass13.Tag = "固高通用,0";
            this.inputClass13.卡类型 = "固高通用";
            this.inputClass13.卡编号 = ((short)(0));
            this.inputClass13.控件编号 = ((short)(2));
            this.inputClass13.新名称 = "远程IO1";
            this.inputClass13.新名称En = "Input1";
            // 
            // inputClass11
            // 
            resources.ApplyResources(this.inputClass11, "inputClass11");
            this.inputClass11.Name = "inputClass11";
            this.inputClass11.Tag = "固高通用,0";
            this.inputClass11.卡类型 = "固高通用";
            this.inputClass11.卡编号 = ((short)(0));
            this.inputClass11.控件编号 = ((short)(3));
            this.inputClass11.新名称 = "远程IO2";
            this.inputClass11.新名称En = "Input1";
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.outputClass1);
            this.tabPage12.Controls.Add(this.inputClass10);
            resources.ApplyResources(this.tabPage12, "tabPage12");
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // outputClass1
            // 
            resources.ApplyResources(this.outputClass1, "outputClass1");
            this.outputClass1.Name = "outputClass1";
            this.outputClass1.Tag = "固高通用,0";
            this.outputClass1.卡类型 = "固高通用";
            this.outputClass1.卡编号 = ((short)(0));
            this.outputClass1.控件编号 = ((short)(5));
            this.outputClass1.新名称 = "远程IO4";
            this.outputClass1.新名称En = "Input1";
            // 
            // inputClass10
            // 
            resources.ApplyResources(this.inputClass10, "inputClass10");
            this.inputClass10.Name = "inputClass10";
            this.inputClass10.Tag = "固高通用,0";
            this.inputClass10.卡类型 = "固高通用";
            this.inputClass10.卡编号 = ((short)(0));
            this.inputClass10.控件编号 = ((short)(4));
            this.inputClass10.新名称 = "远程IO3";
            this.inputClass10.新名称En = "Input1";
            // 
            // tP_Manual
            // 
            this.tP_Manual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tP_Manual.Controls.Add(this.tb_ProductSN);
            resources.ApplyResources(this.tP_Manual, "tP_Manual");
            this.tP_Manual.Name = "tP_Manual";
            // 
            // tb_ProductSN
            // 
            this.tb_ProductSN.Controls.Add(this.TabPage_L移栽);
            this.tb_ProductSN.Controls.Add(this.TabPage_R移栽);
            this.tb_ProductSN.Controls.Add(this.TabPage_L料仓);
            this.tb_ProductSN.Controls.Add(this.tabPage_R料仓);
            this.tb_ProductSN.Controls.Add(this.辅助功能);
            resources.ApplyResources(this.tb_ProductSN, "tb_ProductSN");
            this.tb_ProductSN.Name = "tb_ProductSN";
            this.tb_ProductSN.SelectedIndex = 0;
            this.tb_ProductSN.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // TabPage_L移栽
            // 
            this.TabPage_L移栽.Controls.Add(this.teachS6);
            this.TabPage_L移栽.Controls.Add(this.流线控制1);
            this.TabPage_L移栽.Controls.Add(this.groupBox1);
            this.TabPage_L移栽.Controls.Add(this.cylinder3);
            this.TabPage_L移栽.Controls.Add(this.cylinder2);
            this.TabPage_L移栽.Controls.Add(this.cylinder1);
            resources.ApplyResources(this.TabPage_L移栽, "TabPage_L移栽");
            this.TabPage_L移栽.Name = "TabPage_L移栽";
            this.TabPage_L移栽.UseVisualStyleBackColor = true;
            // 
            // teachS6
            // 
            resources.ApplyResources(this.teachS6, "teachS6");
            this.teachS6.AxisNum_R = ((short)(0));
            this.teachS6.AxisNum_X = ((short)(0));
            this.teachS6.AxisNum_Y = ((short)(1));
            this.teachS6.AxisNum_Z = ((short)(0));
            this.teachS6.CardNum_R = ((short)(0));
            this.teachS6.CardNum_X = ((short)(0));
            this.teachS6.CardNum_Y = ((short)(0));
            this.teachS6.CardNum_Z = ((short)(0));
            this.teachS6.CardType = null;
            this.teachS6.Name = "teachS6";
            this.teachS6.PointNumber = ((short)(30));
            this.teachS6.RAdd_X = ((short)(0));
            this.teachS6.RAdd_Y = ((short)(0));
            this.teachS6.RDec_X = ((short)(0));
            this.teachS6.RDec_Y = ((short)(0));
            this.teachS6.RunClickHandler = true;
            this.teachS6.StaName = "OK移载平台";
            this.teachS6.StaNameEn = null;
            this.teachS6.StaNameShow = true;
            this.teachS6.StationID = ((short)(0));
            this.teachS6.XAdd_X = ((short)(0));
            this.teachS6.XAdd_Y = ((short)(0));
            this.teachS6.XDec_X = ((short)(0));
            this.teachS6.XDec_Y = ((short)(0));
            this.teachS6.YAdd_X = ((short)(0));
            this.teachS6.YAdd_Y = ((short)(0));
            this.teachS6.YDec_X = ((short)(0));
            this.teachS6.YDec_Y = ((short)(0));
            this.teachS6.YExchange = true;
            this.teachS6.YVisiable = true;
            this.teachS6.ZAdd_X = ((short)(0));
            this.teachS6.ZAdd_Y = ((short)(0));
            this.teachS6.ZDec_X = ((short)(0));
            this.teachS6.ZDec_Y = ((short)(0));
            this.teachS6.名称可编辑 = true;
            // 
            // 流线控制1
            // 
            resources.ApplyResources(this.流线控制1, "流线控制1");
            this.流线控制1.Name = "流线控制1";
            this.流线控制1.流线名称 = ParName.名称枚举.StationID.L移载平台;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mBtn_Out2);
            this.groupBox1.Controls.Add(this.mBtn_Out1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // mBtn_Out2
            // 
            this.mBtn_Out2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out2, "mBtn_Out2");
            this.mBtn_Out2.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out2.Name = "mBtn_Out2";
            this.mBtn_Out2.Tag = "2";
            this.mBtn_Out2.新名称 = null;
            this.mBtn_Out2.脉冲宽度 = 0;
            this.mBtn_Out2.输出类型 = null;
            this.mBtn_Out2.输出编号 = ((short)(69));
            // 
            // mBtn_Out1
            // 
            this.mBtn_Out1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out1, "mBtn_Out1");
            this.mBtn_Out1.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out1.Name = "mBtn_Out1";
            this.mBtn_Out1.Tag = "2";
            this.mBtn_Out1.新名称 = null;
            this.mBtn_Out1.脉冲宽度 = 0;
            this.mBtn_Out1.输出类型 = null;
            this.mBtn_Out1.输出编号 = ((short)(70));
            // 
            // cylinder3
            // 
            resources.ApplyResources(this.cylinder3, "cylinder3");
            this.cylinder3.Name = "cylinder3";
            this.cylinder3.动点响应 = null;
            this.cylinder3.动点编号 = ((short)(68));
            this.cylinder3.原点响应 = null;
            this.cylinder3.原点编号 = ((short)(69));
            this.cylinder3.输出编号 = "85";
            // 
            // cylinder2
            // 
            resources.ApplyResources(this.cylinder2, "cylinder2");
            this.cylinder2.Name = "cylinder2";
            this.cylinder2.动点响应 = null;
            this.cylinder2.动点编号 = ((short)(70));
            this.cylinder2.原点响应 = null;
            this.cylinder2.原点编号 = ((short)(71));
            this.cylinder2.输出编号 = "83";
            // 
            // cylinder1
            // 
            resources.ApplyResources(this.cylinder1, "cylinder1");
            this.cylinder1.Name = "cylinder1";
            this.cylinder1.动点响应 = null;
            this.cylinder1.动点编号 = ((short)(70));
            this.cylinder1.原点响应 = null;
            this.cylinder1.原点编号 = ((short)(71));
            this.cylinder1.输出编号 = "82";
            // 
            // TabPage_R移栽
            // 
            this.TabPage_R移栽.Controls.Add(this.teachS3);
            this.TabPage_R移栽.Controls.Add(this.流线控制2);
            this.TabPage_R移栽.Controls.Add(this.groupBox2);
            this.TabPage_R移栽.Controls.Add(this.cylinder6);
            this.TabPage_R移栽.Controls.Add(this.cylinder5);
            this.TabPage_R移栽.Controls.Add(this.cylinder4);
            resources.ApplyResources(this.TabPage_R移栽, "TabPage_R移栽");
            this.TabPage_R移栽.Name = "TabPage_R移栽";
            this.TabPage_R移栽.UseVisualStyleBackColor = true;
            // 
            // teachS3
            // 
            resources.ApplyResources(this.teachS3, "teachS3");
            this.teachS3.AxisNum_R = ((short)(0));
            this.teachS3.AxisNum_X = ((short)(0));
            this.teachS3.AxisNum_Y = ((short)(2));
            this.teachS3.AxisNum_Z = ((short)(0));
            this.teachS3.CardNum_R = ((short)(0));
            this.teachS3.CardNum_X = ((short)(0));
            this.teachS3.CardNum_Y = ((short)(0));
            this.teachS3.CardNum_Z = ((short)(0));
            this.teachS3.CardType = null;
            this.teachS3.Name = "teachS3";
            this.teachS3.PointNumber = ((short)(30));
            this.teachS3.RAdd_X = ((short)(0));
            this.teachS3.RAdd_Y = ((short)(0));
            this.teachS3.RDec_X = ((short)(0));
            this.teachS3.RDec_Y = ((short)(0));
            this.teachS3.RunClickHandler = true;
            this.teachS3.StaName = "NG移载平台";
            this.teachS3.StaNameEn = null;
            this.teachS3.StaNameShow = true;
            this.teachS3.StationID = ((short)(1));
            this.teachS3.XAdd_X = ((short)(0));
            this.teachS3.XAdd_Y = ((short)(0));
            this.teachS3.XDec_X = ((short)(0));
            this.teachS3.XDec_Y = ((short)(0));
            this.teachS3.YAdd_X = ((short)(0));
            this.teachS3.YAdd_Y = ((short)(0));
            this.teachS3.YDec_X = ((short)(0));
            this.teachS3.YDec_Y = ((short)(0));
            this.teachS3.YExchange = true;
            this.teachS3.YVisiable = true;
            this.teachS3.ZAdd_X = ((short)(0));
            this.teachS3.ZAdd_Y = ((short)(0));
            this.teachS3.ZDec_X = ((short)(0));
            this.teachS3.ZDec_Y = ((short)(0));
            this.teachS3.名称可编辑 = true;
            // 
            // 流线控制2
            // 
            resources.ApplyResources(this.流线控制2, "流线控制2");
            this.流线控制2.Name = "流线控制2";
            this.流线控制2.流线名称 = ParName.名称枚举.StationID.R移载平台;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mBtn_Out3);
            this.groupBox2.Controls.Add(this.mBtn_Out4);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // mBtn_Out3
            // 
            this.mBtn_Out3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out3, "mBtn_Out3");
            this.mBtn_Out3.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out3.Name = "mBtn_Out3";
            this.mBtn_Out3.Tag = "2";
            this.mBtn_Out3.新名称 = null;
            this.mBtn_Out3.脉冲宽度 = 0;
            this.mBtn_Out3.输出类型 = null;
            this.mBtn_Out3.输出编号 = ((short)(77));
            // 
            // mBtn_Out4
            // 
            this.mBtn_Out4.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out4, "mBtn_Out4");
            this.mBtn_Out4.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out4.Name = "mBtn_Out4";
            this.mBtn_Out4.Tag = "2";
            this.mBtn_Out4.新名称 = null;
            this.mBtn_Out4.脉冲宽度 = 0;
            this.mBtn_Out4.输出类型 = null;
            this.mBtn_Out4.输出编号 = ((short)(78));
            // 
            // cylinder6
            // 
            resources.ApplyResources(this.cylinder6, "cylinder6");
            this.cylinder6.Name = "cylinder6";
            this.cylinder6.动点响应 = null;
            this.cylinder6.动点编号 = ((short)(76));
            this.cylinder6.原点响应 = null;
            this.cylinder6.原点编号 = ((short)(77));
            this.cylinder6.输出编号 = "84";
            // 
            // cylinder5
            // 
            resources.ApplyResources(this.cylinder5, "cylinder5");
            this.cylinder5.Name = "cylinder5";
            this.cylinder5.动点响应 = null;
            this.cylinder5.动点编号 = ((short)(78));
            this.cylinder5.原点响应 = null;
            this.cylinder5.原点编号 = ((short)(79));
            this.cylinder5.输出编号 = "81";
            // 
            // cylinder4
            // 
            resources.ApplyResources(this.cylinder4, "cylinder4");
            this.cylinder4.Name = "cylinder4";
            this.cylinder4.动点响应 = null;
            this.cylinder4.动点编号 = ((short)(78));
            this.cylinder4.原点响应 = null;
            this.cylinder4.原点编号 = ((short)(79));
            this.cylinder4.输出编号 = "80";
            // 
            // TabPage_L料仓
            // 
            this.TabPage_L料仓.Controls.Add(this.tabControl4);
            resources.ApplyResources(this.TabPage_L料仓, "TabPage_L料仓");
            this.TabPage_L料仓.Name = "TabPage_L料仓";
            this.TabPage_L料仓.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage15);
            this.tabControl4.Controls.Add(this.tabPage16);
            resources.ApplyResources(this.tabControl4, "tabControl4");
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.teachS2);
            this.tabPage15.Controls.Add(this.流线控制3);
            this.tabPage15.Controls.Add(this.groupBox4);
            this.tabPage15.Controls.Add(this.cylinder8);
            this.tabPage15.Controls.Add(this.cylinder7);
            resources.ApplyResources(this.tabPage15, "tabPage15");
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // teachS2
            // 
            resources.ApplyResources(this.teachS2, "teachS2");
            this.teachS2.AxisNum_R = ((short)(0));
            this.teachS2.AxisNum_X = ((short)(0));
            this.teachS2.AxisNum_Y = ((short)(0));
            this.teachS2.AxisNum_Z = ((short)(3));
            this.teachS2.CardNum_R = ((short)(0));
            this.teachS2.CardNum_X = ((short)(0));
            this.teachS2.CardNum_Y = ((short)(0));
            this.teachS2.CardNum_Z = ((short)(0));
            this.teachS2.CardType = null;
            this.teachS2.Name = "teachS2";
            this.teachS2.PointNumber = ((short)(30));
            this.teachS2.RAdd_X = ((short)(0));
            this.teachS2.RAdd_Y = ((short)(0));
            this.teachS2.RDec_X = ((short)(0));
            this.teachS2.RDec_Y = ((short)(0));
            this.teachS2.RunClickHandler = true;
            this.teachS2.StaName = "OK上料";
            this.teachS2.StaNameEn = null;
            this.teachS2.StaNameShow = true;
            this.teachS2.StationID = ((short)(2));
            this.teachS2.XAdd_X = ((short)(0));
            this.teachS2.XAdd_Y = ((short)(0));
            this.teachS2.XDec_X = ((short)(0));
            this.teachS2.XDec_Y = ((short)(0));
            this.teachS2.YAdd_X = ((short)(0));
            this.teachS2.YAdd_Y = ((short)(0));
            this.teachS2.YDec_X = ((short)(0));
            this.teachS2.YDec_Y = ((short)(0));
            this.teachS2.ZAdd_X = ((short)(0));
            this.teachS2.ZAdd_Y = ((short)(0));
            this.teachS2.ZDec_X = ((short)(0));
            this.teachS2.ZDec_Y = ((short)(0));
            this.teachS2.ZExchange = true;
            this.teachS2.ZVisiable = true;
            this.teachS2.名称可编辑 = true;
            // 
            // 流线控制3
            // 
            resources.ApplyResources(this.流线控制3, "流线控制3");
            this.流线控制3.Name = "流线控制3";
            this.流线控制3.流线名称 = ParName.名称枚举.StationID.L上料;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mBtn_Out5);
            this.groupBox4.Controls.Add(this.mBtn_Out6);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // mBtn_Out5
            // 
            this.mBtn_Out5.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out5, "mBtn_Out5");
            this.mBtn_Out5.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out5.Name = "mBtn_Out5";
            this.mBtn_Out5.Tag = "2";
            this.mBtn_Out5.新名称 = null;
            this.mBtn_Out5.脉冲宽度 = 0;
            this.mBtn_Out5.输出类型 = null;
            this.mBtn_Out5.输出编号 = ((short)(64));
            // 
            // mBtn_Out6
            // 
            this.mBtn_Out6.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out6, "mBtn_Out6");
            this.mBtn_Out6.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out6.Name = "mBtn_Out6";
            this.mBtn_Out6.Tag = "2";
            this.mBtn_Out6.新名称 = null;
            this.mBtn_Out6.脉冲宽度 = 0;
            this.mBtn_Out6.输出类型 = null;
            this.mBtn_Out6.输出编号 = ((short)(65));
            // 
            // cylinder8
            // 
            resources.ApplyResources(this.cylinder8, "cylinder8");
            this.cylinder8.Name = "cylinder8";
            this.cylinder8.动点响应 = null;
            this.cylinder8.动点编号 = ((short)(85));
            this.cylinder8.原点响应 = null;
            this.cylinder8.原点编号 = ((short)(87));
            this.cylinder8.输出编号 = "89";
            // 
            // cylinder7
            // 
            resources.ApplyResources(this.cylinder7, "cylinder7");
            this.cylinder7.Name = "cylinder7";
            this.cylinder7.动点响应 = null;
            this.cylinder7.动点编号 = ((short)(84));
            this.cylinder7.原点响应 = null;
            this.cylinder7.原点编号 = ((short)(86));
            this.cylinder7.输出编号 = "89";
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.teachS4);
            this.tabPage16.Controls.Add(this.流线控制4);
            this.tabPage16.Controls.Add(this.groupBox5);
            this.tabPage16.Controls.Add(this.cylinder10);
            this.tabPage16.Controls.Add(this.cylinder9);
            resources.ApplyResources(this.tabPage16, "tabPage16");
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // teachS4
            // 
            resources.ApplyResources(this.teachS4, "teachS4");
            this.teachS4.AxisNum_R = ((short)(0));
            this.teachS4.AxisNum_X = ((short)(0));
            this.teachS4.AxisNum_Y = ((short)(0));
            this.teachS4.AxisNum_Z = ((short)(4));
            this.teachS4.CardNum_R = ((short)(0));
            this.teachS4.CardNum_X = ((short)(0));
            this.teachS4.CardNum_Y = ((short)(0));
            this.teachS4.CardNum_Z = ((short)(0));
            this.teachS4.CardType = null;
            this.teachS4.Name = "teachS4";
            this.teachS4.PointNumber = ((short)(30));
            this.teachS4.RAdd_X = ((short)(0));
            this.teachS4.RAdd_Y = ((short)(0));
            this.teachS4.RDec_X = ((short)(0));
            this.teachS4.RDec_Y = ((short)(0));
            this.teachS4.RunClickHandler = true;
            this.teachS4.StaName = "OK下料";
            this.teachS4.StaNameEn = null;
            this.teachS4.StaNameShow = true;
            this.teachS4.StationID = ((short)(3));
            this.teachS4.XAdd_X = ((short)(0));
            this.teachS4.XAdd_Y = ((short)(0));
            this.teachS4.XDec_X = ((short)(0));
            this.teachS4.XDec_Y = ((short)(0));
            this.teachS4.YAdd_X = ((short)(0));
            this.teachS4.YAdd_Y = ((short)(0));
            this.teachS4.YDec_X = ((short)(0));
            this.teachS4.YDec_Y = ((short)(0));
            this.teachS4.ZAdd_X = ((short)(0));
            this.teachS4.ZAdd_Y = ((short)(0));
            this.teachS4.ZDec_X = ((short)(0));
            this.teachS4.ZDec_Y = ((short)(0));
            this.teachS4.ZExchange = true;
            this.teachS4.ZVisiable = true;
            this.teachS4.名称可编辑 = true;
            // 
            // 流线控制4
            // 
            resources.ApplyResources(this.流线控制4, "流线控制4");
            this.流线控制4.Name = "流线控制4";
            this.流线控制4.流线名称 = ParName.名称枚举.StationID.L下料;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.mBtn_Out7);
            this.groupBox5.Controls.Add(this.mBtn_Out8);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // mBtn_Out7
            // 
            this.mBtn_Out7.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out7, "mBtn_Out7");
            this.mBtn_Out7.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out7.Name = "mBtn_Out7";
            this.mBtn_Out7.Tag = "2";
            this.mBtn_Out7.新名称 = null;
            this.mBtn_Out7.脉冲宽度 = 0;
            this.mBtn_Out7.输出类型 = null;
            this.mBtn_Out7.输出编号 = ((short)(67));
            // 
            // mBtn_Out8
            // 
            this.mBtn_Out8.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out8, "mBtn_Out8");
            this.mBtn_Out8.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out8.Name = "mBtn_Out8";
            this.mBtn_Out8.Tag = "2";
            this.mBtn_Out8.新名称 = null;
            this.mBtn_Out8.脉冲宽度 = 0;
            this.mBtn_Out8.输出类型 = null;
            this.mBtn_Out8.输出编号 = ((short)(68));
            // 
            // cylinder10
            // 
            resources.ApplyResources(this.cylinder10, "cylinder10");
            this.cylinder10.Name = "cylinder10";
            this.cylinder10.动点响应 = null;
            this.cylinder10.动点编号 = ((short)(93));
            this.cylinder10.原点响应 = null;
            this.cylinder10.原点编号 = ((short)(95));
            this.cylinder10.输出编号 = "88";
            // 
            // cylinder9
            // 
            resources.ApplyResources(this.cylinder9, "cylinder9");
            this.cylinder9.Name = "cylinder9";
            this.cylinder9.动点响应 = null;
            this.cylinder9.动点编号 = ((short)(92));
            this.cylinder9.原点响应 = null;
            this.cylinder9.原点编号 = ((short)(94));
            this.cylinder9.输出编号 = "88";
            // 
            // tabPage_R料仓
            // 
            this.tabPage_R料仓.Controls.Add(this.tabControl5);
            resources.ApplyResources(this.tabPage_R料仓, "tabPage_R料仓");
            this.tabPage_R料仓.Name = "tabPage_R料仓";
            this.tabPage_R料仓.UseVisualStyleBackColor = true;
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage13);
            this.tabControl5.Controls.Add(this.tabPage14);
            resources.ApplyResources(this.tabControl5, "tabControl5");
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.teachS1);
            this.tabPage13.Controls.Add(this.流线控制5);
            this.tabPage13.Controls.Add(this.groupBox6);
            this.tabPage13.Controls.Add(this.cylinder12);
            this.tabPage13.Controls.Add(this.cylinder11);
            resources.ApplyResources(this.tabPage13, "tabPage13");
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // teachS1
            // 
            resources.ApplyResources(this.teachS1, "teachS1");
            this.teachS1.AxisNum_R = ((short)(0));
            this.teachS1.AxisNum_X = ((short)(0));
            this.teachS1.AxisNum_Y = ((short)(0));
            this.teachS1.AxisNum_Z = ((short)(5));
            this.teachS1.CardNum_R = ((short)(0));
            this.teachS1.CardNum_X = ((short)(0));
            this.teachS1.CardNum_Y = ((short)(0));
            this.teachS1.CardNum_Z = ((short)(0));
            this.teachS1.CardType = null;
            this.teachS1.Name = "teachS1";
            this.teachS1.PointNumber = ((short)(30));
            this.teachS1.RAdd_X = ((short)(0));
            this.teachS1.RAdd_Y = ((short)(0));
            this.teachS1.RDec_X = ((short)(0));
            this.teachS1.RDec_Y = ((short)(0));
            this.teachS1.RunClickHandler = true;
            this.teachS1.StaName = "NG上料";
            this.teachS1.StaNameEn = null;
            this.teachS1.StaNameShow = true;
            this.teachS1.StationID = ((short)(4));
            this.teachS1.XAdd_X = ((short)(0));
            this.teachS1.XAdd_Y = ((short)(0));
            this.teachS1.XDec_X = ((short)(0));
            this.teachS1.XDec_Y = ((short)(0));
            this.teachS1.YAdd_X = ((short)(0));
            this.teachS1.YAdd_Y = ((short)(0));
            this.teachS1.YDec_X = ((short)(0));
            this.teachS1.YDec_Y = ((short)(0));
            this.teachS1.ZAdd_X = ((short)(0));
            this.teachS1.ZAdd_Y = ((short)(0));
            this.teachS1.ZDec_X = ((short)(0));
            this.teachS1.ZDec_Y = ((short)(0));
            this.teachS1.ZExchange = true;
            this.teachS1.ZVisiable = true;
            this.teachS1.名称可编辑 = true;
            // 
            // 流线控制5
            // 
            resources.ApplyResources(this.流线控制5, "流线控制5");
            this.流线控制5.Name = "流线控制5";
            this.流线控制5.流线名称 = ParName.名称枚举.StationID.R上料;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.mBtn_Out9);
            this.groupBox6.Controls.Add(this.mBtn_Out10);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // mBtn_Out9
            // 
            this.mBtn_Out9.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out9, "mBtn_Out9");
            this.mBtn_Out9.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out9.Name = "mBtn_Out9";
            this.mBtn_Out9.Tag = "2";
            this.mBtn_Out9.新名称 = null;
            this.mBtn_Out9.脉冲宽度 = 0;
            this.mBtn_Out9.输出类型 = null;
            this.mBtn_Out9.输出编号 = ((short)(72));
            // 
            // mBtn_Out10
            // 
            this.mBtn_Out10.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out10, "mBtn_Out10");
            this.mBtn_Out10.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out10.Name = "mBtn_Out10";
            this.mBtn_Out10.Tag = "2";
            this.mBtn_Out10.新名称 = null;
            this.mBtn_Out10.脉冲宽度 = 0;
            this.mBtn_Out10.输出类型 = null;
            this.mBtn_Out10.输出编号 = ((short)(73));
            // 
            // cylinder12
            // 
            resources.ApplyResources(this.cylinder12, "cylinder12");
            this.cylinder12.Name = "cylinder12";
            this.cylinder12.动点响应 = null;
            this.cylinder12.动点编号 = ((short)(101));
            this.cylinder12.原点响应 = null;
            this.cylinder12.原点编号 = ((short)(103));
            this.cylinder12.输出编号 = "87";
            // 
            // cylinder11
            // 
            resources.ApplyResources(this.cylinder11, "cylinder11");
            this.cylinder11.Name = "cylinder11";
            this.cylinder11.动点响应 = null;
            this.cylinder11.动点编号 = ((short)(100));
            this.cylinder11.原点响应 = null;
            this.cylinder11.原点编号 = ((short)(102));
            this.cylinder11.输出编号 = "87";
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.teachS5);
            this.tabPage14.Controls.Add(this.流线控制6);
            this.tabPage14.Controls.Add(this.groupBox7);
            this.tabPage14.Controls.Add(this.cylinder14);
            this.tabPage14.Controls.Add(this.cylinder13);
            resources.ApplyResources(this.tabPage14, "tabPage14");
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // teachS5
            // 
            resources.ApplyResources(this.teachS5, "teachS5");
            this.teachS5.AxisNum_R = ((short)(0));
            this.teachS5.AxisNum_X = ((short)(0));
            this.teachS5.AxisNum_Y = ((short)(0));
            this.teachS5.AxisNum_Z = ((short)(6));
            this.teachS5.CardNum_R = ((short)(0));
            this.teachS5.CardNum_X = ((short)(0));
            this.teachS5.CardNum_Y = ((short)(0));
            this.teachS5.CardNum_Z = ((short)(0));
            this.teachS5.CardType = null;
            this.teachS5.Name = "teachS5";
            this.teachS5.PointNumber = ((short)(30));
            this.teachS5.RAdd_X = ((short)(0));
            this.teachS5.RAdd_Y = ((short)(0));
            this.teachS5.RDec_X = ((short)(0));
            this.teachS5.RDec_Y = ((short)(0));
            this.teachS5.RunClickHandler = true;
            this.teachS5.StaName = "NG下料";
            this.teachS5.StaNameEn = null;
            this.teachS5.StaNameShow = true;
            this.teachS5.StationID = ((short)(5));
            this.teachS5.XAdd_X = ((short)(0));
            this.teachS5.XAdd_Y = ((short)(0));
            this.teachS5.XDec_X = ((short)(0));
            this.teachS5.XDec_Y = ((short)(0));
            this.teachS5.YAdd_X = ((short)(0));
            this.teachS5.YAdd_Y = ((short)(0));
            this.teachS5.YDec_X = ((short)(0));
            this.teachS5.YDec_Y = ((short)(0));
            this.teachS5.ZAdd_X = ((short)(0));
            this.teachS5.ZAdd_Y = ((short)(0));
            this.teachS5.ZDec_X = ((short)(0));
            this.teachS5.ZDec_Y = ((short)(0));
            this.teachS5.ZExchange = true;
            this.teachS5.ZVisiable = true;
            this.teachS5.名称可编辑 = true;
            // 
            // 流线控制6
            // 
            resources.ApplyResources(this.流线控制6, "流线控制6");
            this.流线控制6.Name = "流线控制6";
            this.流线控制6.流线名称 = ParName.名称枚举.StationID.R下料;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.mBtn_Out11);
            this.groupBox7.Controls.Add(this.mBtn_Out12);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // mBtn_Out11
            // 
            this.mBtn_Out11.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out11, "mBtn_Out11");
            this.mBtn_Out11.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out11.Name = "mBtn_Out11";
            this.mBtn_Out11.Tag = "2";
            this.mBtn_Out11.新名称 = null;
            this.mBtn_Out11.脉冲宽度 = 0;
            this.mBtn_Out11.输出类型 = null;
            this.mBtn_Out11.输出编号 = ((short)(75));
            // 
            // mBtn_Out12
            // 
            this.mBtn_Out12.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mBtn_Out12, "mBtn_Out12");
            this.mBtn_Out12.ForeColor = System.Drawing.Color.Transparent;
            this.mBtn_Out12.Name = "mBtn_Out12";
            this.mBtn_Out12.Tag = "2";
            this.mBtn_Out12.新名称 = null;
            this.mBtn_Out12.脉冲宽度 = 0;
            this.mBtn_Out12.输出类型 = null;
            this.mBtn_Out12.输出编号 = ((short)(76));
            // 
            // cylinder14
            // 
            resources.ApplyResources(this.cylinder14, "cylinder14");
            this.cylinder14.Name = "cylinder14";
            this.cylinder14.动点响应 = null;
            this.cylinder14.动点编号 = ((short)(109));
            this.cylinder14.原点响应 = null;
            this.cylinder14.原点编号 = ((short)(111));
            this.cylinder14.输出编号 = "86";
            // 
            // cylinder13
            // 
            resources.ApplyResources(this.cylinder13, "cylinder13");
            this.cylinder13.Name = "cylinder13";
            this.cylinder13.动点响应 = null;
            this.cylinder13.动点编号 = ((short)(108));
            this.cylinder13.原点响应 = null;
            this.cylinder13.原点编号 = ((short)(110));
            this.cylinder13.输出编号 = "86";
            // 
            // 辅助功能
            // 
            this.辅助功能.Controls.Add(this.IOLanguage);
            this.辅助功能.Controls.Add(this.button2);
            resources.ApplyResources(this.辅助功能, "辅助功能");
            this.辅助功能.Name = "辅助功能";
            this.辅助功能.UseVisualStyleBackColor = true;
            // 
            // IOLanguage
            // 
            this.IOLanguage.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.IOLanguage, "IOLanguage");
            this.IOLanguage.Name = "IOLanguage";
            this.IOLanguage.UseVisualStyleBackColor = false;
            this.IOLanguage.Click += new System.EventHandler(this.IOLanguage_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage19
            // 
            this.tabPage19.Controls.Add(this.tabControl7);
            resources.ApplyResources(this.tabPage19, "tabPage19");
            this.tabPage19.Name = "tabPage19";
            this.tabPage19.UseVisualStyleBackColor = true;
            // 
            // tabControl7
            // 
            this.tabControl7.Controls.Add(this.tabPage21);
            this.tabControl7.Controls.Add(this.tabPage22);
            this.tabControl7.Controls.Add(this.tabPage23);
            this.tabControl7.Controls.Add(this.tabPage18);
            this.tabControl7.Controls.Add(this.tabPage4);
            resources.ApplyResources(this.tabControl7, "tabControl7");
            this.tabControl7.Name = "tabControl7";
            this.tabControl7.SelectedIndex = 0;
            this.tabControl7.Tag = "2";
            // 
            // tabPage21
            // 
            this.tabPage21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tabPage21.Controls.Add(this.Panel_ParList);
            resources.ApplyResources(this.tabPage21, "tabPage21");
            this.tabPage21.Name = "tabPage21";
            // 
            // Panel_ParList
            // 
            resources.ApplyResources(this.Panel_ParList, "Panel_ParList");
            this.Panel_ParList.Controls.Add(this.propertyParS2);
            this.Panel_ParList.Controls.Add(this.propertyParS1);
            this.Panel_ParList.Name = "Panel_ParList";
            // 
            // propertyParS2
            // 
            this.propertyParS2.FldLabelWidth = ((short)(0));
            resources.ApplyResources(this.propertyParS2, "propertyParS2");
            this.propertyParS2.Name = "propertyParS2";
            this.propertyParS2.ParNumber = ((short)(2));
            this.propertyParS2.StartIndex = ((short)(108));
            this.propertyParS2.新名称 = null;
            this.propertyParS2.新名称En = null;
            // 
            // propertyParS1
            // 
            this.propertyParS1.FldLabelWidth = ((short)(0));
            resources.ApplyResources(this.propertyParS1, "propertyParS1");
            this.propertyParS1.Name = "propertyParS1";
            this.propertyParS1.ParNumber = ((short)(17));
            this.propertyParS1.StartIndex = ((short)(0));
            this.propertyParS1.新名称 = null;
            this.propertyParS1.新名称En = null;
            // 
            // tabPage22
            // 
            this.tabPage22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tabPage22.Controls.Add(this.Panel_Communication);
            resources.ApplyResources(this.tabPage22, "tabPage22");
            this.tabPage22.Name = "tabPage22";
            // 
            // Panel_Communication
            // 
            this.Panel_Communication.Controls.Add(this.tcP_IP20);
            this.Panel_Communication.Controls.Add(this.tcP_IP17);
            this.Panel_Communication.Controls.Add(this.tcP_IP16);
            this.Panel_Communication.Controls.Add(this.tcP_IP2);
            this.Panel_Communication.Controls.Add(this.tcP_IP3);
            this.Panel_Communication.Controls.Add(this.button3);
            resources.ApplyResources(this.Panel_Communication, "Panel_Communication");
            this.Panel_Communication.Name = "Panel_Communication";
            // 
            // tcP_IP20
            // 
            resources.ApplyResources(this.tcP_IP20, "tcP_IP20");
            this.tcP_IP20.Name = "tcP_IP20";
            this.tcP_IP20.PortID = ((short)(1));
            this.tcP_IP20.新名称 = "机械手";
            this.tcP_IP20.新名称En = "Robot";
            this.tcP_IP20.服务器 = false;
            // 
            // tcP_IP17
            // 
            resources.ApplyResources(this.tcP_IP17, "tcP_IP17");
            this.tcP_IP17.Name = "tcP_IP17";
            this.tcP_IP17.PortID = ((short)(4));
            this.tcP_IP17.新名称 = "载具相机";
            this.tcP_IP17.新名称En = "Carrier Camera";
            this.tcP_IP17.服务器 = false;
            // 
            // tcP_IP16
            // 
            resources.ApplyResources(this.tcP_IP16, "tcP_IP16");
            this.tcP_IP16.Name = "tcP_IP16";
            this.tcP_IP16.PortID = ((short)(5));
            this.tcP_IP16.新名称 = "AVI_PLC";
            this.tcP_IP16.新名称En = "AVI_PLC";
            this.tcP_IP16.服务器 = false;
            // 
            // tcP_IP2
            // 
            resources.ApplyResources(this.tcP_IP2, "tcP_IP2");
            this.tcP_IP2.Name = "tcP_IP2";
            this.tcP_IP2.PortID = ((short)(2));
            this.tcP_IP2.新名称 = "下相机";
            this.tcP_IP2.新名称En = "Down Camera";
            this.tcP_IP2.服务器 = false;
            // 
            // tcP_IP3
            // 
            resources.ApplyResources(this.tcP_IP3, "tcP_IP3");
            this.tcP_IP3.Name = "tcP_IP3";
            this.tcP_IP3.PortID = ((short)(3));
            this.tcP_IP3.新名称 = "机械手相机";
            this.tcP_IP3.新名称En = "Robot Camera";
            this.tcP_IP3.服务器 = false;
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage23
            // 
            this.tabPage23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tabPage23.Controls.Add(this.Axis_Setting);
            this.tabPage23.Controls.Add(this.UserChkSts1);
            resources.ApplyResources(this.tabPage23, "tabPage23");
            this.tabPage23.Name = "tabPage23";
            // 
            // Axis_Setting
            // 
            resources.ApplyResources(this.Axis_Setting, "Axis_Setting");
            this.Axis_Setting.Name = "Axis_Setting";
            this.Axis_Setting.UseVisualStyleBackColor = true;
            this.Axis_Setting.Click += new System.EventHandler(this.Axis_Setting_Click);
            // 
            // UserChkSts1
            // 
            resources.ApplyResources(this.UserChkSts1, "UserChkSts1");
            this.UserChkSts1.Name = "UserChkSts1";
            this.UserChkSts1.ParNumber = ((short)(8));
            this.UserChkSts1.StartIndex = ((short)(0));
            this.UserChkSts1.新名称 = "";
            this.UserChkSts1.新名称En = null;
            // 
            // tabPage18
            // 
            this.tabPage18.Controls.Add(this.offsetCompenControl1);
            resources.ApplyResources(this.tabPage18, "tabPage18");
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.UseVisualStyleBackColor = true;
            // 
            // offsetCompenControl1
            // 
            this.offsetCompenControl1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.offsetCompenControl1, "offsetCompenControl1");
            this.offsetCompenControl1.KeyName = "oK_Line1";
            this.offsetCompenControl1.Name = "offsetCompenControl1";
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tp_UserManagerNew
            // 
            this.tp_UserManagerNew.Controls.Add(this.userManager1);
            resources.ApplyResources(this.tp_UserManagerNew, "tp_UserManagerNew");
            this.tp_UserManagerNew.Name = "tp_UserManagerNew";
            this.tp_UserManagerNew.UseVisualStyleBackColor = true;
            // 
            // userManager1
            // 
            resources.ApplyResources(this.userManager1, "userManager1");
            this.userManager1.Name = "userManager1";
            // 
            // StatusTimer
            // 
            this.StatusTimer.Enabled = true;
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // CheckAlarm
            // 
            this.CheckAlarm.Tick += new System.EventHandler(this.CheckAlarm_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SettingPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(222)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.TabControl1);
            this.Name = "SettingPage";
            this.Tag = "6";
            this.Load += new System.EventHandler(this.me_Load);
            this.TabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.panel_HardWare.ResumeLayout(false);
            this.panel_HardWare.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.Panel0.ResumeLayout(false);
            this.tabControl6.ResumeLayout(false);
            this.tabPage20.ResumeLayout(false);
            this.tabPage20.PerformLayout();
            this.tabPage24.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.TabControl2.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage17.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tP_Manual.ResumeLayout(false);
            this.tb_ProductSN.ResumeLayout(false);
            this.TabPage_L移栽.ResumeLayout(false);
            this.TabPage_L移栽.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.TabPage_R移栽.ResumeLayout(false);
            this.TabPage_R移栽.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.TabPage_L料仓.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tabPage_R料仓.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.辅助功能.ResumeLayout(false);
            this.tabPage19.ResumeLayout(false);
            this.tabControl7.ResumeLayout(false);
            this.tabPage21.ResumeLayout(false);
            this.Panel_ParList.ResumeLayout(false);
            this.tabPage22.ResumeLayout(false);
            this.Panel_Communication.ResumeLayout(false);
            this.tabPage23.ResumeLayout(false);
            this.tabPage18.ResumeLayout(false);
            this.tp_UserManagerNew.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.TabPage tP_Manual;
        internal System.Windows.Forms.TabControl tb_ProductSN;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage 辅助功能;
        private System.ComponentModel.IContainer components;
        internal Panel Panel0;
        internal ComboBox ComboBox_Robot1;
        internal Button Cmd_Robot_Trigger1;
        private Zcm.mButton Robot1_IO_清除错误;
        private Zcm.mShp_Input mShp_Input36;
        private Zcm.mButton Robot1_IO_继续;
        private Zcm.mShp_Input mShp_Input35;
        private Zcm.mButton Robot1_IO_暂停;
        private Zcm.mShp_Input mShp_Input34;
        private Zcm.mButton Robot1_IO_停止;
        private Zcm.mShp_Input mShp_Input33;
        private Zcm.mButton Robot1_IO_启动;
        private Zcm.mButton mButton9;
        private Zcm.mShp_Input mShp_Input32;
        private Zcm.mButton mButton7;
        private Zcm.mShp_Input mShp_Input31;
        private Zcm.mButton mButton5;
        private Zcm.mShp_Input mShp_Input30;
        private Zcm.mButton mButton4;
        private Zcm.mShp_Input mShp_Input29;
        private Zcm.mButton mButton3;
        private TabControl tabControl6;
        private TabPage tabPage20;
        private TabPage tabPage19;
        private TabPage tabPage3;
        private GroupBox groupBox23;
        private GroupBox groupBox22;
        private Label label97;
        private Label label96;
        private Label label95;
        private Label label91;
        private Label label90;
        private ComboBox cbLanguage;
        private ComboBox cbLine;
        private ComboBox cbMachineNum;
        private ComboBox cbSite;
        private AudioButton btnChangeConfig;
        private Panel panel_HardWare;
        internal Button button2;
        public Timer StatusTimer;
        internal Timer CheckAlarm;
        public RichTextBox richTextBox1;
        private Label label6;
        public ComboBox comboBox1;
        public ComboBox cbStation;
        private TabPage tp_UserManagerNew;
        private UserManager userManager1;
        private TabPage tabPage6;
        private TabPage tabPage7;
        internal TabControl TabControl2;
        internal TabPage tabPage9;
        private TabPage tabPage10;
        private TabPage TabPage_L移栽;
        internal TabPage tabPage8;
        internal Zcm.InputClass inputClass5;
        internal Zcm.InputClass inputClass4;
        internal Zcm.InputClass inputClass7;
        internal TabControl tabControl7;
        internal TabPage tabPage21;
        internal Panel Panel_ParList;
        private Zcm.PropertyParS propertyParS1;
        private Zcm.PropertyParS propertyParS2;
        internal TabPage tabPage22;
        internal Panel Panel_Communication;
        internal Zcm.TCP_IP tcP_IP2;
        internal Zcm.TCP_IP tcP_IP16;
        internal Zcm.TCP_IP tcP_IP17;
        internal TabPage tabPage23;
        internal Zcm.UserChk UserChkSts1;
        private TabPage TabPage_L料仓;
        internal Zcm.InputClass InputClass1;
        internal Zcm.InputClass inputClass12;
        internal TabControl tabControl3;
        internal TabPage tabPage2;
        internal Zcm.OutputClass inputClass6;
        internal Zcm.OutputClass inputClass9;
        internal TabPage tabPage11;
        internal Zcm.OutputClass inputClass11;
        internal Zcm.OutputClass inputClass13;
        private TabPage tabPage12;
        private TabPage TabPage_R移栽;
        private Zcm.TeachS teachS2;
        private Zcm.TeachS teachS6;
        private TabControl tabControl4;
        private TabPage tabPage15;
        //private BoTech.User_Control.mTaskManual mTaskManual1;
        internal Zcm.TCP_IP tcP_IP3;
        private TabPage tabPage16;
        private Timer timer1;
        public Zcm.TCP_IP tcP_IP20;

        internal Label label4;
        internal Label label5;
        internal Label Label_MachineStatus;
        internal Label Label47;
        internal Label label13;
        internal Zcm.InputClass inputClass3;
        internal Zcm.OutputClass inputClass10;
        private Zcm.TeachS teachS3;
        private Zcm.TeachS teachS4;
        private TabPage tabPage_R料仓;
        private TabControl tabControl5;
        private TabPage tabPage13;
        private Zcm.TeachS teachS1;
        private TabPage tabPage14;
        private Zcm.TeachS teachS5;
        private TabPage tabPage17;
        internal Zcm.InputClass inputClass2;
        internal Zcm.OutputClass outputClass1;
        private Zcm.Cylinder cylinder3;
        private Zcm.Cylinder cylinder2;
        private Zcm.Cylinder cylinder1;
        private Zcm.Cylinder cylinder6;
        private Zcm.Cylinder cylinder5;
        private Zcm.Cylinder cylinder4;
        private Zcm.Cylinder cylinder8;
        private Zcm.Cylinder cylinder7;
        private Zcm.Cylinder cylinder10;
        private Zcm.Cylinder cylinder9;
        private Zcm.Cylinder cylinder12;
        private Zcm.Cylinder cylinder11;
        private Zcm.Cylinder cylinder14;
        private Zcm.Cylinder cylinder13;
        private GroupBox groupBox1;
        private Zcm.mBtn_Out mBtn_Out2;
        private Zcm.mBtn_Out mBtn_Out1;
        private GroupBox groupBox2;
        private Zcm.mBtn_Out mBtn_Out3;
        private Zcm.mBtn_Out mBtn_Out4;
        private GroupBox groupBox4;
        private Zcm.mBtn_Out mBtn_Out5;
        private Zcm.mBtn_Out mBtn_Out6;
        private GroupBox groupBox5;
        private Zcm.mBtn_Out mBtn_Out7;
        private Zcm.mBtn_Out mBtn_Out8;
        private GroupBox groupBox6;
        private Zcm.mBtn_Out mBtn_Out9;
        private Zcm.mBtn_Out mBtn_Out10;
        private GroupBox groupBox7;
        private Zcm.mBtn_Out mBtn_Out11;
        private Zcm.mBtn_Out mBtn_Out12;
        private BoTech.User_Control.流线控制 流线控制1;
        private BoTech.User_Control.流线控制 流线控制2;
        private BoTech.User_Control.流线控制 流线控制3;
        private BoTech.User_Control.流线控制 流线控制4;
        private BoTech.User_Control.流线控制 流线控制5;
        private BoTech.User_Control.流线控制 流线控制6;
        private TabPage tabPage24;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button3;
        private TabPage tabPage18;
        private TableLayoutPanel tableLayoutPanel1;
        private LParamManag.Manage.Control.OffsetCompenControl offsetCompenControl1;
        private TabPage tabPage4;

        private Button Axis_Setting;
        internal Button IOLanguage;
        private XStation.StationRun stationRun2;
        private XStation.StationRun stationRun3;
        private XStation.StationRun stationRun5;
        private XStation.StationRun stationRun1;
        private XStation.StationRun stationRun4;
        private XStation.StationRun stationRun6;
    }

}
