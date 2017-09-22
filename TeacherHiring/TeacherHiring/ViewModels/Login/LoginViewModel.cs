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
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged("User");
                }
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
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
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
                if (isTeacher != value)
                {
                    isTeacher = value;
                    OnPropertyChanged("IsTeacher");
                }
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
