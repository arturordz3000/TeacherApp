using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Dashboard;
using TeacherHiring.Views.Dashboard.Factory;
using TeacherHiring.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeacherHiring.Views.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPageMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public DashboardPageMaster()
        {
            InitializeComponent();

            UserDto user = (UserDto)App.LogicContext.SessionStorage.Get("CurrentUser");
            IDetailPageFactory detailPageFactory = App.LogicContext.DetailPageFactory;

            BindingContext = new DashboardPageMasterViewModel(user, detailPageFactory);
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            App.LogicContext.AuthenticationService.Logout();
            App.Current.MainPage = new LoginPage();
        }
    }
}
