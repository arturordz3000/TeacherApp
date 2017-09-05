using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Http
{
    public class HttpClientResponse
    {
        public object Content { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
