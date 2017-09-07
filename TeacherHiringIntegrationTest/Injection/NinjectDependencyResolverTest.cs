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

namespace TeacherHiringIntegrationTest.Injection
{
    [TestClass]
    public class NinjectDependencyResolverTest
    {
        private IKernel kernel;

        public NinjectDependencyResolverTest()
        {
            kernel = new StandardKernel(new TeacherHiringModule());
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
    }
}
