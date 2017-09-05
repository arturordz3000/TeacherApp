using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class RequestFailedException : Exception
    {
        public RequestFailedException(string endpoint)
            : base(string.Format("Request to the endpoint {0} has failed.", endpoint))
        {

        }
    }
}
