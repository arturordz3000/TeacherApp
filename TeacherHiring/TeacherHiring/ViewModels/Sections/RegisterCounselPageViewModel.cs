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
    public class RegisterCounselPageViewModel : AsyncViewModel
    {
        private SubjectDto[] subjects;
        private SubjectDto selectedSubject;
        private DateTime counselDate = DateTime.Now;
        private TimeSpan counselTime = DateTime.Now.TimeOfDay;

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

        public DateTime CounselDate
        {
            get
            {
                return counselDate;
            }

            set
            {
                OnPropertyChanged(ref counselDate, ref value, "CounselDate");
            }
        }

        public TimeSpan CounselTime
        {
            get
            {
                return counselTime;
            }

            set
            {
                OnPropertyChanged(ref counselTime, ref value, "CounselTime");
            }
        }

        public bool InputsVisible
        {
            get
            {
                return !IsBusy;
            }
        }

        public override void OnBusyChange()
        {
            OnPropertyChanged("InputsVisible");
        }
    }
}
