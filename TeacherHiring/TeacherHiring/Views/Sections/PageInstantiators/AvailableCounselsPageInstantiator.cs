using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TeacherHiring.Views.Sections.PageInstantiators
{
    public class AvailableCounselsPageInstantiator : IPageInstatiator
    {
        public Page Instantiate(params object[] parameters)
        {
            return new AvailableCounselsPage((SubjectDto)parameters[0]);
        }
    }
}
