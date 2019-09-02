using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine.Model.Google;
using SearchEngine.Model.Bing;
using SearchEngine.Domain;
using SearchEngine.Data;
using System.Threading.Tasks;

namespace SearchEngineTests
{
    [TestClass]
    public class TestSearchEngine
    {
        [TestMethod]
        public async Task GoogleSearchTest()
        {
            DomainLogic dl = new DomainLogic(new ApiIntegrator());
            GoogleSearchResults gsr = new GoogleSearchResults();
            gsr = await dl.Search<GoogleSearchResults>("lambda"
                                                        , "googleApiParameterConfig"
                                                        , "googleApiHeaderConfig"
                                                        , "googleApi");
            Assert.IsTrue(gsr.items.Count > 0);
        }

        [TestMethod]
        public async Task BingSearchTest()
        {
            DomainLogic dl = new DomainLogic(new ApiIntegrator());
            BingSearchResults bsr = new BingSearchResults();
            bsr = await dl.Search<BingSearchResults>("lambda"
                                                        , "bingApiParameterConfig"
                                                        , "bingApiHeaderConfig"
                                                        , "bingApi");
            Assert.IsTrue(bsr.webPages.value.Count > 1);
        }
    }
}
