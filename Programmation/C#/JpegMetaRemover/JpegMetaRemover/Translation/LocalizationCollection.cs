using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace JpegMetaRemover.Translation
{
    internal class LocalizationCollection : ObservableCollection<Localization>
    {

        public Localization FindLocalizationByTwoLetterLanguageName(string twoLetter)
        {
            Localization localizationFound = null;
            foreach (var localization in this)
            {
                if (localization.TwoLetterISOLanguageName == twoLetter)
                {
                    localizationFound = localization;
                    break;
                }
            }
            return localizationFound;
        }

        public void AddRange(IEnumerable<Localization> localizations)
        {
            foreach (var localization in localizations)
            {
                if (localization != null)
                {
                    this.Add(localization);
                }
            }
        }
    }
}
