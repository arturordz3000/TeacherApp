using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Alerts
{
    public interface IAlertDisplayer
    {
        Task DisplayAlert(object sender, string title, string message, string buttonMessage);
    }
}
