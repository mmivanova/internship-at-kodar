using System.Collections.Generic;

namespace WebsiteDataRetriever.Data
{
    public class Website
    {
        public string WebsiteUrl { get; set; }
        public string WebsiteData { get; set; }

        public Website(string websiteUrl, string websiteData)
        {
            WebsiteUrl = websiteUrl;
            WebsiteData = websiteData;
        }

        public Website()
        {
            
        }
        public static List<string> GetWebsiteUrls()
        {
            var websites = new List<string>
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

            return websites;
        }
    }
}