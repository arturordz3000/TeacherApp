using Common.Handlers;
using Services.Authentication;
using Services.Authentication.Implementations;
using Services.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeacherHiring.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                LoginViewModel loginViewModel = (LoginViewModel)BindingContext;
                Token accessToken = App.LogicContext.AuthenticationService.Authenticate(loginViewModel.User, loginViewModel.Password);
                App.LogicContext.TokenProvider.SaveToken(accessToken);

                Navigation.PushAsync(new Dashboard.DashboardPage());
            }
            catch (Exception ex)
            {
                App.LogicContext.ExceptionHandler.HandleException(this, ex);
            }
        }
    }
}
