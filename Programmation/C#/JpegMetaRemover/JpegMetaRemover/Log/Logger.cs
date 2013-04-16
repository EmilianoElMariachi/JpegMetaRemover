namespace JpegMetaRemover.Log
{
    public delegate void LogEvent(object sender, string message, MsgType msgType);

    internal static class Logger
    {

        public static event LogEvent OnLog;

        public static void Log(object sender, string message, MsgType msgType)
        {
           if (OnLog != null)
           {
               OnLog(sender, message, msgType);
           }
        }

        public static void LogInfo(object sender, string message)
        {
            Log(sender, message, MsgType.INFO);
        }

        public static void LogWarning(object sender, string message)
        {
            Log(sender, message, MsgType.WARNING);
        }

        public static void LogError(object sender, string message)
        {
            Log(sender, message, MsgType.ERROR);
        }

    }
}
