using System.Drawing;

namespace ImgCompProc.ImageProcessing
{

    /// <summary>
    /// Classe contenant les informations résultants d'une comparaison d'images
    /// </summary>
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
        /// Rappel de la spécification ayant permi d'obtenir ce résultat
        /// </summary>
        public ComparisonSpecifications SpecificationsUsed { get; internal set; }

        /// <summary>
        /// Indique si l'image a été acceptée selon les tolérances spécifiées
        /// </summary>
        public bool IsImageAccepted
        {
            get
            {
                var isNbPositionsAccepted = NumberOfAcceptedPosition <=
                                          this.SpecificationsUsed.MaxNumberOfAcceptedPositions && NumberOfAcceptedPosition >= 1;

                var isToleranceAccepted = this.PourcentageOfAcceptedPixelsAtBestMatchOffset >=
                                           this.SpecificationsUsed.MinPourcentageOfAcceptedPixels;

                return isNbPositionsAccepted && isToleranceAccepted;
            }
        }

    }
}
