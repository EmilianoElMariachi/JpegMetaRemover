using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using JpegMetaRemover.Log;
using JpegMetaRemover.Translation;
using Microsoft.Win32;
using System.Threading;
using System.Globalization;
using JpegMetaRemover.Tools;

namespace JpegMetaRemover
{
    public partial class FormMain : Form
    {
        private const string EDITOR_NAME = "Emignatik";
        private const string APP_NAME = "JpegMetaRemover";

        private const string REG_KEY_APP = "SOFTWARE\\" + EDITOR_NAME + "\\" + APP_NAME;
        private const string REG_VAL_LANGUAGE = "lang";

        private List<LocalizableControlWrapper> LocalizableControls { get; set; }

        private readonly LocalizationManager LocalizationManager = new LocalizationManager();

        public FormMain()
        {
            Logger.OnLog += (sender, message, type) => { this.Log(message, type); };

            InitializeComponent();

            InitializeLanguages();
        }

        private void InitializeLanguages()
        {

            LocalizableControls = LocalizableControlWrapper.FetchFormLocalizableControls(this);

            var defaultLocalization = LocalizationManager.LoadLocalizationFromLocalizableControls(this.LocalizableControls, "English", "en");

            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var languageFiles = Directory.GetFiles(currentDir, "*.lng");

            LocalizationManager.LoadLocalizationsFromFiles(languageFiles);

            foreach (Localization localization in LocalizationManager.LoadedLocalizations)
            {
                var item = _languageToolStripMenuItem.DropDownItems.Add(localization.LanguageName);

                item.Tag = localization;
                item.Click += item_Click;
            }

                
            Localization localizationToApply = null;

            //Charge la localization depuis la base de registre si elle existe
            RegistryKey regKeyApp = null;
            try
            {
                regKeyApp = Registry.CurrentUser.OpenSubKey(REG_KEY_APP);
                if (regKeyApp != null)
                {
                    var regkeyTowLetterLang = regKeyApp.GetValue(REG_VAL_LANGUAGE) as string;
                    if (regkeyTowLetterLang != null)
                    {
                        var localizationFound = LocalizationManager.LoadedLocalizations.FindLocalizationByTwoLetterLanguageName(regkeyTowLetterLang);
                        if (localizationFound != null)
                        { localizationToApply = localizationFound; }
                    }
                }
            }
            finally
            { MemHelper.DisposeSecure(regKeyApp); }

            //Charge la localization depuis la culture du PC si elle existe
            if(localizationToApply == null)
            {
                var currentPCTowLetterLang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
                var localizationFound = LocalizationManager.LoadedLocalizations.FindLocalizationByTwoLetterLanguageName(currentPCTowLetterLang);
                if (localizationFound != null)
                { localizationToApply = localizationFound; }
            }

            if (localizationToApply == null)
            {
                localizationToApply = defaultLocalization;
            }

            ApplyLocalization(localizationToApply);
        }

        void ApplyLocalization(Localization localization)
        {
            if (localization != null)
            {
                foreach (ToolStripMenuItem languageMenuItem in _languageToolStripMenuItem.DropDownItems)
                {
                    languageMenuItem.Checked = (localization == languageMenuItem.Tag as Localization);
                }

                localization.SetActiveLocalization(this.LocalizableControls);

                //Sauvegarde la localization séléctionnée dans la base de registre
                RegistryKey regKeyApp = null;
                try
                {
                    regKeyApp = Registry.CurrentUser.CreateSubKey(REG_KEY_APP);
                    if (regKeyApp != null)
                    {
                        regKeyApp.SetValue(REG_VAL_LANGUAGE, localization.TwoLetterISOLanguageName);
                    }
                }
                catch(Exception ex)
                {
                    LogException(ex);
                }
                finally
                { MemHelper.DisposeSecure(regKeyApp); }

            }
        }

        void item_Click(object sender, EventArgs e)
        {
            var clickedMenuItem = sender as ToolStripMenuItem;
            if (clickedMenuItem != null)
            {
                ApplyLocalization(clickedMenuItem.Tag as Localization);
            }
        }

