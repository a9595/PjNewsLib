using System.Collections.Generic;
using Newtonsoft.Json;

namespace PjNewsLib
{
    public class Result
    {

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
    }


}