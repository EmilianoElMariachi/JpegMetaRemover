using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JpegMetaRemover.JpegTools
{
    public class JpegMarkerSectionsReader
    {

        public static IEnumerable<MarkerSection> Read(Stream stream)
        {
            var binaryReader = new BinaryReader(stream);
            var markerBytes = ReadMarker(binaryReader, out var markerType);


            if (markerType != MarkerType.SOI) //SOI - Start Of Image
                throw new BadImageException($"Image not starting with expected marker {MarkerType.SOI}.");

            yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: false, hasEntropyCodedData: false);

            while (true)
            {
                markerBytes = ReadMarker(binaryReader, out markerType);

                switch (markerType)
                {
                    case MarkerType.SOI:
                        throw new BadImageException($"Duplicated marker {MarkerType.SOI} found.");
                    case MarkerType.SOF0:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: true, hasEntropyCodedData: false);
                        break;
                    case MarkerType.SOF2:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: true, hasEntropyCodedData: false);
                        break;
                    case MarkerType.DHT:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: true, hasEntropyCodedData: false);
                        break;
                    case MarkerType.DQT:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: true, hasEntropyCodedData: false);
                        break;
                    case MarkerType.DRI:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: true, hasEntropyCodedData: false);
                        break;
                    case MarkerType.SOS:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: true, hasEntropyCodedData: true);
                        break;
                    case MarkerType.RST_N:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: false, hasEntropyCodedData: false);
                        break;
                    case MarkerType.APP_N:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: true, hasEntropyCodedData: false);
                        break;
                    case MarkerType.COM:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: true, hasEntropyCodedData: false);
                        break;
                    case MarkerType.EOI:
                        yield return ReadMarkerSection(binaryReader, markerType, markerBytes, hasContent: false, hasEntropyCodedData: false);
                        yield break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown marker {markerType} found.");
                }

            }

        }

        private static MarkerSection ReadMarkerSection(BinaryReader binaryReader, MarkerType markerType, byte[] markerBytes, bool hasContent, bool hasEntropyCodedData)
        {
            byte[] payloadSizeBytes;
            byte[] payloadBytes;
            if (hasContent)
            {
                ReadMarkerSegmentPayload(binaryReader, out payloadSizeBytes, out payloadBytes);
            }
            else
            {
                payloadSizeBytes = new byte[0];
                payloadBytes = new byte[0];
            }

            var entropyCodedDataBytes = hasEntropyCodedData ? ReadEntropyCodedData(binaryReader) : new byte[0];

            var rawData = markerBytes.Concat(payloadSizeBytes).Concat(payloadBytes).Concat(entropyCodedDataBytes).ToArray();


            return new MarkerSection
            {
                Type = markerType,
                RawData = rawData
            };

        }

        private static void ReadMarkerSegmentPayload(BinaryReader stream, out byte[] payloadSizeBytes, out byte[] payloadBytes)
        {
            payloadSizeBytes = stream.ReadBytes(2);

            // Interprète les octets représentant la taille du payload (notons que les octets sont en Big endian, d'où l'inversion des octets)
            var payloadSize = BitConverter.ToInt16(new[] { payloadSizeBytes[1], payloadSizeBytes[0] }, 0) - 2; // -2 car la taille inclut les 2 octets de la taille

            payloadBytes = stream.ReadBytes(payloadSize);
            if (payloadSize != payloadBytes.Length)
                throw new BadImageException("Invalid payload data, end of file reached before expected payload size.");
        }

        private static byte[] ReadMarker(BinaryReader stream, out MarkerType markerType)
        {
            var markerBuffer = new byte[2];
            var nbBytesRead = stream.Read(markerBuffer, 0, markerBuffer.Length);
            if (nbBytesRead <= 1)
                throw new BadImageException("End of file reached instead of a marker.");

            const int FIRST_MARKER_BYTE = 0xFF;
            if (markerBuffer[0] != FIRST_MARKER_BYTE)
                throw new BadImageException($"Invalid marker, 0x{markerBuffer[0]:X2} found instead of 0x{FIRST_MARKER_BYTE:X2}.");

            var markerByte = markerBuffer[1];

            if (markerByte == 0xD8)
                markerType = MarkerType.SOI;
            else if (markerByte == 0xC0)
                markerType = MarkerType.SOF0;
            else if (markerByte == 0xC2)
                markerType = MarkerType.SOF0;
            else if (markerByte == 0xC4)
                markerType = MarkerType.DHT;
            else if (markerByte == 0xDB)
                markerType = MarkerType.DQT;
            else if (markerByte == 0xDD)
                markerType = MarkerType.DRI;
            else if (markerByte == 0xDA)
                markerType = MarkerType.SOS;
            else if (markerByte is >= 0xD0 and <= 0xD7)
                markerType = MarkerType.RST_N;
            else if (markerByte is >= 0xE0 and <= 0xEF)
                markerType = MarkerType.APP_N;
            else if (markerByte == 0xFE)
                markerType = MarkerType.COM;
            else if (markerByte == 0xD9)
                markerType = MarkerType.EOI;
            else
                throw new Exception($"Unknown marker 0x{markerByte:X2} found.");

            return markerBuffer;
        }

        /// <summary>
        /// Lit l'ensemble de données d'entropie qui suivent les données d'un marqueur sans consommer le marqueur suivant
        /// </summary>
        /// <param name="binaryReader"></param>
        /// <returns></returns>
        private static byte[] ReadEntropyCodedData(BinaryReader binaryReader)
        {
            var data = new List<byte>();
            while (true)
            {
                byte b;
                try
                {
                    b = binaryReader.ReadByte();
                }
                catch (EndOfStreamException)
                {
                    throw new BadImageException("Failed to read entropy coded data, end of stream reached.");
                }

                if (b != 0xFF)
                {
                    data.Add(b);
                    continue;
                }

                // Ici, on a trouvé un octet 0xFF byte, peut-être un marqueur ?

                byte stuffByte;
                try
                {
                    stuffByte = binaryReader.ReadByte();
                }
                catch (EndOfStreamException)
                {
                    throw new BadImageException("Failed to read entropy coded data, end of stream reached.");
                }

                if (stuffByte == 0)
                {
                    // Ici, pas de marqueur, car échappé par l'octet 0x00 (stuff byte)
                    data.Add(b);
                    continue;
                }

                // Ici, nouveau marqueur trouvé, donc on revient à la position du marqueur
                binaryReader.BaseStream.Position -= 2;
                return data.ToArray();
            }

        }
    }

    public enum MarkerType
    {
        /// <summary>
        /// Start Of Image
        /// </summary>
        SOI,
        /// <summary>
        /// Start Of Frame (Baseline DCT)
        /// </summary>
        SOF0,
        /// <summary>
        /// Start Of Frame (Progressive DCT)
        /// </summary>
        SOF2,
        /// <summary>
        /// Define Huffman Table(s)
        /// </summary>
        DHT,
        /// <summary>
        /// Define Quantization Table(s)
        /// </summary>
        DQT,
        /// <summary>
        /// Define Restart Interval
        /// </summary>
        DRI,
        /// <summary>
        /// Start Of Scan
        /// </summary>
        SOS,
        /// <summary>
        /// Restart
        /// </summary>
        RST_N,
        /// <summary>
        /// Application-specific
        /// </summary>
        APP_N,
        /// <summary>
        /// Commentaire
        /// </summary>
        COM,
        /// <summary>
        /// End Of Image
        /// </summary>
        EOI,

    }
}
