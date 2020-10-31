using InternetSpeedLogger.Models;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace InternetSpeedLogger.Infrastructure
{
    public class SpeedTester
    {
        private Logger logger;
        private string filePath;
        private DateTime curDate;
        public SpeedTester(Logger logger, string filePath, DateTime curDate)
        {
            this.logger = logger;
            this.filePath = filePath;
            this.curDate = curDate;
        }

        /// <summary>
        /// Tests internet speed using a 100 MB file
        /// </summary>
        /// <returns></returns>
        public Download TestInternet()
        {
            Download download = new Download();
            Stopwatch watch = new Stopwatch();
            string url = "";

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["UseNewYork"]))
            {
                url = "http://speedtest-ny.turnkeyinternet.net/100mb.bin";
            }
            else
            {
                url = "http://speedtest-ca.turnkeyinternet.net/100mb.bin";
            }

            byte[] data;
            using (var client = new System.Net.WebClient())
            {
                logger.Log("Begining Download");
                logger.Log("File URL: " + url);

                watch.Start();
                try
                {
                    data = client.DownloadData(url);
                    download.BytesDownloaded = data;
                    data = new byte[0];
                }
                catch (Exception e)
                {
                    logger.LogError(e);
                }
                watch.Stop();
            }

            download.TimeElapsed = watch.Elapsed;

            logger.Log("");
            logger.Log("Results");
            logger.Log("File Size: " + download.BitsDownloaded + "b/" + download.MegaBitsDownloaded + "mb/" + download.BytesDownloaded.Length + "B/" + download.MegaBytesDownloaded + "MB");
            logger.Log("Time Elapsed: " + download.TimeElapsed.ToString());
            logger.Log("Download Speed: " + download.BitsPerSecond + "bps/" + download.MegaBitsPerSecond + "mbps/" + download.BytesPerSecond + "Bps/" + download.MegaBytesPerSecond + "MBps");
            WriteFile(download);
            return download;
        }

        private void WriteFile(Download download)
        {
            bool fileExists = false;
            if (File.Exists(filePath))
            {
                fileExists = true;
            }
                using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                //adds headers if it is a new file
                if (!fileExists)
                {
                    sw.WriteLine("Date,Speed(bits/second),Speed(Megabits/second),Speed(bytes/second),Speed(Megabytes/second)");
                }
                sw.WriteLine(curDate.ToString() + "," + download.BitsPerSecond + "," + download.MegaBitsPerSecond + "," + download.BytesPerSecond + "," + download.MegaBytesPerSecond);
            }
        }
    }
}
