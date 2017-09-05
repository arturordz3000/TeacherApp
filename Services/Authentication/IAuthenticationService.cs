using Services.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication
{
    interface IAuthenticationService
    {
        Token Authenticate(string user, string password);
    }
}
