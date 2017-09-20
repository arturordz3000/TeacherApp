using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Sqlite;
using Moq;
using DataAccess.Implementations;

namespace TeacherHiringIntegrationTest.Sqlite
{
    [TestClass]
    public class SqliteUnitOfWorkTest
    {
        [TestMethod]
        public void Constructor_WhenContextIsSqliteContext_Initialized()
        {
            SqliteUnitOfWork unitOfWork = new SqliteUnitOfWork(new SqliteContext());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The context for SqliteUnitOfWork must be an instance of SqliteContext")]
        public void Constructor_WhenContextIsNotSqliteContext_ThrowException()
        {
            Mock<IContext> mockContext = new Mock<IContext>();
            SqliteUnitOfWork unitOfWork = new SqliteUnitOfWork(mockContext.Object);
        }
    }
}
