using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using JpegMetaRemover.JpegTools;
using JpegMetaRemover.Log;
using JpegMetaRemover.OtherForms;
using JpegMetaRemover.Properties;
using JpegMetaRemover.ServicesProvider;
using System.Threading;
using JpegMetaRemover.ServicesProvider.LocalizationService;

namespace JpegMetaRemover
{
    public partial class FormMain : Form
    {

        private LocalizableControlWrapperCollection LocalizableControls { get; }


        private readonly FormSettings _formSettings = new FormSettings();

        private readonly FormAbout _formAbout = new FormAbout();

        public FormMain()
        {

            InitializeComponent();

            Logger.OnLog += (sender, message, type) => { this.Log(message, type); };

            LocalizableControls = new LocalizableControlWrapperCollection();

            InitializeLanguages();

            _checkBoxIncludeSubdirectories.Checked = Services.SettingsManager.IncludeSubdirectories;

            _checkBoxOverride.Checked = Services.SettingsManager.OverrideOriginalFile;

            _checkBoxRemoveMetadata.Checked = Services.SettingsManager.RemoveMetadata;

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
                item.Click += Item_Click;
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
                var currentComputerTowLetterLang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
                var localizationFound = Services.LocalizationManager.LoadedLocalizations.FindLocalizationByTwoLetterLanguageName(currentComputerTowLetterLang);
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

        private void Item_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem clickedMenuItem)
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

            if (_richTextBoxLog.Text.Length == 0 && message.StartsWith(Environment.NewLine))
            {
                message = message.TrimStart(Environment.NewLine.ToCharArray());
            }

            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length;
            _richTextBoxLog.SelectionFont = new Font(_richTextBoxLog.Font, fontStyle);
            _richTextBoxLog.SelectionColor = msgColor;

            _richTextBoxLog.AppendText(message);
            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length;
            _richTextBoxLog.SelectionLength = 0;
            _richTextBoxLog.ScrollToCaret();
        }

