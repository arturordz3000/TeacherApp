using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Http.Implementations
{
    public interface IHttpClientResponse
    {
        string GetContent();
        T GetContentAsObject<T>();
        string GetHeader(string name);
        bool IsSuccessfulResponse();
    }
}
