using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchEngine.Model.Bing
{
    public class QueryContext
    {
        public string originalQuery { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public bool isFamilyFriendly { get; set; }
        public string displayUrl { get; set; }
        public string snippet { get; set; }
        public string language { get; set; }
        public bool isNavigational { get; set; }
        public DateTime? dateLastCrawled { get; set; }
    }

    public class WebPages
    {
        public WebPages()
        {
            value = new List<Value>();
        }
        public string webSearchUrl { get; set; }
        public int totalEstimatedMatches { get; set; }
        public List<Value> value { get; set; }
    }

    public class Thumbnail
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Value2
    {
        public string webSearchUrl { get; set; }
        public string name { get; set; }
        public string thumbnailUrl { get; set; }
        public DateTime datePublished { get; set; }
        public string contentUrl { get; set; }
        public string hostPageUrl { get; set; }
        public string contentSize { get; set; }
        public string encodingFormat { get; set; }
        public string hostPageDisplayUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Thumbnail thumbnail { get; set; }
    }

    public class Images
    {
        public Images()
        {
            value = new List<Value2>();
        }
        public string id { get; set; }
        public string readLink { get; set; }
        public string webSearchUrl { get; set; }
        public bool isFamilyFriendly { get; set; }
        public List<Value2> value { get; set; }
    }

    public class Value3
    {
        public string id { get; set; }
    }

    public class Item
    {
        public string answerType { get; set; }
        public int resultIndex { get; set; }
        public Value3 value { get; set; }
    }

    public class Mainline
    {
        public Mainline()
        {
            items = new List<Item>();
        }
        public List<Item> items { get; set; }
    }

    public class RankingResponse
    {
        public Mainline mainline { get; set; }
    }

    public class BingSearchResults
    {
        public BingSearchResults()
        {
            webPages = new WebPages();
        }
        public string _type { get; set; }
        public QueryContext queryContext { get; set; }
        public WebPages webPages { get; set; }
        public Images images { get; set; }
        public RankingResponse rankingResponse { get; set; }
    }
}