using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebsiteDataRetriever.Data;

namespace WebsiteDataRetriever.Helpers
{
    public static class Executor
    {
        private static readonly List<string> WebsiteUrls = Website.GetWebsiteUrls();

        public static List<Website> ExecuteNormal()
        {
            return WebsiteUrls.Select(DownloadWebsite).ToList();
        }

        public static List<Website> ExecuteParallel()
        {
            var result = new List<Website>();
            Parallel.ForEach(WebsiteUrls, websiteUrl =>
            {
                var website = DownloadWebsite(websiteUrl);
                result.Add(website);
            });

            return result;
        }

        public static async Task<List<Website>> ExecuteAsync()
        {
            var result = new List<Website>();
            
            foreach (var websiteUrl in WebsiteUrls)
            {
                var website = await DownloadWebsiteAsync(websiteUrl);
                result.Add(website);
            }

            return result;
        }

        public static async Task<List<Website>> ExecuteParallelAsync()
        {
            var tasks = WebsiteUrls
                .Select(DownloadWebsiteAsync)
                .ToList();

            var result = await Task.WhenAll(tasks);

            return new List<Website>(result);
        }

        private static async Task<Website> DownloadWebsiteAsync(string websiteUrl)
        {
            var webClient = new WebClient();
            var result = new Website
            {
                WebsiteUrl = websiteUrl,
                WebsiteData = await webClient.DownloadStringTaskAsync(websiteUrl)
            };

            return result;
        }

        private static Website DownloadWebsite(string websiteUrl)
        {
            var webClient = new WebClient();
            var result = new Website(websiteUrl, webClient.DownloadString(websiteUrl));
            return result;
        }
    }
}