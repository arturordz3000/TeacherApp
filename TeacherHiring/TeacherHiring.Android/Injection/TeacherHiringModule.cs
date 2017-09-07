using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using DataAccess.Implementations;
using DataAccess;
using Services.Authentication;
using Services.Authentication.Providers;
using Services.Http.Clients;
using Services.Http.Implementations;
using Services.Authentication.Implementations;
using Services.Http.Resolvers;
using Services.Http.Responses;

namespace TeacherHiring.Android.Injection
{
    public class TeacherHiringModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthenticationService>().To<AuthenticationService>();
            Bind<ITokenProvider>().To<TokenProvider>();
            Bind<IHttpClient>().To<RestClient>();
            Bind<EndpointResolver>().ToSelf().WithConstructorArgument("baseUrl", Common.Constants.ApiUrl);
            Bind<IStorage>().To<AppPropertiesStorage>();
        }
    }
}
