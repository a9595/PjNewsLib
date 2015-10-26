using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace PjNewsLib
{
    public class NewsObject
    {
        public int offset { get; set; }
        public IList<Result> results { get; set; }
        public IList<string> cookies { get; set; }
        public string connectorVersionGuid { get; set; }
        public string connectorGuid { get; set; }
        public string pageUrl { get; set; }
        //public IList<OutputProperty> outputProperties { get; set; }

        public string GetTitle()
        {
            return results.First().title;
        }
        public string GetContent()
        {

            //string delimeter = ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,";
            //results.First().content.Aggregate((i, j) => i + delimeter + j);

            var allContent = "";
            foreach (var str in results.First().content)
            {
                allContent = allContent + str + "\n";
            }

            return allContent;
        }

        public async Task<BitmapImage> GetHeaderImage()
        {
            var httpClient = new HttpClient();
            var contentBytes = await httpClient.GetByteArrayAsync(results.First().header_img);
            var ims = new InMemoryRandomAccessStream();
            var dataWriter = new DataWriter(ims);
            dataWriter.WriteBytes(contentBytes);
            await dataWriter.StoreAsync();
            ims.Seek(0);

            var bitmap = new BitmapImage();
            bitmap.SetSource(ims);

            getHeaderImageUrl();

            return bitmap;
        }

        public string getHeaderImageUrl()
        {
            return results.First().header_img;
        }
    }

    public class Result
    {
        //public string header_img_alt { get; set; }
        public string header_img { get; set; }
        //public string header_img_source { get; set; }
        public string title { get; set; }
        public IList<string> content { get; set; }
    }

}