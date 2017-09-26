using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Implementations;

namespace TeacherHiring.ViewModels.Sections
{
    public class RequestCounselPageViewModel : BaseViewModel
    {
        private SubjectDto[] subjects;
        private SubjectDto selectedSubject;

        public SubjectDto[] Subjects
        {
            get
            {
                return subjects;
            }

            set
            {
                OnPropertyChanged(ref subjects, ref value, "Subjects");
            }
        }

        public SubjectDto SelectedSubject
        {
            get
            {
                return selectedSubject;
            }

            set
            {
                OnPropertyChanged(ref selectedSubject, ref value, "SelectedSubject");
            }
        }
    }
}
