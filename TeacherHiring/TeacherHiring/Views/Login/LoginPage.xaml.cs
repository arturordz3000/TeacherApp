using Services.Authentication;
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
        private IAuthenticationService authenticationService;

        public LoginPage()
        {
            InitializeComponent();
            authenticationService = App.DependencyResolver.Resolve<IAuthenticationService>();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                LoginViewModel loginViewModel = (LoginViewModel)BindingContext;
                Token accessToken = authenticationService.Authenticate(loginViewModel.User, loginViewModel.Password);
                int debug = 0;
            }
            catch (Exception ex)
            {
                // TODO: Show message
            }
        }
    }
}
