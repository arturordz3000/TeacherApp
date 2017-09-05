using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Services.Http;
using TeacherHiringUnitTest.Services.Mocks;
using Services.Http.Responses;

namespace TeacherHiringUnitTest.Services.Http
{
    [TestClass]
    public class HttpClientResponseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenHeadersIsNull_ThrowsException()
        {
            HttpClientResponse response = new HttpClientResponse("Content", null, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenContentIsNull_ThrowsException()
        {
            HttpClientResponse response = new HttpClientResponse(null, new Dictionary<string, string>(), true);
        }

        [TestMethod]
        public void GetHeader_WhenHeaderExists_ReturnHeader()
        {
            Dictionary<string, string> mockHeaders = new Dictionary<string, string>();
            mockHeaders.Add("Header1", "Value1");
            mockHeaders.Add("Header2", "Value2");
            mockHeaders.Add("Header3", "Value3");

            HttpClientResponse response = new HttpClientResponse("Content", mockHeaders, true);

            Assert.AreEqual("Value1", response.GetHeader("Header1"));
            Assert.AreEqual("Value2", response.GetHeader("Header2"));
            Assert.AreEqual("Value3", response.GetHeader("Header3"));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Header with name \"Header2\" does not exist in this response.")]
        public void GetHeader_WhenHeaderDoesNotExists_ThrowsException()
        {
            Dictionary<string, string> mockHeaders = new Dictionary<string, string>();
            mockHeaders.Add("Header1", "Value1");
            mockHeaders.Add("Header3", "Value3");

            HttpClientResponse response = new HttpClientResponse("Content", mockHeaders, true);

            Assert.AreEqual("Value1", response.GetHeader("Header1"));
            Assert.AreEqual("Value3", response.GetHeader("Header3"));
            response.GetHeader("Header2");
        }

        [TestMethod]
        public void GetContent_WhenContentNotNull_ReturnObject()
        {
            HttpClientResponse response = new HttpClientResponse("{Property1: 1, Property2: '2', Property3: {SubProperty1: 1}}", new Dictionary<string, string>(), true);
            Assert.IsNotNull(response.GetContent());
        }

        [TestMethod]
        public void GetContentAsObject_WhenContentIsValidJson_ReturnObject()
        {
            HttpClientResponse response = new HttpClientResponse("{Property1: 1, Property2: '2', Property3: {SubProperty1: 1}}", new Dictionary<string, string>(), true);

            MockResponseModel model = response.GetContentAsObject<MockResponseModel>();

            Assert.AreEqual(1, model.Property1);
            Assert.AreEqual("2", model.Property2);
            Assert.AreEqual(1, model.Property3.SubProperty1);
        }

        [TestMethod]
        public void GetResponseCode_WhenResponseIsSuccessful_ReturnTrue()
        {
            HttpClientResponse response = new HttpClientResponse("{Property1: 1, Property2: '2', Property3: {SubProperty1: 1}}", new Dictionary<string, string>(), true);
            Assert.IsTrue(response.IsSuccessfulResponse());
        }

        [TestMethod]
        public void GetResponseCode_WhenResponseIsUnsuccessful_ReturnFalse()
        {
            HttpClientResponse response = new HttpClientResponse("SomeOtherResponseBody", new Dictionary<string, string>(), false);
            Assert.IsFalse(response.IsSuccessfulResponse());
        }
    }
}
