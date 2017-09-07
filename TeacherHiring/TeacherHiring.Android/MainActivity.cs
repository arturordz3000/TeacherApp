using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Ninject;
using TeacherHiring.Droid.Injection;

namespace TeacherHiring.Droid
{
    [Activity(Label = "TeacherHiring", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            App app = new App();
            initializeInjectionContainer(app);

            LoadApplication(app);
        }

        private void initializeInjectionContainer(App app)
        {
            IKernel kernel = new StandardKernel(new TeacherHiring.Android.Injection.TeacherHiringModule(app.Properties));
            App.DependencyResolver = new NinjectDependencyResolver(kernel);
            App.LogicContext = new Facades.AppFacade(App.DependencyResolver);
        }
    }
}

