using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public interface IStorage
    {
        object Get(object query);
        void Save(params object[] obj);
        int Delete(object query);
    }
}
