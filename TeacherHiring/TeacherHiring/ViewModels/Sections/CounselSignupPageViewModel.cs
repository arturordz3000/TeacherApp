using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Implementations;

namespace TeacherHiring.ViewModels.Sections
{
    public class CounselSignupPageViewModel : AsyncViewModel
    {
        private CounselDto counsel;

        public CounselDto Counsel
        {
            get
            {
                return counsel;
            }

            set
            {
                OnPropertyChanged(ref counsel, ref value, "Counsel");
            }
        }

        public bool InputsVisible
        {
            get { return !IsBusy; }
        }

        public override void OnBusyChange()
        {
            OnPropertyChanged("InputsVisible");
        }
    }
}
