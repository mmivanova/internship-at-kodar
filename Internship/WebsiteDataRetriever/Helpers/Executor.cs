using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsiteDataRetriever.Helpers
{
    public static class Executor
    {
        private const int ValuePerWebsite = 100 / 12;

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

        public static string ExecuteParallel(ProgressBar progressBar)
        {
            var result = string.Empty;
            Parallel.ForEach(Websites, website =>
            {
                var characters = DownloadWebsite(website);
                progressBar.Increment(ValuePerWebsite);
                result += $@"{website} downloaded: {characters.Length} characters long" + Environment.NewLine;
            });

            return result;
        }

        public static string ExecuteNormal(ProgressBar progressBar)
        {
            var result = string.Empty;
            foreach (var website in Websites)
            {
                var characters = DownloadWebsite(website);
                progressBar.Increment(ValuePerWebsite);
                result += $@"{website} downloaded: {characters.Length} characters long" + Environment.NewLine;
            }

            return result;
        }

        public static async Task<string> ExecuteAsync(ProgressBar progressBar)
        {
            var result = string.Empty;
            foreach (var website in Websites)
            {
                var data = await GetWebsiteDataAsync(website);
                progressBar.Increment(ValuePerWebsite);
                result += $@"{website} downloaded: {data.Length} characters long" + Environment.NewLine;
            }
            
            return result;
        }

        public static async Task<string> ExecuteParallelAsync(ProgressBar progressBar)
        {
            // var data = Task.Run((() =>
            // {
            //     var result = string.Empty;
            //     Parallel.ForEach(Websites,  website =>
            //     {
            //         var data = GetWebsiteData(website);
            //         progressBar.Increment(ValuePerWebsite);
            //         result += $@"{website} downloaded: {data.Result.Length} characters long" + Environment.NewLine;
            //     });
            //     return result;
            // }));
            //
            var result = string.Empty;
            Parallel.ForEach(Websites, async website =>
            {
                var data = await GetWebsiteDataAsync(website);
                progressBar.Increment(ValuePerWebsite);
                result += $@"{website} downloaded: {data.Length} characters long" + Environment.NewLine;
            });
            
            // var result = string.Empty;
            // foreach (var website in Websites.AsParallel())
            // {
            //     var data = await GetWebsiteData(website);
            //     progressBar.Increment(ValuePerWebsite);
            //     result += $@"{website} downloaded: {data.Length} characters long" + Environment.NewLine;
            // }

            return result;
        }
        
        private static Task<string> GetWebsiteDataAsync(string website)
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
    }
}