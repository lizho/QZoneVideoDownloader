using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QZoneVideoDownloader
{
    public partial class Downloader : Form
    {
        public Uri Url { get; private set; }
        public string FileToSave { get; private set; }
        private WebClient DownloadClient = new WebClient();

        public Downloader()
        {
            InitializeComponent();
        }

        public void SetDownloadTask(string url, string title, string key, string path)
        {
            pbDownload.Value = 0;
            label1.Text = "";
            Url = new Uri(url);
            FileToSave = Path.Combine(path, $"{title}_{key}.mp4");
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Downloader_Load(object sender, EventArgs e)
        {
            DownloadClient.DownloadProgressChanged += DownloadClient_DownloadProgressChanged;
            DownloadClient.DownloadFileCompleted += DownloadClient_DownloadFileCompleted;
        }

        private void DownloadClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            pbDownload.Value = 100;
            btnDir.Enabled = btnFile.Enabled = btnQuit.Enabled = true;
        }

        private void Downloader_Shown(object sender, EventArgs e)
        {
            if (File.Exists(FileToSave) && MessageBox.Show("文件已存在，要覆盖吗？", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            btnDir.Enabled = btnFile.Enabled = btnQuit.Enabled = false;
            DownloadClient.DownloadFileAsync(Url, FileToSave);
        }

        private void DownloadClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbDownload.Value = e.ProgressPercentage;
            label1.Text = $"已下载{e.BytesReceived * 100d / e.TotalBytesToReceive:f2}%";
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(FileToSave))
                System.Diagnostics.Process.Start(FileToSave);
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + FileToSave);
        }
    }
}
