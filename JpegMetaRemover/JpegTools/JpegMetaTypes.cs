using System;

namespace JpegMetaRemover.JpegTools
{
    [Flags]
    public enum JpegMetaTypes
    {
        NONE = 0,                   

        JFIF = 1,                   //APP 0
        EXIF = 2,                   //APP 1
        ICC_PROFILE = 4,            //APP 2
        META = 8,                   //APP 3
        SCALADO = 16,               //APP 4
        RMETA = 32,                 //APP 5
        EPPIM = 64,                 //APP 6
        QUALCOMM = 128,             //APP 7
        SPIFF = 256,                //APP 8
        UNKNOWN_1 = 512,            //APP 9
        PHOTOSTUDIO = 1024,         //APP10
        UNKNOWN_2 = 2048,           //APP11
        PICTURE_INFO = 8192,        //APP12
        PHOTOSHOP = 16384,          //APP13
        ADOBE = 32768,              //APP14
        GRAPHICCONVERTER = 65536,   //APP15
    }
}