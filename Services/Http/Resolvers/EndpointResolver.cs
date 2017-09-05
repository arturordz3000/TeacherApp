using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Http.Resolvers
{
    public class EndpointResolver
    {
        private string baseUrl;

        public EndpointResolver(string baseUrl)
        {
            this.baseUrl = baseUrl;
            if (this.baseUrl == null)
                throw new ArgumentNullException("baseUrl");
        }

        public virtual string ResolveUrl(string action, string controller = null)
        {
            if (string.IsNullOrEmpty(action))
                throw new ArgumentException("The \"action\" parameter can't be null nor empty");

            return string.IsNullOrEmpty(controller) ?
                string.Format("{0}/{1}", baseUrl, action) : string.Format("{0}/{1}/{2}", baseUrl, controller, action);
        }
    }
}