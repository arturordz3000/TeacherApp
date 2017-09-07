using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using TeacherHiring.Android.Injection;
using TeacherHiring.Droid.Injection;
using Services.Authentication;
using DataAccess.Implementations;
using Services.Authentication.Implementations;
using Services.Http.Implementations;
using Services.Http.Resolvers;
using Common.Alerts;
using Common.Handlers;
using Moq;
using System.Collections.Generic;

namespace TeacherHiringIntegrationTest.Injection
{
    [TestClass]
    public class NinjectDependencyResolverTest
    {
        private IKernel kernel;

        public NinjectDependencyResolverTest()
        {
            kernel = new StandardKernel(new TeacherHiringModule(new Dictionary<string, object>()));
        }

        [TestMethod]
        public void ResolveAsIAuthenticationService_WithTeacherHiringModule_DependenciesShouldBeResolved()
        {
            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            object resolved = resolver.Resolve<IAuthenticationService>();

            Assert.IsNotNull(resolved);
        }

        [TestMethod]
        public void ResolveAsITokenProvider_WithTeacherHiringModule_DependenciesShouldBeResolved()
        {
            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            object resolved = resolver.Resolve<ITokenProvider>();

            Assert.IsNotNull(resolved);
        }

        [TestMethod]
        public void ResolveAsIHttpClient_WithTeacherHiringModule_DependenciesShouldBeResolved()
        {
            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            object resolved = resolver.Resolve<IHttpClient>();

            Assert.IsNotNull(resolved);
        }

        [TestMethod]
        public void ResolveAsEndpointResolver_WithTeacherHiringModule_DependenciesShouldBeResolved()
        {
            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            object resolved = resolver.Resolve<EndpointResolver>();

            Assert.IsNotNull(resolved);
        }

        [TestMethod]
        public void ResolveAsIStorage_WithTeacherHiringModule_DependenciesShouldBeResolved()
        {
            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            object resolved = resolver.Resolve<IStorage>();

            Assert.IsNotNull(resolved);
        }

        [TestMethod]
        public void ResolveAsIAlertDisplayer_WithTeacherHiringModule_DependenciesShouldBeResolved()
        {
            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            object resolved = resolver.Resolve<IAlertDisplayer>();

            Assert.IsNotNull(resolved);
        }

        [TestMethod]
        public void ResolveAsIAlertExceptionHandler_WithTeacherHiringModule_DependenciesShouldBeResolved()
        {
            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            object resolved = resolver.Resolve<IAlertExceptionHandler>();

            Assert.IsNotNull(resolved);
        }
    }
}
