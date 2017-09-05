using Services.Authentication.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Authentication.Models;

namespace Services.Authentication.Providers
{
    public class SqliteTokenProvider : ITokenProvider
    {
        public Token GetToken()
        {
            throw new NotImplementedException();
        }

        public void SaveToken(Token token)
        {
            throw new NotImplementedException();
        }
    }
}
