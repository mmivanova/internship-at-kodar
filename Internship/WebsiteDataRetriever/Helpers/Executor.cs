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
                WriteWebsiteData(website, ref result);
            });

            return result;
        }

        public static string ExecuteNormal(ProgressBar progressBar)
        {
            var result = string.Empty;
            foreach (var website in WebsiteUrls.Select(DownloadWebsite))
            {
                progressBar.Increment(ValuePerWebsite);
                WriteWebsiteData(website, ref result);
            }

            return result;
        }

        public static async Task<string> ExecuteAsync(ProgressBar progressBar)
        {
            var result = string.Empty;
            var tasks = WebsiteUrls
                .Select(DownloadWebsiteAsync)
                .ToList();

            for (var i = 0; i < WebsiteUrls.Count; i++)
            {
                var website = await Task.WhenAny(tasks);
                progressBar.Increment(ValuePerWebsite);
                WriteWebsiteData(website.Result, ref result);
                tasks.Remove(website);
            }
            
            return result;
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
                    WriteWebsiteData(website, ref result);
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

        private static void WriteWebsiteData(Website website, ref string text)
        {
            text +=
                $@"{website.WebsiteUrl} downloaded: {website.WebsiteData.Length} characters long {Environment.NewLine}";
        }

        private static Website DownloadWebsite(string websiteUrl)
        {
            var webClient = new WebClient();
            var result = new Website(websiteUrl, webClient.DownloadString(websiteUrl));
            return result;
        }
    }
}