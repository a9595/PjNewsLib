using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace TMPDataBidningTestingToListView.Model
{
    public class NewsItem
    {
        public override string ToString()
        {
            return Date + "  " + LinkTitle;
        }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("link/_text")]
        public string LinkText { get; set; }

        [JsonProperty("link/_source")]
        public string LinkSource { get; set; }

        [JsonProperty("link/_title")]
        public string LinkTitle { get; set; }
        
        public Article ArticleItem { get; }

        public NewsItem()
        {
            ArticleItem = Article.GetArticleSimply(Link);
            
        }

    }
    
    public class OutputProperty
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class News
    {
        public News()
        {
            var news = News.GetNews();
            Results = news.Results;
            ConnectorGuid = news.ConnectorGuid;
        }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("results")]
        public ObservableCollection<NewsItem> Results { get; set; }

        [JsonProperty("cookies")]
        public IList<string> Cookies { get; set; }

        [JsonProperty("connectorVersionGuid")]
        public string ConnectorVersionGuid { get; set; }

        [JsonProperty("connectorGuid")]
        public string ConnectorGuid { get; set; }

        [JsonProperty("pageUrl")]
        public string PageUrl { get; set; }

        [JsonProperty("outputProperties")]
        public IList<OutputProperty> OutputProperties { get; set; }

        public string GetAllNewsTitlesString()
        {
            
            string result = "";

            foreach (var rez in Results)
            {
                result = result + rez.Date + "  " + rez.LinkText + "\n";
            }

            return result;
        }

        


        public static string _urlNews =
            "https://api.import.io/store/data/ac6a058d-2785-42b6-b1d9-b20c4d48c8f7/_query?input/webpage/url=http%3A%2F%2Fwww.pja.edu.pl%2Faktualnosci%2Fglowna&_user=ac4a2596-0302-46ee-a01a-153a5b50f8bf&_apikey=ac4a2596030246eea01a153a5b50f8bf8d83fcfebeb20555e1c978bf8baa34cc8783b48aa9648c98236227aa39e38c716a3280346535778f39005f54d0a00eb45cdf4387ab49e5af783d95afa60b5c37";

        public static News GetNews()
        {
            var httpClient = new HttpClient();
            var payload = httpClient.GetStringAsync(_urlNews).Result;
            var news = JsonConvert.DeserializeObject<News>(payload,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            return news;
        }
    }


}