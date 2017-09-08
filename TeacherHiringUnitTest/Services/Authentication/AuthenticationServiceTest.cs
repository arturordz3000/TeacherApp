using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Authentication;
using Services.Http;
using Moq;
using System.Collections.Generic;
using Services.Exceptions;
using Services.Http.Implementations;
using Services.Http.Resolvers;
using Services.Authentication.Models;
using System.Threading.Tasks;

namespace TeacherHiringUnitTest.Services.Authentication
{
    [TestClass]
    public class AuthenticationServiceTest
    {
        private EndpointResolver mockEndpointResolver = new EndpointResolver("someUrl");

        [TestMethod]
        public async Task Authenticate_WhenValidCredentials_ReturnToken()
        {
            Mock<IHttpClientResponse> mockHttpClientResponse = new Mock<IHttpClientResponse>();
            mockHttpClientResponse.Setup(client => client.GetContent()).Returns("Authorized");
            mockHttpClientResponse.Setup(client => client.GetHeader("token")).Returns("g+s6yrDPNBgsXu6EGaGlZfXYKoJafkZxncqDWriNvz46QQTNfzGyNDaCy6xD3iN2IxVuBk8r3R5dFX7bl8wc3g==");
            mockHttpClientResponse.Setup(client => client.GetHeader("tokenexpiry")).Returns("123456");
            mockHttpClientResponse.Setup(client => client.IsSuccessfulResponse()).Returns(true);

            Mock<IHttpClient> mockHttpClient = createMockHttpClient(mockHttpClientResponse);

            AuthenticationService authenticationService = new AuthenticationService(mockHttpClient.Object, mockEndpointResolver);
            Token token = await authenticationService.Authenticate("ValidUser", "ValidPassword");

            Assert.IsNotNull(token);
            Assert.AreEqual("g+s6yrDPNBgsXu6EGaGlZfXYKoJafkZxncqDWriNvz46QQTNfzGyNDaCy6xD3iN2IxVuBk8r3R5dFX7bl8wc3g==", token.AccessValue);
            Assert.AreEqual(123456, token.ExpirySeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCredentialsException))]
        public async Task Authenticate_WhenNotValidCredentials_ThrowsException()
        {
            Mock<IHttpClientResponse> mockHttpClientResponse = new Mock<IHttpClientResponse>();
            mockHttpClientResponse.Setup(client => client.GetContent()).Returns("Not User Found");
            mockHttpClientResponse.Setup(client => client.IsSuccessfulResponse()).Returns(false);

            Mock<IHttpClient> mockHttpClient = createMockHttpClient(mockHttpClientResponse);

            AuthenticationService authenticationService = new AuthenticationService(mockHttpClient.Object, mockEndpointResolver);
            Token token = await authenticationService.Authenticate("NotValidUser", "NotValidPassword");
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public async Task Authenticate_WhenUnsuccessfulResponseCode_ThrowsException()
        {
            Mock<IHttpClientResponse> mockHttpClientResponse = new Mock<IHttpClientResponse>();
            mockHttpClientResponse.Setup(client => client.IsSuccessfulResponse()).Returns(false);

            Mock<IHttpClient> mockHttpClient = createMockHttpClient(mockHttpClientResponse);

            AuthenticationService authenticationService = new AuthenticationService(mockHttpClient.Object, mockEndpointResolver);
            Token token = await authenticationService.Authenticate("NotValidUser", "NotValidPassword");
        }

        private Mock<IHttpClient> createMockHttpClient(Mock<IHttpClientResponse> mockHttpClientResponse)
        {
            Mock<IHttpClient> mockHttpClient = new Mock<IHttpClient>();

            mockHttpClient.Setup(client => client.Post(It.IsAny<string>(), It.IsNotNull<object>()))
               .Returns(Task.FromResult(mockHttpClientResponse.Object));

            return mockHttpClient;
        }
    }
}
