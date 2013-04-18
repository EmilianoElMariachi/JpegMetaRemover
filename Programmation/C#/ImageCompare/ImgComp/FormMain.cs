using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenericLogger;
using ImgComp.ImageProcessing;

namespace ImgComp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            UpdateTextBoxColorToleranceFromTrackBar();

            UpdatePourcentageOfAcceptablePixelsFromTrackBar();

            UpdateColorComparisonTest();
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
                        message = "> " + message;
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
                        message = "> " + message;
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
            { actionName = "UNKNOWN ACTION"; }

            this.Log(actionName, MsgType.ACTION_START);
        }

        /// <summary>
        /// Permet d'indiquer que l'action s'est déroulée avec succès (sans exception)
        /// </summary>
        private void LogActionDoneSuccessfully()
        {
            this.Log("Done." + Environment.NewLine, MsgType.ACTION_END);
        }

        private void _compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareImages();
        }

        private double GetPixelColorTolerance()
        {
            var text = _textBoxColorTolerancePerPixel.Text;
            try
            {
                var tolerance = double.Parse(text.Replace(",", "."), CultureInfo.InvariantCulture);
                return tolerance;
            }
            catch
            {
                throw new Exception("Invalid tolerance \"" + text + "\" specified");
            }
        }

        private bool _canUpdate = true;
        private void _trackBarColorTolerance_Scroll(object sender, EventArgs e)
        {
            UpdateTextBoxColorToleranceFromTrackBar();
        }

        private void UpdateTextBoxColorToleranceFromTrackBar()
        {
            _canUpdate = false;
            _textBoxColorTolerancePerPixel.Text =
                ((double)_trackBarColorTolerance.Value /
                 (double)(_trackBarColorTolerance.Maximum - _trackBarColorTolerance.Minimum)).ToString("0.00");
            _canUpdate = true;
        }

        private void _textBoxColorTolerancePerPixel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_canUpdate)
                { _trackBarColorTolerance.Value = (int)Math.Round(GetPixelColorTolerance() * 100); }

                UpdateColorComparisonTest();
            }
            catch
            { }
        }

        private void _buttonCompare_Click(object sender, EventArgs e)
        {
            CompareImages();
        }

        private void UpdatePourcentageOfAcceptablePixelsFromTrackBar()
        {
            _canUpdate = false;
            _textBoxPourcentageOfAcceptablePixels.Text =
                ((double)_trackBarPourcentageOfAcceptablePixels.Value /
                 (double)(_trackBarPourcentageOfAcceptablePixels.Maximum - _trackBarPourcentageOfAcceptablePixels.Minimum)).ToString("0.00");
            _canUpdate = true;
        }

        private void _trackBarPourcentageOfAcceptablePixels_Scroll(object sender, EventArgs e)
        {
            UpdatePourcentageOfAcceptablePixelsFromTrackBar();
        }

        private void _textBoxPourcentageOfAcceptablePixels_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_canUpdate)
                { _trackBarPourcentageOfAcceptablePixels.Value = (int)Math.Round(GetPixelColorTolerance() * 100); }
            }
            catch
            { }
        }

        private double GetPourcentageOfAcceptablePixels()
        {
            var text = _textBoxPourcentageOfAcceptablePixels.Text;
            try
            {
                var tolerance = double.Parse(text.Replace(",", "."), CultureInfo.InvariantCulture);
                return tolerance;
            }
            catch
            {
                throw new Exception("Invalid tolerance of acceptable pixels \"" + text + "\" specified");
            }
        }


        private void CompareImages()
        {
            if (_backgroundWorkerCompareImages.IsBusy)
            {
                LogWarning("Please wait");
            }
            else
            {
                try
                {
                    var referenceImagePath = _textBoxRefImage.Text;
                    var comparedImagePath = _textBoxComparedImage.Text;
                    var pixelColorTolerance = GetPixelColorTolerance();
                    var pourcentageOfAcceptablePixels = GetPourcentageOfAcceptablePixels();
                    _backgroundWorkerCompareImages.RunWorkerAsync(new object[] { referenceImagePath, comparedImagePath, pixelColorTolerance, pourcentageOfAcceptablePixels });
                }
                catch (Exception ex)
                {

                    LogException(ex);
                }
            }
        }

        private void _backgroundWorkerCompareImages_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap referenceImage = null;
            Bitmap comparedImage = null;

            try
            {


                var args = e.Argument as object[];

                var referenceImagePath = (string)args[0];
                var comparedImagePath = (string)args[1];
                var pixelColorTolerance = (double)args[2];
                var pourcentageOfAcceptablePixels = (double)args[3];

                referenceImage = Image.FromFile(referenceImagePath) as Bitmap;
                comparedImage = Image.FromFile(comparedImagePath) as Bitmap;

                LogActionAboutToBeDone("Comparing \"" + referenceImagePath + "\" with \"" + comparedImagePath +
                                       "\". Please wait");

                var imageComparer = new ImageComparer((Bitmap)referenceImage.Clone(), (Bitmap)comparedImage.Clone());

                e.Result = imageComparer.Compare(pixelColorTolerance, pourcentageOfAcceptablePixels);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
            finally
            {
                try
                { referenceImage.Dispose(); }
                catch
                { }

                try
                { comparedImage.Dispose(); }
                catch
                { }

            }


        }

        private void _backgroundWorkerCompareImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogException(e.Error);
            }
            else
            {
                var imageComparisonResult = e.Result as ImageComparisonResult;

                var percentageResult = "(" + imageComparisonResult.PourcentageOfAcceptedPixelsAtBestMatchOffset + "/" + imageComparisonResult.SpecifiedMinPourcentageOfAcceptedPixels + ")";

                if (imageComparisonResult.IsImageAccepted)
                {
                    LogInfo("Image accepted " + percentageResult);
                }
                else
                {
                    LogWarning("Image rejected " + percentageResult);
                }

                LogInfo("Best match at : " + imageComparisonResult.BestMatchOffsetPoint);
                LogInfo("Number of accepted positions : " + imageComparisonResult.NumberOfAcceptedPosition + "/" + imageComparisonResult.NumberOfPossiblePositions);
                LogInfo("Max Acceptable Color Delta : " + imageComparisonResult.SpecifiedMaxAcceptableColorDelta);

                var formResult = new FormResult();

                formResult.ImagesToDisplay.Add(new DisplayedBitmap()
                {
                    Image = imageComparisonResult.ComparedImage,
                    Location = new Point(0, 0)
                });


                formResult.ImagesToDisplay.Add(new DisplayedBitmap()
                {
                    Image = imageComparisonResult.ReferenceImage,
                    Location = imageComparisonResult.BestMatchOffsetPoint
                });

                formResult.ImagesToDisplay.Add(new DisplayedBitmap()
                {
                    Image = imageComparisonResult.ResultImage,
                    Location = imageComparisonResult.BestMatchOffsetPoint
                });

                formResult.Show();


                LogActionDoneSuccessfully();
            }

        }

        private void OnTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }

        }

        private void OnTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (droppedFiles.Length == 1)
                {
                    ((Control)sender).Text = droppedFiles[0];
                }
            }
            catch
            { }
        }

        private void OnLabelBackgroundColor_Click(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                _colorDialog.Color = label.BackColor;
                if (_colorDialog.ShowDialog() == DialogResult.OK)
                {
                    label.BackColor = _colorDialog.Color;
                }

                UpdateColorComparisonTest();
            }
        }

        private void UpdateColorComparisonTest()
        {
            try
            {
                if (ImageComparer.IsPixelColorDeltaAcceptable(_labelColor1.BackColor, _labelColor2.BackColor,
                                                              GetPixelColorTolerance()))
                {
                    _flowLayoutPanelColorCompare.BackColor = Color.Green;
                }
                else
                {
                    _flowLayoutPanelColorCompare.BackColor = Color.Orange;
                }
            }
            catch (Exception)
            {
                _flowLayoutPanelColorCompare.BackColor = Color.Red;
            }

        }
    }
}
