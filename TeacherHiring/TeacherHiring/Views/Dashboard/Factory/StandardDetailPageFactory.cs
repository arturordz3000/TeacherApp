using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.Views.Sections;

namespace TeacherHiring.Views.Dashboard.Factory
{
    public class StandardDetailPageFactory : IDetailPageFactory
    {
        private Dictionary<string, Type> targetTypes = new Dictionary<string, Type>();

        public StandardDetailPageFactory()
        {
            // Student Detail Pages
            targetTypes.Add("Solicitar Asesoría", typeof(RequestCounselPage));
            targetTypes.Add("Solicitudes Realizadas", typeof(DashboardPageDetail));

            // Teacher detail pages
            targetTypes.Add("Registrar Asesoría", typeof(RegisterCounselPage));
            targetTypes.Add("Confirmar Asesoría", typeof(ConfirmCounselPage));
            targetTypes.Add("Asesorías Aceptadas", typeof(AcceptedCounselsPage));
        }

        public DashboardPageMenuItem CreateMenuItem(int id, string title)
        {
            return new DashboardPageMenuItem { Id = id, Title = title, TargetType = targetTypes[title] };
        }
    }
}
