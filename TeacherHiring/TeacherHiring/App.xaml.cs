using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeacherHiring.Injection;
using Xamarin.Forms;

namespace TeacherHiring
{
    public partial class App : Application
    {
        public static IDependencyResolver DependencyResolver { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new TeacherHiring.Views.Login.LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
