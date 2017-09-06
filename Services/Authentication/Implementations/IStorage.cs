using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication.Implementations
{
    public interface IStorage
    {
        object Get(object query);
        void Save(params object[] obj);
    }
}
