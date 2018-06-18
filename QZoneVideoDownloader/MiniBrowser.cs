using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QZoneVideoDownloader
{
    public partial class MiniBrowser : Form
    {
        public MiniBrowser()
        {
            InitializeComponent();
        }
        private Regex Reg = new Regex(@"(?<key>[^=]+?)=(?<value>[^;]*);?\s*");
        public Dictionary<string, string> CookieDict { get; private set; } = new Dictionary<string, string>();

        public string Cookie { get; private set; }
        public string PSKey { get; private set; }
        public string QQ { get; private set; }
        public string QZoneTitle => wbLogin.DocumentTitle;

        private static readonly Uri HomeUri = new Uri(@"https://i.qq.com/");

        private void WbLogin_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.Host == "user.qzone.qq.com")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void MiniBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Cookie = wbLogin.Document.Cookie;
                CookieDict.Clear();
                foreach (Match match in Reg.Matches(Cookie))
                {
                    CookieDict.Add(match.Groups["key"].Value, match.Groups["value"].Value);
                }
                PSKey = CookieDict["p_skey"];
                QQ = CookieDict["uin"].Substring(1).TrimStart('0');
                DialogResult = DialogResult.OK;
            }
            catch
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;
        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        private void MiniBrowser_Shown(object sender, EventArgs e)
        {
            wbLogin.Document.Cookie.Remove(0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
            wbLogin.Url = HomeUri;
        }
    }
}
