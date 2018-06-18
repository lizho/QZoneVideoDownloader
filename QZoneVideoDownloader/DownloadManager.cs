using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace QZoneVideoDownloader
{
    delegate void DownloadCompletedHandler(object sender, DownloadCompletedEventArgs e);

    internal class DownloadCompletedEventArgs : EventArgs
    {
        public string Key { get; set; }
        public byte[] Result { get; set; }
    }

    class DownloadManager
    {
        static private Queue<WebClient> IdleDownloaderQueue = new Queue<WebClient>();

        static private Queue<Tuple<string, Uri>> DownloadTaskQueue = new Queue<Tuple<string, Uri>>();

        static private object QueueLocker = new object();

        static public event DownloadCompletedHandler DownloadCompleted;

        static DownloadManager()
        {
            for (int i = 0; i < 4; i++)
            {
                var wc = new WebClient();
                wc.DownloadDataCompleted += Wc_DownloadDataCompleted;
                IdleDownloaderQueue.Enqueue(wc);
            }
        }

        private static void Wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            lock (QueueLocker)
            {
                IdleDownloaderQueue.Enqueue(sender as WebClient);
            }

            DownloadCompleted?.Invoke(sender, new DownloadCompletedEventArgs { Key = e.UserState as string, Result = e.Result });
        }

        public static void Timer_Tick(object sender, EventArgs e)
        {
            if (IdleDownloaderQueue.Count > 0 && DownloadTaskQueue.Count > 0)
            {
                WebClient wc;
                Tuple<string, Uri> dt;
                lock (QueueLocker)
                {
                    wc = IdleDownloaderQueue.Dequeue();
                    dt = DownloadTaskQueue.Dequeue();
                }
                wc.DownloadDataAsync(dt.Item2, dt.Item1);
            }
        }

        static public void ManagedDownload(string key, string url)
        {
            lock (QueueLocker)
            {
                DownloadTaskQueue.Enqueue(Tuple.Create(key, new Uri(url)));
            }
        }
    }
}
