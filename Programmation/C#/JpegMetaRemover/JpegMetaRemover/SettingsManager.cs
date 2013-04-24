using System;
using JpegMetaRemover.Tools;
using Microsoft.Win32;

namespace JpegMetaRemover
{
    internal static class SettingsManager
    {
        internal const string EDITOR_NAME = "Emignatik";
        internal const string APP_NAME = "JpegMetaRemover";

        internal const string REG_KEY_APP = "SOFTWARE\\" + EDITOR_NAME + "\\" + APP_NAME;

        internal const string REG_VAL_LANGUAGE = "Language";
        internal const string REG_VAL_META_TYPES_TO_REMOVE = "MetaTypesToRemove";


        private static JpegMetaTypes _metaTypesToRemove;

        public static JpegMetaTypes MetaTypesToRemove
        {
            get { return _metaTypesToRemove; }
            set
            {
                _metaTypesToRemove = value;
                SaveMetaTypesToRemove();
            }
        }
        private static string _twoLetterISOLanguageName;

        public static string TwoLetterISOLanguageName
        {
            get { return _twoLetterISOLanguageName; }
            set
            {
                _twoLetterISOLanguageName = value;
                SaveLocalization();
            }
        }

        static SettingsManager()
        {
            TwoLetterISOLanguageName = ReadFromRegistry(REG_VAL_LANGUAGE);

            var metaTypesToRemoveAsString = ReadFromRegistry(REG_VAL_META_TYPES_TO_REMOVE);
            if (metaTypesToRemoveAsString != null)
            {
                JpegMetaTypes jpegMetaTypesToRemoveFromRegistry;
                if (JpegMetaTypes.TryParse(metaTypesToRemoveAsString, out jpegMetaTypesToRemoveFromRegistry))
                {
                    MetaTypesToRemove = jpegMetaTypesToRemoveFromRegistry;
                }
                else
                {
                    SetDefaultMetaTypesToRemove();
                }
            }
            else
            {
                SetDefaultMetaTypesToRemove();
            }

        }

        private static void SetDefaultMetaTypesToRemove()
        {
            foreach (JpegMetaTypes metaType in Enum.GetValues(typeof(JpegMetaTypes)))
            {
                MetaTypesToRemove = MetaTypesToRemove | metaType;
            }
        }

        private static void SaveLocalization()
        {
            if (TwoLetterISOLanguageName != null)
            {
                SaveToRegistry(REG_VAL_LANGUAGE, TwoLetterISOLanguageName);
            }
        }

        private static void SaveMetaTypesToRemove()
        {
            SaveToRegistry(REG_VAL_META_TYPES_TO_REMOVE, MetaTypesToRemove.ToString());
        }

        private static string ReadFromRegistry(string valueName)
        {
            string value = null;

            //Charge la localization depuis la base de registre si elle existe
            RegistryKey regKeyApp = null;
            try
            {
                regKeyApp = Registry.CurrentUser.OpenSubKey(REG_KEY_APP);
                if (regKeyApp != null)
                { value = regKeyApp.GetValue(valueName) as string; }
            }
            catch
            { }
            finally
            { MemHelper.DisposeSecure(regKeyApp); }

            return value;
        }

        private static void SaveToRegistry(string valueName, string value)
        {
            //Charge la localization depuis la base de registre si elle existe
            RegistryKey regKeyApp = null;
            try
            {
                regKeyApp = Registry.CurrentUser.CreateSubKey(REG_KEY_APP);
                if (regKeyApp != null)
                {
                    regKeyApp.SetValue(valueName, value);
                }
            }
            catch
            { }
            finally
            { MemHelper.DisposeSecure(regKeyApp); }
        }

    }
}