        public delegate void DelegateLogAsync(string message, MsgType msgType);
        /// <summary>
        /// Permet de logguer un message
        /// </summary>
        private void Log(string message, MsgType msgType)
        {
            //Test si l'appel du log est fait depuis un Thread
            if (this.InvokeRequired == true)
            {
                this.Invoke(new DelegateLogAsync(this.Log), message, msgType);
                return;
            }

            //Vérifie qu'il y ait bien un message a afficher
            if (message == null)
            { return; }

            var msgColor = Color.Black;

            //associe une couleur à un type de message
            switch (msgType)
            {
                case MsgType.ERROR:
                    {
                        message = LocalizationManager.ActiveLocalization.Translate("ERROR : ") + message;
                        msgColor = Color.Red;
                        break;
                    }
                case MsgType.INFO:
                    {
                        message = "> " + message;
                        msgColor = Color.Blue;
                        break;
                    }
                case MsgType.WARNING:
                    {
                        message = LocalizationManager.ActiveLocalization.Translate("WARNING : ") + message;
                        msgColor = Color.Orange;
                        break;
                    }
                case MsgType.ACTION_START:
                    {

                        message = "===> " + message + " <===";
                        msgColor = Color.Green;
                        break;
                    }
                case MsgType.ACTION_END:
                    {
                        msgColor = Color.Green;
                        break;
                    }
            }

            //Place le curseur à la fin
            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length + 10;

            //Associe la couleur sélectionnée
            _richTextBoxLog.SelectionColor = msgColor;

            //Affiche le message et passe à la ligne
            _richTextBoxLog.AppendText(message + Environment.NewLine);

            //le richTexBox scroll automatiquement 
            //des que les messages sortent de la zone visible
            _richTextBoxLog.ScrollToCaret();
        }

        /// <summary>
        /// Permet de logguer une info
        /// </summary>
        /// <param name="message"></param>
        private void LogInfo(string message)
        {
            this.Log(message, MsgType.INFO);
        }

        /// <summary>
        /// Permet de logguer un warning
        /// </summary>
        /// <param name="message"></param>
        private void LogWarning(string message)
        {
            this.Log(message, MsgType.WARNING);
        }

        /// <summary>
        /// Permet de logguer une erreur
        /// </summary>
        /// <param name="message"></param>
        private void LogError(string message)
        {
            this.Log(message, MsgType.ERROR);
        }

        /// <summary>
        /// Permet de logguer une Exception
        /// </summary>
        /// <param name="ex"></param>
        private void LogException(Exception ex)
        {
            if (ex != null)
            { this.Log(ex.Message, MsgType.ERROR); }
            else
            { this.Log("Can't log null exception", MsgType.ERROR); }
        }

        /// <summary>
        /// Permet de logguer qu'une action est sur le point d'être executée
        /// </summary>
        /// <param name="actionName"></param>
        private void LogActionAboutToBeDone(string actionName)
        {
            if (actionName == null)
            { actionName = LocalizationManager.ActiveLocalization.Translate("UNKNOWN ACTION"); }

            this.Log(actionName, MsgType.ACTION_START);
        }

        /// <summary>
        /// Permet d'indiquer que l'action s'est déroulée avec succès (sans exception)
        /// </summary>
        private void LogActionDoneSuccessfully()
        {
            this.Log(LocalizationManager.ActiveLocalization.Translate("Done.") + Environment.NewLine, MsgType.ACTION_END);
        }

        private string ActionTypeToString(ActionType actionType, bool writeOutputFile)
        {
            if (writeOutputFile)
            {
                switch (actionType)
                {
                    case ActionType.KEEP:
                        return LocalizationManager.ActiveLocalization.Translate("kept");
                    case ActionType.REMOVE:
                        return LocalizationManager.ActiveLocalization.Translate("removed");
                    default:
                        return LocalizationManager.ActiveLocalization.Translate("unknown");
                }

            }
            else
            {
                return LocalizationManager.ActiveLocalization.Translate("found");
            }
        }

        private string GetFreeFilePath(string filePath)
        {
            var fileDir = Path.GetDirectoryName(filePath);
            var fileExt = Path.GetExtension(filePath);
            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

            var filePathWithoutExt = Path.Combine(fileDir, fileNameWithoutExt);

            int i = 0;
            string freeFilePath;
            do
            {
                freeFilePath = filePathWithoutExt + "_" + (++i).ToString("0") + fileExt;
            } while (File.Exists(freeFilePath));
            return freeFilePath;
        }

        private void PurifyJpegFile()
        {
            if (_backgroundWorkerPurify.IsBusy)
            {
                LogWarning(this.LocalizationManager.ActiveLocalization.Translate("Please wait."));
            }
            else
            {
                var inputJpegFilePath = _textBoxInputPath.Text;
                var metadatasAction = _checkBoxRemoveMetadatas.Checked ? ActionType.REMOVE : ActionType.KEEP;
                var commentsAction = _checkBoxRemoveComments.Checked ? ActionType.REMOVE : ActionType.KEEP;
                var overrideInputFile = _checkBoxOverride.Checked;
                var includeSubDirectories = _checkBoxIncludeSubdirectories.Checked;

                _backgroundWorkerPurify.RunWorkerAsync(new object[] { inputJpegFilePath, metadatasAction, commentsAction, overrideInputFile, includeSubDirectories });
            }
        }

        private void _runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurifyJpegFile();
        }

        private void _buttonRun_Click(object sender, EventArgs e)
        {
            PurifyJpegFile();
        }

