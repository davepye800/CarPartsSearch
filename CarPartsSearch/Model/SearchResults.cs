using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CarPartsSearch.Model
{
    public class SearchResults
    {
        public SearchResults()
        {
            SearchResultList = new List<SearchResult>();
        }
        public List<SearchResult> SearchResultList { get; set; }
    }

    public class SearchResult
    {
        public string Name { get; set; }
        public string DisplayUrl { get; set; }
        public string Url { get; set; }
        public string Snippet { get; set; }
        public string Source { get; set; }
    }
}