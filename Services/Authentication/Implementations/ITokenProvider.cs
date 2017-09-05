using Services.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication.Implementations
{
    public interface ITokenProvider
    {
        Token GetToken();
        void SaveToken(Token token);
    }
}
