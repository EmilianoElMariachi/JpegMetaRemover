using System;
using System.IO;
using JpegMetaRemover.JpegTools;

namespace JpegMetaRemover
{
    internal class JpegMetadataRemover
    {
        public static PurificationResult Remove(FileStream inputStream, MemoryStream outputStream, JpegMetaTypes jpegMetaTypesToRemove, bool removeComments)
        {
            var result = new PurificationResult
            {
                NbMetasFound = 0,
                MetaTypesFound = JpegMetaTypes.NONE,
                MetaTypesRemoved = JpegMetaTypes.NONE,
                MetaTypesToRemove = jpegMetaTypesToRemove,
                NbCommentsFound = 0,
                NbCommentsRemoved = 0,
                NbMetasRemoved = 0,
                ResultStreamDiffersFromOriginal = false,
            };


            var markerSections = JpegMarkerSectionsReader.Read(inputStream);
            foreach (var markerSection in markerSections)
            {
                var recopySection = true;
                switch (markerSection.Type)
                {
                    case MarkerType.COM:
                        result.NbCommentsFound++;

                        if (removeComments)
                        {
                            result.NbCommentsRemoved++;
                            recopySection = false;
                        }

                        break;
                    case MarkerType.APP_N:
                        result.NbMetasFound++;

                        var jpegMetaType = AppNToMetaType(markerSection.MarkerValue);
                        result.MetaTypesFound |= jpegMetaType;

                        if (jpegMetaTypesToRemove.HasFlag(jpegMetaType))
                        {
                            result.MetaTypesRemoved |= jpegMetaType;
                            result.NbMetasRemoved++;
                            recopySection = false;
                        }

                        break;
                }

                if (recopySection)
                {
                    //Recopie la section dans le flux de sortie
                    outputStream.Write(markerSection.RawData, 0, markerSection.RawData.Length);
                }
                else
                {
                    result.ResultStreamDiffersFromOriginal = true;
                }
            }

            return result;
        }

        private static JpegMetaTypes AppNToMetaType(byte markerValue)
        {
            var appNValue = markerValue - 0xE0;

            switch (appNValue)
            {
                case 0:
                    return JpegMetaTypes.APP0;
                case 1:
                    return JpegMetaTypes.APP1;
                case 2:
                    return JpegMetaTypes.APP2;
                case 3:
                    return JpegMetaTypes.APP3;
                case 4:
                    return JpegMetaTypes.APP4;
                case 5:
                    return JpegMetaTypes.APP5;
                case 6:
                    return JpegMetaTypes.APP6;
                case 7:
                    return JpegMetaTypes.APP7;
                case 8:
                    return JpegMetaTypes.APP8;
                case 9:
                    return JpegMetaTypes.APP9;
                case 10:
                    return JpegMetaTypes.APP10;
                case 11:
                    return JpegMetaTypes.APP11;
                case 12:
                    return JpegMetaTypes.APP12;
                case 13:
                    return JpegMetaTypes.APP13;
                case 14:
                    return JpegMetaTypes.APP14;
                case 15:
                    return JpegMetaTypes.APP15;
                default:
                    throw new ArgumentOutOfRangeException($"APPN marker value 0X{appNValue:X2} is out of range.");
            }

        }
    }
}