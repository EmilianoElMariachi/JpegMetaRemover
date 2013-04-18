using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImgComp
{
    public partial class FormResult : Form
    {
        private List<DisplayedBitmap> _images = new List<DisplayedBitmap>();
        public List<DisplayedBitmap> ImagesToDisplay
        {
            get { return _images; }
        }

        public FormResult()
        {
            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            using (var g = e.Graphics)
            {
                //set background color
                g.Clear(Color.White);

                foreach (DisplayedBitmap positionnedBitmap in ImagesToDisplay)
                {
                    g.DrawImage(positionnedBitmap.Image, new Rectangle(positionnedBitmap.Location, positionnedBitmap.Image.Size));
                }
            }


        }
    }
}
