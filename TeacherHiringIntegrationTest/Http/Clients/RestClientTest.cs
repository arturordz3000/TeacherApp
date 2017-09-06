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
            mockToken = new Token { AccessValue = "Xhbiu26IM/+/R9U+FZ1fmE5ivNdyYov/wxGW8dI9M8P55Fu0AN+XcAFCU5cyStbQxjY51o6uryisMXW1pu6TQg==", ExpirySeconds = 43800 };
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
        public void GetListMateriaApps_WhenValidToken_ReturnsData()
        {
            RestClient client = new RestClient(mockTokenProvider.Object);

            IHttpClientResponse response = client.Get("http://online.cuprum.com/webapixamarin/api/Materia/GetListMateriaApps");

            Assert.IsTrue(response.IsSuccessfulResponse());
            Assert.IsNotNull(response.GetContent());
        }
    }
}
