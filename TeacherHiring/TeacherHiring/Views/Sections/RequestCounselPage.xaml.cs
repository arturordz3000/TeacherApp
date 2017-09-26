using Common.Handlers;
using DomainEntities.DataTransferObjects;
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
    public partial class RequestCounselPage : ContentPage
    {
        private ISubjectsService subjectsService;
        private IExceptionHandler exceptionHandler;
        private RequestCounselPageViewModel requestCounselViewModel;

        public RequestCounselPage()
        {
            InitializeComponent();

            subjectsService = App.LogicContext.SubjectsService;
            exceptionHandler = App.LogicContext.ExceptionHandler;
            requestCounselViewModel = new RequestCounselPageViewModel() { Subjects = new SubjectDto[] { } };

            BindingContext = requestCounselViewModel;
        }

        protected async override void OnAppearing()
        {
            try
            {
                await updateBindings();
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(this, ex);
            }
        }

        private async Task updateBindings()
        {
            List<SubjectDto> subjects = await subjectsService.GetSubjects();
            requestCounselViewModel.Subjects = subjects.ToArray();
        }

        private async void SubjectsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AvailableCounselsPage(requestCounselViewModel.SelectedSubject));
        }
    }
}
