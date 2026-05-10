using LParamManag.Manage.Collection;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LParamManag.Manage.Control
{
    public partial class OffsetCompenControl : UserControl
    {
        public OffsetCompenControl()
        {
            InitializeComponent();

            //列标题居中显示
            lMyDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //禁止添加行
            lMyDataGridView1.AllowUserToAddRows = false;
            lMyDataGridView1.AllowUserToResizeRows = false;
            //设置单元格文本居中
            lMyDataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //设置单元格文本颜色
            lMyDataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
            //禁止用户使用鼠标改变列标题高度
            lMyDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //设置列头的高度
            lMyDataGridView1.ColumnHeadersHeight = 30;
            //去除首列
            lMyDataGridView1.RowHeadersVisible = false;
            // 禁止用户改变DataGridView的所有列的列宽
            lMyDataGridView1.AllowUserToResizeColumns = false;
        }

        public string KeyName { get; set; }

        private void Init(string _keyName)
        {
            this.lMyDataGridView1.CellValueChanged -= this.lMyDataGridView1_CellValueChanged;
            lMyDataGridView1.Columns.Clear();
            lMyDataGridView1.AddColumnString("Index", 70);
            lMyDataGridView1.AddColumnString("Name", 180);
            lMyDataGridView1.AddColumnDouble("X", 100, false);
            lMyDataGridView1.AddColumnDouble("Y", 100, false);
            lMyDataGridView1.AddColumnDouble("Z", 100, false);
            lMyDataGridView1.AddColumnDouble("R", 100, false);
            if (OffsetParamCollection.PARAM_Offset_Parameter.ContainsKey(_keyName))
            {
                for (int i = 0; i < OffsetParamCollection.PARAM_Offset_Parameter[_keyName].Count; i++)
                {
                    lMyDataGridView1.AddRow(i.ToString());
                    lMyDataGridView1.SetItemString(1, i, OffsetParamCollection.PARAM_Offset_Parameter[_keyName][i].Name);
                    lMyDataGridView1.SetItemDouble(2, i, OffsetParamCollection.PARAM_Offset_Parameter[_keyName][i].Value_X);
                    lMyDataGridView1.SetItemDouble(3, i, OffsetParamCollection.PARAM_Offset_Parameter[_keyName][i].Value_Y);
                    lMyDataGridView1.SetItemDouble(4, i, OffsetParamCollection.PARAM_Offset_Parameter[_keyName][i].Value_Z);
                    lMyDataGridView1.SetItemDouble(5, i, OffsetParamCollection.PARAM_Offset_Parameter[_keyName][i].Value_R);
                }
                this.lMyDataGridView1.CellValueChanged += this.lMyDataGridView1_CellValueChanged;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OffsetParamCollection.GetIntance.Save();
            MessageBox.Show("OffsetCompenParam.json 保存完成!!!");
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyName = comboBox1.SelectedItem.ToString();

            Init(KeyName);
        }

        private void lMyDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 2)
            {
                double CurrentCellValue = double.Parse(lMyDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if (e.ColumnIndex == 2)
                {
                    if (OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MinValue_X <= CurrentCellValue && CurrentCellValue <= OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MaxValue_X)
                    {
                        if (OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_X != CurrentCellValue)
                        {
                            OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_X = CurrentCellValue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入值" + CurrentCellValue + ",超出范围" + OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MinValue_X + "-" + OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MaxValue_X + ".", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lMyDataGridView1.SetItemDouble(2, e.RowIndex, OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_X);
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MinValue_Y <= CurrentCellValue && CurrentCellValue <= OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MaxValue_Y)
                    {
                        if (OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_Y != CurrentCellValue)
                        {
                            OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_Y = CurrentCellValue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入值" + CurrentCellValue + ",超出范围" + OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MinValue_Y + "-" + OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MaxValue_Y + ".", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lMyDataGridView1.SetItemDouble(3, e.RowIndex, OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_Y);
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    if (OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MinValue_R <= CurrentCellValue && CurrentCellValue <= OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MaxValue_R)
                    {
                        if (OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_R != CurrentCellValue)
                        {
                            OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_R = CurrentCellValue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入值" + CurrentCellValue + ",超出范围" + OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MinValue_R + "-" + OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MaxValue_R + ".", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lMyDataGridView1.SetItemDouble(5, e.RowIndex, OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_R);
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    if (OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MinValue_Z <= CurrentCellValue && CurrentCellValue <= OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MaxValue_Z)
                    {
                        if (OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_Z != CurrentCellValue)
                        {
                            OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_Z = CurrentCellValue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入值" + CurrentCellValue + ",超出范围" + OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MinValue_Z + "-" + OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].MaxValue_Z + ".", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lMyDataGridView1.SetItemDouble(4, e.RowIndex, OffsetParamCollection.PARAM_Offset_Parameter[KeyName][e.RowIndex].Value_Z);
                    }
                }

                this.lMyDataGridView1.Rows[e.RowIndex].Selected = true;
                this.lMyDataGridView1.CurrentCell = this.lMyDataGridView1.Rows[e.RowIndex].Cells[0];
            }
        }

        private void OffsetCompenControl_Load(object sender, EventArgs e)
        {
            if (OffsetParamCollection.PARAM_Offset_Parameter != null)
            {
                var count = OffsetParamCollection.PARAM_Offset_Parameter.Count;
                if (count > 0)
                {
                    comboBox1.Items.Clear();
                    foreach (var item in OffsetParamCollection.PARAM_Offset_Parameter)
                    {
                        comboBox1.Items.Add(item.Key);
                    }
                    comboBox1.SelectedIndex = 0;

                    KeyName = comboBox1.SelectedItem.ToString();
                }
            }
        }
    }
}