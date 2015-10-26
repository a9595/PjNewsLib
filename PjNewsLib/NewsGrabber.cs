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
        public static async Task<NewsObject> GetNewsByUrl(string url)
        {
            using (HttpClient hClient = new HttpClient())
            {
                HttpResponseMessage response = await hClient.GetAsync(url);
                string strContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NewsObject>(strContent);
            }

        }

        public static NewsObject GetArticleSimply(string url)
        {
            var httpClient = new HttpClient();
            var payload = httpClient.GetStringAsync(url).Result;

            var sampleResponse = JsonConvert.DeserializeObject<NewsObject>(payload,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            return sampleResponse;
        }
    }

}
