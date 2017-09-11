using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Sqlite
{
    public class SqliteStorage : ICacheStorage
    {
        public int Delete(object query)
        {
            throw new NotImplementedException();
        }

        public object Get(object query)
        {
            throw new NotImplementedException();
        }

        public void Save(params object[] obj)
        {
            throw new NotImplementedException();
        }
    }
}
