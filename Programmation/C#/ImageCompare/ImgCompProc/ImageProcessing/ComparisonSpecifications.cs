using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgCompProc.ImageProcessing
{
    /// <summary>
    /// Classe permettant de paramétrer les tolérances et les spécifications du comparateur d'images
    /// </summary>
    public class ComparisonSpecifications
    {

        /// <summary>
        /// Le delta max de couleur permettant d'accepter un pixel
        /// </summary>
        public double MaxAcceptableColorDelta { get; set; }

        /// <summary>
        /// Le pourcentage minimum de pixels devant être atteint pour accepter l'image
        /// </summary>
        public double MinPourcentageOfAcceptedPixels { get; set; }

        /// <summary>
        /// True pour ignorer les pixels transparents
        /// </summary>
        public bool IgnoreTransparentPixels { get; set; }

        /// <summary>
        /// Représente le nombre maximum acceptable de positions où l'image de référence a été acceptée dans l'image comparée 
        /// La valeur minimale est de 1
        /// </summary>
        public int MaxNumberOfAcceptedPositions { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ComparisonSpecifications()
        {
            MaxAcceptableColorDelta = 0.0;
            MinPourcentageOfAcceptedPixels = 1.0;
            MaxNumberOfAcceptedPositions = 1;
            IgnoreTransparentPixels = true;
        }

    }
}
