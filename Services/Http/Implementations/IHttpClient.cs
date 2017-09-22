using Services.Authentication.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Http.Implementations
{
    public interface IHttpClient
    {
        ITokenProvider GetTokenProvider();
        Task<IHttpClientResponse> Post(string endpoint, object parameters, bool requiresAuthentication = true);
        Task<IHttpClientResponse> Get(string endpoint, bool requiresAuthentication = true);
    }
}
