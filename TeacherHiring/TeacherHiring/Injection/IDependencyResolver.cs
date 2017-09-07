using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiring.Injection
{
    public interface IDependencyResolver
    {
        T Resolve<T>();
    }
}
