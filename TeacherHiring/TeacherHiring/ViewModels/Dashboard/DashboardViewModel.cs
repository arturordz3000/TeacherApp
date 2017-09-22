using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Implementations;

namespace TeacherHiring.ViewModels.Dashboard
{
    public class DashboardViewModel : BaseViewModel
    {
        private string userName;
        private int userType;

        public string UserName
        {
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged("UserName");
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
                    OnPropertyChanged("UserType");
                }
            }

            get
            {
                return userType;
            }
        }
    }
}
