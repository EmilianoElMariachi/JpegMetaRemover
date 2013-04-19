using System;
using System.Drawing;

namespace ImgComp.ImageProcessing
{
    public class ImageComparer
    {
        public Bitmap ReferenceImage { get; set; }
        public Bitmap ComparedImage { get; set; }

        public ImageComparer(Bitmap referenceBitmap, Bitmap comparedBitmap)
        {
            ReferenceImage = referenceBitmap;
            ComparedImage = comparedBitmap;
        }

        public ImageComparisonResult Compare(double maxAcceptableColorDelta, double minPourcentageOfAcceptedPixels, bool ignoreTransparentPixels)
        {

            var xVariance = Math.Abs(ComparedImage.Width - ReferenceImage.Width);
            var yVariance = Math.Abs(ComparedImage.Height - ReferenceImage.Height);

            var bestComparisonResult = new ImageComparisonResult()
                {
                    BestMatchOffsetPoint = new Point(-1, -1),
                    PourcentageOfAcceptedPixelsAtBestMatchOffset = -1,
                    SpecifiedMaxAcceptableColorDelta = maxAcceptableColorDelta,
                    SpecifiedMinPourcentageOfAcceptedPixels = minPourcentageOfAcceptedPixels,
                    ComparedImage = (Bitmap)this.ComparedImage.Clone(),
                    ReferenceImage = (Bitmap)ReferenceImage.Clone(),
                    NumberOfPossiblePositions = Math.Max((this.ComparedImage.Width - this.ReferenceImage.Width) * (this.ComparedImage.Height - this.ReferenceImage.Height), 0)
                };

            for (var startX = 0; startX <= xVariance; startX++)
            {
                for (var startY = 0; startY <= yVariance; startY++)
                {
                    var startPoint = new Point(startX, startY);
                    double pourcentageOfAcceptedPixels;
                    Bitmap resultImage;

                    CompareImagesStartingAt(ReferenceImage, ComparedImage, startPoint, maxAcceptableColorDelta, ignoreTransparentPixels, out pourcentageOfAcceptedPixels, out resultImage);

                    if (pourcentageOfAcceptedPixels >= bestComparisonResult.PourcentageOfAcceptedPixelsAtBestMatchOffset)
                    {
                        bestComparisonResult.BestMatchOffsetPoint = startPoint;
                        bestComparisonResult.PourcentageOfAcceptedPixelsAtBestMatchOffset = pourcentageOfAcceptedPixels;

                        if (bestComparisonResult.ResultImage != null)
                        { bestComparisonResult.ResultImage.Dispose(); }

                        bestComparisonResult.ResultImage = resultImage;

                        if (bestComparisonResult.IsImageAccepted)
                        { bestComparisonResult.NumberOfAcceptedPosition++; }
                    }
                }
            }

            return bestComparisonResult;
        }

        /// <summary>
        /// Compare l'image à comparer à l'image de référence
        /// 
        /// et retourne le pourcentage des pixels acceptés pour la tolérance fournie 
        /// </summary>
        /// <param name="refImage"></param>
        /// <param name="comparedImage"></param>
        /// <param name="startOffetInComparedImage"></param>
        /// <param name="colorTolerance"></param>
        /// <returns></returns>
        private static void CompareImagesStartingAt(Bitmap refImage, Bitmap comparedImage, Point startOffetInComparedImage, double colorTolerance, bool ignoreTransparentPixels, out double pourcentageOfAcceptedPixels, out Bitmap resultImage)
        {
            var acceptedPixels = 0;

            var numberOfPossibleWidth = Math.Min(refImage.Width, comparedImage.Width - startOffetInComparedImage.X);
            var numberOfPossibleHeight = Math.Min(refImage.Height, comparedImage.Height - startOffetInComparedImage.Y);

            resultImage = new Bitmap(numberOfPossibleWidth, numberOfPossibleHeight);

            var numOfRefPixelsIgnored = 0;

            for (var x = 0; x < numberOfPossibleWidth; x++)
            {

                for (var y = 0; y < numberOfPossibleHeight; y++)
                {
                    var refImagePixelColor = refImage.GetPixel(x, y);
                    var cmpImagePixelColor = comparedImage.GetPixel(x + startOffetInComparedImage.X, y + startOffetInComparedImage.Y);

                    if (ignoreTransparentPixels && refImagePixelColor.A < byte.MaxValue)
                    {
                        numOfRefPixelsIgnored++;
                        continue;
                    }

                    if (IsPixelColorDeltaAcceptable(refImagePixelColor, cmpImagePixelColor, colorTolerance))
                    {
                        acceptedPixels++;
                        resultImage.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {
                        resultImage.SetPixel(x, y, Color.Red);
                    }
                }
            }

            var numPixelsRefImage = (refImage.Width * refImage.Height) - numOfRefPixelsIgnored;
            pourcentageOfAcceptedPixels = (double)acceptedPixels / (double)numPixelsRefImage;

        }

        /// <summary>
        /// Permet de savoir si le delta de couleur est acceptable pour la tolérance fournie
        /// </summary>
        /// <param name="colorA"></param>
        /// <param name="colorB"></param>
        /// <param name="colorDeltaTolerance"></param>
        /// <returns></returns>
        public static bool IsPixelColorDeltaAcceptable(Color colorA, Color colorB, double colorDeltaTolerance)
        {
            var pixelColorDelta = ComputePixelColorDelta(colorA, colorB);

            var isPixelColorDeltaAcceptable = pixelColorDelta <= colorDeltaTolerance;
            return isPixelColorDeltaAcceptable;
        }

        /// <summary>
        /// Retourne un nombre entre 0 inclu et 1 inclu.
        /// 0: aucune différence
        /// 1: différence maximale
        /// </summary>
        /// <param name="colorA"></param>
        /// <param name="colorB"></param>
        /// <returns></returns>
        private static double ComputePixelColorDelta(Color colorA, Color colorB)
        {
            var sigmaColorDelta = Math.Abs(colorA.R - colorB.R) + Math.Abs(colorA.G - colorB.G) + Math.Abs(colorA.B - colorB.B);

            var colorDelta = (sigmaColorDelta / (double)(byte.MaxValue * 3));

            return colorDelta;
        }

        private static Color ComputePixelOverBlend(Color colorA, Color colorB)
        {

            var alphaA = (double)colorA.A / (double)byte.MaxValue;
            var alphaB = (double)colorB.A / (double)byte.MaxValue;

            var A = SaturateByteFromDouble(alphaA + alphaB * (1.0 - alphaA) * byte.MaxValue);
            var R = ComputeAlphaComponent(colorA.R, colorB.R, alphaA, alphaB);
            var G = ComputeAlphaComponent(colorA.G, colorB.G, alphaA, alphaB);
            var B = ComputeAlphaComponent(colorA.B, colorB.B, alphaA, alphaB);

            return Color.FromArgb(A, R, G, B);
        }

        private static byte ComputeAlphaComponent(byte componentA, byte componentB, double alphaA, double alphaB)
        {
            if (alphaA < 0.0 || alphaA > 1.0 || alphaB < 0.0 || alphaB > 1.0)
            { throw new Exception("Invalid argument"); }

            var doubleResult = componentA * alphaA + componentB * alphaB * (1.0 - alphaA);

            var byteResult = SaturateByteFromDouble(doubleResult);
            return byteResult;
        }

        private static byte SaturateByteFromDouble(double d)
        {
            if (d > 255.0)
            { return 255; }
            else if (d < 0.0)
            { return 0; }
            else
            { return (byte)Math.Round(d); }

        }

    }
}
