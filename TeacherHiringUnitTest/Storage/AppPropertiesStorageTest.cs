using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiringUnitTest.Storage
{
    [TestClass]
    public class AppPropertiesStorageTest
    {
        [TestMethod]
        public void Save_WhenKeyDoesNotExist_KeyAdded()
        {
            IDictionary<string, object> mockProperties = new Dictionary<string, object>();
            AppPropertiesStorage storage = new AppPropertiesStorage(mockProperties);

            storage.Save("key1", "value1");
            storage.Save("key2", "value2");
            storage.Save("key3", "value3");

            Assert.IsTrue(mockProperties.ContainsKey("key1"));
            Assert.IsTrue(mockProperties.ContainsKey("key2"));
            Assert.IsTrue(mockProperties.ContainsKey("key3"));
        }

        [TestMethod]
        public void Save_WhenKeyExists_KeyUpdated()
        {
            IDictionary<string, object> mockProperties = new Dictionary<string, object>();
            AppPropertiesStorage storage = new AppPropertiesStorage(mockProperties);

            storage.Save("key1", "value1");
            Assert.IsTrue(mockProperties.ContainsKey("key1"));
            Assert.AreEqual("value1", mockProperties["key1"]);

            storage.Save("key1", "value2");
            Assert.IsTrue(mockProperties.ContainsKey("key1"));
            Assert.AreEqual("value2", mockProperties["key1"]);
        }
    }
}
