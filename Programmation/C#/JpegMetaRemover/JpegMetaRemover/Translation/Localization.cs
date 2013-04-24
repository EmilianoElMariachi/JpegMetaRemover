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
        public LocalizationManager LocalizationManager { get; private set; }

        public Localization(LocalizationManager localizationManager)
        {
            LocalizationManager = localizationManager;
            this.Elements = new Dictionary<string, string>();
            this.LanguageName = "";
            this.TwoLetterISOLanguageName = "";
        }

        public string LanguageName { get; internal set; }

        public string TwoLetterISOLanguageName { get; internal set; }

        public Dictionary<string, string> Elements { get; private set; }

        internal void AddTranslatedElementIfKeyNotNull(string key, string value)
        {
            key = (key == null) ? "" : key.Trim();

            if (key != "")
            { this.Elements.Add(key, value); }
        }

        public string GetTranslatedElementOrNullIfNotFound(string key)
        {
            if (key != null && this.Elements.ContainsKey(key))
            {
                return this.Elements[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Permet de traduire la clé.
        /// Si aucune traduction, la clé est retournée
        /// </summary>
        /// <param name="key"></param>
        /// <param name="formatArgs"></param>
        /// <returns></returns>
        public string Translate(string key, params string[] formatArgs)
        {
            var translation = "";
            if (this.Elements.ContainsKey(key))
            {
                translation = this.Elements[key];
            }
            else
            {
                translation = key;
            }

            if (formatArgs != null && formatArgs.Length > 0)
            {
                try
                { translation = string.Format(translation, formatArgs); }
                catch
                { }
            }

            return translation;
        }

        public void SetActiveLocalization(IEnumerable<LocalizableControlWrapper> wrappedControls)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.TwoLetterISOLanguageName);

            foreach (var controlWrapper in wrappedControls)
            {

                var elementValueSecure = GetTranslatedElementOrNullIfNotFound(controlWrapper.AccessibleName);
                if (elementValueSecure != null)
                {
                    controlWrapper.Text = elementValueSecure;
                }
            }

            this.LocalizationManager.ActiveLocalization = this;
        }

    }
}
