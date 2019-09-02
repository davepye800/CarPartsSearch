using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Model.Bing;
using SearchEngine.Model.Google;
using SearchEngine.Data;
using Newtonsoft.Json;
using System.Configuration;
using SearchEngine.Interface;

namespace SearchEngine.Domain
{
    public class DomainLogic
    {
        private IApiIntegrator m_apiIntegrator;
        public DomainLogic(IApiIntegrator apiIntegrator)
        {
            m_apiIntegrator = apiIntegrator;
        }
        public async Task<T> Search<T>(string searchTerm
                                        , string paramatersConfigKey
                                        , string headersConfigKey
                                        , string apiConfigKey)
        {
            Dictionary<string, string> parameterValues = (Dictionary<string, string>)JsonConvert.DeserializeObject(ConfigurationManager.AppSettings[paramatersConfigKey], typeof(Dictionary<string, string>));
            parameterValues.Add("q", searchTerm);
            Dictionary<string, string> headerValues = (Dictionary<string, string>)JsonConvert.DeserializeObject(ConfigurationManager.AppSettings[headersConfigKey], typeof(Dictionary<string, string>));
            var result = await m_apiIntegrator.Search(parameterValues, headerValues, ConfigurationManager.AppSettings[apiConfigKey]);
            var stringResult = await result.Content.ReadAsStringAsync();
            return (T)JsonConvert.DeserializeObject(stringResult, typeof(T));
        }
    }
}
