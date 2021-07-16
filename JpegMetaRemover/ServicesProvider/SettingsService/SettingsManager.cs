using System;
using JpegMetaRemover.JpegTools;
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
        internal const string REG_VAL_CLEAN_ON_DRAG_AND_DROP = "CleanOnDragAndDrop";

        internal const string REG_VAL_REMOVE_METADATA = "RemoveMetadata";
        internal const string REG_VAL_REMOVE_COMMENTS = "RemoveComments";
        internal const string REG_VAL_LAST_INPUT_PATH = "LastInputPath";


        private JpegMetaTypes _metaTypesToRemove;

        public JpegMetaTypes MetaTypesToRemove
        {
            get => _metaTypesToRemove;
            set
            {
                _metaTypesToRemove = value;
                TrySaveToRegistry(REG_VAL_META_TYPES_TO_REMOVE, MetaTypesToRemove.ToString());
            }
        }
        private string _twoLetterISOLanguageName;

        public string TwoLetterISOLanguageName
        {
            get => _twoLetterISOLanguageName;
            set
            {
                _twoLetterISOLanguageName = value;
                TrySaveToRegistry(REG_VAL_LANGUAGE, value);
            }
        }

        private bool _includeSubdirectories;

        public bool IncludeSubdirectories
        {
            get => _includeSubdirectories;
            set
            {
                _includeSubdirectories = value;
                TrySaveToRegistry(REG_VAL_INCLUDE_SUB_DIRECTORIES, value.ToString());
            }
        }

        private bool _overrideOriginalFile;

        public bool OverrideOriginalFile
        {
            get => _overrideOriginalFile;
            set
            {
                _overrideOriginalFile = value;
                TrySaveToRegistry(REG_VAL_OVERRIDE_ORIGINAL_FILE, value.ToString());
            }
        }

        private bool _removeMetadata;

        public bool RemoveMetadata
        {
            get => _removeMetadata;
            set
            {
                _removeMetadata = value;
                TrySaveToRegistry(REG_VAL_REMOVE_METADATA, value.ToString());
            }
        }

        private bool _removeComments;

        public bool RemoveComments
        {
            get => _removeComments;
            set
            {
                _removeComments = value;
                TrySaveToRegistry(REG_VAL_REMOVE_COMMENTS, value.ToString());
            }
        }

        private string _lastInputPath;
        private bool _cleanOnDragAndDrop;

        public string LastInputPath
        {
            get => _lastInputPath;
            set
            {
                _lastInputPath = value;
                TrySaveToRegistry(REG_VAL_LAST_INPUT_PATH, value);
            }
        }

        /// <summary>
        /// Indique si l'image doit être nettoyée au moment d'un drag & drop
        /// </summary>
        public bool CleanOnDragAndDrop
        {
            get => _cleanOnDragAndDrop;
            set
            {
                TrySaveToRegistry(REG_VAL_CLEAN_ON_DRAG_AND_DROP, value);
                _cleanOnDragAndDrop = value;
            }
        }

        internal SettingsManager()
        {
            InitializeFromRegistry();
        }

        public void InitializeFromRegistry()
        {
            _twoLetterISOLanguageName = TryReadFromRegistry<string>(REG_VAL_LANGUAGE, null);

            var metaTypesToRemoveAsString = TryReadFromRegistry<string>(REG_VAL_META_TYPES_TO_REMOVE, null);
            if (metaTypesToRemoveAsString == null || !Enum.TryParse(metaTypesToRemoveAsString, out _metaTypesToRemove))
                _metaTypesToRemove = GetDefaultMetaTypesToRemove();

            if (!bool.TryParse(TryReadFromRegistry<string>(REG_VAL_INCLUDE_SUB_DIRECTORIES, null), out _includeSubdirectories))
                _includeSubdirectories = false;

            if (!bool.TryParse(TryReadFromRegistry<string>(REG_VAL_OVERRIDE_ORIGINAL_FILE, null), out _overrideOriginalFile))
                _overrideOriginalFile = true;

            if (!bool.TryParse(TryReadFromRegistry<string>(REG_VAL_REMOVE_METADATA, null), out _removeMetadata))
                _removeMetadata = true;

            if (!bool.TryParse(TryReadFromRegistry<string>(REG_VAL_REMOVE_COMMENTS, null), out _removeComments))
                _removeComments = true;

            if (!bool.TryParse(TryReadFromRegistry<string>(REG_VAL_CLEAN_ON_DRAG_AND_DROP, null), out _cleanOnDragAndDrop))
                _cleanOnDragAndDrop = true;

            LastInputPath = TryReadFromRegistry<string>(REG_VAL_LAST_INPUT_PATH, "");
        }

        private static JpegMetaTypes GetDefaultMetaTypesToRemove()
        {
            var defaultMetaTypes = JpegMetaTypes.NONE;
            foreach (JpegMetaTypes metaType in Enum.GetValues(typeof(JpegMetaTypes)))
            {
                defaultMetaTypes |= metaType;
            }
            return defaultMetaTypes;
        }

        private static TRegValType TryReadFromRegistry<TRegValType>(string valueName, TRegValType defaultValue)
        {
            TRegValType value = defaultValue;

            //Charge la localization depuis la base de registre si elle existe

            try
            {
                using var regKeyApp = Registry.CurrentUser.OpenSubKey(REG_KEY_APP);
                if (regKeyApp != null)
                    value = (TRegValType)regKeyApp.GetValue(valueName);
            }
            catch
            {
                // ignored
            }
            return value;
        }

        private static void TrySaveToRegistry(string valueName, object value)
        {
            //Charge la localization depuis la base de registre si elle existe
            try
            {
                using var regKeyApp = Registry.CurrentUser.CreateSubKey(REG_KEY_APP);
                regKeyApp?.SetValue(valueName, value);
            }
            catch
            {

            }
        }

        public void CleanRegistry()
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(REG_KEY_APP);
            }
            catch
            {
                // ignored
            }
        }
    }
}