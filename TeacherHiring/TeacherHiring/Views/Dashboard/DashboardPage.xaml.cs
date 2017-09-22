using Common.Handlers;
using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Dashboard;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeacherHiring.Views.Dashboard
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : MasterDetailPage
    {
        private IExceptionHandler exceptionHandler;

        public DashboardPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            exceptionHandler = App.LogicContext.ExceptionHandler;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = e.SelectedItem as DashboardPageMenuItem;
                if (item == null)
                    return;

                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;
                Detail = new NavigationPage(page);
                MasterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(this, ex);
            }

        }
    }

}
