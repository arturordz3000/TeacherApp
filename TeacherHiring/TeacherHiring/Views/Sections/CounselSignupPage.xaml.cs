using Common.Alerts;
using Common.Handlers;
using DomainEntities.DataTransferObjects;
using Services.Counsels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Sections;
using TeacherHiring.Views.Sections.Initializers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TeacherHiring.Views.Sections
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounselSignupPage : ContentPage
    {
        private ICounselService counselService;
        private IAlertDisplayer alertDisplayer;
        private IMapInitializer mapInitializer;
        private IExceptionHandler exceptionHandler;
        private CounselSignupPageViewModel counselSignupViewModel;

        public CounselSignupPage(CounselDto counsel)
        {
            InitializeComponent();

            counselService = App.LogicContext.CounselService;
            alertDisplayer = App.LogicContext.AlertDisplayer;
            mapInitializer = App.LogicContext.MapInitializer;
            exceptionHandler = App.LogicContext.ExceptionHandler;
            counselSignupViewModel = new CounselSignupPageViewModel { Counsel = counsel };

            BindingContext = counselSignupViewModel;
            Title = counsel.SubjectName;
        }

        protected override void OnAppearing()
        {
            try
            {
                CounselDto counsel = counselSignupViewModel.Counsel;
                mapInitializer.Initialize(ref CounselMap, counsel.Latitude, counsel.Longitude, 0.3f);
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(this, ex);
            }
        }

        private async Task RequestButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                counselSignupViewModel.IsBusy = true;

                UserDto user = (UserDto)App.LogicContext.SessionStorage.Get("CurrentUser");
                StudentCounselDto studentCounsel = await counselService.SignupToCounsel(user, counselSignupViewModel.Counsel);

                if (studentCounsel != null)
                {
                    await alertDisplayer.DisplayAlert(this, "Asesoría", "Solicitud exitosa!", "Ok");
                    App.Current.MainPage = new Dashboard.DashboardPage();
                }
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(this, ex);
            }
            finally { counselSignupViewModel.IsBusy = false; }
        }
    }
}
