using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Handlers
{
    public interface IExceptionHandler
    {
        void HandleException(object sender, Exception ex);
    }
}
