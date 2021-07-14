using System;

namespace JpegMetaRemover.JpegTools
{
    /// <summary>
    /// https://exiftool.org/TagNames/JPEG.html
    /// </summary>
    [Flags]
    public enum JpegMetaTypes
    {
        /// <summary>
        /// Aucun flag
        /// </summary>
        NONE = 0x00,
        /// <summary>
        /// JFIF
        /// JFXX
        /// CIFF
        /// AVI1
        /// Ocad
        /// </summary>
        APP0 = 0x01,
        /// <summary>
        /// EXIF
        /// ExtendedXMP
        /// XMP
        /// QVCI
        /// FLIR
        /// RawThermalImage
        /// </summary>
        APP1 = 0x02,
        /// <summary>
        /// ICC_Profile
        /// FPXR
        /// MPF
        /// PreviewImage
        /// </summary>
        APP2 = 0x04,
        /// <summary>
        /// Meta
        /// Stim
        /// JPS
        /// ThermalData
        /// PreviewImage
        /// </summary>
        APP3 = 0x08,
        /// <summary>
        /// Scalado
        /// FPXR
        /// ThermalParams
        /// PreviewImage
        /// </summary>
        APP4 = 0x10,
        /// <summary>
        /// RMETA
        /// SamsungUniqueID
        /// ThermalCalibration
        /// PreviewImage
        /// </summary>
        APP5 = 0x20,
        /// <summary>
        /// EPPIM
        /// NITF
        /// HP_TDHD
        /// GoPro
        /// DJI_DTAT
        /// </summary>
        APP6 = 0x40,
        /// <summary>
        /// Pentax
        /// Huawei
        /// Qualcomm
        /// </summary>
        APP7 = 0x80,
        /// <summary>
        /// SPIFF
        /// </summary>
        APP8 = 0x100,
        /// <summary>
        /// MediaJukebox
        /// </summary>
        APP9 = 0x200,
        /// <summary>
        /// Comment
        /// </summary>
        APP10 = 0x400,
        /// <summary>
        /// JPEG-HDR
        /// JUMBF
        /// </summary>
        APP11 = 0x800,
        /// <summary>
        /// PictureInfo
        /// Ducky
        /// </summary>
        APP12 = 0x1000,
        /// <summary>
        /// Photoshop
        /// Adobe_CM
        /// </summary>
        APP13 = 0x2000,
        /// <summary>
        /// Adobe
        /// </summary>
        APP14 = 0x4000,
        /// <summary>
        /// GraphicConverter
        /// </summary>
        APP15 = 0x8000,
    }
}