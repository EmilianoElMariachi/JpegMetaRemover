using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using JpegMetaRemover.JpegTools;
using JpegMetaRemover.Log;
using JpegMetaRemover.OtherForms;
using JpegMetaRemover.ServicesProvider;
using System.Threading;
using System.Globalization;
using JpegMetaRemover.ServicesProvider.LocalizationService;
using JpegMetaRemover.Tools;

namespace JpegMetaRemover
{
    public partial class FormMain : Form
    {

        private LocalizableControlWrapperCollection LocalizableControls
        {
            get { return _localizableControls; }
        }

        
        private LocalizableControlWrapperCollection _localizableControls;

        private FormSettings _formSettings = new FormSettings();

        private FormAbout _formAbout = new FormAbout();

        public FormMain()
        {

            InitializeComponent();

            Logger.OnLog += (sender, message, type) => { this.Log(message, type); };

            _localizableControls = new LocalizableControlWrapperCollection();

            InitializeLanguages();

            _checkBoxIncludeSubdirectories.Checked = Services.SettingsManager.IncludeSubdirectories;

            _checkBoxOverride.Checked = Services.SettingsManager.OverrideOriginalFile;

            _checkBoxRemoveMetadatas.Checked = Services.SettingsManager.RemoveMetadatas;

            _checkBoxRemoveComments.Checked = Services.SettingsManager.RemoveComments;

            _textBoxInputPath.Text = Services.SettingsManager.LastInputPath;

        }

