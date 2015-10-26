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
            var payload = httpClient.GetStringAsync(url).Result;

            var sampleResponse = JsonConvert.DeserializeObject<Article>(payload,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            return sampleResponse;
        }



    }

}
