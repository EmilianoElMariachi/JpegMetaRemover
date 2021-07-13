namespace JpegMetaRemover.JpegTools
{
    public class MarkerSection
    {
        /// <summary>
        /// Le type de marqueur
        /// </summary>
        public MarkerType Type { get; set; }

        /// <summary>
        /// La valeur du marqueur (octet qui suit l'octet 0xFF)
        /// </summary>
        public byte MarkerValue => RawData[1];

        /// <summary>
        /// Contient l'ensemble des données du marqueur.
        /// Ce tableau contient dans l'ordre:
        ///     - Les deux octets du marqueur
        ///     - Les deux octets représentant la taille du payload (uniquement pour les marqueurs supportant un payload)
        ///     - Les octets du payload
        ///     - Les données entropiques (uniquement pour les marqueurs supportant des données entropiques)
        /// 
        /// </summary>
        public byte[] RawData { get; set; }

        public override string ToString()
        {
            return $"{Type} (Marker value={MarkerValue:X2})";
        }
    }
}