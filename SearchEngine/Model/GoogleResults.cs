using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SearchEngine.Model.Google
{
    public class Url
    {
        public string type { get; set; }
        public string template { get; set; }
    }

    public class Request
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class NextPage
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class Queries
    {
        public Queries()
        {
            request = new List<Request>();
            nextPage = new List<NextPage>(0);
        }
        public List<Request> request { get; set; }
        public List<NextPage> nextPage { get; set; }
    }

    public class Context
    {
        public string title { get; set; }
    }

    public class SearchInformation
    {
        public double searchTime { get; set; }
        public string formattedSearchTime { get; set; }
        public string totalResults { get; set; }
        public string formattedTotalResults { get; set; }
    }

    public class Metatag
    {
        public string viewport { get; set; }
        [JsonProperty(PropertyName = "msvalidate.01")]
        public string msvalidate01 { get; set; }
        [JsonProperty(PropertyName = "og:url")]
        public string ogurl { get; set; }
        [JsonProperty(PropertyName = "og:title")]
        public string ogtitle { get; set; }
        [JsonProperty(PropertyName = "og:description")]
        public string ogdescription { get; set; }
        [JsonProperty(PropertyName = "og:image")]
        public string ogimage { get; set; }
        [JsonProperty(PropertyName = "format-detection")]
        public string formatdetection { get; set; }
        [JsonProperty(PropertyName = "og:site_name")]
        public string ogsite_name { get; set; }
        public string referrer { get; set; }
        public string y_key { get; set; }
        [JsonProperty(PropertyName = "fb:app_id")]
        public string fbapp_id { get; set; }
        [JsonProperty(PropertyName = "og:type")]
        public string ogtype { get; set; }
    }

    public class CseThumbnail
    {
        public string width { get; set; }
        public string height { get; set; }
        public string src { get; set; }
    }

    public class Rating
    {
        public string average { get; set; }
        public string best { get; set; }
    }

    public class Breadcrumb
    {
        public string url { get; set; }
        public string title { get; set; }
    }

    public class ReviewAggregate
    {
        public string votes { get; set; }
        public string itemreviewed { get; set; }
    }

    public class CseImage
    {
        public string src { get; set; }
    }

    public class Review
    {
        public string reviewbody { get; set; }
        public string datepublished { get; set; }
    }

    public class Pagemap
    {
        public Pagemap()
        {
            metatags = new List<Metatag>();
            cseThumbnailList = new List<CseThumbnail>();
            rating = new List<Rating>();
            breadcrumb = new List<Breadcrumb>();
            reviewAggregateList = new List<ReviewAggregate>();
            cse_image = new List<CseImage>();
            review = new List<Review>();
        }
        public List<Metatag> metatags { get; set; }
        public List<CseThumbnail> cseThumbnailList { get; set; }
        public List<Rating> rating { get; set; }
        public List<Breadcrumb> breadcrumb { get; set; }
        public List<ReviewAggregate> reviewAggregateList { get; set; }
        public List<CseImage> cse_image { get; set; }
        public List<Review> review { get; set; }
    }

    public class Item
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string htmlTitle { get; set; }
        public string link { get; set; }
        public string displayLink { get; set; }
        public string snippet { get; set; }
        public string htmlSnippet { get; set; }
        public string cacheId { get; set; }
        public string formattedUrl { get; set; }
        public string htmlFormattedUrl { get; set; }
        public Pagemap pagemap { get; set; }
    }

    public class GoogleSearchResults
    {
        public GoogleSearchResults()
        {
            items = new List<Item>();
        }
        public string kind { get; set; }
        public Url url { get; set; }
        public Queries queries { get; set; }
        public Context context { get; set; }
        public SearchInformation searchInformation { get; set; }
        public List<Item> items { get; set; }
    }
}
