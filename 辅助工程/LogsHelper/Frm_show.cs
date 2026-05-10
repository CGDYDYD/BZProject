using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace LogsHelper
{
    public partial class Frm_show : Form
    {
        private DialogResult dialogResult1, dialogResult2, dialogResult3;
        private int model;
        private long oldtime;

        public Frm_show()
        {
            InitializeComponent();
            SetWindowRegion();
            this.listBox1.Items.Clear();
            model = 1;
            btn_01.Visible = false;
            btn_02.Visible = true;
            btn_03.Visible = false;
            dialogResult1 = DialogResult.None;
            //dialogResult2 = DialogResult.None;
            dialogResult3 = DialogResult.None;

            btn_02.Text = "OK";
            dialogResult2 = DialogResult.OK;
            this.info_name.Text = "Prompt";

            this.Show();
            this.Hide();
        }

        public Frm_show(string title)
        {
            Action act = new Action(() =>
            {
                InitializeComponent();
                SetWindowRegion();
                this.listBox1.Items.Clear();
                model = 2;
                btn_01.Visible = false;
                btn_02.Visible = true;
                btn_03.Visible = false;
                dialogResult1 = DialogResult.None;
                dialogResult3 = DialogResult.None;

                btn_02.Text = "OK";
                dialogResult2 = DialogResult.OK;
                this.info_name.Text = title;

                this.Show();
                this.Hide();
            });

            if (this.InvokeRequired)
            {
                this.Invoke(act);
            }
            else
            {
                act();
            }
        }

        public void AddMsg(string msg)
        {
            if (this.listBox1.InvokeRequired)
            {
                this.Invoke(new Action(() => AddMsg(msg)));
            }
            else
            {
                if (model != 3)
                {
                    if (!this.Visible)
                    {
                        this.TopMost = true;
                        oldtime = Environment.TickCount;
                    }
                    if (Environment.TickCount - oldtime > 10000)
                    {
                        this.TopMost = true;
                        oldtime = Environment.TickCount;
                    }
                }
                if (listBox1.Items.Contains(msg))
                {
                    return;
                }

                listBox1.Items.Add(msg);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                this.Show();
            }
        }

        public Frm_show(string msg, MessageBoxButtons msgboxbtn, string Title = "")
        {
            InitializeComponent();
            SetWindowRegion();
            model = 3;
            btn_01.Visible = true;
            btn_02.Visible = true;
            btn_03.Visible = true;
            dialogResult1 = DialogResult.None;
            dialogResult2 = DialogResult.None;
            dialogResult3 = DialogResult.None;

            listBox1.Items.Clear();
            listBox1.Items.Add(msg);
            this.info_name.Text = Title;

            timer1.Enabled = true;
            switch (msgboxbtn)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    btn_01.Text = "Abort";
                    dialogResult1 = DialogResult.Abort;
                    btn_02.Text = "Retry";
                    dialogResult2 = DialogResult.Retry;
                    btn_03.Text = "Ignore";
                    dialogResult3 = DialogResult.Ignore;
                    break;

                case MessageBoxButtons.OK:
                    btn_01.Visible = false;
                    btn_02.Text = "OK";
                    dialogResult2 = DialogResult.OK;
                    btn_03.Visible = false;
                    break;

                case MessageBoxButtons.OKCancel:
                    btn_01.Text = "OK";
                    dialogResult1 = DialogResult.OK;
                    btn_02.Visible = false;
                    btn_03.Text = "Cancel";
                    dialogResult3 = DialogResult.Cancel;
                    break;

                case MessageBoxButtons.RetryCancel:
                    btn_01.Text = "Retry";
                    dialogResult1 = DialogResult.Retry;
                    btn_02.Visible = false;
                    btn_03.Text = "Cancel";
                    dialogResult3 = DialogResult.Cancel;
                    break;

                case MessageBoxButtons.YesNo:
                    btn_01.Text = "Yes";
                    dialogResult1 = DialogResult.Yes;
                    btn_02.Visible = false;
                    btn_03.Text = "No";
                    dialogResult3 = DialogResult.No;
                    break;

                case MessageBoxButtons.YesNoCancel:
                    btn_01.Text = "Yes";
                    dialogResult1 = DialogResult.Yes;
                    btn_02.Text = "No";
                    dialogResult2 = DialogResult.No;
                    btn_03.Text = "Cancel";
                    dialogResult3 = DialogResult.Cancel;
                    break;
            }
        }

        private void SetWindowRegion()
        {
            GraphicsPath FormPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 10);
            this.Region = new Region(FormPath);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);
            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return path;
        }

        private void btn_01_Click(object sender, EventArgs e)
        {
            this.DialogResult = dialogResult1;
            if (model == 3)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        private void btn_02_Click(object sender, EventArgs e)
        {
            if (model == 3)
            {
                this.DialogResult = dialogResult2;
                this.Close();
            }
            else
            {
                listBox1.Items.Clear();
                this.Hide();
                this.DialogResult = dialogResult2;
            }
        }

        private void btn_03_Click(object sender, EventArgs e)
        {
            this.DialogResult = dialogResult3;
            if (model == 3)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #region **********************

        private int _x0;
        private int _y0;

        private void Frm_show_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
            }
        }

        private void Frm_show_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.Capture)
            {
                int dx = e.X - _x0;
                int dy = e.Y - _y0;
                this.Location = new Point(this.Left + dx, this.Top + dy);
            }
        }

        private void Frm_show_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _x0 = e.X;
                _y0 = e.Y;
                this.Capture = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.listBox1.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    if (checkBox1.Checked)
                    {
                        this.TopMost = false;
                    }
                }));
            }
            else if (checkBox1.Checked)
            {
                this.TopMost = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.listBox1.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => this.TopMost = !checkBox1.Checked));
            }
            else
            {
                this.TopMost = !checkBox1.Checked;
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string str = "";
                if (this.listBox1.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        str = listBox1.SelectedItem.ToString();
                        Thread sdf = new Thread(() => Clipboard.SetDataObject(str, true));
                        sdf.SetApartmentState(ApartmentState.STA);
                        sdf.Start();
                    }));
                }
                else
                {
                    str = listBox1.SelectedItem.ToString();
                    Thread sdf = new Thread(() => Clipboard.SetDataObject(str.Trim(), true));
                    sdf.SetApartmentState(ApartmentState.STA);
                    sdf.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        #endregion **********************
    }
}