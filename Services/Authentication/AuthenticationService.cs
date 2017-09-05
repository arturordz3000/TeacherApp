﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Http;
using System.Net.Http;
using Services.Exceptions;
using Services.Http.Resolvers;
using Services.Http.Implementations;
using Services.Authentication.Models;

namespace Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpClient httpClient;
        private EndpointResolver endpointResolver;

        public AuthenticationService(IHttpClient httpClient, EndpointResolver endpointResolver)
        {
            this.httpClient = httpClient;
            this.endpointResolver = endpointResolver;
        }

        public Token Authenticate(string user, string password)
        {
            string endpoint = endpointResolver.ResolveUrl("Authenticate", "Authenticate");
            IHttpClientResponse response = httpClient.Post(endpoint, new { ClaveAcceso = user, Contrasena = password });

            validateResponse(endpoint, response);

            string accessValue = response.GetHeader("token");
            long expirySeconds = long.Parse(response.GetHeader("tokenexpiry"));

            return new Token { AccessValue = accessValue, ExpirySeconds = expirySeconds };
        }

        private void validateResponse(string endpoint, IHttpClientResponse response)
        {
            if (!response.IsSuccessfulResponse())
            {
                if (response.GetContent() == "Not User Found")
                    throw new InvalidCredentialsException();

                throw new RequestFailedException(endpoint);
            }
        }
    }
}
