using DomainEntities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Counsels
{
    public interface ICounselService
    {
        Task<CounselDto> RegisterCounsel(CounselDto counsel);
        Task<CounselDto[]> GetAvailableCounselsBySubject(SubjectDto subject);
    }
}
