using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TeacherHiring.ViewModels.Login;
using System.ComponentModel;

namespace TeacherHiringUnitTest.App.ViewModels
{
    [TestClass]
    public class LoginViewModelTest
    {
        [TestMethod]
        public void SetUser_WhenValueIsNotTheSame_PropertyChangedEventIsCalled()
        {
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.PropertyChanged += (sender, e) =>
            {
                Assert.AreEqual("User", e.PropertyName);
            };

            viewModel.User = "someUser";

            Assert.AreEqual("someUser", viewModel.User);
        }

        [TestMethod]
        public void SetUser_WhenValueIsTheSame_PropertyChangedEventShouldNotBeCalled()
        {
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.User = "initialName";

            viewModel.PropertyChanged += (sender, e) =>
            {
                throw new Exception("This method should not be called");
            };

            viewModel.User = "initialName";

            Assert.AreEqual("initialName", viewModel.User);
        }

        [TestMethod]
        public void SetPassword_WhenValueIsNotTheSame_PropertyChangedEventIsCalled()
        {
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.PropertyChanged += (sender, e) =>
            {
                Assert.AreEqual("Password", e.PropertyName);
            };

            viewModel.Password = "somePassword";

            Assert.AreEqual("somePassword", viewModel.Password);
        }

        [TestMethod]
        public void SetPassword_WhenValueIsTheSame_PropertyChangedEventShouldNotBeCalled()
        {
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.Password = "initialPassword";

            viewModel.PropertyChanged += (sender, e) =>
            {
                throw new Exception("This method should not be called");
            };

            viewModel.Password = "initialPassword";

            Assert.AreEqual("initialPassword", viewModel.Password);
        }

        [TestMethod]
        public void SetIsTeacher_WhenValueIsNotTheSame_PropertyChangedEventIsCalled()
        {
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.PropertyChanged += (sender, e) =>
            {
                Assert.AreEqual("IsTeacher", e.PropertyName);
            };

            viewModel.IsTeacher = true;

            Assert.IsTrue(viewModel.IsTeacher);
        }

        [TestMethod]
        public void SetIsTeacher_WhenValueIsTheSame_PropertyChangedEventShouldNotBeCalled()
        {
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.IsTeacher = false;

            viewModel.PropertyChanged += (sender, e) =>
            {
                throw new Exception("This method should not be called");
            };

            viewModel.IsTeacher = false;

            Assert.IsFalse(viewModel.IsTeacher);
        }
    }
}
