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
        private IExceptionHandler exceptionHandler;
        private CounselSignupPageViewModel counselSignupViewModel;

        public CounselSignupPage(CounselDto counsel)
        {
            InitializeComponent();

            counselService = App.LogicContext.CounselService;
            alertDisplayer = App.LogicContext.AlertDisplayer;
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
                initializeMap(counsel.Latitude, counsel.Longitude, 0.3f);
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(this, ex);
            }
        }

        private void initializeMap(double latitude, double longitude, float distanceInKilometers)
        {
            Position center = new Position(latitude, longitude);
            Distance distance = Distance.FromKilometers(distanceInKilometers);
            Pin pin = new Pin
            {
                Position = center,
                Type = PinType.Place,
                Label = "Lugar",
                Address = "En este lugar se impartirá la asesoría"
            };

            CounselMap.MoveToRegion(MapSpan.FromCenterAndRadius(center, distance));
            CounselMap.Pins.Add(pin);
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
