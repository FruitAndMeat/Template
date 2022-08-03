using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Utils
{
    public class LogHelper
    {
       private static ILog log = log4net.LogManager.GetLogger("Test");
        public static void LogError(string errormsg)
        {
            log.Error(errormsg, new Exception("发生了一个错误"));
        }

        public static void LogFatal(string Fatalmsg)
        {
            log.Error(Fatalmsg, new Exception("发生了一个严重错误"));
        }

    }
}
