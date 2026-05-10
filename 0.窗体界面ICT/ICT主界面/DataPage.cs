using System;
using System.Drawing;
using static CoreFunction.mFunction;

namespace BoTech
{
    public partial class DataPage : MyControl
    {
        private static DataPage instance;

        public static DataPage Instance
        {
            get
            {
                if (instance?.IsDisposed != false)
                {
                    instance = new DataPage();
                }

                return instance;
            }
        }

        public DataPage()
        {
            InitializeComponent();
            this.Visible = true;
        }

        private void DataPage_Load(object sender, EventArgs e)
        {
            this.Location = mGlobal.ChildFrmOffsetPoint;
            this.Size = new Size(Frm_ICT_Main.Instance.Main_ChildPage.Width, Frm_ICT_Main.Instance.Main_ChildPage.Height);
            SetTag(this, Convert.ToInt32(this.Tag), true);
            SetControls(mGlobal.NewX, mGlobal.NewY, this, Convert.ToInt32(this.Tag), true);
        }
    }
}