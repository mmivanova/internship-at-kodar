using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsiteDataRetriever.Data;

namespace WebsiteDataRetriever.Helpers
{
    public static class Executor
    {
        private const int ValuePerWebsite = 100 / 12;
        private static readonly List<string> WebsiteUrls = Website.GetWebsiteUrls();

        public static string ExecuteParallel(ProgressBar progressBar)
        {
            var result = string.Empty;

            Parallel.ForEach(WebsiteUrls, websiteUrl =>
            {
                var website = DownloadWebsite(websiteUrl);
                progressBar.Increment(ValuePerWebsite);
                result += $@"{website.WebsiteUrl} downloaded: {website.WebsiteData.Length} characters long" +
                          Environment.NewLine;
            });

            return result;
        }

        public static string ExecuteNormal(ProgressBar progressBar, TextBox textBox)
        {
            textBox.Text = string.Empty;
            foreach (var websiteUrl in WebsiteUrls)
            {
                var website = DownloadWebsite(websiteUrl);
                progressBar.Increment(ValuePerWebsite);
                textBox.Text += $@"{websiteUrl} downloaded: {website.WebsiteData.Length} characters long" +
                                Environment.NewLine;
            }

            return textBox.Text;
        }

        public static async Task<string> ExecuteAsync(ProgressBar progressBar, TextBox textBox)
        {
            textBox.Text = string.Empty;
            var tasks = WebsiteUrls
                .Select(DownloadWebsiteAsync)
                .ToList();

            for (var i = 0; i < WebsiteUrls.Count; i++)
            {
                var website = await Task.WhenAny(tasks);
                progressBar.Increment(ValuePerWebsite);
                textBox.Text +=
                    $@"{website.Result.WebsiteUrl} downloaded: {website.Result.WebsiteData.Length} characters long" +
                    Environment.NewLine;
                tasks.Remove(website);
            }

            return textBox.Text;
        }

        public static async Task<string> ExecuteParallelAsync(ProgressBar progressBar)
        {
            var result = string.Empty;

            await Task.Run(() =>
            {
                Parallel.ForEach(WebsiteUrls, websiteUrl =>
                {
                    var website = DownloadWebsite(websiteUrl);
                    progressBar.Increment(ValuePerWebsite);
                    result += $@"{website.WebsiteUrl} downloaded: {website.WebsiteData.Length} characters long" +
                              Environment.NewLine;
                });
            });

            return result;
        }

        private static async Task<Website> DownloadWebsiteAsync(string website)
        {
            return await Task.Run(() =>
            {
                var data = DownloadWebsite(website);
                return data;
            });
        }

        private static Website DownloadWebsite(string websiteUrl)
        {
            var webClient = new WebClient();
            var result = new Website(websiteUrl, webClient.DownloadString(websiteUrl));
            return result;
        }
    }
}