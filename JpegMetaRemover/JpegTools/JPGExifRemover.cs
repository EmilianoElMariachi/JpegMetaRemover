using System;
using System.IO;

namespace JpegMetaRemover.JpegTools
{
    public class JPGExifRemover : BinaryReader
    {
        private readonly string _filePath;

        public JPGExifRemover(string filePath)
            : base(new FileStream(filePath, FileMode.Open))
        {
            this._filePath = filePath;
        }

        public override byte[] ReadBytes(int nbBytesToRead)
        {
            try
            {
                return base.ReadBytes(nbBytesToRead);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid file", ex);

            }
        }

        private byte ReadJPGMarker()
        {
            var readBytes = ReadBytes(2);

            if (readBytes[0] != 0xFF)
            { throw new Exception("Invalid marker found"); }
            return readBytes[1];
        }

        private void ReadVariableLengthSegment(byte marker, Stream outStream, bool writeToOutStream)
        {
            var bytes = this.ReadBytes(2);
            if (writeToOutStream)
            {
                WriteMarkerToOutStream(marker, outStream);
                outStream.Write(bytes, 0, bytes.Length);
            }

            Array.Reverse(bytes);

            var segmentSize = BitConverter.ToUInt16(bytes, 0) - 2;

            var segmentBytes = new byte[segmentSize];

            this.Read(segmentBytes, 0, segmentSize);
            if (writeToOutStream) 
                outStream.Write(segmentBytes, 0, segmentBytes.Length);
        }

        private void ReadEntropyCodedData(out byte marker, Stream outStream, bool writeToOutStream)
        {
            while (true)
            {
                byte byteTmp;
                while (true)
                {
                    byteTmp = this.ReadByte();

                    if (byteTmp != 0xFF)
                    {
                        if (writeToOutStream) 
                            outStream.WriteByte(byteTmp);
                    }
                    else
                        break;
                }

                marker = this.ReadByte();
                if (marker == 0)
                {
                    if (writeToOutStream)
                    {
                        outStream.WriteByte(byteTmp);
                        outStream.WriteByte(marker);
                    }
                }
                else
                    break;
            }
        }

        private void WriteMarkerToOutStream(byte marker, Stream outStream)
        {
            outStream.WriteByte(0xFF);
            outStream.WriteByte(marker);
        }

        public PurificationResult Purify(JpegMetaTypes metaTypesToRemove, CommentsActionType commentsAction)
        {
            var purificationResult = new PurificationResult
            {
                    ResultStream = new MemoryStream(),
                    ResultStreamDiffersFromOriginal = false,
                    MetaTypesFound = JpegMetaTypes.NONE,
                    MetaTypesRemoved = JpegMetaTypes.NONE,
                    MetaTypesToRemove = metaTypesToRemove,
                    NbCommentsFound = 0,
                    NbCommentsRemoved = 0,
                    NbMetasFound = 0,
                    NbMetasRemoved = 0,
                    OriginalFilePath = this._filePath

                };

            var jpegMetaTypes = (JpegMetaTypes[])Enum.GetValues(typeof(JpegMetaTypes));

            // Lecture du magic code JPEG
            var marker = this.ReadJPGMarker();
            if (marker != 0xD8) //SOI : Start Of Image 
                throw new Exception("Invalid file type, SOI marker not found.");
            WriteMarkerToOutStream(marker, purificationResult.ResultStream);

            var writeCommentSegmentToOutStream = (commentsAction == CommentsActionType.KEEP);

            while (true)
            {
                marker = this.ReadJPGMarker();

            SkipMarkerReading:


                if (marker == 0xC0)    //SOF0 : Indicates that this is a baseline DCT-based JPEG, and specifies the width, height, number of components, and component subsampling 
                {
                    ReadVariableLengthSegment(marker, purificationResult.ResultStream, true);
                }
                else if (marker == 0xC2)    //SOF2 : Indicates that this is a progressive DCT-based JPEG, and specifies the width, height, number of components, and component subsampling 
                {
                    ReadVariableLengthSegment(marker, purificationResult.ResultStream, true);
                }
                else if (marker == 0xC4)    //DHT : Specifies one or more Huffman tables.
                {
                    ReadVariableLengthSegment(marker, purificationResult.ResultStream, true);
                }
                else if (marker == 0xDB)    //DQT : Specifies one or more quantization tables
                {
                    ReadVariableLengthSegment(marker, purificationResult.ResultStream, true);
                }
                else if (marker == 0xDD)    //DRI : Specifies the interval between RSTn markers, in macroblocks
                {
                    ReadVariableLengthSegment(marker, purificationResult.ResultStream, true);
                }
                else if (marker == 0xDA)    //SOS : Begins a top-to-bottom scan of the image
                {
                    ReadVariableLengthSegment(marker, purificationResult.ResultStream, true);

                    ReadEntropyCodedData(out marker, purificationResult.ResultStream, true);

                    goto SkipMarkerReading;
                }
                else if (marker >= 0xD0 && marker <= 0xD7)  //RSTn : Inserted every r macroblocks, where r is the restart interval set by a DRI marker
                {
                    WriteMarkerToOutStream(marker, purificationResult.ResultStream);

                    ReadEntropyCodedData(out marker, purificationResult.ResultStream, true);

                    goto SkipMarkerReading;
                }
                else if (marker >= 0xE0 && marker <= 0xEF)//APPn : Application-specific (example : exif)
                {
                    var appNumOneBased = (0x0F & marker) + 1;

                    var currentMetadataType = jpegMetaTypes[appNumOneBased];

                    var metaTypeShouldBeRemoved = ((currentMetadataType & metaTypesToRemove) == currentMetadataType);

                    var writeMetadataSegmentToOutStream = !metaTypeShouldBeRemoved;
                    ReadVariableLengthSegment(marker, purificationResult.ResultStream, writeMetadataSegmentToOutStream);

                    purificationResult.NbMetasFound++;
                    purificationResult.MetaTypesFound |= currentMetadataType;
                    if (metaTypeShouldBeRemoved)
                    {
                        purificationResult.NbMetasRemoved++;
                        purificationResult.MetaTypesRemoved |= currentMetadataType;
                        purificationResult.ResultStreamDiffersFromOriginal = true;
                    }
                }
                else if (marker == 0xFE) //COM : Comment
                {
                    ReadVariableLengthSegment(marker, purificationResult.ResultStream, writeCommentSegmentToOutStream);

                    purificationResult.NbCommentsFound++;
                    if (!writeCommentSegmentToOutStream)
                    {
                        purificationResult.NbCommentsRemoved++;
                        purificationResult.ResultStreamDiffersFromOriginal = true;
                    }
                }
                else if (marker == 0xD9) //EOI : End Of Image
                {
                    WriteMarkerToOutStream(marker, purificationResult.ResultStream);
                    break;
                }
                else
                    throw new Exception("Unknown marker found");

            }

            return purificationResult;
        }

    }
}
