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
    public partial class RegisterCounselPage : ContentPage
    {
        private ISubjectsService subjectsService;
        private RegisterCounselPageViewModel viewModel;

        public RegisterCounselPage()
        {
            InitializeComponent();
            subjectsService = App.LogicContext.SubjectsService;
            viewModel = new RegisterCounselPageViewModel { Subjects = new SubjectDto[] { } };

            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await updateBindings();
        }

        private async Task updateBindings()
        {
            List<SubjectDto> subjects = await subjectsService.GetSubjects();
            viewModel.Subjects = subjects.ToArray();
        }
    }
}
