using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication.Models
{
    public class Token
    {
        public string AccessValue { get; set; }
        public int ExpirySeconds { get; set; }
    }
}
