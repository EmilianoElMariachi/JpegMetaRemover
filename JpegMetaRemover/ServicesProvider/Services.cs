using JpegMetaRemover.ServicesProvider.LocalizationService;
using JpegMetaRemover.ServicesProvider.SettingsService;

namespace JpegMetaRemover.ServicesProvider
{
    internal static class Services
    {
        public static readonly LocalizationManager LocalizationManager = new LocalizationManager();

        public static readonly SettingsManager SettingsManager = new SettingsManager();
    }
}
