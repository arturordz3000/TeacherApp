using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Subjects
{
    public interface ISubjectsService
    {
        Task<List<SubjectDto>> GetSubjects();
    }
}
