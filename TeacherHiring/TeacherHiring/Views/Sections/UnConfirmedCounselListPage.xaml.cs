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
    public partial class UnConfirmedCounselListPage : ContentPage
    {
        private SubjectDto subject;
        private ICounselService counselsService;
        private IExceptionHandler exceptionHandler;
        private ConfirmCounselListPageViewModel confirmCounselListViewModel;

        public UnConfirmedCounselListPage(SubjectDto subject)
        {
            InitializeComponent();

            this.subject = subject;
            counselsService = App.LogicContext.CounselService;
            exceptionHandler = App.LogicContext.ExceptionHandler;
            confirmCounselListViewModel = new ConfirmCounselListPageViewModel
            {
                CounselRequests = new CounselRequestDto[] { }
            };

            Title = "Solicitudes para " + subject.Description;
            BindingContext = confirmCounselListViewModel;
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
            UserDto currentUser = (UserDto)App.LogicContext.SessionStorage.Get("CurrentUser");
            CounselRequestDto[] counselRequests = await counselsService.GetCounselRequestsForTeacher(currentUser, false);
            confirmCounselListViewModel.CounselRequests = counselRequests.Where(x => x.SubjectId == subject.SubjectId).ToArray();
        }

        private async void CounselsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new CounselRequestDetailPage(confirmCounselListViewModel.SelectedCounselRequest));
        }
    }
}
