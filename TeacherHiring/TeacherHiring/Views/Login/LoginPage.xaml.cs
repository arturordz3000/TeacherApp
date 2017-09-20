using Common.Handlers;
using DomainEntities.DataTransferObjects;
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

        private async Task LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                LoginViewModel loginViewModel = (LoginViewModel)BindingContext;
                Token accessToken = await App.LogicContext.AuthenticationService.Authenticate(loginViewModel.User, loginViewModel.Password);

                App.LogicContext.TokenProvider.SaveToken(accessToken);

                UserDto user = await App.LogicContext.UsersService.GetUserData();
                App.LogicContext.UsersService.SaveUserData(user);

                App.Current.MainPage = new Dashboard.DashboardPage(user);
            }
            catch (Exception ex)
            {
                App.LogicContext.ExceptionHandler.HandleException(this, ex);
            }
        }
    }
}
