using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Implementations;

namespace TeacherHiring.ViewModels.Sections
{
    public class RegisterCounselPageViewModel : BaseViewModel
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
                if (subjects != value)
                {
                    subjects = value;
                    OnPropertyChanged("Subjects");
                }
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
                if (selectedSubject != value)
                {
                    selectedSubject = value;
                    OnPropertyChanged("SelectedSubject");
                }
            }
        }
    }
}
