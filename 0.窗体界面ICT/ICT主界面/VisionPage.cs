using System;
using System.Drawing;
using 运动模块;
using static CoreFunction.mFunction;

namespace BoTech
{
    public partial class VisionPage : MyControl
    {
        private static VisionPage instance;

        public static VisionPage Instacne
        {
            get
            {
                if (instance?.IsDisposed != false)
                {
                    instance = new VisionPage();
                }

                return instance;
            }
        }

        public VisionPage() => InitializeComponent();

        private void VisionPage_Load(object sender, EventArgs e)
        {
            this.Location = mGlobal.ChildFrmOffsetPoint;
            this.Size = new Size(Frm_ICT_Main.Instance.Main_ChildPage.Width, Frm_ICT_Main.Instance.Main_ChildPage.Height);
            SetTag(this, Convert.ToInt32(this.Tag), true);
            SetControls(mGlobal.NewX, mGlobal.NewY, this, Convert.ToInt32(this.Tag), true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < Enum.GetNames(typeof(eErrCode)).Length; i++)
            {
                Task00_空站.Instance.myTipNew((eErrCode)i, true);
            }

            //Task00_空站.Instance.myTipNew(eErrCode.急停按钮按下, true);
            //Task00_空站.Instance.myTipNew(eErrCode.前右安全门信号异常);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LanguageState = 语言设定.ENG;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LanguageState = 语言设定.CHN;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LanguageState = 语言设定.OTH;
        }
    }
}