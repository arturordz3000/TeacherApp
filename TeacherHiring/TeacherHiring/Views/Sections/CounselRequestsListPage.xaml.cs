using Common.Enums;
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
    public partial class CounselRequestsListPage : ContentPage
    {
        private SubjectDto subject;
        private ICounselService counselsService;
        private IExceptionHandler exceptionHandler;
        private ConfirmCounselListPageViewModel confirmCounselListViewModel;
        private bool showAcceptedRequests;

        public CounselRequestsListPage(SubjectDto subject, bool showAcceptedRequests)
        {
            InitializeComponent();
            
            this.subject = subject;
            this.showAcceptedRequests = showAcceptedRequests;
            counselsService = App.LogicContext.CounselService;
            exceptionHandler = App.LogicContext.ExceptionHandler;
            confirmCounselListViewModel = new ConfirmCounselListPageViewModel
            {
                CounselRequests = new CounselRequestDto[] { }
            };

            Title = subject != null ? "Solicitudes para " + subject.Description : "Solicitudes realizadas";
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

            CounselRequestDto[] counselRequests = null;

            if (currentUser.UserTypeId == (int)UserType.Teacher)
            {
                counselRequests = await counselsService.GetCounselRequestsForTeacher(currentUser, showAcceptedRequests);
                confirmCounselListViewModel.CounselRequests = counselRequests.Where(x => x.SubjectId == subject.SubjectId).ToArray();
            }
            else
            {
                counselRequests = await counselsService.GetCounselRequestsForStudent(currentUser);
                confirmCounselListViewModel.CounselRequests = counselRequests;
            }
        }

        private async void CounselsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new CounselRequestDetailPage(confirmCounselListViewModel.SelectedCounselRequest, showAcceptedRequests));
        }
    }
}
