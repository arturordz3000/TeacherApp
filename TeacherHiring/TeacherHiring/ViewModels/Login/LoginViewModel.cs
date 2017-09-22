using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TeacherHiring.ViewModels.Implementations;

namespace TeacherHiring.ViewModels.Login
{
    public class LoginViewModel : AsyncViewModel
    {
        private string user;
        private string password;
        private bool isTeacher;

        public string User
        {
            set
            {
                OnPropertyChanged(ref user, ref value, "User");
            }

            get
            {
                return user;
            }
        }

        public string Password
        {
            set
            {
                OnPropertyChanged(ref password, ref value, "Password");
            }

            get
            {
                return password;
            }
        }

        public bool IsTeacher
        {
            set
            {
                OnPropertyChanged(ref isTeacher, ref value, "IsTeacher");
            }

            get
            {
                return isTeacher;
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
