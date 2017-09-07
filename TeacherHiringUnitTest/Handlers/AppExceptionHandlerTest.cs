using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Common.Alerts;
using System.Threading.Tasks;
using Common.Handlers;

namespace TeacherHiringUnitTest.Handlers
{
    [TestClass]
    public class AppExceptionHandlerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The type is not an Exception")]
        public void RegisterExceptionType_WhenTypeIsNotException_ThrowException()
        {
            Mock<IAlertDisplayer> alertDisplayerMock = new Mock<IAlertDisplayer>();
            AppExceptionHandler handler = new AppExceptionHandler(alertDisplayerMock.Object);

            handler.RegisterExceptionType(typeof(int), "AnyMessage");
        }

        [TestMethod]
        public void RegisterExceptionType_WhenTypeIsException_RegisterException()
        {
            Mock<IAlertDisplayer> alertDisplayerMock = new Mock<IAlertDisplayer>();
            AppExceptionHandler handler = new AppExceptionHandler(alertDisplayerMock.Object);

            handler.RegisterExceptionType(typeof(Exception), "AnyMessage");
            Assert.AreEqual(1, handler.RegisteredExceptions.Count);

            handler.RegisterExceptionType(typeof(ArgumentException), "AnyMessage");
            Assert.AreEqual(2, handler.RegisteredExceptions.Count);
        }

        [TestMethod]
        public void Handle_WithRegisteredException_DisplayRegisteredErrorAlert()
        {
            Mock<IAlertDisplayer> alertDisplayerMock = new Mock<IAlertDisplayer>();

            alertDisplayerMock.Setup(alert => alert.DisplayAlert(this, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(It.IsAny<Task>());

            AppExceptionHandler handler = new AppExceptionHandler(alertDisplayerMock.Object);

            handler.RegisterExceptionType(typeof(Exception), "Ha ocurrido un problema registrado");
            handler.HandleException(this, new Exception());

            alertDisplayerMock.Verify(alert => alert.DisplayAlert(this, "Teacher Hiring App", "Ha ocurrido un problema registrado", "Ok"));
        }

        [TestMethod]
        public void Handle_WithNotRegisteredException_DisplayUnknownErrorAlert()
        {
            Mock<IAlertDisplayer> alertDisplayerMock = new Mock<IAlertDisplayer>();

            alertDisplayerMock.Setup(alert => alert.DisplayAlert(this, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(It.IsAny<Task>());

            AppExceptionHandler handler = new AppExceptionHandler(alertDisplayerMock.Object);

            handler.RegisterExceptionType(typeof(ArgumentException), "Ha ocurrido un problema registrado");
            handler.HandleException(this, new Exception());

            alertDisplayerMock.Verify(alert => alert.DisplayAlert(this, "Teacher Hiring App", "Ha ocurrido un problema desconocido", "Ok"));
        }
    }
}
