using Common.Handlers;
using Services.Authentication;
using Services.Authentication.Implementations;
using Services.Exceptions;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.Injection;

namespace TeacherHiring.Facades
{
    public class AppFacade
    {
        private IDependencyResolver dependencyResolver;

        private IAuthenticationService authenticationService;
        private ITokenProvider tokenProvider;
        private IExceptionHandler exceptionHandler;
        private IUsersService usersService;

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
    }
}
