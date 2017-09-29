using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Implementations;

namespace TeacherHiring.ViewModels.Sections
{
    public class ConfirmCounselListPageViewModel : BaseViewModel
    {
        private CounselRequestDto[] counselRequests;
        private CounselRequestDto selectedCounselRequest;

        public CounselRequestDto[] CounselRequests
        {
            get
            {
                return counselRequests;
            }

            set
            {
                OnPropertyChanged(ref counselRequests, ref value, "CounselRequests");
            }
        }

        public CounselRequestDto SelectedCounselRequest
        {
            get
            {
                return selectedCounselRequest;
            }

            set
            {
                OnPropertyChanged(ref selectedCounselRequest, ref value, "SelectedCounselRequest");
            }
        }
    }
}
