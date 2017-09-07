using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Implementations;

namespace DataAccess
{
    public class AppPropertiesStorage : IStorage
    {
        public object Get(object query)
        {
            string key = (string)query;

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(key))
                return Xamarin.Forms.Application.Current.Properties[key];
            else return null;
        }

        public void Save(params object[] obj)
        {
            string key = (string)obj[0];
            object value = obj[1];

            Xamarin.Forms.Application.Current.Properties.Add(key, value);
        }

        public int Delete(object query)
        {
            throw new NotImplementedException();
        }
    }
}
