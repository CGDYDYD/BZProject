using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogsHelper
{
    public partial class FrmListBox : ListBox
    {
        public FrmListBox()
        {
            InitializeComponent();
            cLogs.OnStep += new Action<string, LogsType,int>(BeginShow);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void BeginShow(string strInfo, LogsType _logsType,int taskid)
        {
            try
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action<string, LogsType,int>(Show), new object[] { strInfo, _logsType , taskid });
                }
            }
            catch
            {

            }
        }

        string str;

        private void Show(string strInfo, LogsType _logsType,int taskid)
        {
            try
            {
                
                if (Visible || _ShowMode == e显示模式.不可见显示Log)
                {
                    //str = DateTime.Now.ToString("◆[HH:mm:ss:fff]") + ":" + strInfo;
                    str = DateTime.Now.ToString("◆[HH:mm:ss]") + $":{taskid}:" + strInfo;
                    if (this.Items.Count > 50)
                    {
                        this.Items.Clear();
                    }
                    this.Items.Add(str);
                    this.SelectedIndex = this.Items.Count - 1;

                }
            }
            catch (Exception)
            {

            }
        }

        public enum e显示模式
        {
            不可见不显示Log,
            不可见显示Log,
        }
        e显示模式 _ShowMode = e显示模式.不可见不显示Log;

        [Category("0.参数设置"), Description("在可见和不可以见是否显示Log")]
        public e显示模式 显示模式
        {
            get { return _ShowMode; }
            set { _ShowMode = value; }
        }



    }
}
