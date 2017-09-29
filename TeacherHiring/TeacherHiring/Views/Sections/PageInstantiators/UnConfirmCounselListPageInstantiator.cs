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
        private bool showAcceptedRequests;

        public UnConfirmCounselListPageInstantiator(bool showAcceptedRequests)
        {
            this.showAcceptedRequests = showAcceptedRequests;
        }

        public Page Instantiate(params object[] parameters)
        {
            SubjectDto subject = (SubjectDto)parameters[0];
            return new CounselRequestsListPage(subject, showAcceptedRequests);
        }
    }
}
