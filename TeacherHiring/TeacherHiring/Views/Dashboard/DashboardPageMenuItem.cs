using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiring.Views.Dashboard
{

    public class DashboardPageMenuItem
    {
        public DashboardPageMenuItem()
        {
            TargetType = typeof(DashboardPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
