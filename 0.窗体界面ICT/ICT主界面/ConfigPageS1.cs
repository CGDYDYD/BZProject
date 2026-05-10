using System;
using System.Drawing;
using System.Windows.Forms;
using static CoreFunction.mFunction;

namespace BoTech
{
    public partial class ConfigPage : MyControl
    {
        private static ConfigPage instance;

        public static ConfigPage Instance
        {
            get
            {
                if (instance?.IsDisposed != false)
                {
                    instance = new ConfigPage();
                }
                return instance;
            }
        }

        public ConfigPage()
        {
            InitializeComponent();

            AudioLoginManager.Instance.UserLogin_event += UserLevelChange;
            AudioLoginManager.Instance.Logout_event += UserLogout;
            ControlDisable();

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.BackgroundColor = Color.FromArgb(213, 213, 213);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(213, 213, 213);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 193, 255);
            dataGridView1.ReadOnly = true;
            dataGridView1.Enabled = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(Column_add("Enable", "Enable", true));
            dataGridView1.Columns.Add(Column_add("KeyName", "KeyName"));
            dataGridView1.Columns.Add(Column_add("LSL", "LSL"));
            dataGridView1.Columns.Add(Column_add("USL", "USL"));
            //GlobalVar.critialParamCls.CiritialParamDatas.Clear();
        }

        private DataGridViewColumn Column_add(string name, string dataPropertyName, bool isCheckBoxClum = false)
        {
            if (isCheckBoxClum)
            {
                DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = name,
                    ReadOnly = true
                };
                dataGridViewCheckBoxColumn.HeaderCell.Style.BackColor = Color.BlueViolet;
                return dataGridViewCheckBoxColumn;
            }
            DataGridViewTextBoxColumn txtClum = new DataGridViewTextBoxColumn();
            Name = dataPropertyName;
            txtClum.DataPropertyName = dataPropertyName;
            txtClum.HeaderText = name;
            txtClum.SortMode = DataGridViewColumnSortMode.NotSortable;
            txtClum.MinimumWidth = 120;
            txtClum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            txtClum.HeaderCell.Style.BackColor = Color.FromArgb(115, 253, 234);
            txtClum.HeaderCell.Style.SelectionBackColor = Color.FromArgb(115, 253, 234);

            return txtClum;
        }

        private void ControlDisable()
        {
            this.pa_Level2.Enabled = false;
            this.pa_Level3.Enabled = false;
            this.nB_Edit.Visible = false;
            this.nB_Save.Visible = false;
            this.DGV_SpecLimit.AllowUserToAddRows = false;
            this.DGV_SpecLimit.ReadOnly = true;
            gb_Laser.Enabled = false;
        }

        private void UserLevelChange(AccountInfo AI)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    if (AI.UserLevel == LoginLevel.Level2)
                    {
                        this.pa_Level2.Enabled = true;
                        dataGridView1.ReadOnly = true;
                    }
                    else if (AI.UserLevel >= LoginLevel.Level3)
                    {
                        this.pa_Level2.Enabled = true;
                        this.pa_Level3.Enabled = true;
                        this.nB_Edit.Visible = true;
                        this.nB_Save.Visible = true;
                        SetCellReadOnly();
                        gb_Laser.Enabled = true;
                    }
                    else
                    {
                        ControlDisable();
                    }
                }));
            }
            else
            {
                this.CreateHandle();
                UserLevelChange(AI);
            }
        }

        public void SetCellReadOnly()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].ReadOnly = i != 0;
            }
        }

        private void UserLogout()
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() => ControlDisable()));
            }
        }

        public void Frm_Par_Load(object sender, EventArgs e)
        {
            this.Tag = 3;
            //InitConfigData();
            mGlobal.ChildFrmOffsetPoint = new Point(0, 0);
            this.Location = mGlobal.ChildFrmOffsetPoint;
            this.Size = new Size(Frm_ICT_Main.Instance.Main_ChildPage.Width, Frm_ICT_Main.Instance.Main_ChildPage.Height);
            SetTag(this, Convert.ToInt32(this.Tag), true);
            SetControls(mGlobal.NewX, mGlobal.NewY, this, Convert.ToInt32(this.Tag), true);
        }
    }
}