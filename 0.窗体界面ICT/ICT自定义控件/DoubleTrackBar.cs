using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using UserHelper;

namespace BoTech
{
    public class DoubleTrackBar : Control
    {
        #region 变量

        private const string DateTimeFormate = "MM/dd/yyyy HH:mm:ss";//定义时间格式；
        private int _checkDays = 7;//数据回溯日期；
        private DateTime _dateStartValue1;//日期回溯起始值；
        private DateTime _dateEndValue2;//日期回溯终值；
        private DateTime _temStartMouseDown;
        private DateTime _temStartMouseUp;
        private DateTime _temEndMouseDown;
        private DateTime _temEndMouseUp;

        private string _dtNewestTime = DateTime.Now.ToString(DateTimeFormate);//获取数据库dataTable里的当前时间，此时间是滑动条最新值；

        private const int m_MinSize = 10;//最小控件尺寸；
        private const int m_TrackSize = 3;//轨道宽度；

        private int _controlHeight = 10;//默认控件高度为10；

        private emBtnStatus m_btnStatus = emBtnStatus.None; //按钮状态；按下、松开、无、移动中；
        private double m_dbRate;  //比例
        private Point m_lastMouseLocation;   //鼠标坐标最后位置
        private double m_dbValue1;  //滑块1初始值；
        private double m_dbValue2 = 100;//滑块2初始值；

        #endregion 变量

        #region 事件属性；

        [Description("滑块滑动事件")]
        public Action<DateTime, DateTime> ValueChanged_Event;

        public event Action Value1Changed;

        public event Action Value2Changed;

        public event Action ValueChanged;

        public event Action<DateTime, DateTime> UpdateDT;

        /// <summary>
        /// 数据查询起始时间；
        /// </summary>
        [Description("数据回溯时间1")]
        public DateTime DateStartValue1
        {
            get => _dateStartValue1;
            set
            {
                _dateStartValue1 = value;
                Value1 = DateTimeToSlidePos(_dateStartValue1);
            }
        }

        /// <summary>
        /// 数据查询第二段时间；
        /// </summary>
        [Description("数据回溯时间2")]
        public DateTime DateEndValue2
        {
            get => _dateEndValue2;
            set
            {
                _dateEndValue2 = value;
                Value2 = DateTimeToSlidePos(_dateEndValue2);
            }
        }

        public double Value1
        {
            get => m_dbValue1;
            set
            {
                if (value <= Value2 && value >= Minimum)
                {
                    m_dbValue1 = value;
                    UpdateDT?.Invoke(_dateStartValue1, _dateEndValue2);
                    this.Invalidate();
                }
            }
        }

