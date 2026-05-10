using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BoTech
{
    public class AudioButton : Button
    {
        public enum RoundStyles
        {
            None,
            All,
            Left,
            Right,
            Top,
            Bottom,
        }

        public Color _OnMouseColor;
        private int _radius = 10;
        private RoundStyles _roundStyle;
        private Color _NewBackColor;
        private Image _energized;
        private Image _deEnergized;
        private Image _disabled;
        private Image _alarmed;
        private Image _hiveEngineer;
        private Image _hiveAlarm;
        private bool _setDisabled = true;

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int wndproc);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [Category("GUI属性")]
        [Browsable(true)]
        [DefaultValue("")]
        [Description("设置鼠标在控件上方填充颜色。")]
        public Color OnMouseColor
        {
            get => _OnMouseColor;
            set
            {
                _OnMouseColor = value;
                Invalidate();
            }
        }

        [Category("GUI属性")]
        [Browsable(true)]
        [DefaultValue("")]
        [Description("设置鼠标在控件上方填充颜色。")]
        public bool ButtonEnable
        {
            get => _setDisabled;
            set
            {
                _setDisabled = value;
                Invalidate();
            }
        }

        [Category("GUI属性")]
        [Browsable(true)]
        [DefaultValue("")]
        [Description("是否启用鼠标On Leave 控件变色")]
        public bool UseMouseOnOrLeave { get; set; } = true;

        [Browsable(true)]
        [Category("GUI属性")]
        [Description("设置圆角矩形圆角半径")]
        [DefaultValue("")]
        public int Radius
        {
            get => _radius;
            set
            {
                _radius = value < 0 ? 0 : value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("GUI属性")]
        [Description("设置圆角矩形的样式")]
        [DefaultValue("")]
        public RoundStyles RoundStyle
        {
            get => _roundStyle;
            set
            {
                _roundStyle = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("GUI属性")]
        [Description("设置空间填充颜色")]
        [DefaultValue("")]
        public Color NBackColor
        {
            get => _NewBackColor;
            set
            {
                _NewBackColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("GUI属性")]
        [Description("设置Energized背景图片")]
        [DefaultValue("")]
        public Image Energized1
        {
            get => _energized;
            set
            {
                _energized = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("GUI属性")]
        [Description("设置Disabled背景图片")]
        [DefaultValue("")]
        public Image Disabled0
        {
            get => _disabled;
            set
            {
                _disabled = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("GUI属性")]
        [Description("设置Deenergized背景图片")]
        [DefaultValue("")]
        public Image DeEnergized2
        {
            get => _deEnergized;
            set
            {
                _deEnergized = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("GUI属性")]
        [Description("设置Alarmed背景图片")]
        [DefaultValue("")]
        public Image Alarmed3
        {
            get => _alarmed;
            set
            {
                _alarmed = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("GUI属性")]
        [Description("设置Alarmed背景图片")]
        [DefaultValue("")]
        public Image HiveEngineer4
        {
            get => _hiveEngineer;
            set
            {
                _hiveEngineer = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("GUI属性")]
        [Description("设置Alarmed背景图片")]
        [DefaultValue("")]
        public Image hiveAlarm5
        {
            get => _hiveAlarm;
            set
            {
                _hiveAlarm = value;
                Invalidate();
            }
        }

        public AudioButton()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (UseMouseOnOrLeave)
            {
                base.OnMouseEnter(e);
                this.BackColor = OnMouseColor;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (UseMouseOnOrLeave)
            {
                base.OnMouseLeave(e);
                this.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// 按钮状态切换 背景图片变更；
        /// </summary>
        public void ButtonStateChange(NewButtonState NBS)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Enabled = true;
            ChangeThisVisable(true);
            this._setDisabled = true;
            switch (NBS)
            {
                case NewButtonState.Alarm:
                    this.BackgroundImage = _alarmed;
                    break;

                case NewButtonState.Deenergized:
                    this.BackgroundImage = _deEnergized;
                    break;

                case NewButtonState.Disabled:
                    this.BackgroundImage = _disabled;
                    ChangeThisVisable(false);
                    this._setDisabled = false;
                    break;

                case NewButtonState.Energized:
                    this.BackgroundImage = _energized;
                    break;
            }
            Invalidate();
        }

        private void ChangeThisVisable(bool b)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() => this.Enabled = b));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            base.OnPaintBackground(e);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            RenderBackgroundInternal(graphics, ClientRectangle, RoundStyle, Radius);
        }

        private void RenderBackgroundInternal(Graphics g, Rectangle rect, RoundStyles roundstyle, int roundWidth)
        {
            Rectangle empty = Rectangle.Empty;
            Rectangle destRect = Rectangle.Empty;
            if (Image != null)
            {
                empty = new Rectangle(0, 0, Width, Height);
                destRect = checked(new Rectangle((int)Math.Round((Width - Image.Width) / 2.0), (int)Math.Round((Height - Image.Height) / 2.0), Image.Width, Image.Height));
            }
            else
            {
                empty = new Rectangle(0, 0, Width, Height);
            }
            if (roundstyle != 0)
            {
                CreatePath(rect, roundWidth, roundstyle, correction: false);
                GraphicsPath graphicsPath = (roundWidth != 0) ? CreatePath(rect, roundWidth, roundstyle, correction: false) : CreatePath(rect, roundWidth, RoundStyles.None, correction: false);
                Pen pen1 = SetPen(g, graphicsPath);
                g.DrawPath(pen1, graphicsPath);
            }
            else
            {
                CreatePath(rect, roundWidth, roundstyle, correction: false);
                GraphicsPath graphicsPath2 = CreatePath(rect, roundWidth, RoundStyles.None, correction: false);
                Pen pen2 = SetPen(g, graphicsPath2);
                g.DrawPath(pen2, graphicsPath2);
            }
            if (Image != null)
            {
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.DrawImage(Image, destRect, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel);
            }
            TextRenderer.DrawText(g, Text, Font, empty, ForeColor);
        }

        private Pen SetPen(Graphics g, GraphicsPath graphicsPath2)
        {
            PathGradientBrush pathGradientBrush2 = new PathGradientBrush(graphicsPath2) { CenterColor = _NewBackColor };
            pathGradientBrush2.SurroundColors = new Color[1] { _NewBackColor };
            g.FillPath(pathGradientBrush2, graphicsPath2);
            return new Pen(_NewBackColor, 1f);
        }

        public GraphicsPath CreatePath(Rectangle rect, int radius, RoundStyles style, bool correction)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int num = correction ? 1 : 0;
            checked
            {
                switch (style)
                {
                    case RoundStyles.None:
                        graphicsPath.AddLine(rect.X, rect.Y, rect.Right - 1, rect.Y);
                        graphicsPath.AddLine(rect.Right - 1, rect.Y, rect.Right - 1, rect.Right - 1);
                        graphicsPath.AddLine(Width - 1, rect.Right - 1, rect.X, rect.Right - 1);
                        graphicsPath.AddLine(rect.X, rect.Right - 1, rect.X, rect.Y);
                        break;

                    case RoundStyles.All:
                        graphicsPath.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                        graphicsPath.AddArc(rect.Right - radius - num - 1, rect.Y, radius, radius, 270f, 90f);
                        graphicsPath.AddArc(rect.Right - radius - num - 1, rect.Bottom - radius - num - 1, radius, radius, 0f, 90f);
                        graphicsPath.AddArc(rect.X, rect.Bottom - radius - num - 1, radius, radius, 90f, 90f);
                        break;

                    case RoundStyles.Left:
                        graphicsPath.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                        graphicsPath.AddLine(rect.Right - num - 1, rect.Y, rect.Right - num - 1, rect.Bottom - num - 1);
                        graphicsPath.AddArc(rect.X, rect.Bottom - radius - num - 1, radius, radius, 90f, 90f);
                        break;

                    case RoundStyles.Right:
                        graphicsPath.AddArc(rect.Right - radius - num - 1, rect.Y, radius, radius, 270f, 90f);
                        graphicsPath.AddArc(rect.Right - radius - num - 1, rect.Bottom - radius - num - 1, radius, radius, 0f, 90f);
                        graphicsPath.AddLine(rect.X, rect.Bottom - num - 1, rect.X, rect.Y);
                        break;

                    case RoundStyles.Top:
                        graphicsPath.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                        graphicsPath.AddArc(rect.Right - radius - num - 1, rect.Y, radius, radius, 270f, 90f);
                        graphicsPath.AddLine(rect.Right - num - 1, rect.Bottom - num - 1, rect.X, rect.Bottom - num - 1);
                        break;

                    case RoundStyles.Bottom:
                        graphicsPath.AddArc(rect.Right - radius - num - 1, rect.Bottom - radius - num - 1, radius, radius, 0f, 90f);
                        graphicsPath.AddArc(rect.X, rect.Bottom - radius - num - 1, radius, radius, 90f, 90f);
                        graphicsPath.AddLine(rect.X, rect.Y, rect.Right - num - 1, rect.Y);
                        break;
                }
                graphicsPath.CloseFigure();
                return graphicsPath;
            }
        }
    }

    public enum NewButtonState
    {
        /// <summary>
        /// 禁用
        /// </summary>
        Disabled,

        /// <summary>
        /// 显示颜色
        /// </summary>
        Energized,

        /// <summary>
        /// 不显示颜色
        /// </summary>
        Deenergized,

        Alarm,
    }
}