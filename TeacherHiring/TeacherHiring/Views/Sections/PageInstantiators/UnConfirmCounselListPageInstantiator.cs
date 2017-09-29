using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TeacherHiring.Views.Sections.PageInstantiators
{
    public class UnConfirmCounselListPageInstantiator : IPageInstatiator
    {
        public Page Instantiate(object parameters)
        {
            return new UnConfirmedCounselListPage((SubjectDto)parameters);
        }
    }
}
