using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using JpegMetaRemover.Log;

namespace JpegMetaRemover.Translation
{
    internal static class LocalizationManager 
    {

        public static List<LocalizableControlWrapper> FetchFormLocalizableControls(Form form)
        {
            var controlWrappers = new List<LocalizableControlWrapper>();
            FetchLocalizableControls(form.Controls, controlWrappers);
            return controlWrappers;
        }

        private static void FetchLocalizableControls(IEnumerable controls, List<LocalizableControlWrapper> localizableControlWrappers)
        {
            foreach (var rawControl in controls)
            {
                if (rawControl is MenuStrip)
                {
                    var control = (MenuStrip)rawControl;
                    localizableControlWrappers.Add(new LocalizableControlWrapper()
                    {
                        Name = control.Name,
                        WrappedControl = control
                    });
                    FetchLocalizableControls(control.Items, localizableControlWrappers);
                }
                else if (rawControl is Control)
                {
                    var control = (Control)rawControl;
                    localizableControlWrappers.Add(new LocalizableControlWrapper()
                    {
                        Name = control.Name,
                        WrappedControl = control
                    });
                    FetchLocalizableControls(control.Controls, localizableControlWrappers);
                }
                else if (rawControl is ToolStripItem)
                {
                    var control = (ToolStripItem)rawControl;
                    localizableControlWrappers.Add(new LocalizableControlWrapper()
                    {
                        Name = control.Name,
                        WrappedControl = control
                    });

                    var dropDown = control as ToolStripDropDownItem;
                    if (dropDown != null)
                    {
                        FetchLocalizableControls(dropDown.DropDownItems, localizableControlWrappers);
                    }
                }
                else
                {
                    Logger.LogError(typeof(LocalizationManager), "Unsupported element of type \"" + rawControl.GetType().Name + "\" found for localization");
                }
            }
        }

        /// <summary>
        /// Permet de créer une localization à partir d'une liste de controls wrappés
        /// </summary>
        /// <param name="localizableControlWrappers"></param>
        /// <param name="languageName"></param>
        /// <param name="shortName"></param>
        /// <returns></returns>
        public static Localization CreateLocalizationFromLocalizableControls(List<LocalizableControlWrapper> localizableControlWrappers, string languageName, string shortName)
        {
            var localization = new Localization {LanguageName = languageName, TwoLetterISOLanguageName = shortName};

            foreach (var localizableControl in localizableControlWrappers)
            {
                localization.AddTranslatedElementIfKeyNotNull(localizableControl.Name, localizableControl.Text);  
            }

            return localization;
        }

        public static List<Localization> LoadLocalizationFromFile(string languageFile)
        {
            var localizations = new List<Localization>();

            var xmlDocument = new XmlDocument();

            xmlDocument.Load(languageFile);

            var languageNodes = xmlDocument.DocumentElement.SelectNodes("language");

            foreach (XmlNode languageNode in languageNodes)
            {
                var languageName = GetAttributeSecure(languageNode, "name");
                var twoLetterISOLanguageName = GetAttributeSecure(languageNode, "twoLetterISOLanguageName");

                var localization = new Localization()
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
                        Logger.LogWarning(typeof(LocalizationManager), "Empty id found in \"" + languageFile + "\"");
                    }
                    else
                    {
                        try
                        {
                            localization.Elements.Add(id, elementNode.InnerText);
                        }
                        catch
                        {
                            Logger.LogWarning(typeof(LocalizationManager), "Duplicate id found in \"" + languageFile + "\"");
                        }
                    }
                }
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

        public static List<Localization> LoadLocalizationsFromFiles(string[] languageFiles)
        {
            var localizations = new List<Localization>();

            foreach (var languageFilePath in languageFiles)
            {
                localizations.AddRange(LocalizationManager.LoadLocalizationFromFile(languageFilePath));
            }

            return localizations;
        }
    }
}
