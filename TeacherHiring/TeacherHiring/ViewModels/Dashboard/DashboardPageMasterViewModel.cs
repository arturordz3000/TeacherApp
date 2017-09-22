using Common.Enums;
using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.Views.Dashboard;
using TeacherHiring.Views.Dashboard.Factory;

namespace TeacherHiring.ViewModels.Dashboard
{
    public class DashboardPageMasterViewModel : INotifyPropertyChanged
    {
        public string UserLabelText { get; set; }
        public ObservableCollection<DashboardPageMenuItem> MenuItems { get; }

        private IDetailPageFactory detailPageFactory;

        public DashboardPageMasterViewModel(UserDto user, IDetailPageFactory detailPageFactory)
        {
            this.detailPageFactory = detailPageFactory;
            string userTypeDescription = user.UserTypeId == (int)UserType.Teacher ? "Profesor" : "Alumno";

            UserLabelText = string.Format("{0} ({1})", user.Name, userTypeDescription);
            MenuItems = initializeMenuItemsByUserType(user.UserTypeId);
        }

        private ObservableCollection<DashboardPageMenuItem> initializeMenuItemsByUserType(int userType)
        {
            switch ((UserType)userType)
            {
                case UserType.Teacher:
                    return initializeTeacherMenuItems();
                case UserType.Student:
                    return initializeStudentMenuItems();
                default:
                    throw new Exception("User type is not supported");
            }
        }

        private ObservableCollection<DashboardPageMenuItem> initializeStudentMenuItems()
        {
            return new ObservableCollection<DashboardPageMenuItem>(buildPageMenuItems(
                "Solicitar Asesoría",
                "Solicitudes Realizadas"
            ));
        }

        private ObservableCollection<DashboardPageMenuItem> initializeTeacherMenuItems()
        {
            return new ObservableCollection<DashboardPageMenuItem>(buildPageMenuItems(
                "Registrar Asesoría",
                "Confirmar Asesoría",
                "Asesorías Aceptadas"
            ));
        }

        private DashboardPageMenuItem[] buildPageMenuItems(params string[] itemsTitles)
        {
            List<DashboardPageMenuItem> items = new List<DashboardPageMenuItem>();

            for (int i = 0; i < itemsTitles.Length; i++)
            {
                DashboardPageMenuItem menuItem = detailPageFactory.CreateMenuItem(i, itemsTitles[i]);
                items.Add(menuItem);
            }

            return items.ToArray();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
