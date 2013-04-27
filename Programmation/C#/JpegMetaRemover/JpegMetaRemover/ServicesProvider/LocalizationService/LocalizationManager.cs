using System.Collections.Generic;
using System.Xml;
using JpegMetaRemover.Log;

namespace JpegMetaRemover.ServicesProvider.LocalizationService
{
    internal class LocalizationManager 
    {
        private Localization _activeLocalization;


        /// <summary>
        /// La liste de localizations chargées
        /// </summary>
        public LocalizationCollection LoadedLocalizations { get; private set; }

        /// <summary>
        /// La localization active
        /// </summary>
        public Localization ActiveLocalization
        {
            get { return _activeLocalization; }
            internal set { _activeLocalization = value; }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public LocalizationManager()
        {
            LoadedLocalizations = new LocalizationCollection();
        }

        /// <summary>
        /// Permet de charger une localization à partir d'une liste de controls wrappés et ajoute
        /// la localization à la liste 
        /// </summary>
        /// <param name="localizableControlWrappers"></param>
        /// <param name="languageName"></param>
        /// <param name="shortName"></param>
        /// <returns></returns>
        public Localization LoadLocalizationFromLocalizableControls(List<LocalizableControlWrapper> localizableControlWrappers, string languageName, string shortName)
        {
            var localization = new Localization(this) {LanguageName = languageName, TwoLetterISOLanguageName = shortName};

            foreach (var localizableControl in localizableControlWrappers)
            {
                localization.AddTranslatedElementIfKeyNotNull(localizableControl.AccessibleName, localizableControl.Text);  
            }
            
            this.LoadedLocalizations.Add(localization);

            return localization;
        }

        /// <summary>
        /// Permet de charger un fichier de localization et ajoute les localization à la liste des localizations chargées
        /// </summary>
        /// <param name="languageFile"></param>
        public List<Localization> LoadLocalizationsFromFile(string languageFile)
        {
            var localizations = new List<Localization>();

            var xmlDocument = new XmlDocument();

            xmlDocument.Load(languageFile);

            var languageNodes = xmlDocument.DocumentElement.SelectNodes("language");

            foreach (XmlNode languageNode in languageNodes)
            {
                var languageName = GetAttributeSecure(languageNode, "name");
                var twoLetterISOLanguageName = GetAttributeSecure(languageNode, "twoLetterISOLanguageName");

                var localization = new Localization(this)
                    {
                        LanguageName = languageName,
                        TwoLetterISOLanguageName = twoLetterISOLanguageName
                    };

                localizations.Add(localization);

                var elementNodes = languageNode.SelectNodes("element");

                foreach (XmlNode elementNode in elementNodes)
                {
                    var id = GetAttributeSecure(elementNode, "id");
                    if (id == "")
                    {
                        Logger.LogWarning(typeof (LocalizationManager), "Empty id found in \"" + languageFile + "\"");
                    }
                    else
                    {
                        if (localization.Elements.ContainsKey(id))
                        {
                            Logger.LogWarning(typeof (LocalizationManager),
                                              "Duplicate id \"" + id + "\" found in \"" + languageFile + "\"");
                        }
                        else
                        {
                            localization.Elements.Add(id, elementNode.InnerText);
                        }
                    }
                }
            }

            LoadedLocalizations.AddRange(localizations);

            return localizations;
        }

        /// <summary>
        /// Permet de charger un ensemble de localization à partir de la liste des fichiers fournis
        /// </summary>
        /// <param name="languageFiles"></param>
        /// <returns></returns>
        public List<Localization> LoadLocalizationsFromFiles(string[] languageFiles)
        {
            var localizations = new List<Localization>();

            foreach (var languageFilePath in languageFiles)
            {
                localizations.AddRange(this.LoadLocalizationsFromFile(languageFilePath));
            }

            return localizations;
        }

        private static string GetAttributeSecure(XmlNode node, string attributeName)
        {
            if (node != null && node.Attributes != null)
            {
                var attribute = node.Attributes[attributeName];
                if (attribute != null)
                {
                    return attribute.Value;
                }
            }

            return "";
        }


    }
}
