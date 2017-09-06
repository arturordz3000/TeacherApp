using Services.Authentication.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Authentication.Models;
using Services.Exceptions;

namespace Services.Authentication.Providers
{
    public class TokenProvider : ITokenProvider
    {
        private IStorage storage;

        public TokenProvider(IStorage storage)
        {
            this.storage = storage;
        }

        public Token GetToken()
        {
            if (!tokenIsProvided())
                return null;

            Token token = new Token
            {
                AccessValue = (string)storage.Get("token"),
                ExpirySeconds = (int)storage.Get("tokenexpiry")
            };

            validateToken(token, (DateTime)storage.Get("tokendatetime"));

            return token;
        }

        private bool tokenIsProvided()
        {
            return storage.Get("token") != null 
                && storage.Get("tokenexpiry") != null 
                && storage.Get("tokendatetime") != null;
        }

        private void validateToken(Token token, DateTime tokenDateTime)
        {
            double deltaSeconds = (DateTime.Now - tokenDateTime).TotalSeconds;

            if (deltaSeconds >= token.ExpirySeconds)
                throw new TokenExpiredException();
        }

        public void SaveToken(Token token)
        {
            if (token == null)
                throw new ArgumentNullException("token");

            storage.Save("token", token.AccessValue);
            storage.Save("tokenexpiry", token.ExpirySeconds);
            storage.Save("tokendatetime", DateTime.Now);
        }
    }
}
