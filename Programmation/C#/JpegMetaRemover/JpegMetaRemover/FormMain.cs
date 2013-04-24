using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using JpegMetaRemover.JpegTools;
using JpegMetaRemover.Log;
using JpegMetaRemover.Translation;
using System.Threading;
using System.Globalization;
using JpegMetaRemover.Tools;

namespace JpegMetaRemover
{
    public partial class FormMain : Form
    {

        private LocalizableControlWrapperCollection LocalizableControls { get; set; }

        private readonly LocalizationManager _localizationManager = new LocalizationManager();

        public FormMain()
        {
            Logger.OnLog += (sender, message, type) => { this.Log(message, type); };

            InitializeComponent();

            InitializeLanguages();

            _checkBoxIncludeSubdirectories.Checked = SettingsManager.IncludeSubdirectories;

            _checkBoxOverride.Checked = SettingsManager.OverrideOriginalFile;

            _checkBoxRemoveMetadatas.Checked = SettingsManager.RemoveMetadatas;

            _checkBoxRemoveComments.Checked = SettingsManager.RemoveComments;

        }

        private void InitializeLanguages()
        {

            LocalizableControls = LocalizableControlWrapper.FetchFormLocalizableControls(this);

            var defaultLocalization = _localizationManager.LoadLocalizationFromLocalizableControls(this.LocalizableControls, "English", "en");

            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var languageFiles = Directory.GetFiles(currentDir, "*.lng");

            _localizationManager.LoadLocalizationsFromFiles(languageFiles);

            foreach (Localization localization in _localizationManager.LoadedLocalizations)
            {
                var item = _languageToolStripMenuItem.DropDownItems.Add(localization.LanguageName);

                item.Tag = localization;
                item.Click += item_Click;
            }


            Localization localizationToApply = null;

            //Charge la localization depuis la base de registre si elle existe
            if (SettingsManager.TwoLetterISOLanguageName != null)
            {
                var localizationFound = _localizationManager.LoadedLocalizations.FindLocalizationByTwoLetterLanguageName(SettingsManager.TwoLetterISOLanguageName);
                if (localizationFound != null)
                { localizationToApply = localizationFound; }
            }

            //Charge la localization depuis la culture du PC si elle existe
            if (localizationToApply == null)
            {
                var currentPCTowLetterLang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
                var localizationFound = _localizationManager.LoadedLocalizations.FindLocalizationByTwoLetterLanguageName(currentPCTowLetterLang);
                if (localizationFound != null)
                { localizationToApply = localizationFound; }
            }

            if (localizationToApply == null)
            {
                localizationToApply = defaultLocalization;
            }

            ApplyLocalization(localizationToApply);
        }

        private void ApplyLocalization(Localization localization)
        {
            if (localization != null)
            {
                foreach (ToolStripMenuItem languageMenuItem in _languageToolStripMenuItem.DropDownItems)
                {
                    languageMenuItem.Checked = (localization == languageMenuItem.Tag as Localization);
                }

                localization.SetActiveLocalization(this.LocalizableControls);

                //Sauvegarde la localization séléctionnée dans la base de registre
                SettingsManager.TwoLetterISOLanguageName = localization.TwoLetterISOLanguageName;
            }
        }

        private void item_Click(object sender, EventArgs e)
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
                        message = _localizationManager.ActiveLocalization.Translate("ERROR : ") + message;
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
                        message = _localizationManager.ActiveLocalization.Translate("WARNING : ") + message;
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
            { actionName = _localizationManager.ActiveLocalization.Translate("UNKNOWN ACTION"); }

            this.Log(actionName, MsgType.ACTION_START);
        }

        /// <summary>
        /// Permet d'indiquer que l'action s'est déroulée avec succès (sans exception)
        /// </summary>
        private void LogActionDoneSuccessfully()
        {
            this.Log(_localizationManager.ActiveLocalization.Translate("Done.") + Environment.NewLine, MsgType.ACTION_END);
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
                LogWarning(this._localizationManager.ActiveLocalization.Translate("Please wait."));
            }
            else
            {
                var inputPath = _textBoxInputPath.Text;

                var jpegMetaTypesToRemove = JpegMetaTypes.NONE;
                if (_checkBoxRemoveMetadatas.Checked)
                {
                    jpegMetaTypesToRemove = SettingsManager.MetaTypesToRemove;
                }

                var commentsAction = _checkBoxRemoveComments.Checked ? CommentsActionType.REMOVE : CommentsActionType.KEEP;
                var overrideInputFile = _checkBoxOverride.Checked;
                var includeSubDirectories = _checkBoxIncludeSubdirectories.Checked;

                _backgroundWorkerPurify.RunWorkerAsync(new object[] { inputPath, jpegMetaTypesToRemove, commentsAction, overrideInputFile, includeSubDirectories });
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
            var jpegMetaTypesToRemove = (JpegMetaTypes)args[1];
            var commentsAction = (CommentsActionType)args[2];
            var overrideInputFile = (bool)args[3];
            var includeSubdirectories = (bool)args[4];

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
                var exMessage = _localizationManager.ActiveLocalization.Translate("Specified path \"{0}\" doesn't exist.", inputPath);
                throw new Exception(exMessage);
            }

