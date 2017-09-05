﻿using Newtonsoft.Json;
using Services.Authentication.Implementations;
using Services.Authentication.Models;
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

        public IHttpClientResponse Get(string endpoint)
        {
            throw new NotImplementedException();
        }

        public IHttpClientResponse Post(string endpoint, object parameters)
        {
            string json = JsonConvert.SerializeObject(parameters);

            HttpContent content = buildContent(tokenProvider.GetToken(), json);
            HttpResponseMessage message = client.PostAsync(endpoint, content).Result;

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
    }
}
