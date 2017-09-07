﻿using System;

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

            initializeInjectionContainer();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private void initializeInjectionContainer()
        {
            IKernel kernel = new StandardKernel(new TeacherHiring.Android.Injection.TeacherHiringModule());
            App.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}