            if (_backgroundWorkerPurify.CancellationPending)
            { return; }

            if (jpegFilesToPurify.Count <= 0)
            {
                LogWarning(_localizationManager.ActiveLocalization.Translate("No file to process."));
            }

            var maxProgression = jpegFilesToPurify.Count * 2;
            var currentProgression = 0.0;
            foreach (var inputJpegFilePath in jpegFilesToPurify)
            {
                if (_backgroundWorkerPurify.CancellationPending)
                { return; }

                JPGExifRemover jpgExifRemover = null;
                FileStream outputFileStream = null;
                PurificationResult purificationResult = null;
                try
                {
                    this.LogActionAboutToBeDone(inputJpegFilePath);
                    jpgExifRemover = new JPGExifRemover(inputJpegFilePath);

                    purificationResult = jpgExifRemover.Purify(jpegMetaTypesToRemove, commentsAction);

                    _backgroundWorkerPurify.ReportProgress((int)(++currentProgression / maxProgression * 100.0));

                    jpgExifRemover.Dispose();

                    LogInfo(_localizationManager.ActiveLocalization.Translate("{0} metadata(s) found ({1})", purificationResult.NbMetasFound.ToString() , purificationResult.MetaTypesFound.ToString()));
                    LogInfo(_localizationManager.ActiveLocalization.Translate("{0} metadata(s) removed ({1})", purificationResult.NbMetasRemoved.ToString(), purificationResult.MetaTypesRemoved.ToString()));
                    LogInfo(_localizationManager.ActiveLocalization.Translate("{0} comment(s) found", purificationResult.NbCommentsFound.ToString()));
                    LogInfo(_localizationManager.ActiveLocalization.Translate("{0} comment(s) removed", purificationResult.NbCommentsRemoved.ToString()));


                    if (purificationResult.ResultStreamDiffersFromOriginal)
                    {
                        if (overrideInputFile)
                        {
                            outputFileStream = new FileStream(inputJpegFilePath, FileMode.Create);
                            purificationResult.ResultStream.WriteTo(outputFileStream);
                            LogInfo(_localizationManager.ActiveLocalization.Translate("File overriden."));
                        }
                        else
                        {
                            var outputFilePath = GetFreeFilePath(inputJpegFilePath);
                            outputFileStream = new FileStream(outputFilePath, FileMode.Create);
                            purificationResult.ResultStream.WriteTo(outputFileStream);
                            LogInfo(_localizationManager.ActiveLocalization.Translate("File saved to \"{0}\".", Path.GetFileName(outputFilePath)));
                        }
                    }
                    else
                    {
                        LogInfo(_localizationManager.ActiveLocalization.Translate("No file written."));
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
                    if (purificationResult != null)
                    { MemHelper.DisposeSecure(purificationResult.ResultStream); }
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
            { }
        }

        private void _selectFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowseImageFile();
        }

        private void BrowseImageFile()
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Title = _localizationManager.ActiveLocalization.Translate("Select an image"),
                    Filter = "Jpeg file (*.jpg)|*.jpg;*.jpeg| All files (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _textBoxInputPath.Text = openFileDialog.FileName;
                }
            }
            catch
            {

            }
        }

        private void _selectDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowseDirectory();
        }

        private void BrowseDirectory()
        {
            try
            {
                var folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    _textBoxInputPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
            catch
            {
            }
        }

        private void _buttonBrowseImageFile_Click(object sender, EventArgs e)
        {
            BrowseImageFile();
        }

        private void _settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSettings = new FormSettings();

            if (formSettings.ShowDialog() == DialogResult.OK)
            {
                SettingsManager.MetaTypesToRemove = formSettings.GetJpegMetaTypesToRemove();
            }
        }

        private void _checkBoxIncludeSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.IncludeSubdirectories = _checkBoxIncludeSubdirectories.Checked;
        }

        private void _checkBoxOverride_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.OverrideOriginalFile = _checkBoxOverride.Checked;
        }

        private void _checkBoxRemoveMetadatas_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.RemoveMetadatas = _checkBoxRemoveMetadatas.Checked;
        }

        private void _checkBoxRemoveComments_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.RemoveComments = _checkBoxRemoveComments.Checked;
        }

    }
}
