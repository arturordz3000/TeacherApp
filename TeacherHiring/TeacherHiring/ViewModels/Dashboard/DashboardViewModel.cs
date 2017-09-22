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
                OnPropertyChanged(ref userName, ref value, "UserName");
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
                OnPropertyChanged(ref userType, ref value, "UserType");
            }

            get
            {
                return userType;
            }
        }
    }
}
