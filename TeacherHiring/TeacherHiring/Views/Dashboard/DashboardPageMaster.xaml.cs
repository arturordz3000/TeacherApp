using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeacherHiring.Views.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPageMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public DashboardPageMaster()
        {
            InitializeComponent();
            BindingContext = new DashboardPageMasterViewModel();
        }



        class DashboardPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DashboardPageMenuItem> MenuItems { get; }
            public DashboardPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<DashboardPageMenuItem>(new[]
                {
                    new DashboardPageMenuItem { Id = 0, Title = "Page 1" },
                    new DashboardPageMenuItem { Id = 1, Title = "Page 2" },
                    new DashboardPageMenuItem { Id = 2, Title = "Page 3" },
                    new DashboardPageMenuItem { Id = 3, Title = "Page 4" },
                    new DashboardPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