        private void _backgroundWorkerPurify_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var args = e.Argument as object[];

            var inputPath = args[0] as string;
            var metadatasAction = (ActionType)args[1];
            var commentsAction = (ActionType)args[2];
            var overrideInputFile = (bool)args[3];
            var includeSubdirectories = (bool)args[4];

            var writeOutputFile = !(metadatasAction == ActionType.KEEP && commentsAction == ActionType.KEEP);

            var jpegFilesToPurify = new List<string>();

            if (Directory.Exists(inputPath))
            {
                var searchOption = includeSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                jpegFilesToPurify.AddRange(Directory.GetFiles(inputPath, "*.jpg", searchOption));
                jpegFilesToPurify.AddRange(Directory.GetFiles(inputPath, "*.jpeg", searchOption));
            }
            else if (File.Exists(inputPath))
            {
                jpegFilesToPurify.Add(inputPath);
            }
            else
            {
                var exMessage = LocalizationManager.ActiveLocalization.Translate("Specified path \"{0}\" doesn't exist.", inputPath);
                throw new Exception(exMessage);
            }

            if(_backgroundWorkerPurify.CancellationPending)
            { return; }

            if (jpegFilesToPurify.Count <= 0)
            {
                LogWarning(LocalizationManager.ActiveLocalization.Translate("No file to process."));
            }

            var maxProgression = jpegFilesToPurify.Count * 2;
            var currentProgression = 0.0;
            foreach (var inputJpegFilePath in jpegFilesToPurify)
            {
                if (_backgroundWorkerPurify.CancellationPending)
                { return; }

                JPGExifRemover jpgExifRemover = null;
                MemoryStream outputMemoryStream = null;
                FileStream outputFileStream = null;
                try
                {
                    this.LogActionAboutToBeDone(inputJpegFilePath);
                    jpgExifRemover = new JPGExifRemover(inputJpegFilePath);

                    outputMemoryStream = new MemoryStream();

                    var purificationResult = jpgExifRemover.Purify(metadatasAction, commentsAction, outputMemoryStream);

                    _backgroundWorkerPurify.ReportProgress((int)(++currentProgression / maxProgression * 100.0));

                    jpgExifRemover.Dispose();

                    LogInfo(LocalizationManager.ActiveLocalization.Translate("{0} metadata(s) {1} ({2})", purificationResult.NbMetadatasEncountered.ToString(), ActionTypeToString(purificationResult.ActionPerformedOnMetadatas, writeOutputFile), purificationResult.MetaTypesEncountered.ToString()));
                    LogInfo(LocalizationManager.ActiveLocalization.Translate("{0} comment(s) {1}", purificationResult.NbCommentsEncountered.ToString(), ActionTypeToString(purificationResult.ActionPerformedOnComments, writeOutputFile)));


                    if (writeOutputFile && (purificationResult.NbMetadatasEncountered > 0 || purificationResult.NbCommentsEncountered > 0))
                    {
                        if (overrideInputFile)
                        {
                            outputFileStream = new FileStream(inputJpegFilePath, FileMode.Create);
                            outputMemoryStream.WriteTo(outputFileStream);
                            LogInfo(LocalizationManager.ActiveLocalization.Translate("File overriden."));
                        }
                        else
                        {
                            var outputFilePath = GetFreeFilePath(inputJpegFilePath);
                            outputFileStream = new FileStream(outputFilePath, FileMode.Create);
                            outputMemoryStream.WriteTo(outputFileStream);
                            LogInfo(LocalizationManager.ActiveLocalization.Translate("File saved to \"{0}\".", Path.GetFileName(outputFilePath)));
                        }
                    }
                    else
                    {
                        LogInfo(LocalizationManager.ActiveLocalization.Translate("No file written."));
                    }
                    _backgroundWorkerPurify.ReportProgress((int)(++currentProgression / maxProgression * 100.0));


                    LogActionDoneSuccessfully();
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }
                finally
                {
                    MemHelper.DisposeSecure(jpgExifRemover);
                    MemHelper.DisposeSecure(outputMemoryStream);
                    MemHelper.DisposeSecure(outputFileStream);
                }
            }


        }

        private void _backgroundWorkerPurify_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            { this.LogException(e.Error); }

            _progressBar.Value = _progressBar.Minimum;
        }

        private void _backgroundWorkerPurify_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            _progressBar.Value = e.ProgressPercentage;
        }

        private void _buttonCancel_Click(object sender, EventArgs e)
        {
            if (_backgroundWorkerPurify.IsBusy && !_backgroundWorkerPurify.CancellationPending)
            {
                _backgroundWorkerPurify.CancelAsync();
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            catch
            {
            }
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var files = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (files.Length >= 0)
                {
                    _textBoxInputPath.Text = files[0];
                }
            }
            catch
            {}
        }



    }
}
