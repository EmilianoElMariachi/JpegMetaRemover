using System;

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

        public static void LogLine(object sender, string message, MsgType msgType)
        {
            Log(sender, message + Environment.NewLine, msgType);
        }

        public static void LogInfo(object sender, string message)
        {
            Log(sender, message, MsgType.INFO);
        }

        public static void LogLineInfo(object sender, string message)
        {
            LogLine(sender, message, MsgType.INFO);
        }

        public static void LogWarning(object sender, string message)
        {
            Log(sender, message, MsgType.WARNING);
        }

        public static void LogLineWarning(object sender, string message)
        {
            LogLine(sender, message, MsgType.WARNING);
        }

        public static void LogError(object sender, string message)
        {
            Log(sender, message, MsgType.ERROR);
        }

        public static void LogLineError(object sender, string message)
        {
            LogLine(sender, message, MsgType.ERROR);
        }

        public static void LogActionStart(object sender, string message)
        {
            Log(sender, message, MsgType.ACTION_START);
        }

        public static void LogLineActionStart(object sender, string message)
        {
            LogLine(sender, message, MsgType.ACTION_START);
        }

        public static void LogActionEnd(object sender, string message)
        {
            Log(sender, message, MsgType.ACTION_END);
        }

        public static void LogLineActionEnd(object sender, string message)
        {
            LogLine(sender, message, MsgType.ACTION_END);
        }

        public static void LogException(object sender, Exception ex)
        {
            Log(sender, GetExceptionMessage(ex), MsgType.ERROR);
        }

        public static void LogLineException(object sender, Exception ex)
        {
            LogLine(sender, GetExceptionMessage(ex), MsgType.ERROR);
        }

        private static string GetExceptionMessage(Exception ex)
        {
            var exMsg = (ex == null) ? "undefined exception (null)" : ex.Message;
            return "Exception : " + exMsg;
        }
    }
}
