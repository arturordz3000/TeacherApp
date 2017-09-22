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
        private LoginViewModel loginViewModel;

        public LoginPage()
        {
            InitializeComponent();
            loginViewModel = (LoginViewModel)BindingContext;
        }

        private async Task LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                loginViewModel.IsBusy = true;

                await startAuthenticationTask(loginViewModel);
                App.Current.MainPage = new Dashboard.DashboardPage();
            }
            catch (Exception ex)
            {
                App.LogicContext.ExceptionHandler.HandleException(this, ex);
            }
            finally { loginViewModel.IsBusy = false; }            
        }

        private async Task startAuthenticationTask(LoginViewModel loginViewModel)
        {
            Token accessToken = await App.LogicContext.AuthenticationService.Authenticate(loginViewModel.User, loginViewModel.Password);
            App.LogicContext.TokenProvider.SaveToken(accessToken);

            await updateUserData();
        }

        protected async override void OnAppearing()
        {
            try
            {
                bool shouldAuthenticate = App.LogicContext.AuthenticationService.ShouldAuthenticate();

                if (!shouldAuthenticate)
                {
                    loginViewModel.IsBusy = true;

                    await updateUserData();
                    App.Current.MainPage = new Dashboard.DashboardPage();
                }
            }
            catch (Exception ex)
            {
                App.LogicContext.ExceptionHandler.HandleException(this, ex);
            }
            finally { loginViewModel.IsBusy = false; }
        }

        private async Task updateUserData()
        {
            UserDto user = await App.LogicContext.UsersService.GetUserData();
            App.LogicContext.UsersService.SaveUserData(user);
            App.LogicContext.SessionStorage.Save("CurrentUser", user);
        }
    }
}
