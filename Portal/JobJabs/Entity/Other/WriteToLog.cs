using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;


namespace JobJabs.Entity
{
    public class WriteToLogClass
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void WriteErrorLog(string Controller, string Action, Exception ex)
        {
            string str = (
             Environment.NewLine
                 + "-------------------------------------" + Environment.NewLine
                 + "TimeStamp  : " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + Environment.NewLine
                 + "Controller : " + Controller + Environment.NewLine
                 + "Action     : " + Action + Environment.NewLine
                 + "Message    : " + ex.Message.ToString() + Environment.NewLine
                 + "Details    : " + ex.ToString().Trim() + Environment.NewLine
              );
            _log.Error(str);

        }

        public static void WriteInfo(string info)
        {
            string str = (
             Environment.NewLine
                 + "-------------------------------------" + Environment.NewLine
                 + "TimeStamp  : " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + Environment.NewLine
                 + "Info    : " + info + Environment.NewLine + Environment.NewLine
              );
            _log.Info(str);

        }

    }
}
