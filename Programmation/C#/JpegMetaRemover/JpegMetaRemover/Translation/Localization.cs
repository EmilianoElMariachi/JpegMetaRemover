using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JpegMetaRemover.Translation
{
    internal class Localization
    {

        public Localization()
        {
            this.Elements = new Dictionary<string, string>();
            this.LanguageName = "";
            this.ShortName = "";
        }

        public string LanguageName { get; internal set; }

        public string ShortName { get; internal set; }

        public Dictionary<string, string> Elements { get; private set; }

        internal void AddTranslatedElementIfKeyNotNull(string key, string value)
        {
            key = (key == null) ? "" : key.Trim();

            if (key != "")
            { this.Elements.Add(key, value); }
        }

        public string GetTranslatedElementOrNullIfNotFound(string key)
        {
            if (this.Elements.ContainsKey(key))
            {
                return this.Elements[key];
            }
            else
            {
                return null;
            }
        }

        public void ChangeUIThread()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.ShortName);
        }

        public void ChangeLanguage(IEnumerable<LocalizableControlWrapper> wrappedControls)
        {
            ChangeUIThread();

            foreach (var controlWrapper in wrappedControls)
            {

                var elementValueSecure = GetTranslatedElementOrNullIfNotFound(controlWrapper.Name);
                if (elementValueSecure != null)
                {
                    controlWrapper.Text = elementValueSecure;
                }
            }
        }

    }
}
