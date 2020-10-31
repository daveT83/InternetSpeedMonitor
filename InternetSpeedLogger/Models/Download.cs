using System;
using System.Collections.Generic;
using System.Text;

namespace InternetSpeedLogger.Models
{
    public class Download
    {
        public byte[] BytesDownloaded { get; set; }
        public TimeSpan TimeElapsed { get; set; }
        public double BitsDownloaded { get { return BytesDownloaded.Length * 8; } }
        public double MegaBytesDownloaded { get { return BytesDownloaded.Length* 0.000001; } }
        public double MegaBitsDownloaded { get { return MegaBytesDownloaded * 8; } }
        public double BytesPerSecond { get { return BytesDownloaded.Length / TimeElapsed.TotalSeconds; } }
        public double BitsPerSecond { get { return BitsDownloaded / TimeElapsed.TotalSeconds; } }
        public double MegaBytesPerSecond { get { return MegaBytesDownloaded / TimeElapsed.TotalSeconds; } }
        public double MegaBitsPerSecond { get { return MegaBitsDownloaded / TimeElapsed.TotalSeconds; } }
    }
}
