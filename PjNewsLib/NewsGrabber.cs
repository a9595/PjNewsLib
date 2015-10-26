using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PjNewsLib
{
    public class NewsGrabber
    {

        private static string _urlNews =
            "https://api.import.io/store/data/ac6a058d-2785-42b6-b1d9-b20c4d48c8f7/_query?input/webpage/url=http%3A%2F%2Fwww.pja.edu.pl%2Faktualnosci%2Fglowna&_user=ac4a2596-0302-46ee-a01a-153a5b50f8bf&_apikey=ac4a2596030246eea01a153a5b50f8bf8d83fcfebeb20555e1c978bf8baa34cc8783b48aa9648c98236227aa39e38c716a3280346535778f39005f54d0a00eb45cdf4387ab49e5af783d95afa60b5c37";

        public static Article GetArticleSimply(string url)
        {
            var httpClient = new HttpClient();
            var payload = httpClient.GetStringAsync(url).Result;

            var sampleResponse = JsonConvert.DeserializeObject<Article>(payload,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            return sampleResponse;
        }


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
