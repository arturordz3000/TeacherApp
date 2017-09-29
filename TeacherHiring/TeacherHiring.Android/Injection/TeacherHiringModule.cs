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
using Common.Alerts;
using Common.Handlers;
using Services.Users;
using DataAccess.Sqlite;
using DataAccess.Cache;
using TeacherHiring.Droid.PathBuilder;
using TeacherHiring.Views.Dashboard.Factory;
using Services.Subjects;
using Services.Counsels;
using TeacherHiring.Views.Sections.Initializers;

namespace TeacherHiring.Android.Injection
{
    public class TeacherHiringModule : NinjectModule
    {
        private IDictionary<string, object> appProperties;

        public TeacherHiringModule(IDictionary<string, object> appProperties)
        {
            this.appProperties = appProperties;
        }

        public override void Load()
        {
            Bind<IAuthenticationService>().To<AuthenticationService>();
            Bind<ITokenProvider>().To<TokenProvider>();
            Bind<IHttpClient>().To<RestClient>();
            Bind<EndpointResolver>().ToSelf().WithConstructorArgument("baseUrl", Common.Constants.ApiUrl);
            Bind<ICacheStorage>().To<AppPropertiesStorage>().Named("AppProperties").WithConstructorArgument("properties", appProperties);
            Bind<ICacheStorage>().To<SessionStorage>().Named("Session");
            Bind<IAlertDisplayer>().To<PageAlertDisplayer>();
            Bind<IAlertExceptionHandler>().To<AppExceptionHandler>();
            Bind<IUsersService>().To<UsersService>();
            Bind<IUnitOfWork>().To<SqliteUnitOfWork>().InSingletonScope();
            Bind<IContext>().To<SqliteContext>();
            Bind<IPathBuilder>().To<StandardPathBuilder>();
            Bind<IDetailPageFactory>().To<StandardDetailPageFactory>();
            Bind<ISubjectsService>().To<SubjectsService>();
            Bind<ICounselService>().To<CounselService>();
            Bind<IMapInitializer>().To<MapWithPinInitializer>();
        }
    }
}
