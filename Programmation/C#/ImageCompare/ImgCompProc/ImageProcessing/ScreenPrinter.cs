using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace ImgCompProc.ImageProcessing
{
    /// <summary>
    /// Classe fournissant des méthodes permettant de capturer des zones de l'écran
    /// </summary>
    public static class ScreenPrinter
    {

        /// <summary>
        /// Permet de créer une capture d'écran à partir des coordonnées spécifiées
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap Print(int x, int y, int width, int height)
        {
            return Print(new Rectangle(x, y, width, height));
        }

        /// <summary>
        /// Permet de créer une capture d'écran à partir du rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static Bitmap Print(Rectangle rectangle)
        {
            var screenImage = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);

            using (var graphics = Graphics.FromImage(screenImage))
            {
                graphics.CopyFromScreen(rectangle.Location, new Point(0, 0), rectangle.Size, CopyPixelOperation.SourceCopy);
            }

            return screenImage;
        }

    }
}
