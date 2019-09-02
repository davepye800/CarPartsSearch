using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SearchEngine;
using System.Net.Http;
using SearchEngine.Model.Google;
using SearchEngine.Model.Bing;
using Newtonsoft.Json;
using SearchEngine.Domain;
using CarPartsSearch.Model;
using System.IO;
using System.Configuration;
using SearchEngine.Data;
namespace CarPartsSearch.Controllers
{
    public class PartoogleController : Controller
    {
        public ActionResult InitialSearch()
        {
            return View("Search");
        }

        public ActionResult Results()
        {
            return View();
        }

        public async Task<ActionResult> PostSearch(string searchTerm, string searchMode)
        {
            SearchResults result = await Search(searchTerm, searchMode);
            return View("Results", result);
        }

        public async Task<JsonResult> AjaxSearch(string searchTerm, string searchMode)
        {
            SearchResults result = await Search(searchTerm, searchMode);
            return Json(result.SearchResultList);
        }

        private SearchResults PackageResults(GoogleSearchResults gsr, BingSearchResults bsr)
        {
            SearchResults results = new SearchResults();
            foreach (SearchEngine.Model.Google.Item item in gsr.items)
            {
                SearchResult result = new SearchResult();
                result.Name = item.title;
                result.DisplayUrl = item.formattedUrl;
                result.Url = item.formattedUrl;
                result.Snippet = item.snippet;
                result.Source = "Google";
                results.SearchResultList.Add(result);
            }

            foreach (SearchEngine.Model.Bing.Value item in bsr.webPages.value)
            {
                SearchResult result = new SearchResult();
                result.Name = item.name;
                result.DisplayUrl = item.displayUrl;
                result.Url = item.url;
                result.Snippet = item.snippet;
                result.Source = "Bing";
                results.SearchResultList.Add(result);
            }
            results.SearchResultList = results.SearchResultList.OrderBy(x => x.Name).ToList();
            return results;
        }

        private async Task<SearchResults> Search(string searchTerm, string searchMode)
        {
            GoogleSearchResults gsr = new GoogleSearchResults();
            BingSearchResults bsr = new BingSearchResults();
            DomainLogic dl = new DomainLogic(new ApiIntegrator());
            switch (searchMode)
            {
                case "all":
                    gsr = await dl.Search<GoogleSearchResults>(searchTerm
                                                                , "googleApiParameterConfig"
                                                                , "googleApiHeaderConfig"
                                                                , "googleApi");
                    bsr = await dl.Search<BingSearchResults>(searchTerm
                                                                , "bingApiParameterConfig"
                                                                , "bingApiHeaderConfig"
                                                                , "bingApi");
                    break;
                case "google":
                    gsr = await dl.Search<GoogleSearchResults>(searchTerm
                                                                , "googleApiParameterConfig"
                                                                , "googleApiHeaderConfig"
                                                                , "googleApi");
                    break;
                case "bing":
                    bsr = await dl.Search<BingSearchResults>(searchTerm
                                                                , "bingApiParameterConfig"
                                                                , "bingApiHeaderConfig"
                                                                , "bingApi");
                    break;
            }
            return PackageResults(gsr, bsr);
        }
    }
}