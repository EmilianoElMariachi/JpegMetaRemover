using System;

namespace JpegMetaRemover.Tools
{
    internal static class MemHelper
    {
        public static void DisposeSecure(IDisposable disposable)
        {
            try
            {
                disposable?.Dispose();
            }
            catch
            {
                // ignored
            }
        }
    }
}
