using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Authentication
{
    public class Token
    {
        public string AccessValue { get; set; }
        public long ExpirySeconds { get; set; }
    }
}
