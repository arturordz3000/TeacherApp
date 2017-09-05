using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Http;
using Services.Http.Clients;
using Services.Http.Implementations;
using Moq;
using Services.Authentication.Implementations;
using Services.Authentication.Models;

namespace TeacherHiringIntegrationTest.Http
{
    [TestClass]
    public class RestClientTest
    {
        private Mock<ITokenProvider> mockTokenProvider;
        private Token mockToken;

        public RestClientTest()
        {
            mockToken = new Token { AccessValue = "BQkGz1w+ERCD/dhqYSNQaitXWGiDuWtgzfMxmdPUre2tI+678Z9rGADPy3b6QkIYA1pPTL2Ln3OUkGtU772aTA==", ExpirySeconds = 43800 };
            mockTokenProvider = new Mock<ITokenProvider>();
            mockTokenProvider.Setup(provider => provider.GetToken()).Returns(mockToken);
        }

        [TestMethod]
        public void PostAuthenticate_WhenValidCredentials_ReturnsToken()
        {
            RestClient client = new RestClient(mockTokenProvider.Object);

            IHttpClientResponse response = client.Post("http://online.cuprum.com/webapixamarin/Api/Authenticate/Authenticate", new { ClaveAcceso = "arodriguez", Contrasena = "admin123$" });

            Assert.AreEqual("\"Authorized\"", response.GetContent());
            Assert.IsNotNull(response.GetHeader("token"));
        }

        [TestMethod]
        public void GetDataPerson_WhenValidToken_ReturnsData()
        {
            RestClient client = new RestClient(mockTokenProvider.Object);

            IHttpClientResponse response = client.Get("http://online.cuprum.com/webapixamarin/api/Usuario/GetDataPerson?token=MlsPdiXsWpuE6OFVLuj/a3/uuGz8zETh+dNzOl9x0HYS2Bjd1MZ1hOY9/eWrGRvuaUjMyr6gCy9BjSE3y8uAbQ==");

            Assert.IsTrue(response.IsSuccessfulResponse());
            Assert.IsNotNull(response.GetContent());
        }
    }
}
