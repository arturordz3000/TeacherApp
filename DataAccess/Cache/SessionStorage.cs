using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Cache
{
    public class SessionStorage : ICacheStorage
    {
        private static Dictionary<string, object> sessionItems = new Dictionary<string, object>();

        public object Get(string query)
        {
            return sessionItems.ContainsKey(query) ? sessionItems[query] : null;
        }

        public void Save(string key, object value)
        {
            if (sessionItems.ContainsKey(key))
                sessionItems[key] = value;
            else
                sessionItems.Add(key, value);
        }

        public int Delete(string query)
        {
            throw new NotImplementedException();
        }
    }
}
