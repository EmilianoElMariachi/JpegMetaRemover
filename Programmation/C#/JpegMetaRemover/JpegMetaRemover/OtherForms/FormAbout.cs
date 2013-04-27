using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;

namespace JpegMetaRemover.OtherForms
{
    partial class FormAbout : Form
    {

        public FormAbout()
        {
            InitializeComponent();

            this._labelToolName.Text = AssemblyProduct;

            this._labelVersion.Text = this.AssemblyVersion;

            _ucAnimatedText.Text = "by " + CompanyName + " - " + AssemblyCopyright;

            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        }

        public string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;

                return "v" + version.Major + "." + version.Minor;
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Obtenir tous les attributs Description de cet assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // Si aucun attribut Description n'existe, retourner une chaîne vide
                if (attributes.Length == 0)
                    return "";
                // Si un attribut Description existe, retourner sa valeur
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        private void _ucAnimatedText_Click(object sender, EventArgs e)
        {
            try
            { Process.Start("http://www.emignatik.com/JpegMetaRemover"); }
            catch
            { }
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
