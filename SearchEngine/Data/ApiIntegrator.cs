using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using SearchEngine.Interface;

namespace SearchEngine.Data
{
    public class ApiIntegrator : IApiIntegrator
    {
        public async Task<HttpResponseMessage> Search(IDictionary<string, string> parameterValues
                                                        , IDictionary<string, string> headerValues
                                                        , string searchEngine)
        {
            HttpClient client = new HttpClient();
            foreach (KeyValuePair<string, string> headerValue in headerValues)
            {
                client.DefaultRequestHeaders.Add(headerValue.Key, headerValue.Value);
            }
            var builder = new UriBuilder(searchEngine);
            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach (KeyValuePair<string, string> parameterValue in parameterValues)
            {
                query[parameterValue.Key] = parameterValue.Value;
            }
            builder.Query = query.ToString();
            string url = builder.ToString();
            HttpResponseMessage response = await client.GetAsync(url);
            client.Dispose();
            return response;
        }
    }
}
