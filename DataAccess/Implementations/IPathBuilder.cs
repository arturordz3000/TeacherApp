using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public interface IPathBuilder
    {
        string Build(string fileName);
    }
}