        public double Value2
        {
            get => m_dbValue2;
            set
            {
                if (value >= Value1 && value <= Maximum)
                {
                    m_dbValue2 = value;
                    UpdateDT?.Invoke(_dateStartValue1, _dateEndValue2);
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 数据回溯天数；
        /// </summary>
        [Description("数据回溯天数")]
        public int CheckDays
        {
            get => _checkDays;
            set
            {
                if (value > 0)
                {
                    _checkDays = value;
                }
            }
        }

        /// <summary>
        /// 设备状态数据表；
        /// </summary>
        [Description("数据源最新时间")]
        public string DataTableNewestTime
        {
            get
            {
                if (string.IsNullOrEmpty(_dtNewestTime) || _dtNewestTime.Contains("0001"))
                {
                    _dtNewestTime = DateTime.Now.ToString(DateTimeFormate);
                }
                return _dtNewestTime;
            }
            set
            {
                _dtNewestTime = value;
                if (_dtNewestTime.Contains("0001"))
                {
                    _dtNewestTime = DateTime.Now.ToString(DateTimeFormate);
                }
                base.Refresh();
            }
        }

        [Description("滑轨日期字体大小")]
        public int TrackBarFontSize { get; set; } = 8;

        public override Size MinimumSize
        {
            get => this.Orientation == Orientation.Horizontal ? new Size(m_MinSize, ControlHeight) : new Size(ControlHeight, m_MinSize);
            set => base.MinimumSize = value;
        }

        [Description("滑块2是否可用")]
        public bool IsSlider2Enable
        {
            get;
            set;
        } = true;

        private enum emBtnStatus
        {
            None,
            Btn1MouseIn,
            Btn2MouseIn,
            Btn1MouseDown,
            Btn2MouseDown,
        }

        /// <summary>
        /// 控件高度（水平）/宽度（垂直）
        /// </summary>
        [Description(" 控件高度（水平）/宽度（垂直）")]
        public int ControlHeight
        {
            get => _controlHeight;
            set
            {
                if (_controlHeight < 1)
                { _controlHeight = 10; }
                _controlHeight = value;
                if (this.Orientation == Orientation.Horizontal)
                {
                    Size = new Size(Width, _controlHeight);
                }
            }
        }

        public double Minimum { get; } = 0;

        public double Maximum { get; } = 100;

        private Orientation m_Orientation = Orientation.Horizontal;

        public Orientation Orientation
        {
            get => m_Orientation;
            set
            {
                if (m_Orientation != value)
                {
                    m_Orientation = value;
                    this.Invalidate();
                }
            }
        }

        public bool TickLabelVisible { get; set; }

        public uint LabelPlaces { get; set; } = 1;

        /// <summary>
        /// 键1
        /// </summary>
        private Rectangle m_rectBtn1;

        /// <summary>
        /// 键2
        /// </summary>
        private Rectangle m_rectBtn2;

        public enum emTrackBarSelectedMode
        {
            //选中两个滑块内部的值；
            Inner,

            //选中两个滑块外部的值；
            Outer,
        }

        /// <summary>
        /// 刻度线个数
        /// </summary>
        public int TickCount { get; set; } = 5;

        public Color TickColor { get; set; } = Color.Black;

        /// <summary>
        /// 读两个滑块之间的值；
        /// </summary>
        public emTrackBarSelectedMode TrackSelectedMode
        {
            get;
            set;
        } = emTrackBarSelectedMode.Inner;

        public Color SelectTrackColor { get; set; } = Color.DarkGray;
        public Color TrackColor { get; set; } = Color.White;
        public Color TrackButtonColor1 { get; set; } = Color.LightGray;
        public Color TrackButtonColor2 { get; set; } = Color.LightGray;
        public Color TrackButtonClickColor { get; set; } = Color.Green;

        [Browsable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override bool AutoSize
        {
            get => base.AutoSize;
            set => base.AutoSize = value;
        }

        /// <summary>
        /// 滑块的大小；
        /// </summary>
        public Size TrackButtonSize
        {
            get => new Size(12, 12);
            set => this.Refresh();
        }

        #endregion 事件属性；

        public DoubleTrackBar()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            CreateControl();
        }

        #region 方法；

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (m_rectBtn1.Contains(e.X, e.Y))
            {
                m_btnStatus = emBtnStatus.Btn1MouseDown;
                m_lastMouseLocation = e.Location;
                this.Invalidate();
            }
            else if (m_rectBtn2.Contains(e.X, e.Y))
            {
                m_btnStatus = emBtnStatus.Btn2MouseDown;
                m_lastMouseLocation = e.Location;
                this.Invalidate();
            }
            else if (m_rectBtn1.Contains(e.X, e.Y) && m_rectBtn2.Contains(e.X, e.Y))
            {
                if (Value2 <= Maximum)
                {
                    m_btnStatus = emBtnStatus.Btn1MouseDown;
                    m_lastMouseLocation = e.Location;
                    this.Invalidate();
                }

                if (Value1 >= Minimum)
                {
                    m_btnStatus = emBtnStatus.Btn2MouseDown;
                    m_lastMouseLocation = e.Location;
                    this.Invalidate();
                }
            }
            this._temEndMouseDown = this._dateEndValue2;
            this._temStartMouseDown = this._dateStartValue1;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            m_btnStatus = emBtnStatus.None;

            ValueChanged_Event?.Invoke(DateStartValue1, DateEndValue2);
            this._temEndMouseUp = this._dateEndValue2;
            this._temStartMouseUp = this._dateStartValue1;

            if ((_temEndMouseUp != _temEndMouseDown) && Value2Changed != null)
            {
                Value2Changed();
            }

            if ((_temStartMouseUp != _temStartMouseDown) && Value1Changed != null)
            {
                Value1Changed();
            }

            if (((_temStartMouseUp != _temStartMouseDown) || (_temEndMouseUp != _temEndMouseDown)) && ValueChanged != null)
            {
                ValueChanged();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (m_btnStatus == emBtnStatus.Btn1MouseDown)
            {
                if (m_dbRate != 0)
                {
                    this.Value1 += GetMouseChangedValue(e.Location, m_lastMouseLocation);
                }
                m_lastMouseLocation = e.Location;
            }
            else if (m_btnStatus == emBtnStatus.Btn2MouseDown && IsSlider2Enable)
            {
                if (m_dbRate != 0)
                {
                    this.Value2 += GetMouseChangedValue(e.Location, m_lastMouseLocation);
                }
                m_lastMouseLocation = e.Location;
            }
            else if (m_rectBtn1.Contains(e.X, e.Y))
            {
                if (m_btnStatus != emBtnStatus.Btn1MouseIn)
                {
                    m_btnStatus = emBtnStatus.Btn1MouseIn;
                    this.Refresh();
                }
            }
            else if (m_rectBtn2.Contains(e.X, e.Y))
            {
                if (m_btnStatus != emBtnStatus.Btn2MouseIn)
                {
                    m_btnStatus = emBtnStatus.Btn2MouseIn;
                    this.Refresh();
                }
            }
            else if (m_btnStatus != emBtnStatus.None)
            {
                m_btnStatus = emBtnStatus.None;
                this.Refresh();
            }
        }

        /*滑块与时间的关系*/

        private double DateTimeToSlidePos(DateTime dtValue)
        {
            DateTime dtTemp = dtValue;
            IFormatProvider culture = new CultureInfo("en-US", true);
            DateTime dtNew = DateTime.ParseExact(_dtNewestTime, DateTimeFormate, culture);
            DateTime dtTempStart = dtNew.AddDays(-7);
            double rate = 0.0;
            int weekSec = 7 * 24 * 3600;
            rate = 100.0 / weekSec;

            double iSec = dtTemp.Subtract(dtTempStart).TotalSeconds;
            double dLength = iSec * rate;
            if (dLength > 100)
            { dLength = 100; }
            if (dLength < 0)
            {
                dLength = 0;
            }

            return Math.Round(dLength, 1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.SizeChanged -= OnLhxTrackBar2SizeChanged;
            base.OnPaint(e);
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            if (this.Orientation == Orientation.Horizontal)
            {
                OnPaintHorizontal(e);
            }
            else
            {
                OnPaintVertical(e);
            }

            this.SizeChanged += OnLhxTrackBar2SizeChanged;
        }

        private double GetMouseChangedValue(Point nowLocation, Point oldLocation)
        {
            double rlt = this.Orientation == Orientation.Horizontal ? nowLocation.X - oldLocation.X : nowLocation.Y - oldLocation.Y;
            return rlt / m_dbRate;
        }

        private void OnLhxTrackBar2SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// 水平
        /// </summary>
        protected virtual void OnPaintHorizontal(PaintEventArgs e)
        {
            double left = 0;
            double right = this.Width;
            try
            {
                #region 画滑块

                Pen pen_track = new Pen(new SolidBrush(TrackColor), 1);
                int trackTop = Height - TrackButtonSize.Height; //滑轨顶部坐标；
                int trackHeight = m_TrackSize;//滑轨高度；

                int trackBtnTop = trackTop - ((TrackButtonSize.Height - trackHeight) / 2);

                //画空滑轨
                e.Graphics.DrawRectangle(pen_track, new Rectangle((int)left, trackTop, (int)(right - left), trackHeight));
                e.Graphics.FillRectangle(new SolidBrush(TrackColor), new Rectangle((int)left, trackTop, (int)(right - left), trackHeight));
                //画选中的滑块部分
                double rate = (right - left) / (Maximum - Minimum);
                m_dbRate = rate;

                int value1 = (int)((Value1 - Minimum) * rate);
                int value2 = (int)((Value2 - Minimum) * rate);
                int value1_x = (int)(left + value1);
                int value2_x = (int)(left + value2);

                //画选中部分
                if (TrackSelectedMode == emTrackBarSelectedMode.Inner)
                {
                    e.Graphics.FillRectangle(new SolidBrush(SelectTrackColor), new Rectangle(value1_x, trackTop, value2 - value1, trackHeight + 2));
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(SelectTrackColor), new Rectangle((int)left, trackTop, value1, m_TrackSize));
                    e.Graphics.FillRectangle(new SolidBrush(SelectTrackColor), new Rectangle(value2_x, trackTop, (int)(right - value2 - left), trackHeight));
                }

                //画左侧滑块
                e.Graphics.FillRectangle(new SolidBrush(m_btnStatus == emBtnStatus.Btn1MouseDown || m_btnStatus == emBtnStatus.Btn1MouseIn ? TrackButtonClickColor : Color.DarkGray),
                   new Rectangle(value1_x - (TrackButtonSize.Width / 2), trackBtnTop, TrackButtonSize.Width, TrackButtonSize.Height));
                if (IsSlider2Enable)
                {
                    e.Graphics.FillRectangle(new SolidBrush(m_btnStatus == emBtnStatus.Btn2MouseDown || m_btnStatus == emBtnStatus.Btn2MouseIn ? TrackButtonClickColor : Color.DarkGray),
                   new Rectangle(value2_x - (TrackButtonSize.Width / 2), trackBtnTop, TrackButtonSize.Width, TrackButtonSize.Height));
                }

                m_rectBtn1 = new Rectangle(value1_x - (TrackButtonSize.Width / 2), trackBtnTop, TrackButtonSize.Width, TrackButtonSize.Height);
                m_rectBtn2 = new Rectangle(value2_x - (TrackButtonSize.Width / 2), trackBtnTop, TrackButtonSize.Width, TrackButtonSize.Height);

                #endregion 画滑块

                #region

                double dValue1Rate = Math.Round(Value1 / (Maximum - Minimum), 1);
                double dValue2Rate = Math.Round(Value2 / (Maximum - Minimum), 1);

                IFormatProvider culture = new CultureInfo("en-US", true);
                DateTime dtCheckEnd = DateTime.ParseExact(_dtNewestTime, DateTimeFormate, culture);
                DateTime dtCheckStart = dtCheckEnd.AddDays(-_checkDays);
                double iSecondValue1 = dValue1Rate * _checkDays * 24 * 3600;
                double iSecondValue2 = dValue2Rate * _checkDays * 24 * 3600;
                _dateStartValue1 = dtCheckStart.AddSeconds(iSecondValue1);
                _dateEndValue2 = dtCheckStart.AddSeconds(iSecondValue2);

                #endregion 方法；
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        protected virtual void OnPaintVertical(PaintEventArgs e)
        {
            //如果是垂直放置滑动条需要修改；
        }

        #endregion
    }
}