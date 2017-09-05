using Newtonsoft.Json;
using Services.Http.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Http.Responses
{
    public class HttpClientResponse : IHttpClientResponse
    {
        private Dictionary<string, string> headers;
        private string content;
        private bool isSuccessfulResponse;

        public HttpClientResponse(string content, Dictionary<string, string> headers, bool isSuccessfulResponse)
        {
            this.content = content;
            if (this.content == null)
                throw new ArgumentNullException("content");

            this.headers = headers;
            if (this.headers == null)
                throw new ArgumentNullException("headers");

            this.isSuccessfulResponse = isSuccessfulResponse;
        }

        public string GetContent()
        {
            return content;
        }

        public T GetContentAsObject<T>()
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public string GetHeader(string name)
        {
            if (headers.ContainsKey(name))
                return headers[name];

            throw new KeyNotFoundException("Header with name \"" + name + "\" does not exist in this response.");
        }

        public bool IsSuccessfulResponse()
        {
            return isSuccessfulResponse;
        }
    }
}
