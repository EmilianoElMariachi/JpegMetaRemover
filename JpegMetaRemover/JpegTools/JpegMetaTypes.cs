using System;

namespace JpegMetaRemover.JpegTools
{
    /// <summary>
    /// https://exiftool.org/TagNames/JPEG.html
    /// </summary>
    [Flags]
    public enum JpegMetaTypes
    {
        NONE=0,

        /// <summary>
        /// JFIF
        /// JFXX
        /// CIFF
        /// AVI1
        /// Ocad
        /// </summary>
        APP0,

        /// <summary>
        /// EXIF
        /// ExtendedXMP
        /// XMP
        /// QVCI
        /// FLIR
        /// RawThermalImage
        /// </summary>
        APP1,
        /// <summary>
        /// ICC_Profile
        /// FPXR
        /// MPF
        /// PreviewImage
        /// </summary>
        APP2,
        /// <summary>
        /// Meta
        /// Stim
        /// JPS
        /// ThermalData
        /// PreviewImage
        /// </summary>
        APP3,
        /// <summary>
        /// Scalado
        /// FPXR
        /// ThermalParams
        /// PreviewImage
        /// </summary>
        APP4,
        /// <summary>
        /// RMETA
        /// SamsungUniqueID
        /// ThermalCalibration
        /// PreviewImage
        /// </summary>
        APP5,
        /// <summary>
        /// EPPIM
        /// NITF
        /// HP_TDHD
        /// GoPro
        /// DJI_DTAT
        /// </summary>
        APP6,
        /// <summary>
        /// Pentax
        /// Huawei
        /// Qualcomm
        /// </summary>
        APP7,
        /// <summary>
        /// SPIFF
        /// </summary>
        APP8,
        /// <summary>
        /// MediaJukebox
        /// </summary>
        APP9,
        /// <summary>
        /// Comment
        /// </summary>
        APP10,
        /// <summary>
        /// JPEG-HDR
        /// JUMBF
        /// </summary>
        APP11,
        /// <summary>
        /// PictureInfo
        /// Ducky
        /// </summary>
        APP12,
        /// <summary>
        /// Photoshop
        /// Adobe_CM
        /// </summary>
        APP13,
        /// <summary>
        /// Adobe
        /// </summary>
        APP14,
        /// <summary>
        /// GraphicConverter
        /// </summary>
        APP15,
    }
}