using System.Reflection;

namespace JpegMetaRemover
{
    public static class AppInfo
    {
        private static readonly Assembly _executingAssembly = Assembly.GetExecutingAssembly();
        private static string _assemblyProduct = null;
        private static string _assemblyCopyright = null;
        private static string _assemblyVersion = null;


        public static string AssemblyVersion
        {
            get
            {
                if (_assemblyVersion == null)
                {
                    var version = _executingAssembly.GetName().Version;
                    _assemblyVersion = "v" + version.Major + "." + version.Minor;
                }

                return _assemblyVersion;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                if (_assemblyProduct == null)
                {
                    var attributes = _executingAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                    _assemblyProduct = attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
                }

                return _assemblyProduct;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                if (_assemblyCopyright == null)
                {
                    var attributes = _executingAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                    _assemblyCopyright = attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
                }

                return _assemblyCopyright;
            }
        }
    }
}
