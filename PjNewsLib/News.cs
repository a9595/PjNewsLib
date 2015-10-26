using System.Collections.Generic;

namespace PjNewsLib
{
    public class NewsResult
    {
        public string date { get; set; }
        public string link { get; set; }
        public string link_text { get; set; }
        public string link_source { get; set; }
        public string link_title { get; set; }
    }

    public class OutputProperty
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class News
    {
        public int offset { get; set; }
        public IList<NewsResult> results { get; set; }
        public IList<string> cookies { get; set; }
        public string connectorVersionGuid { get; set; }
        public string connectorGuid { get; set; }
        public string pageUrl { get; set; }
        public IList<OutputProperty> outputProperties { get; set; }


        public string GetAllNewsTitlesString()
        {
            string result = "";

            foreach (var rez in results)
            {
                result = result + rez.link_title + "\n";
            }

            return result;
        }
    }


}