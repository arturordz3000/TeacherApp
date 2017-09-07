using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Alerts
{
    public class PageAlertDisplayer : IAlertDisplayer
    {
        public Task DisplayAlert(object sender, string title, string message, string buttonMessage)
        {
            Xamarin.Forms.Page page = (Xamarin.Forms.Page)sender;
            return page.DisplayAlert(title, message, buttonMessage);
        }
    }
}
