using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BoTech
{
    public partial class STN : UserControl
    {
        public STN() => InitializeComponent();

        public event Action<object, EventArgs> HiveLogCLick;

        public event Action<object, EventArgs> MachineLogCLick;

        public event Action<object, EventArgs> MainSWPathCLick;

        private string _sTN;
        private string _site;
        private string _vender;
        private string _sW_Version;
        private string _main_SW_Path;
        private string _mS_Hash;
        private bool _hiveConnected;
        private bool _mESConnected;
        private bool _pDCAConnected;

        [Category("GUI属性"), Description("SensorPageButtonVisible")]
        public bool SensorPageButtonVisible { get; set; }

        [Category("GUI属性"), Description("STNName ")]
        public string STNName
        { get => _sTN; set { _sTN = value; this.lbl_STN.Text = _sTN; } }

        [Category("GUI属性"), Description("SiteName")]
        public string SiteName
        { get => _site; set { _site = value; this.lbl_Site.Text = _site; } }

        [Category("GUI属性"), Description("Vender")]
        public string Vender
        { get => _vender; set { _vender = value; this.lbl_Vender.Text = _vender; } }

        [Category("GUI属性"), Description("SW_Version")]
        public string SW_Version
        { get => _sW_Version; set { _sW_Version = value; this.lbl_SW.Text = _sW_Version; } }

        [Category("GUI属性"), Description("Main_SW_Path")]
        public string Main_SW_Path
        { get => _main_SW_Path; set { _main_SW_Path = value; this.lbl_MSP.Text = _main_SW_Path; } }

        [Category("GUI属性"), Description("MS_Hash")]
        public string MS_Hash
        { get => _mS_Hash; set { _mS_Hash = value; this.lbl_MH.Text = _mS_Hash; } }

        public Color stnBackColor { get; set; }

        [Category("GUI属性"), Description("HIVEConnected")]
        public bool HIVEConnected
        {
            get => _hiveConnected;
            set
            {
                _hiveConnected = value;
                if (_hiveConnected)
                {
                    lbl_Hive.Text = "HIVE Connected";
                    lbl_Hive.ForeColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    lbl_Hive.Text = "HIVE Disconnected";
                    lbl_Hive.ForeColor = Color.Red;
                }
            }
        }

        [Category("GUI属性"), Description("MESConnected")]
        public bool MESConnected
        {
            get => _mESConnected;
            set
            {
                _mESConnected = value;
                if (_mESConnected)
                {
                    lbl_MES.Text = "MES Connected";
                    lbl_MES.ForeColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    lbl_MES.Text = "MES Disconnected";
                    lbl_MES.ForeColor = Color.Red;
                }
            }
        }

        [Category("GUI属性"), Description("PDCAConnected")]
        public bool PDCAConnected
        {
            get => _pDCAConnected;
            set
            {
                _pDCAConnected = value;
                if (_pDCAConnected)
                {
                    lbl_PDCA.Text = "PDCA Connected";
                    lbl_PDCA.ForeColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    lbl_PDCA.Text = "PDCA Disconnected";
                    lbl_PDCA.ForeColor = Color.Red;
                }
            }
        }

        #region 事件

        private void nB_MachineLog_Click(object sender, EventArgs e)
        {
            MachineLogCLick?.Invoke(sender, e);
        }

        private void nB_HiveLog_Click(object sender, EventArgs e)
        {
            HiveLogCLick?.Invoke(sender, e);
        }

        #endregion 事件

        private void lbl_MSP_Click(object sender, EventArgs e)
        {
            MainSWPathCLick?.Invoke(sender, e);
        }
    }
}