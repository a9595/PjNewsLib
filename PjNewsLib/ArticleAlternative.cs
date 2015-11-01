using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json;

namespace PjNewsLib
{
    public class Result
    {

        [JsonProperty("header_img/_alt")]
        public string HeaderImgAlt { get; set; }

        [JsonProperty("header_img")]
        public string HeaderImg { get; set; }

        [JsonProperty("header_img/_source")]
        public string HeaderImgSource { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public IList<string> Content { get; set; }
    }

    public class OutputPropertyAlternative
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class ArticleAlternative
    {

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("results")]
        public IList<Result> Results { get; set; }

        [JsonProperty("cookies")]
        public IList<string> Cookies { get; set; }

        [JsonProperty("connectorVersionGuid")]
        public string ConnectorVersionGuid { get; set; }

        [JsonProperty("connectorGuid")]
        public string ConnectorGuid { get; set; }

        [JsonProperty("pageUrl")]
        public string PageUrl { get; set; }

        [JsonProperty("outputProperties")]
        public IList<OutputPropertyAlternative> OutputProperties { get; set; }



        #region Methods added by me

        public string GetTitle()
        {
            return Results.First().Title;
        }

        public string GetContent()
        {

            //string delimeter = ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,";
            //results.First().content.Aggregate((i, j) => i + delimeter + j);

            var allContent = "";
            foreach (var str in Results.First().Content)
            {
                allContent = allContent + str + "\n";
            }

            return allContent;
        }

        public async Task<BitmapImage> GetHeaderImage()
        {
            var httpClient = new HttpClient();
            var contentBytes = await httpClient.GetByteArrayAsync(Results.First().HeaderImg);
            var ims = new InMemoryRandomAccessStream();
            var dataWriter = new DataWriter(ims);
            dataWriter.WriteBytes(contentBytes);
            await dataWriter.StoreAsync();
            ims.Seek(0);

            var bitmap = new BitmapImage();
            bitmap.SetSource(ims);

            GetHeaderImageUrl();

            return bitmap;
        }
        public string GetHeaderImageUrl()
        {
            return Results.First().HeaderImg;
        }


        #endregion
    }
}
