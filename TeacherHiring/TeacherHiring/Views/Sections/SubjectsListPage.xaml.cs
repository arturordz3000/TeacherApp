using Common.Handlers;
using DomainEntities.DataTransferObjects;
using Services.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Sections;
using TeacherHiring.Views.Sections.PageInstantiators;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeacherHiring.Views.Sections
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectsListPage : ContentPage
    {
        private ISubjectsService subjectsService;
        private IPageInstatiator nextPageInstantiator;
        private IExceptionHandler exceptionHandler;
        private RequestCounselPageViewModel requestCounselViewModel;

        public SubjectsListPage(IPageInstatiator nextPageInstantiator)
        {
            InitializeComponent();

            subjectsService = App.LogicContext.SubjectsService;
            this.nextPageInstantiator = nextPageInstantiator;
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
            Page nextPage = nextPageInstantiator.Instantiate(requestCounselViewModel.SelectedSubject);
            await Navigation.PushAsync(nextPage);
        }
    }
}
