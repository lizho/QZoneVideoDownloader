using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lizho.SimpleBriefJson;
using System.IO;

namespace QZoneVideoDownloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private MiniBrowser LoginWindow = new MiniBrowser();
        private Downloader DownloadWindow = new Downloader();
        private string URLFormat = @"https://h5.qzone.qq.com/proxy/domain/taotao.qq.com/cgi-bin/video_get_data?g_tk={0}&hostUin={1}&appid=4&getMethod=2&start={2}&count=20&need_old=1&getUserInfo=1&inCharset=utf-8&outCharset=utf-8";
        private string LabelFormat = @"第 {0} 页 | 共  {1} 页";
        private int StartIndex;
        private int TotalVideos;
        private const int VideosPerPage = 20;
        private Dictionary<string, QZoneVideo> VideoDict = new Dictionary<string, QZoneVideo>();


        private void BtnNext_Click(object sender, EventArgs e)
        {
            ShowNextPage();
        }

        private int MakeToken(string key)
        {
            var token = 5381;
            foreach (var c in LoginWindow.PSKey)
            {
                token += (token << 5) + c;
            }
            return token & 2147483647;
        }

        private void ShowNextPage()
        {

            if (LoginWindow.PSKey == null)
            {
                MessageBox.Show("获取登陆信息失败！");
                return;
            }

            ilCover.Images.Clear();
            lvCover.Items.Clear();
            VideoDict.Clear();

            var token = MakeToken(LoginWindow.PSKey);
            var url = string.Format(URLFormat, token, LoginWindow.QQ, StartIndex);
            //MessageBox.Show(url);

            var wc = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            wc.Headers.Add(HttpRequestHeader.Cookie, LoginWindow.Cookie);
            var res = wc.DownloadString(url);
            var start_index = res.IndexOf('(') + 1;
            var end_index = res.LastIndexOf(')');
            res = res.Substring(start_index, end_index - start_index);
            var json = new SBJsonHelper(res);
            if (json["code"].CastTo<SBJsonNumber>().Value != 0)
            {
                MessageBox.Show("ERROR");
                return;
            }

            var jsonData = json["data"];

            TotalVideos = (int)jsonData["total"].CastTo<SBJsonNumber>().Value;
            label1.Text = string.Format(LabelFormat, StartIndex / VideosPerPage + 1, TotalVideos / VideosPerPage + 1);

            StartIndex += VideosPerPage;
            btnNext.Enabled = !bool.Parse(jsonData["isLast"].CastTo<SBJsonString>().Value);
            btnPre.Enabled = StartIndex >= (VideosPerPage << 1);
            
            foreach (SBJsonDict jsonVideo in jsonData["Videos"].CastTo<SBJsonArray>().Value)
            {
                var qzvideo = new QZoneVideo(jsonVideo);
                VideoDict.Add(qzvideo.Key, qzvideo);
                lvCover.Items.Add(qzvideo.Key, qzvideo.Title, qzvideo.Key);
                DownloadManager.ManagedDownload(qzvideo.Key, qzvideo.PreImg);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (LoginWindow.ShowDialog(this) == DialogResult.OK)
            {
                tbUserInfo.Text = $"{LoginWindow.QZoneTitle} 已登录";
                StartIndex = 0;
                ShowNextPage();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DownloadManager.DownloadCompleted += DownloadManager_DownloadCompleted;
            tDownload.Tick += DownloadManager.Timer_Tick;
            tDownload.Start();
        }

        private void DownloadManager_DownloadCompleted(object sender, DownloadCompletedEventArgs e)
        {
            if (VideoDict.ContainsKey(e.Key))
            {
                var video = VideoDict[e.Key];
                video.GenerateCover(e.Result, ilCover.ImageSize);
                ilCover.Images.Add(video.Key, video.CoverImage);
            }
        }
        
        private void BtnPre_Click(object sender, EventArgs e)
        {
            StartIndex -= (VideosPerPage << 1);
            ShowNextPage();
        }

        private void BtnSel_Click(object sender, EventArgs e)
        {
            if (fbdSaveDir.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = fbdSaveDir.SelectedPath;
            }
        }

        private void DLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(tbPath.Text))
            {
                if (fbdSaveDir.ShowDialog() == DialogResult.OK)
                {
                    tbPath.Text = fbdSaveDir.SelectedPath;
                }
                else
                {
                    return;
                }
            }

            var video = VideoDict[lvCover.SelectedItems[0].Name];

            DownloadWindow.SetDownloadTask(video.VidUrl, video.Title, video.Key, tbPath.Text);
            DownloadWindow.ShowDialog();

        }

        private void TDownload_Tick(object sender, EventArgs e)
        {
            DownloadManager.Timer_Tick(sender, e);
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            tbPath.Clear();
        }
    }
}
