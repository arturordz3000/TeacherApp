using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Implementations;
using Xamarin.Forms;

namespace DataAccess
{
    public class AppPropertiesStorage : IStorage
    {
        private IDictionary<string, object> properties;

        public AppPropertiesStorage(IDictionary<string, object> properties)
        {
            this.properties = properties;
        }

        public object Get(object query)
        {
            string key = (string)query;

            if (properties.ContainsKey(key))
                return properties[key];
            else return null;
        }

        public void Save(params object[] obj)
        {
            string key = (string)obj[0];
            object value = obj[1];

            if (properties.ContainsKey(key))
                properties[key] = value;
            else
                properties.Add(key, value);
        }

        public int Delete(object query)
        {
            throw new NotImplementedException();
        }
    }
}
