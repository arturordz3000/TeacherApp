using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiring.ViewModels.Sections
{
    public class RegisterCounselPageViewModel : INotifyPropertyChanged
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subjects"));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedSubject"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
