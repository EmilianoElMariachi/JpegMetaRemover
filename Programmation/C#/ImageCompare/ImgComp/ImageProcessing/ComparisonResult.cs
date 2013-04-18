using System.Drawing;

namespace ImgComp.ImageProcessing
{
    public class ImageComparisonResult
    {

        /// <summary>
        /// L'image de référence
        /// </summary>
        public Bitmap ReferenceImage { get; internal set; }

        /// <summary>
        /// L'image ayant été comparée
        /// </summary>
        public Bitmap ComparedImage { get; internal set; }

        /// <summary>
        /// L'image matérialisant la cartographie des points acceptés
        /// </summary>
        public Bitmap ResultImage { get; internal set; }

        /// <summary>
        /// Représente l'offset ou l'image de référence à le mieux correspondu dans l'image à comparer
        /// </summary>
        public Point BestMatchOffsetPoint { get; internal set; }

        /// <summary>
        /// Nombre de fois ou l'image de référence à été offsettée et acceptée dans l'image à comparer
        /// </summary>
        public int NumberOfAcceptedPosition { get; internal set; }

        /// <summary>
        /// Représente le nombre potentiel d'emplacements de l'image de référence dans l'image à comparer 
        /// </summary>
        public int NumberOfPossiblePositions { get; internal set; }

        /// <summary>
        /// Représente le pourcentage de pixels acceptés, selon la tolérance de couleur spécifiée
        /// </summary>
        public double PourcentageOfAcceptedPixelsAtBestMatchOffset { get; internal set; }

        /// <summary>
        /// Représente le pourcentage de pixels acceptés, selon la tolérance de couleur spécifiée
        /// </summary>
        public double SpecifiedMinPourcentageOfAcceptedPixels { get; internal set; }

        /// <summary>
        /// Tolérance de delta de couleur spécifié pour accepter un pixel
        /// </summary>
        public double SpecifiedMaxAcceptableColorDelta { get; internal set; }

        /// <summary>
        /// Indique si l'image a été acceptée selon les tolérances spécifiées
        /// </summary>
        public bool IsImageAccepted
        {
            get { return this.PourcentageOfAcceptedPixelsAtBestMatchOffset >= this.SpecifiedMinPourcentageOfAcceptedPixels; }
        }

    }
}
