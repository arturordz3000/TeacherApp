using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TeacherHiring.Views.Dashboard
{

    public class DashboardPageMenuItem
    {
        public DashboardPageMenuItem()
        {
            TargetType = new DashboardPageDetail();
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Page TargetType { get; set; }
    }
}