        private static string GetFreeFilePath(string filePath)
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
                if (!_backgroundWorkerPurify.CancellationPending)
                {
                    _backgroundWorkerPurify.CancelAsync();
                }
            }
            else
            {
                _buttonRun.BackgroundImage = Resources.Stop;

                var inputPath = _textBoxInputPath.Text;

                var jpegMetaTypesToRemove = _checkBoxRemoveMetadata.Checked ? Services.SettingsManager.MetaTypesToRemove : JpegMetaTypes.NONE;

                var removeComments = _checkBoxRemoveComments.Checked;
                var overrideInputFile = _checkBoxOverride.Checked;
                var includeSubDirectories = _checkBoxIncludeSubdirectories.Checked;

                _backgroundWorkerPurify.RunWorkerAsync(new object[] { inputPath, jpegMetaTypesToRemove, removeComments, overrideInputFile, includeSubDirectories });
            }
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurifyJpegFile();
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            PurifyJpegFile();
        }

        private void BackgroundWorkerPurify_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var args = e.Argument as object[];

            var inputPath = args[0] as string;
            var jpegMetaTypesToRemove = (JpegMetaTypes)args[1];
            var removeComments = (bool)args[2];
            var overrideInputFile = (bool)args[3];
            var includeSubdirectories = (bool)args[4];

            Log(Environment.NewLine + ">>> " + inputPath + " <<<" + Environment.NewLine, Color.Purple, FontStyle.Bold);

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
                return;

            if (jpegFilesToPurify.Count <= 0)
            {
                Logger.LogLineWarning(this, Services.LocalizationManager.ActiveLocalization.Translate("No file to process."));
            }


            var maxProgression = jpegFilesToPurify.Count * 2;
            var currentProgression = 0.0;

            var updateProgression = new Action(delegate
            {
                var percentProgress = (int)Math.Round(++currentProgression / maxProgression * 100.0);
                _backgroundWorkerPurify.ReportProgress(percentProgress);
            });

            foreach (var inputJpegFilePath in jpegFilesToPurify)
            {
                if (_backgroundWorkerPurify.CancellationPending)
                {
                    Logger.LogLineWarning(this, Services.LocalizationManager.ActiveLocalization.Translate("Operation Cancelled..."));
                    return;
                }

                try
                {
                    Logger.LogLineActionStart(this, inputJpegFilePath);


                    using var fileStream = File.OpenRead(inputJpegFilePath);

                    using var outputStream = new MemoryStream();
                    var purificationResult = JpegMetadataRemover.Remove(fileStream, outputStream, jpegMetaTypesToRemove, removeComments);

                    updateProgression();


                    Logger.LogLineInfo(this, Services.LocalizationManager.ActiveLocalization.Translate("{0} metadata(s) found ({1})", purificationResult.NbMetasFound.ToString(), purificationResult.MetaTypesFound.ToString()));
                    Logger.LogLineInfo(this, Services.LocalizationManager.ActiveLocalization.Translate("{0} metadata(s) removed ({1})", purificationResult.NbMetasRemoved.ToString(), purificationResult.MetaTypesRemoved.ToString()));
                    Logger.LogLineInfo(this, Services.LocalizationManager.ActiveLocalization.Translate("{0} comment(s) found", purificationResult.NbCommentsFound.ToString()));
                    Logger.LogLineInfo(this, Services.LocalizationManager.ActiveLocalization.Translate("{0} comment(s) removed", purificationResult.NbCommentsRemoved.ToString()));


                    if (purificationResult.ResultStreamDiffersFromOriginal)
                    {

                        string outputFilePath;
                        string logMessage;
                        if (overrideInputFile)
                        {
                            outputFilePath = inputJpegFilePath;
                            logMessage = Services.LocalizationManager.ActiveLocalization.Translate("File overriden.");
                        }
                        else
                        {
                            outputFilePath = GetFreeFilePath(inputJpegFilePath);
                            logMessage = Services.LocalizationManager.ActiveLocalization.Translate("File saved to \"{0}\".", Path.GetFileName(outputFilePath));
                        }

                        using var outputFileStream = File.Create(outputFilePath);
                        outputStream.Position = 0;
                        outputStream.WriteTo(outputFileStream);

                        Logger.LogLineInfo(this, logMessage);

                    }
                    else
                    {
                        Logger.LogLineInfo(this, Services.LocalizationManager.ActiveLocalization.Translate("No file written."));
                    }

                    updateProgression();

                    Logger.LogLineActionEnd(this, Services.LocalizationManager.ActiveLocalization.Translate("Done."));

                }
                catch (Exception ex)
                {
                    Logger.LogLineException(this, ex);
                }

            }//End for each file

            var dateEnd = DateTime.Now;

            var ellapsedTime = dateEnd - dateStart;

            Log(Services.LocalizationManager.ActiveLocalization.Translate("Total : {0} file(s) in {1} (s)", jpegFilesToPurify.Count.ToString(), ellapsedTime.TotalSeconds.ToString()), Color.Purple, FontStyle.Bold);

        }

        private void BackgroundWorkerPurify_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            { Logger.LogLineException(this, e.Error); }

            _progressBar.Value = _progressBar.Maximum;

            Thread.Sleep(300);

            _progressBar.Value = _progressBar.Minimum;

            _buttonRun.BackgroundImage = Resources.Play;
        }

        private void BackgroundWorkerPurify_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            _progressBar.Value = e.ProgressPercentage;

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
                // ignored
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
                    if (Services.SettingsManager.CleanOnDragAndDrop)
                    {
                        PurifyJpegFile();
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private void SelectFileToolStripMenuItem_Click(object sender, EventArgs e)
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
                // ignored
            }
        }

        private void SelectDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
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
                // ignored
            }
        }

        private void ButtonBrowseImageFile_Click(object sender, EventArgs e)
        {
            BrowseImageFile();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formSettings.ShowDialog(this);
        }

        private void CheckBoxIncludeSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            Services.SettingsManager.IncludeSubdirectories = _checkBoxIncludeSubdirectories.Checked;
        }

        private void CheckBoxOverride_CheckedChanged(object sender, EventArgs e)
        {
            Services.SettingsManager.OverrideOriginalFile = _checkBoxOverride.Checked;
        }

        private void CheckBoxRemoveMetadata_CheckedChanged(object sender, EventArgs e)
        {
            Services.SettingsManager.RemoveMetadata = _checkBoxRemoveMetadata.Checked;
        }

        private void CheckBoxRemoveComments_CheckedChanged(object sender, EventArgs e)
        {
            Services.SettingsManager.RemoveComments = _checkBoxRemoveComments.Checked;
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _richTextBoxLog.Clear();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _richTextBoxLog.Copy();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Services.SettingsManager.LastInputPath = _textBoxInputPath.Text;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formAbout.ShowDialog(this);
        }

    }
}
