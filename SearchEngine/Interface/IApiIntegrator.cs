using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace SearchEngine.Interface
{
    public interface IApiIntegrator
    {
        Task<HttpResponseMessage> Search(IDictionary<string, string> parameterValues
                                            , IDictionary<string, string> headerValues
                                            , string searchEngine);
    }
}

