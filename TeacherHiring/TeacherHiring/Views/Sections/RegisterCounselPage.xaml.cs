using Common.Alerts;
using Common.Handlers;
using DomainEntities.DataTransferObjects;
using Services.Counsels;
using Services.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Sections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeacherHiring.Views.Sections
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCounselPage : ContentPage
    {
        private ISubjectsService subjectsService;
        private ICounselService counselService;
        private IExceptionHandler exceptionHandler;
        private IAlertDisplayer alertDisplayer;
        private RegisterCounselPageViewModel registerCounselViewModel;

        public RegisterCounselPage()
        {
            InitializeComponent();

            subjectsService = App.LogicContext.SubjectsService;
            counselService = App.LogicContext.CounselService;
            exceptionHandler = App.LogicContext.ExceptionHandler;
            alertDisplayer = App.LogicContext.AlertDisplayer;
            registerCounselViewModel = new RegisterCounselPageViewModel { Subjects = new SubjectDto[] { } };

            BindingContext = registerCounselViewModel;
        }

        protected override async void OnAppearing()
        {
            try
            {
                initializeCustomControls();
                await updateBindings();
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(this, ex);
            }
        }

        private void initializeCustomControls()
        {
            CounselMap.Initialize();
        }

        private async Task updateBindings()
        {
            List<SubjectDto> subjects = await subjectsService.GetSubjects();
            registerCounselViewModel.Subjects = subjects.ToArray();
        }

        private async Task SaveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                registerCounselViewModel.IsBusy = true;

                CounselDto counsel = buildCounsel();
                CounselDto responseCounsel = await counselService.RegisterCounsel(counsel);

                if (responseCounsel != null)
                    await alertDisplayer.DisplayAlert(this, "Asesoría", "Asesoría registrada exitosamente!", "Ok");
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(this, ex);
            }
            finally { registerCounselViewModel.IsBusy = false; }
        }

        private CounselDto buildCounsel()
        {
            UserDto currentUser = (UserDto)App.LogicContext.SessionStorage.Get("CurrentUser");

            return new CounselDto
            {
                SubjectId = registerCounselViewModel.SelectedSubject.SubjectId,
                SubjectName = registerCounselViewModel.SelectedSubject.Description,
                Latitude = CounselMap.VisibleRegion.Center.Latitude,
                Longitude = CounselMap.VisibleRegion.Center.Longitude,
                TeacherUserId = currentUser.UserId,
                TeacherName = currentUser.Name,
                CounselDateTime = registerCounselViewModel.CounselDate + registerCounselViewModel.CounselTime
            };
        }
    }
}
