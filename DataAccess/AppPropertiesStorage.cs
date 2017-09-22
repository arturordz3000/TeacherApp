using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Implementations;
using Xamarin.Forms;

namespace DataAccess
{
    public class AppPropertiesStorage : ICacheStorage
    {
        private IDictionary<string, object> properties;

        public AppPropertiesStorage(IDictionary<string, object> properties)
        {
            this.properties = properties;
        }

        public object Get(string query)
        {
            if (properties.ContainsKey(query))
                return properties[query];
            else return null;
        }

        public void Save(string key, object value)
        {
            if (properties.ContainsKey(key))
                properties[key] = value;
            else
                properties.Add(key, value);
        }

        public int Delete(string query)
        {
            if (properties.ContainsKey(query))
                properties.Remove(query);

            return 1;
        }
    }
}
