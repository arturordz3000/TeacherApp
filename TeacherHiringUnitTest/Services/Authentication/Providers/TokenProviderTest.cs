using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Authentication.Implementations;
using Services.Authentication.Providers;
using Services.Authentication.Models;
using Services.Exceptions;
using System.Collections.Generic;
using DataAccess.Implementations;

namespace TeacherHiringUnitTest.Services.Authentication.Providers
{
    [TestClass]
    public class TokenProviderTest
    {
        [TestMethod]
        public void GetToken_WhenValidTokenExists_ReturnToken()
        {
            Mock<IStorage> storageMock = new Mock<IStorage>();
            storageMock.Setup(storage => storage.Get("token")).Returns("g+s6yrDPNBgsXu6EGaGlZfXYKoJafkZxncqDWriNvz46QQTNfzGyNDaCy6xD3iN2IxVuBk8r3R5dFX7bl8wc3g==");
            storageMock.Setup(storage => storage.Get("tokenexpiry")).Returns(43800);
            storageMock.Setup(storage => storage.Get("tokendatetime")).Returns(DateTime.Now);

            TokenProvider tokenProvider = new TokenProvider(storageMock.Object);

            Token token = tokenProvider.GetToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("g+s6yrDPNBgsXu6EGaGlZfXYKoJafkZxncqDWriNvz46QQTNfzGyNDaCy6xD3iN2IxVuBk8r3R5dFX7bl8wc3g==", token.AccessValue);
            Assert.AreEqual(43800, token.ExpirySeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(TokenExpiredException))]
        public void GetToken_WhenTokenExpired_ThrowException()
        {
            Mock<IStorage> storageMock = new Mock<IStorage>();
            storageMock.Setup(storage => storage.Get("token")).Returns("g+s6yrDPNBgsXu6EGaGlZfXYKoJafkZxncqDWriNvz46QQTNfzGyNDaCy6xD3iN2IxVuBk8r3R5dFX7bl8wc3g==");
            storageMock.Setup(storage => storage.Get("tokenexpiry")).Returns(43800);
            storageMock.Setup(storage => storage.Get("tokendatetime")).Returns(DateTime.Now.AddSeconds(-43801));

            TokenProvider tokenProvider = new TokenProvider(storageMock.Object);

            Token token = tokenProvider.GetToken();
        }

        [TestMethod]
        public void GetToken_WhenTokenNotFound_ReturnNull()
        {
            Mock<IStorage> storageMock = new Mock<IStorage>();
            storageMock.Setup(storage => storage.Get("token")).Returns(() => null);

            TokenProvider tokenProvider = new TokenProvider(storageMock.Object);

            Token token = tokenProvider.GetToken();

            Assert.IsNull(token);
        }

        [TestMethod]
        public void SaveToken_WhenTokenIsValid_CallStorageSaveMethod()
        {
            Mock<IStorage> storageMock = new Mock<IStorage>();
            Token mockToken = new Token
            {
                AccessValue = "g+s6yrDPNBgsXu6EGaGlZfXYKoJafkZxncqDWriNvz46QQTNfzGyNDaCy6xD3iN2IxVuBk8r3R5dFX7bl8wc3g==",
                ExpirySeconds = 43800
            };

            TokenProvider tokenProvider = new TokenProvider(storageMock.Object);

            tokenProvider.SaveToken(mockToken);

            storageMock.Verify(storage => storage.Save("token", mockToken.AccessValue));
            storageMock.Verify(storage => storage.Save("tokenexpiry", mockToken.ExpirySeconds));
            storageMock.Verify(storage => storage.Save("tokendatetime", It.IsAny<DateTime>()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveToken_WhenTokenIsNull_CallStorageSaveMethod()
        {
            Mock<IStorage> storageMock = new Mock<IStorage>();

            TokenProvider tokenProvider = new TokenProvider(storageMock.Object);

            tokenProvider.SaveToken(null);
        }
    }
}
