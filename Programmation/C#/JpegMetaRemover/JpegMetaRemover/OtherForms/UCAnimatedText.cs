using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace JpegMetaRemover.OtherForms
{
    public partial class UCAnimatedText : UserControl
    {

        private int _animAngle = 0;
        private int _alpha = 0;
        private int _offset = 4;

        private Color _color = Color.Red;

        /// <summary>
        /// Surchage permettant le double buffering
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020;
                return createParams;
            }
        }

        private List<Color> _colors;
        private int _colorIndex = 0;

        public UCAnimatedText()
        {
            InitializeComponent();

            if (this.DesignMode == false)
            {
                _colors = GetHSVWheel(200);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.DesignMode == false)
            {

                var fontSize = e.Graphics.MeasureString(this.Text, this.Font);
                var pos = new PointF(e.ClipRectangle.Width / 2 - fontSize.Width / 2, e.ClipRectangle.Height / 2 - fontSize.Height / 2);
                var linearGradientBrush = new LinearGradientBrush(e.ClipRectangle, _color, Color.Black, _animAngle, true);
                e.Graphics.DrawString(this.Text, this.Font, linearGradientBrush, pos);
                linearGradientBrush.Dispose();
            }
        }

        private void TimerAnimationTick(object sender, EventArgs e)
        {

            if (this.DesignMode == false)
            {
                _animAngle++;

                if (_animAngle > 360)
                { _animAngle = 0; }

                _alpha += _offset;
                if (_alpha > 255)
                {
                    _offset = _offset * (-1);
                    _alpha = 255;
                }
                else if (_alpha < 0)
                {
                    _offset = _offset * (-1);
                    _alpha = 0;
                }

                _colorIndex++;
                if (_colorIndex >= _colors.Count)
                {
                    _colorIndex = 0;
                }

                _color = _colors[_colorIndex];// Color.FromArgb(_alpha, r, g, b);
                this.Invalidate();
            }
        }

        public List<Color> GetHSVWheel(int precision)
        {
            var increaseStep = 360.0 / precision;

            var colors = new List<Color>();

            for (var hue = 0.0; hue < 360.0; hue += increaseStep)
            {
                colors.Add(HSBToRVB(hue, 1.0, 1.0));
            }

            return colors;
        }

        public static Color HSBToRVB(double hue, double saturation, double brightness)
        {
            if (hue < 0.0 && hue > 360.0)
            { throw new ArgumentException("Invalid hue, valid : 0 to 360"); }

            if (saturation < 0 && saturation > 1)
            { throw new ArgumentException("Invalid saturation, range : [0.0 to 1.0]"); }

            if (brightness < 0 && brightness > 1)
            { throw new ArgumentException("Invalid brightness, range : [0.0 to 1.0]"); }

            var hueRangeRaw = hue / 60.0;

            var hueRange = (int)hueRangeRaw % 6;

            var f = hueRangeRaw - hueRange;

            var vByte = (byte)Math.Round(brightness * byte.MaxValue);
            var lByte = (byte)Math.Round(brightness * (1 - saturation) * byte.MaxValue);
            var mByte = (byte)Math.Round(brightness * (1 - f * saturation) * byte.MaxValue);
            var nByte = (byte)Math.Round(brightness * (1 - (1 - f) * saturation) * byte.MaxValue);

            switch (hueRange)
            {
                case 0:
                    return Color.FromArgb(vByte, nByte, lByte);
                case 1:
                    return Color.FromArgb(mByte, vByte, lByte);
                case 2:
                    return Color.FromArgb(lByte, vByte, nByte);
                case 3:
                    return Color.FromArgb(lByte, mByte, vByte);
                case 4:
                    return Color.FromArgb(nByte, lByte, vByte);
                case 5:
                    return Color.FromArgb(vByte, lByte, mByte);
                default:
                    throw new Exception("Unexpected case.");
            }

        }

        public bool IsAnimating
        {
            get { return _timerAnimation.Enabled; }
            set
            { _timerAnimation.Enabled = value; }
        }

    }
}
