﻿using Newtonsoft.Json;
using Services.Authentication.Implementations;
using Services.Authentication.Models;
using Services.Exceptions;
using Services.Http.Implementations;
using Services.Http.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.Http.Clients
{
    public class RestClient : IHttpClient
    {
        private HttpClient client;
        private ITokenProvider tokenProvider;

        public RestClient(ITokenProvider tokenProvider)
        {
            client = initializeClient();
            this.tokenProvider = tokenProvider;
        }

        private HttpClient initializeClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public async Task<IHttpClientResponse> Get(string endpoint, bool requiresAuthentication = true)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            Token token = requiresAuthentication ? tokenProvider.GetToken() : null;

            if (token != null && !string.IsNullOrEmpty(token.AccessValue))
                request.Headers.Add("Token", tokenProvider.GetToken().AccessValue);

            HttpResponseMessage message = await client.SendAsync(request);
            validateResponse(message, endpoint);

            return buildResponse(message);
        }

        public async Task<IHttpClientResponse> Post(string endpoint, object parameters, bool requiresAuthentication = true)
        {
            string json = JsonConvert.SerializeObject(parameters);

            Token token = requiresAuthentication ? tokenProvider.GetToken() : null;

            HttpContent content = buildContent(token, json);
            HttpResponseMessage message = await client.PostAsync(endpoint, content);
            validateResponse(message, endpoint);

            return buildResponse(message);
        }

        private HttpContent buildContent(Token token, string json)
        {
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            if (token != null && !string.IsNullOrEmpty(token.AccessValue))
                content.Headers.Add("Token", token.AccessValue);

            return content;
        }

        private IHttpClientResponse buildResponse(HttpResponseMessage message)
        {
            string jsonResult = message.Content.ReadAsStringAsync().Result;
            Dictionary<string, string> headers = new Dictionary<string, string>();

            foreach (var h in message.Headers)
                headers.Add(h.Key.ToLower(), h.Value.FirstOrDefault());

            return new HttpClientResponse(jsonResult, headers, message.IsSuccessStatusCode);
        }

        private void validateResponse(HttpResponseMessage response, string endpoint)
        {
            if (!response.IsSuccessStatusCode)
                throw new RequestFailedException(endpoint);
        }

        public ITokenProvider GetTokenProvider()
        {
            return tokenProvider;
        }
    }
}
