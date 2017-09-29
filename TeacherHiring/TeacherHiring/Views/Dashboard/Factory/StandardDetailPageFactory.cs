using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.Views.Sections;
using TeacherHiring.Views.Sections.PageInstantiators;
using Xamarin.Forms;

namespace TeacherHiring.Views.Dashboard.Factory
{
    public class StandardDetailPageFactory : IDetailPageFactory
    {
        private Dictionary<string, Page> targetTypes = new Dictionary<string, Page>();

        public StandardDetailPageFactory()
        {
            // Student Detail Pages
            targetTypes.Add("Solicitar Asesoría", new SubjectsListPage(new AvailableCounselsPageInstantiator()));
            targetTypes.Add("Solicitudes Realizadas", new DashboardPageDetail());

            // Teacher detail pages
            targetTypes.Add("Registrar Asesoría", new RegisterCounselPage());
            targetTypes.Add("Confirmar Asesoría", new SubjectsListPage(new UnConfirmCounselListPageInstantiator()));
            targetTypes.Add("Asesorías Aceptadas", new AcceptedCounselsPage());
        }

        public DashboardPageMenuItem CreateMenuItem(int id, string title)
        {
            return new DashboardPageMenuItem { Id = id, Title = title, TargetType = targetTypes[title] };
        }
    }
}
