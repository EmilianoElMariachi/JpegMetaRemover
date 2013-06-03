using System;
using JpegMetaRemover.JpegTools;
using JpegMetaRemover.Tools;
using Microsoft.Win32;

namespace JpegMetaRemover.ServicesProvider.SettingsService
{
    internal class SettingsManager
    {
        internal const string EDITOR_NAME = "Emignatik";
        internal const string APP_NAME = "JpegMetaRemover";

        internal const string REG_KEY_APP = "SOFTWARE\\" + EDITOR_NAME + "\\" + APP_NAME;

        internal const string REG_VAL_LANGUAGE = "Language";
        internal const string REG_VAL_META_TYPES_TO_REMOVE = "MetaTypesToRemove";
        internal const string REG_VAL_INCLUDE_SUB_DIRECTORIES = "IncludeSubDirectories";
        internal const string REG_VAL_OVERRIDE_ORIGINAL_FILE = "OverrideOriginalFile";
        internal const string REG_VAL_REMOVE_METADATAS = "RemoveMetaDatas";
        internal const string REG_VAL_REMOVE_COMMENTS = "RemoveComments";
        internal const string REG_VAL_LAST_INPUT_PATH = "LastInputPath";


        private JpegMetaTypes _metaTypesToRemove;

        public JpegMetaTypes MetaTypesToRemove
        {
            get { return _metaTypesToRemove; }
            set
            {
                _metaTypesToRemove = value;
                TrySaveToRegistry(REG_VAL_META_TYPES_TO_REMOVE, MetaTypesToRemove.ToString());
            }
        }
        private string _twoLetterISOLanguageName;

        public string TwoLetterISOLanguageName
        {
            get { return _twoLetterISOLanguageName; }
            set
            {
                _twoLetterISOLanguageName = value;
                TrySaveToRegistry(REG_VAL_LANGUAGE, value);
            }
        }

        private bool _includeSubdirectories;

        public bool IncludeSubdirectories
        {
            get { return _includeSubdirectories; }
            set
            {
                _includeSubdirectories = value;
                TrySaveToRegistry(REG_VAL_INCLUDE_SUB_DIRECTORIES, value.ToString());
            }
        }

        private bool _overrideOriginalFile;

        public bool OverrideOriginalFile
        {
            get { return _overrideOriginalFile; }
            set
            {
                _overrideOriginalFile = value;
                TrySaveToRegistry(REG_VAL_OVERRIDE_ORIGINAL_FILE, value.ToString());
            }
        }

        private bool _removeMetadatas;

        public bool RemoveMetadatas
        {
            get { return _removeMetadatas; }
            set
            {
                _removeMetadatas = value;
                TrySaveToRegistry(REG_VAL_REMOVE_METADATAS, value.ToString());
            }
        }

        private bool _removeComments;

        public bool RemoveComments
        {
            get { return _removeComments; }
            set
            {
                _removeComments = value;
                TrySaveToRegistry(REG_VAL_REMOVE_COMMENTS, value.ToString());
            }
        }

        private string _lastInputPath;

        public string LastInputPath
        {
            get { return _lastInputPath; }
            set
            {
                _lastInputPath = value;
                TrySaveToRegistry(REG_VAL_LAST_INPUT_PATH, value);
            }
        }

        public bool CleanUpSavedSettingsOnClose { get; set; }

        internal SettingsManager()
        {
            _twoLetterISOLanguageName = TryReadFromRegistry<string>(REG_VAL_LANGUAGE, null);


            _metaTypesToRemove = GetDefaultMetaTypesToRemove();
            var metaTypesToRemoveAsString = TryReadFromRegistry<string>(REG_VAL_META_TYPES_TO_REMOVE, null);
            if (metaTypesToRemoveAsString != null)
            { Enum.TryParse(metaTypesToRemoveAsString, out _metaTypesToRemove); }


            _includeSubdirectories = false;
            bool.TryParse(TryReadFromRegistry<string>(REG_VAL_INCLUDE_SUB_DIRECTORIES, null), out _includeSubdirectories);

            _overrideOriginalFile = false;
            bool.TryParse(TryReadFromRegistry<string>(REG_VAL_OVERRIDE_ORIGINAL_FILE, null), out _overrideOriginalFile);

            _removeMetadatas = true;
            bool.TryParse(TryReadFromRegistry<string>(REG_VAL_REMOVE_METADATAS, null), out _removeMetadatas);

            _removeComments = true;
            bool.TryParse(TryReadFromRegistry<string>(REG_VAL_REMOVE_COMMENTS, null), out _removeComments);

            LastInputPath = TryReadFromRegistry<string>(REG_VAL_LAST_INPUT_PATH, "");

            CleanUpSavedSettingsOnClose = false;

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
        }

        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            if (CleanUpSavedSettingsOnClose)
            { CleanRegistry(); }
        }

        private static JpegMetaTypes GetDefaultMetaTypesToRemove()
        {
            var defaultMetaTypes = JpegMetaTypes.NONE;
            foreach (JpegMetaTypes metaType in Enum.GetValues(typeof(JpegMetaTypes)))
            {
                defaultMetaTypes = defaultMetaTypes | metaType;
            }
            return defaultMetaTypes;
        }

        private static TRegValType TryReadFromRegistry<TRegValType>(string valueName, TRegValType defaultValue)
        {
            TRegValType value = defaultValue;

            //Charge la localization depuis la base de registre si elle existe
            RegistryKey regKeyApp = null;
            try
            {
                regKeyApp = Registry.CurrentUser.OpenSubKey(REG_KEY_APP);
                if (regKeyApp != null)
                { value = (TRegValType)regKeyApp.GetValue(valueName); }
            }
            catch
            { }
            finally
            { MemHelper.DisposeSecure(regKeyApp); }

            return value;
        }

        private static void TrySaveToRegistry(string valueName, object value)
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

        public static void CleanRegistry()
        {
            try
            { Registry.CurrentUser.DeleteSubKeyTree(REG_KEY_APP); }
            catch
            { }
        }
    }
}