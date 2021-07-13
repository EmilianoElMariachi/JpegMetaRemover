using System;

namespace JpegMetaRemover.JpegTools
{
    public class BadImageException : Exception
    {
        public BadImageException(string message) : base(message)
        {

        }
    }
}