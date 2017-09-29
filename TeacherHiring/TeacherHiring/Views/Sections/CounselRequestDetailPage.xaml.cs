using Common.Handlers;
using DomainEntities.DataTransferObjects;
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
    public partial class CounselRequestDetailPage : ContentPage
    {
        private CounselRequestDto counselRequest;
        private CounselRequestDetailPageViewModel counselRequestDetailViewModel;
        private IMapInitializer mapInitializer;
        private IExceptionHandler exceptionHandler;

        public CounselRequestDetailPage(CounselRequestDto counselRequest)
        {
            InitializeComponent();

            mapInitializer = App.LogicContext.MapInitializer;
            exceptionHandler = App.LogicContext.ExceptionHandler;
            this.counselRequest = counselRequest;

            counselRequestDetailViewModel = new CounselRequestDetailPageViewModel
            {
                SubjectName = counselRequest.SubjectName,
                StudentName = counselRequest.StudentName,
                CounselDateTime = counselRequest.CounselDateTime
            };

            Title = counselRequest.ToString();
            BindingContext = counselRequestDetailViewModel;
        }

        protected override void OnAppearing()
        {
            try
            {
                mapInitializer.Initialize(ref CounselMap, counselRequest.Latitude, counselRequest.Longitude, 0.3f);
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(this, ex);
            }
        }
    }
}
