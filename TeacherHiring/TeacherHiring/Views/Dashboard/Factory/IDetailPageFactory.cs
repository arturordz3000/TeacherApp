using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiring.Views.Dashboard.Factory
{
    public interface IDetailPageFactory
    {
        DashboardPageMenuItem CreateMenuItem(int id, string title);
    }
}
