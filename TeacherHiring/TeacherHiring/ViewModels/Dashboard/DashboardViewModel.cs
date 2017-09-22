using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiring.ViewModels.Dashboard
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private string userName;
        private int userType;

        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName
        {
            set
            {
                if (userName != value)
                {
                    userName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserName"));
                }
            }

            get
            {
                return userName;
            }
        }

        public int UserType
        {
            set
            {
                if (userType != value)
                {
                    userType = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserType"));
                }
            }

            get
            {
                return userType;
            }
        }
    }
}
