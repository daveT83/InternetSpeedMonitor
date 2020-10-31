using InternetSpeedLogger.Infrastructure;
using InternetSpeedLogger.Models;
using System;
using System.Configuration;

namespace InternetSpeedLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dtNow = DateTime.Now;
            Logger logger = new Logger(ConfigurationManager.AppSettings["LogFolder"]+@"InternetMonitorLog_" + dtNow.ToString("MM-dd-yyyy") + ".txt");
            logger.Log("Begining Log: " + dtNow.Hour + ":" + dtNow.Minute + ":" + dtNow.Second);
            logger.Log("______________________________________________________________________________________________________");

            SpeedTester st = new SpeedTester(logger, ConfigurationManager.AppSettings["ResultsFolder"]+@"InternetMonitorResults_" + dtNow.ToString("MM-dd-yyyy") + ".csv", dtNow);
            Download download = st.TestInternet();

            logger.Log("End of Log");
            logger.Log("______________________________________________________________________________________________________");
        }
    }
}
