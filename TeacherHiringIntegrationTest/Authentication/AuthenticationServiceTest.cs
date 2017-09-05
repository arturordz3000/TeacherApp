using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Http.Clients;
using Services.Authentication.Implementations;
using Moq;
using Services.Authentication.Models;
using Services.Authentication;
using Services.Http.Resolvers;
using Services.Exceptions;
using Services.Http.Implementations;

namespace TeacherHiringIntegrationTest.Authentication
{
    [TestClass]
    public class AuthenticationServiceTest
    {
        private Mock<ITokenProvider> mockTokenProvider;
        private Token mockToken;
        private string baseUrl = "http://online.cuprum.com/webapixamarin/Api/";

        public AuthenticationServiceTest()
        {
            mockToken = new Token { AccessValue = "BQkGz1w+ERCD/dhqYSNQaitXWGiDuWtgzfMxmdPUre2tI+678Z9rGADPy3b6QkIYA1pPTL2Ln3OUkGtU772aTA==", ExpirySeconds = 43800 };
            mockTokenProvider = new Mock<ITokenProvider>();
            mockTokenProvider.Setup(provider => provider.GetToken()).Returns(mockToken);
        }

        [TestMethod]
        public void Authenticate_WhenValidCredentials_ReturnToken()
        {
            RestClient client = new RestClient(mockTokenProvider.Object);
            AuthenticationService authenticationService = new AuthenticationService(client, new EndpointResolver(baseUrl));

            Token token = authenticationService.Authenticate("arodriguez", "admin123$");

            Assert.IsNotNull(token);
            Assert.AreEqual(43800, token.ExpirySeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCredentialsException))]
        public void Authenticate_WhenNotValidCredentials_ThrowsException()
        {
            RestClient client = new RestClient(mockTokenProvider.Object);
            AuthenticationService authenticationService = new AuthenticationService(client, new EndpointResolver(baseUrl));

            Token token = authenticationService.Authenticate("NotValidUser", "NotValidPassword");
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public void Authenticate_WhenUnsuccessfulResponseCode_ThrowsException()
        {
            string invalidEndpoint = baseUrl + "InvalidURL/";
            RestClient client = new RestClient(mockTokenProvider.Object);
            AuthenticationService authenticationService = new AuthenticationService(client, new EndpointResolver(invalidEndpoint));

            Token token = authenticationService.Authenticate("arodriguez", "admin123$");
        }
    }
}
