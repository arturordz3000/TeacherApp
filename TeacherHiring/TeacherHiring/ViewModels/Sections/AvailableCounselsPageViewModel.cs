using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Implementations;

namespace TeacherHiring.ViewModels.Sections
{
    public class AvailableCounselsPageViewModel : BaseViewModel
    {
        private SubjectDto subject;
        private CounselDto[] counsels;
        private CounselDto selectedCounsel;

        public SubjectDto Subject
        {
            get
            {
                return subject;
            }

            set
            {
                OnPropertyChanged(ref subject, ref value, "Subject");
            }
        }

        public CounselDto[] Counsels
        {
            get
            {
                return counsels;
            }

            set
            {
                OnPropertyChanged(ref counsels, ref value, "Counsels");
            }
        }

        public CounselDto SelectedCounsel
        {
            get
            {
                return selectedCounsel;
            }

            set
            {
                OnPropertyChanged(ref selectedCounsel, ref value, "SelectedCounsel");
            }
        }
    }
}
