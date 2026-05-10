using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BoTech
{
    public partial class IO_Summary_NoSQL : UserControl
    {
        public IO_Summary_NoSQL() => InitializeComponent();

        private string _sn;
        private bool _unitStatus;
        private string _iO;
        private string _yield;
        private string _pF;
       
        private string _cT;
 private string _报警率;

        [Category("GUI属性"), Description("SN")]
        public string SN
        { get => _sn; set { _sn = value; this.Lbl_Unit.Text = _sn; } }

        [Category("GUI属性"), Description("Input/Output")]
        public string Input_Output
        { get => _iO; set { _iO = value; this.Lbl_IO.Text = _iO; } }

        [Category("GUI属性"), Description("Yield")]
        public string Yield
        { get => _yield; set { _yield = value; this.Lbl_Yield.Text = _yield; } }

        [Category("GUI属性"), Description("Pass/Fail")]
        public string Pass_Fail
        { get => _pF; set { _pF = value; this.Lbl_PF.Text = _pF; } }

        [Category("GUI属性"), Description("报警率")]
        public string 报警率
        { get => _报警率; set { _报警率 = value; this.Lbl_UPH.Text = _报警率; } }

        [Category("GUI属性"), Description("CT")]
        public string CT
        { get => _cT; set { _cT = value; this.LBL_CT.Text = _cT; } }

        [Category("GUI属性"), Description("OKColor")]
        public Color OKColor { get; set; } = Color.FromArgb(0, 249, 0);

        [Category("GUI属性"), Description("NGColor")]
        public Color NGColor { get; set; } = Color.FromArgb(236, 93, 87);

        [Category("GUI属性"), Description("UnitStatus 当前物料状态")]
        public bool UnitStatus
        { get => _unitStatus; set { _unitStatus = value; ChangeUnitBackColor(_unitStatus); } }

        private void ChangeUnitBackColor(bool b)
        {
            this.Pa_Unit.BackColor = b ? OKColor : NGColor;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }
    }
}