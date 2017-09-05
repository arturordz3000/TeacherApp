using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Http;
using Services.Http.Resolvers;

namespace TeacherHiringUnitTest.Services.Http
{
    [TestClass]
    public class EndpointResolverTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenBaseUrlNull_ThrowsException()
        {
            EndpointResolver resolver = new EndpointResolver(null);
        }

        [TestMethod]
        public void ResolveUrl_WhenControllerAndActionAreValid_ConcatOnlyAction()
        {
            EndpointResolver resolver = new EndpointResolver("baseUrl");

            string url = resolver.ResolveUrl("someAction", "someController");

            Assert.AreEqual("baseUrl/someController/someAction", url);
        }

        [TestMethod]
        public void ResolveUrl_WhenControllerIsNullOrEmpty_ConcatOnlyAction()
        {
            EndpointResolver resolver = new EndpointResolver("baseUrl");

            string url = resolver.ResolveUrl("someAction", null);
            Assert.AreEqual("baseUrl/someAction", url);

            url = resolver.ResolveUrl("someAction");
            Assert.AreEqual("baseUrl/someAction", url);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The \"action\" parameter can't be null nor empty")]
        public void ResolveUrl_WhenActionIsNullOrEmpty_ThrowsException()
        {
            EndpointResolver resolver = new EndpointResolver("baseUrl");
            string url = resolver.ResolveUrl(null, "someController");
        }
    }
}
