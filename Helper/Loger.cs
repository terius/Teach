using System;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", ConfigFileExtension = "config", Watch = true)]
namespace Helpers
{
    public class Loger
    {
        private static readonly log4net.ILog oLog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static void LogMessage(string message)
        {
            LogMessage(message, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="msgLevel">1-一般信息 2-警告信息 3-错误信息</param>
        public static void LogMessage(string message, int msgLevel)
        {
            if (msgLevel == 1)
            {
                if (oLog.IsInfoEnabled)
                    oLog.Info(message);
            }
            else if (msgLevel == 2)
            {
                if (oLog.IsWarnEnabled)
                    oLog.Warn(message);
            }
            else if (msgLevel == 3)
            {
                if (oLog.IsErrorEnabled)
                {
                    oLog.Error(message);
                }
            }
        }




        public static void LogMessage(Exception ex, string requestString)
        {
            LogMessage(string.Format("\r\n【错误信息:{0}】\r\n【内部错误信息:{1}】\r\n【请求字符串:{2}】\r\n【位置:{3}】",
                ex.Message, ex.InnerException == null ? "" : ex.InnerException.Message, requestString, ex.StackTrace), 3);
        }

        public static void LogMessage(Exception ex)
        {
            LogMessage(string.Format("\r\n【错误信息:{0}】\r\n【内部错误信息:{1}】\r\n【位置:{2}】", ex.Message, ex.InnerException == null ? "" : ex.InnerException.Message, ex.StackTrace), 3);
        }
    }
}
