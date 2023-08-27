using System;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace EdicoTI
{
	public partial class LiveUpdate : Form
	{
		public string DownloadURL { get; set; }
        private WebClient webClient;
        private string downloadedFilePath;
        private string lblCopy;
        public LiveUpdate(string downloadUrl)
		{
			InitializeComponent();
            DownloadURL = downloadUrl;
            lblCopy = lblDownload.Text;
		}

		private void Updater_Load(object sender, EventArgs e)
		{
            downloadedFilePath = Path.Combine(Path.GetTempPath(), DownloadURL.Substring(DownloadURL.LastIndexOf("/") + 1));
            webClient = new WebClient();
            webClient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(DownloadURL), downloadedFilePath);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblDownload.Text = lblCopy.Replace("\n", e.ProgressPercentage + "% completato.\n");
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            System.Diagnostics.Process.Start(downloadedFilePath);
            Application.Exit();
        }

        public static string checkForUpdate()
		{
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string[] sCurrentVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString().Split('.');
            uint currentVersion = Convert.ToUInt32(sCurrentVersion[0] + sCurrentVersion[1]);
            string sJson = new WebClient().DownloadString(Properties.Settings.Default.updateUrl);
            var json = JObject.Parse(sJson);
            string[] sRemoteVersion = json["version"].ToString().Split('.');
            uint remoteVersion = Convert.ToUInt32(sRemoteVersion[0] + sRemoteVersion[1]);
            if (currentVersion < remoteVersion)
			{
                return json["url"].ToString();
			}
            return null;
        }

    }
}
