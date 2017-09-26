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
using Xamarin.Forms.Xaml;

namespace TeacherHiring.Views.Sections
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvailableCounselsPage : ContentPage
    {
        private ICounselService counselsService;
        private IExceptionHandler exceptionHandler;
        private AvailableCounselsPageViewModel availableCounselsViewModel;

        public AvailableCounselsPage(SubjectDto subject)
        {
            InitializeComponent();

            counselsService = App.LogicContext.CounselService;
            exceptionHandler = App.LogicContext.ExceptionHandler;
            availableCounselsViewModel = new AvailableCounselsPageViewModel
            {
                Subject = subject,
                Counsels = new CounselDto[] {}
            };

            BindingContext = availableCounselsViewModel;
            Title = subject.ToString();
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
            availableCounselsViewModel.Counsels = await counselsService.GetAvailableCounselsBySubject(availableCounselsViewModel.Subject);
        }

        private async void CounselsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new CounselSignupPage(availableCounselsViewModel.SelectedCounsel));
        }
    }
}