        private void InitializeLanguages()
        {

            LocalizableControls.UpdateListFromForm(this);

            LocalizableControls.UpdateListFromForm(_formSettings);

            LocalizableControls.UpdateListFromForm(_formAbout);

            var defaultLocalization = Services.LocalizationManager.LoadLocalizationFromLocalizableControls(this.LocalizableControls, "English", "en");

            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var languageFiles = Directory.GetFiles(currentDir, "*.lng");

            Services.LocalizationManager.LoadLocalizationsFromFiles(languageFiles);

            foreach (Localization localization in Services.LocalizationManager.LoadedLocalizations)
            {
                var item = _languageToolStripMenuItem.DropDownItems.Add(localization.LanguageName);

                item.Tag = localization;
                item.Click += item_Click;
            }


            Localization localizationToApply = null;

            //Charge la localization depuis la base de registre si elle existe
            if (Services.SettingsManager.TwoLetterISOLanguageName != null)
            {
                var localizationFound = Services.LocalizationManager.LoadedLocalizations.FindLocalizationByTwoLetterLanguageName(Services.SettingsManager.TwoLetterISOLanguageName);
                if (localizationFound != null)
                { localizationToApply = localizationFound; }
            }

            //Charge la localization depuis la culture du PC si elle existe
            if (localizationToApply == null)
            {
                var currentPCTowLetterLang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
                var localizationFound = Services.LocalizationManager.LoadedLocalizations.FindLocalizationByTwoLetterLanguageName(currentPCTowLetterLang);
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
                Services.SettingsManager.TwoLetterISOLanguageName = localization.TwoLetterISOLanguageName;
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

        /// <summary>
        /// Permet de logguer un message
        /// </summary>
        private void Log(string message, MsgType msgType)
        {
            var msgColor = Color.Black;
            var fontStyle = FontStyle.Regular;

            //associe une couleur à un type de message
            switch (msgType)
            {
                case MsgType.ERROR:
                    {
                        message = Services.LocalizationManager.ActiveLocalization.Translate("ERROR : ") + message;
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
                        message = Services.LocalizationManager.ActiveLocalization.Translate("WARNING : ") + message;
                        msgColor = Color.Orange;
                        break;
                    }
                case MsgType.ACTION_START:
                    {

                        msgColor = Color.Green;
                        break;
                    }
                case MsgType.ACTION_END:
                    {
                        msgColor = Color.Green;
                        break;
                    }
            }

            Log(message, msgColor, fontStyle);
        }

        public delegate void DelegateLogAsync(string message, Color msgColor, FontStyle fontStyle);

        private void Log(string message, Color msgColor, FontStyle fontStyle)
        {
            //Test si l'appel du log est fait depuis un Thread
            if (this.InvokeRequired == true)
            {
                this.Invoke(new DelegateLogAsync(this.Log), message, msgColor, fontStyle);
                return;
            }

            //Vérifie qu'il y ait bien un message a affichers
            if (message == null)
            { return; }


            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length;
            _richTextBoxLog.SelectionFont = new Font(_richTextBoxLog.Font, fontStyle);
            _richTextBoxLog.SelectionColor = msgColor;

            _richTextBoxLog.AppendText(message + Environment.NewLine);
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
            { actionName = Services.LocalizationManager.ActiveLocalization.Translate("UNKNOWN ACTION"); }

            this.Log(actionName, MsgType.ACTION_START);
        }

        /// <summary>
        /// Permet d'indiquer que l'action s'est déroulée avec succès (sans exception)
        /// </summary>
        private void LogActionDoneSuccessfully()
        {
            this.Log(Services.LocalizationManager.ActiveLocalization.Translate("Done.") + Environment.NewLine, MsgType.ACTION_END);
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
                LogWarning(Services.LocalizationManager.ActiveLocalization.Translate("Please wait."));
            }
            else
            {
                var inputPath = _textBoxInputPath.Text;

                var jpegMetaTypesToRemove = JpegMetaTypes.NONE;
                if (_checkBoxRemoveMetadatas.Checked)
                {
                    jpegMetaTypesToRemove = Services.SettingsManager.MetaTypesToRemove;
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

            Log(">>> " + inputPath + " <<<" + Environment.NewLine, Color.Purple, FontStyle.Bold);

            var dateStart = DateTime.Now;

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
                var exMessage = Services.LocalizationManager.ActiveLocalization.Translate("Specified path \"{0}\" doesn't exist.", inputPath);
                throw new Exception(exMessage);
            }

            if (_backgroundWorkerPurify.CancellationPending)
            { return; }

            if (jpegFilesToPurify.Count <= 0)
            {
                LogWarning(Services.LocalizationManager.ActiveLocalization.Translate("No file to process."));
            }


            var maxProgression = jpegFilesToPurify.Count * 2;
            var currentProgression = 0.0;

            var updateProgression = new Action(delegate()
            {
                var pourcentageValue = (int)Math.Round(++currentProgression / maxProgression * 100.0);
                _backgroundWorkerPurify.ReportProgress(pourcentageValue);
            });

            foreach (var inputJpegFilePath in jpegFilesToPurify)
            {
                if (_backgroundWorkerPurify.CancellationPending)
                {
                    LogWarning(Services.LocalizationManager.ActiveLocalization.Translate("Operation Cancelled..."));
                    return;
                }

                JPGExifRemover jpgExifRemover = null;
                FileStream outputFileStream = null;
                PurificationResult purificationResult = null;
                try
                {
                    this.LogActionAboutToBeDone(inputJpegFilePath);
                    jpgExifRemover = new JPGExifRemover(inputJpegFilePath);

                    purificationResult = jpgExifRemover.Purify(jpegMetaTypesToRemove, commentsAction);

                    updateProgression();

                    jpgExifRemover.Dispose();

                    LogInfo(Services.LocalizationManager.ActiveLocalization.Translate("{0} metadata(s) found ({1})", purificationResult.NbMetasFound.ToString(), purificationResult.MetaTypesFound.ToString()));
                    LogInfo(Services.LocalizationManager.ActiveLocalization.Translate("{0} metadata(s) removed ({1})", purificationResult.NbMetasRemoved.ToString(), purificationResult.MetaTypesRemoved.ToString()));
                    LogInfo(Services.LocalizationManager.ActiveLocalization.Translate("{0} comment(s) found", purificationResult.NbCommentsFound.ToString()));
                    LogInfo(Services.LocalizationManager.ActiveLocalization.Translate("{0} comment(s) removed", purificationResult.NbCommentsRemoved.ToString()));


                    if (purificationResult.ResultStreamDiffersFromOriginal)
                    {
                        if (overrideInputFile)
                        {
                            outputFileStream = new FileStream(inputJpegFilePath, FileMode.Create);
                            purificationResult.ResultStream.WriteTo(outputFileStream);
                            LogInfo(Services.LocalizationManager.ActiveLocalization.Translate("File overriden."));
                        }
                        else
                        {
                            var outputFilePath = GetFreeFilePath(inputJpegFilePath);
                            outputFileStream = new FileStream(outputFilePath, FileMode.Create);
                            purificationResult.ResultStream.WriteTo(outputFileStream);
                            LogInfo(Services.LocalizationManager.ActiveLocalization.Translate("File saved to \"{0}\".", Path.GetFileName(outputFilePath)));
                        }
                    }
                    else
                    {
                        LogInfo(Services.LocalizationManager.ActiveLocalization.Translate("No file written."));
                    }

                    updateProgression();

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
            }//End for each file

            var dateEnd = DateTime.Now;

            var ellapsedTime = dateEnd - dateStart;

            Log(Services.LocalizationManager.ActiveLocalization.Translate("Total : {0} file(s) in {1} (s)", jpegFilesToPurify.Count.ToString(), ellapsedTime.TotalSeconds.ToString()) + Environment.NewLine, Color.Purple, FontStyle.Bold);

        }

        private void _backgroundWorkerPurify_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            { this.LogException(e.Error); }

            _progressBar.Value = _progressBar.Maximum;

            Thread.Sleep(300);

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
                    Title = Services.LocalizationManager.ActiveLocalization.Translate("Select an image"),
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
            _formSettings.ShowDialog(this);
        }

        private void _checkBoxIncludeSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            Services.SettingsManager.IncludeSubdirectories = _checkBoxIncludeSubdirectories.Checked;
        }

        private void _checkBoxOverride_CheckedChanged(object sender, EventArgs e)
        {
            Services.SettingsManager.OverrideOriginalFile = _checkBoxOverride.Checked;
        }

        private void _checkBoxRemoveMetadatas_CheckedChanged(object sender, EventArgs e)
        {
            Services.SettingsManager.RemoveMetadatas = _checkBoxRemoveMetadatas.Checked;
        }

        private void _checkBoxRemoveComments_CheckedChanged(object sender, EventArgs e)
        {
            Services.SettingsManager.RemoveComments = _checkBoxRemoveComments.Checked;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _richTextBoxLog.Clear();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _richTextBoxLog.Copy();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Services.SettingsManager.LastInputPath = _textBoxInputPath.Text;
        }

        private void _aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formAbout.ShowDialog(this);
        }

    }
}
