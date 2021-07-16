using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace JpegMetaRemover.OtherForms
{
    partial class FormAbout : Form
    {

        public FormAbout()
        {
            InitializeComponent();

            this._labelToolName.Text = AppInfo.AssemblyProduct;

            this._labelVersion.Text = AppInfo.AssemblyVersion;

            _ucAnimatedText.Text = $"by {CompanyName} - {AppInfo.AssemblyCopyright}";

            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        }


        private void _ucAnimatedText_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/EmilianoElMariachi/JpegMetaRemover");
            }
            catch
            {
                // ignored
            }
        }

        private void _ucAnimatedText_MouseHover(object sender, EventArgs e)
        {
            _ucAnimatedText.Cursor = Cursors.Hand;
        }

        private void _ucAnimatedText_MouseLeave(object sender, EventArgs e)
        {
            _ucAnimatedText.Cursor = Cursors.Default;
        }

        private void FormAbout_VisibleChanged(object sender, EventArgs e)
        {
            _ucAnimatedText.IsAnimating = this.Visible;
        }

    }



}
