using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImgCompProc.ImageProcessing;

namespace ImgComp
{
    public partial class FormScreenPrinter : Form
    {
        public FormScreenPrinter()
        {
            InitializeComponent();
        }

        private void _buttonPrint_Click(object sender, EventArgs e)
        {
            CaptureImage();
        }

        private void SetStatus(string status)
        {
            _toolStripStatusLabel.Text = status;
        }

        private Rectangle GetEditedRectangle()
        {
            try
            {
                return new Rectangle(int.Parse(_textBoxX.Text), int.Parse(_textBoxY.Text), int.Parse(_textBoxWidth.Text),
                                     int.Parse(_textBoxHeight.Text));
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid coordinate", ex);
            }
        }

        private void CaptureImage()
        {
            try
            {
                var printedScreen = ScreenPrinter.Print(GetEditedRectangle());
                printedScreen.Save(_textBoxDestination.Text);

                _pictureBoxResult.Image = printedScreen;
                _pictureBoxResult.Size = printedScreen.Size;

            }
            catch (Exception ex)
            {
                SetStatus(ex.Message);
            }
        }
    }
}
