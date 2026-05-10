using L_MyCTRLData_name;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace L_MyCTRL_name
{
    /// <summary>
    /// 重绘ComboBox
    /// </summary>
    public partial class LMyComboBox : ComboBox
    {
        public LMyComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();

            string strText = this.Items[e.Index].ToString();

            e.Graphics.DrawString(strText, e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y);
        }
    }

    /// <summary>
    /// /重绘DataGridView
    /// </summary>
    public partial class LMyDataGridView : DataGridView
    {
        //数据表

        // 定义下拉列表框
        private LMyComboBox cmb_Temp = new LMyComboBox();

        private TextBox Text_Temp = new TextBox();
        private List<LMColType> m_List = new List<LMColType>();

        private bool EnableEdit;
        private int OldSelCol;
        private int OldSelRow;

        public LMyDataGridView()
        {
            AutoGenerateColumns = false;

            AllowUserToAddRows = false;
            EnableEdit = true;

            //利用反射设置DataGridView的双缓冲
            Type dgvType = this.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this, true, null);

            this.EditMode = DataGridViewEditMode.EditOnF2;
            cmb_Temp.Visible = false;
            // 添加下拉列表框事件
            cmb_Temp.SelectedIndexChanged += cmb_Temp_SelectedIndexChanged;
            this.Controls.Add(cmb_Temp);

            Text_Temp.AutoSize = false;
            Text_Temp.Visible = false;
            Text_Temp.VisibleChanged += Txet_Temp_VisibleChanged;
            Text_Temp.KeyDown += Txet_Temp_KeyDown;
            this.Controls.Add(Text_Temp);
        }

        private void Txet_Temp_KeyDown(object sender, KeyEventArgs e)
        {
            Text_Temp.Focus();
        }

        public int GetRowIndexAt(int mouseLocation_X, int mouseLocation_Y)
        {
            if (this.FirstDisplayedScrollingRowIndex < 0)
            {
                return -1;
            }
            if (this.ColumnHeadersVisible && mouseLocation_Y <= this.ColumnHeadersHeight)
            {
                return -1;
            }

            int index = this.FirstDisplayedScrollingRowIndex;
            int indexy = this.FirstDisplayedScrollingColumnIndex;
            int displayedCount = this.DisplayedRowCount(true);
            int displayedCounty = this.DisplayedColumnCount(true);
            for (int k = 1; k <= displayedCount;)
            {
                indexy = this.FirstDisplayedScrollingColumnIndex;
                for (int ky = 1; ky <= displayedCounty;)
                {
                    Rectangle rect = this.GetCellDisplayRectangle(indexy, index, true);  // 取该区域的显示部分区域
                    if (rect.Top <= mouseLocation_Y && mouseLocation_Y < rect.Bottom && rect.Left <= mouseLocation_X && mouseLocation_X < rect.Right)
                    {
                        return index + indexy;
                    }
                    ky++;
                    indexy++;
                }
                k++;

                index++;
            }
            return -1;
        }

        // 自定义事件的参数类型
        public delegate void Clik_CellSinglBtn(object sender, EventArgs e, int nRow, int nColumn, bool bOut);

        [Description("当点击控件时发生，调用选中当前控件逻辑"), Category("自定义事件")]
        public event Clik_CellSinglBtn OnClik_CellSinglBtn;

        // 自定义事件的参数类型
        public delegate void Clik_CellCheckBox(object sender, EventArgs e, int nCol, int nRow, bool bOut);

        [Description("当点击控件时发生，调用选中当前控件逻辑"), Category("自定义事件")]
        public event Clik_CellCheckBox OnClik_CellCheckBox;

        // 自定义事件的参数类型
        public delegate void OnMCellINTValueChanged(object sender, EventArgs e, int nCol, int nRow, int vValue);

        [Description("当点击控件时发生，调用选中当前控件逻辑"), Category("自定义事件")]
        public event OnMCellINTValueChanged OnOnMCellINTValueChanged;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!EnableEdit)
            {
                return;
            }
            if (GetRowIndexAt(e.X, e.Y) == -1)
            {
                if (this.CurrentCell != null && cmb_Temp.Visible)
                {
                    this.CurrentCell.Value = cmb_Temp.Text;
                }
                cmb_Temp.Visible = false;
                Text_Temp.Visible = false;
                this.CurrentCell = null;
            }
            else
            {
                cmb_Temp.Visible = false;
                Text_Temp.Visible = false;
                if (this.CurrentCell == null)
                {
                    base.OnMouseClick(e);
                    return;
                }

                if (m_List[this.CurrentCell.ColumnIndex].ReadOnly)
                {
                    base.OnMouseClick(e);
                    return;
                }
                try
                {
                    Rectangle rect = this.GetCellDisplayRectangle(this.CurrentCell.ColumnIndex, this.CurrentCell.RowIndex, false);
                    switch (m_List[this.CurrentCell.ColumnIndex].columType)
                    {
                        case nType._USER_COMBOX:
                            if (OldSelCol == this.CurrentCell.ColumnIndex && OldSelRow == this.CurrentCell.RowIndex)
                            {
                                return;
                            }
                            OldSelCol = this.CurrentCell.ColumnIndex;
                            OldSelRow = this.CurrentCell.RowIndex;
                            string sexValue = this.CurrentCell.Value.ToString();
                            cmb_Temp.Items.Clear();
                            for (int i = 0; i < m_List[this.CurrentCell.ColumnIndex].m_ComboStr.Count; i++)
                            {
                                cmb_Temp.Items.Add(m_List[this.CurrentCell.ColumnIndex].m_ComboStr[i]);
                            }
                            cmb_Temp.SelectedText = sexValue;
                            cmb_Temp.Text = sexValue;
                            if (rect.Height > 6)
                            {
                                cmb_Temp.ItemHeight = rect.Height - 6;
                            }
                            cmb_Temp.Left = rect.Left;
                            cmb_Temp.Top = rect.Top;
                            cmb_Temp.Width = rect.Width;
                            cmb_Temp.Height = rect.Height;
                            cmb_Temp.Visible = true;
                            break;

                        case nType._USER_SIGNALBTN:
                            OldSelCol = this.CurrentCell.ColumnIndex;
                            OldSelRow = this.CurrentCell.RowIndex;
                            if (e.X < rect.X + 3 || e.X > rect.Right - 4 || e.Y < rect.Y + 3 || e.Y > rect.Bottom - 4)
                            {
                                return;
                            }

                            string str = this.CurrentCell.Value == null ? "" : this.CurrentCell.Value.ToString();
                            if (str != "0" && str != "" && str != "FALSE" && str != "false" && str != "False")
                            {
                                this.CurrentCell.Value = false;
                                if (OnClik_CellSinglBtn != null)
                                {
                                    OnClik_CellSinglBtn.Invoke(this, EventArgs.Empty, this.CurrentCell.RowIndex, this.CurrentCell.ColumnIndex, false);
                                }
                            }
                            else
                            {
                                this.CurrentCell.Value = true;
                                if (OnClik_CellSinglBtn != null)
                                {
                                    OnClik_CellSinglBtn.Invoke(this, EventArgs.Empty, this.CurrentCell.RowIndex, this.CurrentCell.ColumnIndex, true);
                                }
                            }

                            break;

                        case nType._USER_BOOL:
                            if (OldSelCol == this.CurrentCell.ColumnIndex && OldSelRow == this.CurrentCell.RowIndex)
                            {
                                return;
                            }
                            OldSelCol = this.CurrentCell.ColumnIndex;
                            OldSelRow = this.CurrentCell.RowIndex;
                            sexValue = this.CurrentCell.Value.ToString();
                            cmb_Temp.Items.Clear();
                            for (int i = 0; i < m_List[this.CurrentCell.ColumnIndex].m_ComboStr.Count; i++)
                            {
                                cmb_Temp.Items.Add(m_List[this.CurrentCell.ColumnIndex].m_ComboStr[i]);
                            }
                            cmb_Temp.SelectedText = sexValue;
                            cmb_Temp.Text = sexValue;
                            if (rect.Height > 6)
                            {
                                cmb_Temp.ItemHeight = rect.Height - 6;
                            }
                            cmb_Temp.Left = rect.Left;
                            cmb_Temp.Top = rect.Top;
                            cmb_Temp.Width = rect.Width;
                            cmb_Temp.Height = rect.Height;
                            cmb_Temp.Visible = true;
                            break;

                        case nType._USER_CHECK:
                            OldSelCol = this.CurrentCell.ColumnIndex;
                            OldSelRow = this.CurrentCell.RowIndex;
                            base.OnMouseClick(e);

                            break;
                    }
                }
                catch
                {
                }
            }
        }

        protected override void OnCurrentCellDirtyStateChanged(EventArgs e)
        {
            base.OnCurrentCellDirtyStateChanged(e);

            this.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            try
            {
                base.OnCellValueChanged(e);

                if (m_List[e.ColumnIndex].columType == nType._USER_CHECK)
                {
                    int n = this.CurrentCell.RowIndex;
                    if (n != e.RowIndex)
                    {
                        return;
                    }

                    if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && (bool)this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                    {
                        if (OnClik_CellCheckBox != null)
                        {
                            OnClik_CellCheckBox.Invoke(this, EventArgs.Empty, e.ColumnIndex, e.RowIndex, true);
                        }
                    }
                    else
                    {
                        if (OnClik_CellCheckBox != null)
                        {
                            OnClik_CellCheckBox.Invoke(this, EventArgs.Empty, e.ColumnIndex, e.RowIndex, false);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (!EnableEdit)
            {
                return;
            }
            if (GetRowIndexAt(e.X, e.Y) == -1)
            {
                if (this.CurrentCell != null && cmb_Temp.Visible)
                {
                    this.CurrentCell.Value = cmb_Temp.Text;
                }
                cmb_Temp.Visible = false;
                Text_Temp.Visible = false;
                this.CurrentCell = null;
            }
            else
            {
                cmb_Temp.Visible = false;
                Text_Temp.Visible = false;
                if (this.CurrentCell == null)
                {
                    base.OnMouseDoubleClick(e);
                    return;
                }

                if (m_List[this.CurrentCell.ColumnIndex].ReadOnly)
                {
                    base.OnMouseDoubleClick(e);
                    return;
                }
                try
                {
                    Rectangle rect = this.GetCellDisplayRectangle(this.CurrentCell.ColumnIndex, this.CurrentCell.RowIndex, false);
                    switch (m_List[this.CurrentCell.ColumnIndex].columType)
                    {
                        case nType._USER_STRING:
                            OldSelCol = this.CurrentCell.ColumnIndex;
                            OldSelRow = this.CurrentCell.RowIndex;
                            Text_Temp.Text = this.CurrentCell.Value.ToString();

                            Text_Temp.Left = rect.Left;
                            Text_Temp.Top = rect.Top;
                            Text_Temp.Width = rect.Width;
                            Text_Temp.Height = rect.Height;
                            Text_Temp.Visible = true;
                            Text_Temp.Focus();
                            //设置光标的位置到文本尾
                            Text_Temp.Select(Text_Temp.TextLength, 0);
                            //滚动到控件光标处
                            Text_Temp.ScrollToCaret();
                            break;

                        case nType._USER_INT:
                            OldSelCol = this.CurrentCell.ColumnIndex;
                            OldSelRow = this.CurrentCell.RowIndex;
                            Text_Temp.Text = this.CurrentCell.Value.ToString();
                            Text_Temp.Left = rect.Left;
                            Text_Temp.Top = rect.Top;
                            Text_Temp.Width = rect.Width;
                            Text_Temp.Height = rect.Height;
                            Text_Temp.Visible = true;
                            Text_Temp.Focus();
                            //设置光标的位置到文本尾
                            Text_Temp.Select(Text_Temp.TextLength, 0);
                            //滚动到控件光标处
                            Text_Temp.ScrollToCaret();
                            break;

                        case nType._USER_DOUBLE:
                            OldSelCol = this.CurrentCell.ColumnIndex;
                            OldSelRow = this.CurrentCell.RowIndex;
                            Text_Temp.Text = this.CurrentCell.Value.ToString();
                            Text_Temp.Left = rect.Left;
                            Text_Temp.Top = rect.Top;
                            Text_Temp.Width = rect.Width;
                            Text_Temp.Height = rect.Height;
                            Text_Temp.Visible = true;
                            Text_Temp.Focus();
                            //设置光标的位置到文本尾
                            Text_Temp.Select(Text_Temp.TextLength, 0);
                            //滚动到控件光标处
                            Text_Temp.ScrollToCaret();
                            break;
                    }
                }
                catch
                {
                }
            }
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            cmb_Temp.Visible = false;
            Text_Temp.Visible = false;
            base.OnScroll(e);
        }

        // 当用户选择下拉列表框时改变DataGridView单元格的内容
        private void cmb_Temp_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentCell.Value = ((LMyComboBox)sender).Text;
        }

        private void Txet_Temp_VisibleChanged(object sender, EventArgs e)
        {
            if (Text_Temp.Visible)
            {
                return;
            }
            string str = ((TextBox)sender).Text;
            if (OldSelCol >= Columns.Count || OldSelRow >= Rows.Count)
            {
                return;
            }
            switch (m_List[OldSelCol].columType)
            {
                case nType._USER_INT:
                    if (!Regex.IsMatch(str, @"^[+-]?\d*$"))
                    {
                        //不是int
                        Text_Temp.Visible = true;
                        Text_Temp.Focus();
                        //设置光标的位置到文本尾
                        Text_Temp.Select(Text_Temp.TextLength, 0);
                        //滚动到控件光标处
                        Text_Temp.ScrollToCaret();
                        base.SetCurrentCellAddressCore(OldSelCol, OldSelRow, false, false, false);
                        return;
                    }

                    break;

                case nType._USER_DOUBLE:
                    if (!Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                    {
                        //不是数字
                        Text_Temp.Visible = true;
                        Text_Temp.Focus();
                        //设置光标的位置到文本尾
                        Text_Temp.Select(Text_Temp.TextLength, 0);
                        //滚动到控件光标处
                        Text_Temp.ScrollToCaret();
                        base.SetCurrentCellAddressCore(OldSelCol, OldSelRow, false, false, false);
                        return;
                    }
                    break;
            }

            Rows[OldSelRow].Cells[OldSelCol].Value = str;
            if (m_List[OldSelCol].columType == nType._USER_INT)
            {
                if (OnOnMCellINTValueChanged != null)
                {
                    OnOnMCellINTValueChanged.Invoke(this, EventArgs.Empty, OldSelCol, OldSelRow, Convert.ToInt32(str));
                }
            }
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                ///////绘制控件
                for (int i = 0; i < ColumnCount; i++)
                {
                    switch (m_List[i].columType)
                    {
                        case nType._USER_COMBOX:
                            break;

                        case nType._USER_SIGNAL:
                            for (int r = 0; r < RowCount; r++)
                            {
                                Rectangle rectSignal = this.GetCellDisplayRectangle(i, r, false);//获取单元格显示矩形
                                if (rectSignal.Height <= 0 || rectSignal.Width <= 0)
                                {
                                    continue;
                                }
                                if (rectSignal.Height > 3 && rectSignal.Width > 3)
                                {
                                    rectSignal.X++;
                                    rectSignal.Y++;
                                    rectSignal.Height -= 3;
                                    rectSignal.Width -= 3;
                                }
                                string str = Rows[r].Cells[i].Value == null ? "" : Rows[r].Cells[i].Value.ToString();

                                if (str != "0" && str != "" && str != "FALSE" && str != "false" && str != "False")
                                {
                                    StringFormat stringFormat = new StringFormat
                                    {
                                        LineAlignment = StringAlignment.Center,
                                        Alignment = StringAlignment.Center
                                    };//封装文本布局信息
                                    LinearGradientBrush LinearGradientBrushs = new LinearGradientBrush(rectSignal, Color.FromArgb(138, 174, 79), Color.FromArgb(138, 234, 79), LinearGradientMode.Vertical);
                                    //根据一个矩形、起始颜色和结束颜色以及方向，创建 LinearGradientBrush 类的新实例。

                                    e.Graphics.FillRectangle(LinearGradientBrushs, rectSignal);//填充 Rectangle 结构指定的矩形的内部。
                                    e.Graphics.DrawString("ON", this.Font, new SolidBrush(base.ForeColor), rectSignal, stringFormat);
                                    //使用指定 Brush 的格式化特性，用指定的 Font 和 StringFormat 对象在指定的位置绘制指定的文本字符串。
                                }
                                else
                                {
                                    LinearGradientBrush LinearGradientBrushs = new LinearGradientBrush(rectSignal, Color.FromArgb(230, 30, 30), Color.FromArgb(230, 60, 60), LinearGradientMode.Vertical);

                                    e.Graphics.FillRectangle(LinearGradientBrushs, rectSignal);
                                    StringFormat stringFormat = new StringFormat
                                    {
                                        LineAlignment = StringAlignment.Center,
                                        Alignment = StringAlignment.Center
                                    };
                                    e.Graphics.DrawString("OFF", this.Font, new SolidBrush(base.ForeColor), rectSignal, stringFormat);
                                }
                            }

                            break;

                        case nType._USER_SIGNALBTN:
                            for (int r = 0; r < RowCount; r++)
                            {
                                Rectangle rectSignal = this.GetCellDisplayRectangle(i, r, false);
                                Rectangle rectText = new Rectangle();
                                Rectangle rectBtn = new Rectangle();
                                if (rectSignal.Height <= 0 || rectSignal.Width <= 0)
                                {
                                    continue;
                                }
                                if (rectSignal.Height > 3 && rectSignal.Width > 3)
                                {
                                    rectSignal.X++;
                                    rectSignal.Y++;
                                    rectSignal.Height -= 3;
                                    rectSignal.Width -= 3;
                                }
                                rectText = rectSignal;
                                rectBtn = rectSignal;
                                string str = Rows[r].Cells[i].Value == null ? "" : Rows[r].Cells[i].Value.ToString();

                                if (str != "0" && str != "" && str != "FALSE" && str != "false" && str != "False")
                                {
                                    if (rectText.Width > 20)
                                    {
                                        rectText.Width -= 20;
                                        rectBtn.Width = 20;
                                        rectBtn.X = rectText.Right;
                                    }
                                    StringFormat stringFormat = new StringFormat
                                    {
                                        LineAlignment = StringAlignment.Center,
                                        Alignment = StringAlignment.Center
                                    };
                                    LinearGradientBrush LinearGradientBrushs = new LinearGradientBrush(rectSignal, Color.FromArgb(138, 174, 79), Color.FromArgb(138, 234, 79), LinearGradientMode.Vertical);
                                    e.Graphics.FillRectangle(LinearGradientBrushs, rectSignal);
                                    e.Graphics.DrawString("ON", this.Font, new SolidBrush(base.ForeColor), rectText, stringFormat);
                                    LinearGradientBrush LinearGradientBrushs2 = new LinearGradientBrush(rectSignal, Color.FromArgb(188, 180, 220), Color.FromArgb(240, 240, 240), LinearGradientMode.Vertical);
                                    e.Graphics.FillRectangle(LinearGradientBrushs2, rectBtn);
                                }
                                else
                                {
                                    if (rectText.Width > 20)
                                    {
                                        rectText.Width -= 20;
                                        rectBtn.Width = 20;
                                        rectText.X = rectBtn.Right;
                                    }
                                    LinearGradientBrush LinearGradientBrushs = new LinearGradientBrush(rectSignal, Color.FromArgb(230, 30, 30), Color.FromArgb(230, 60, 60), LinearGradientMode.Vertical);
                                    e.Graphics.FillRectangle(LinearGradientBrushs, rectSignal);
                                    StringFormat stringFormat = new StringFormat
                                    {
                                        LineAlignment = StringAlignment.Center,
                                        Alignment = StringAlignment.Center
                                    };
                                    e.Graphics.DrawString("OFF", this.Font, new SolidBrush(base.ForeColor), rectText, stringFormat);
                                    LinearGradientBrush LinearGradientBrushs2 = new LinearGradientBrush(rectSignal, Color.FromArgb(188, 180, 220), Color.FromArgb(240, 240, 240), LinearGradientMode.Vertical);
                                    e.Graphics.FillRectangle(LinearGradientBrushs2, rectBtn);
                                }
                            }
                            break;

                        case nType._USER_STRING:

                        case nType._USER_INT:

                        case nType._USER_DOUBLE:

                        case nType._USER_BOOL:

                        case nType._USER_CHECK:
                            break;
                    }
                }
            }
            finally
            {
            }
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
        }

        /// <summary>
        /// 添加string类型列
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="nWidth"></param>
        /// <param name="bReadOnly"></param>
        public void AddColumnString(string Text, int nWidth, bool bReadOnly = true)
        {
            LMColType m_temp = new LMColType
            {
                columType = nType._USER_STRING,
                ReadOnly = bReadOnly,
                m_nWidth = nWidth
            };
            m_List.Add(m_temp);
            Columns.Add(Text, Text);
            Columns[Columns.Count - 1].ToolTipText = Text + " string";
            Columns[Columns.Count - 1].ReadOnly = bReadOnly;
            Columns[Columns.Count - 1].Width = nWidth;
        }

        /// <summary>
        /// 添加double类型列
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="nWidth"></param>
        /// <param name="bReadOnly"></param>
        public void AddColumnDouble(string Text, int nWidth, bool bReadOnly = true)
        {
            LMColType m_temp = new LMColType
            {
                columType = nType._USER_DOUBLE,
                ReadOnly = bReadOnly,
                m_nWidth = nWidth
            };
            m_List.Add(m_temp);
            Columns.Add(Text, Text);
            Columns[Columns.Count - 1].ToolTipText = Text + " double";
            Columns[Columns.Count - 1].ReadOnly = bReadOnly;
            Columns[Columns.Count - 1].Width = nWidth;
        }

        /// <summary>
        /// 增加行
        /// </summary>
        /// <param name="Text"></param>
        public void AddRow(string Text)
        {
            Rows.Add();

            Rows[Rows.Count - 1].Cells[0].Value = Text;
            for (int i = 1; i < Columns.Count; i++)
            {
                switch (m_List[i].columType)
                {
                    case nType._USER_COMBOX:
                        Rows[Rows.Count - 1].Cells[i].Value = m_List[i].m_ComboStr[0];
                        break;

                    case nType._USER_SIGNAL:

                    case nType._USER_SIGNALBTN:
                        Rows[Rows.Count - 1].Cells[i].Value = false;
                        break;

                    case nType._USER_STRING:
                        Rows[Rows.Count - 1].Cells[i].Value = "";
                        break;

                    case nType._USER_INT:
                        Rows[Rows.Count - 1].Cells[i].Value = 0;
                        break;

                    case nType._USER_DOUBLE:
                        Rows[Rows.Count - 1].Cells[i].Value = 0.0;
                        break;

                    case nType._USER_BOOL:
                        Rows[Rows.Count - 1].Cells[i].Value = m_List[i].m_ComboStr[0];
                        break;
                }
            }
        }

        /// <summary>
        /// 烦烦烦
        /// </summary>
        /// <param name="nColumn">列</param>
        /// <param name="nRow">行</param>
        /// <param name="Text">值</param>
        public bool SetItemString(int nColumn, int nRow, string Text)
        {
            if (Rows.Count <= nRow || m_List.Count <= nColumn)
            {
                return false;
            }
            if (m_List[nColumn].columType != nType._USER_STRING)
            {
                return false;
            }
            if (Rows.Count <= nRow)
            {
                return false;
            }
            Rows[nRow].Cells[nColumn].Value = Text;
            return true;
        }

        public bool SetItemDouble(int nColumn, int nRow, double dDou)
        {
            if (Rows.Count <= nRow || m_List.Count <= nColumn)
            {
                return false;
            }
            if (m_List[nColumn].columType != nType._USER_DOUBLE)
            {
                return false;
            }
            if (Rows.Count <= nRow)
            {
                return false;
            }
            Rows[nRow].Cells[nColumn].Value = dDou;
            return true;
        }
    }
}