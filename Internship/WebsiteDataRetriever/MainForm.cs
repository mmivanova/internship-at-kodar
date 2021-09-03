using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsiteDataRetriever.Helpers;

namespace WebsiteDataRetriever
{
    public partial class MainForm : Form
    {
        private readonly Stopwatch _watch = new();
        private static readonly List<string> Websites = new()
        {
            "https://www.google.com",
            "https://www.microsoft.com",
            "https://www.cnn.com",
            "https://www.amazon.com",
            "https://www.facebook.com",
            "https://www.twitter.com",
            "https://www.codeproject.com",
            "https://www.stackoverflow.com",
            "https://en.wikipedia.org/wiki/.NET_Framework",
            "https://nakov.com",
            "https://elmah.io",
            "https://www.pluralsight.com",
            "https://www.udemy.com"
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNormalExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();
            
            _watch.Start();
            tbDisplay.Text = Executor.ExecuteNormal(pbLoader);
            _watch.Stop();
            
            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private void btnNormalParallelExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();
            
            _watch.Start();
            tbDisplay.Text = Executor.ExecuteParallel(pbLoader);
            _watch.Stop();
            
            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private async void btnAsyncExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();
            
            _watch.Start();
            tbDisplay.Text = await Executor.ExecuteAsync(pbLoader);
            _watch.Stop();
            
            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private void btnParallelAsyncExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();
            
            _watch.Start();
            //var result = string.Empty;
            Parallel.ForEach(Websites, async website =>
            {
                var data = await GetWebsiteData(website);
                pbLoader.Increment(100/12);
                tbDisplay.Text += $@"{website} downloaded: {data.Length} characters long" + Environment.NewLine;
            });
            _watch.Stop();
            
            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private static Task<string> GetWebsiteData(string website)
        {
            return Task.Run(() =>
            {
                var data = DownloadWebsite(website);
                return data;
            });
        }
        
        private static string DownloadWebsite(string websiteUrl)
        {
            var webClient = new WebClient();
            var result = webClient.DownloadString(websiteUrl);
            return result;
        }
        
        private void ResetTextBoxAndProgressBar()
        {
            tbDisplay.Text = string.Empty;
            pbLoader.Value = 0;
            _watch.Reset();
        }
    }
}