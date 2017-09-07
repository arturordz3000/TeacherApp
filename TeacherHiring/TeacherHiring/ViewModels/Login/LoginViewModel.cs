using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TeacherHiring.ViewModels.Login
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string user;
        private string password;
        private bool isTeacher;

        public event PropertyChangedEventHandler PropertyChanged;

        public string User
        {
            set
            {
                if (user != value)
                {
                    user = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("User"));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsTeacher"));
                }
            }

            get
            {
                return isTeacher;
            }
        }
    }
}
