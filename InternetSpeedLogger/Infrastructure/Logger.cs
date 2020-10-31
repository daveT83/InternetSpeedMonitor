using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InternetSpeedLogger.Infrastructure
{
    public class Logger
    {
        private string LogFile;
        public Logger(string logFile)
        {
            this.LogFile = logFile;
        }

        /// <summary>
        /// Logs a line
        /// </summary>
        /// <param name="line"></param>
        public void Log(string line)
        {
            using (StreamWriter sw = new StreamWriter(LogFile, true))
            {
                sw.WriteLine(line);
            }
        }

        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="e"></param>
        public void LogError(Exception e)
        {
            using (StreamWriter sw = new StreamWriter(LogFile, true))
            {
                sw.WriteLine("---------------------------------------------------------------------------------------");
                sw.WriteLine("Message:" + e.Message);
                sw.WriteLine("Stacktrace:" + e.StackTrace);
                sw.WriteLine("---------------------------------------------------------------------------------------");
            }
        }
    }
}
