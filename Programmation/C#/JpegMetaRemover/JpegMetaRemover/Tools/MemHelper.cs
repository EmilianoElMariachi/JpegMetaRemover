using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JpegMetaRemover.Tools
{
    internal static class MemHelper
    {
        public static void DisposeSecure(IDisposable disposable)
        {
            try
            {
                if (disposable != null)
                { disposable.Dispose(); }
            }
            catch
            { }

        }
    }
}
