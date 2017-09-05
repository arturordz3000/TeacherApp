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
        IHttpClientResponse Post(string endpoint, object parameters);
        IHttpClientResponse Get(string endpoint);
    }
}
