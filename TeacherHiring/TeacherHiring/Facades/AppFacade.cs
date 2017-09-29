using Common.Alerts;
using Common.Handlers;
using DataAccess.Implementations;
using Services.Authentication;
using Services.Authentication.Implementations;
using Services.Counsels;
using Services.Exceptions;
using Services.Subjects;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.Injection;
using TeacherHiring.Views.Dashboard.Factory;
using TeacherHiring.Views.Sections.Initializers;

namespace TeacherHiring.Facades
{
    public class AppFacade
    {
        private IDependencyResolver dependencyResolver;

        private IAuthenticationService authenticationService;
        private ITokenProvider tokenProvider;
        private IExceptionHandler exceptionHandler;
        private IUsersService usersService;
        private ICacheStorage sessionStorage;
        private IDetailPageFactory detailPageFactory;
        private ISubjectsService subjectsService;
        private ICounselService counselService;
        private IAlertDisplayer alertDisplayer;
        private IMapInitializer mapInitializer;

        public AppFacade(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public IAuthenticationService AuthenticationService
        {
            get
            {
                if (authenticationService == null)
                    authenticationService = dependencyResolver.Resolve<IAuthenticationService>();

                return authenticationService;
            }
        }

        public ITokenProvider TokenProvider
        {
            get
            {
                if (tokenProvider == null)
                    tokenProvider = dependencyResolver.Resolve<ITokenProvider>();

                return tokenProvider;
            }
        }

        public IExceptionHandler ExceptionHandler
        {
            get
            {
                if (exceptionHandler == null)
                    exceptionHandler = initializeExceptionHandler();

                return exceptionHandler;
            }
        }

        private IExceptionHandler initializeExceptionHandler()
        {
            IAlertExceptionHandler exceptionHandler = dependencyResolver.Resolve<IAlertExceptionHandler>();
            exceptionHandler.RegisterExceptionType(typeof(InvalidCredentialsException), "Tu nombre de usuario o contraseña son incorrectos.");
            exceptionHandler.RegisterExceptionType(typeof(RequestFailedException), "Ha ocurrido un problema con la solicitud. Inténtalo de nuevo.");

            return exceptionHandler;
        }

        public IUsersService UsersService
        {
            get
            {
                if (usersService == null)
                    usersService = dependencyResolver.Resolve<IUsersService>();

                return usersService;
            }
        }

        public ICacheStorage SessionStorage
        {
            get
            {
                if (sessionStorage == null)
                    sessionStorage = dependencyResolver.Resolve<ICacheStorage>("Session");

                return sessionStorage;
            }
        }

        public IDetailPageFactory DetailPageFactory
        {
            get
            {
                if (detailPageFactory == null)
                    detailPageFactory = dependencyResolver.Resolve<IDetailPageFactory>();

                return detailPageFactory;
            }
        }

        public ISubjectsService SubjectsService
        {
            get
            {
                if (subjectsService == null)
                    subjectsService = dependencyResolver.Resolve<ISubjectsService>();

                return subjectsService;
            }
        }

        public ICounselService CounselService
        {
            get
            {
                if (counselService == null)
                    counselService = dependencyResolver.Resolve<ICounselService>();

                return counselService;
            }
        }

        public IAlertDisplayer AlertDisplayer
        {
            get
            {
                if (alertDisplayer == null)
                    alertDisplayer = dependencyResolver.Resolve<IAlertDisplayer>();

                return alertDisplayer;
            }
        }

        public IMapInitializer MapInitializer
        {
            get
            {
                if (mapInitializer == null)
                    mapInitializer = dependencyResolver.Resolve<IMapInitializer>();

                return mapInitializer;
            }
        }
    }
}
