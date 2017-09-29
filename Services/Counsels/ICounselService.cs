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
        Task<StudentCounselDto> SignupToCounsel(UserDto student, CounselDto counsel);
        Task<CounselRequestDto[]> GetCounselRequestsForTeacher(UserDto teacherUser, bool accepted);
        Task<CounselRequestDto[]> GetCounselRequestsForStudent(UserDto studentUser);
        Task<CounselRequestDto> AcceptCounselRequest(CounselRequestDto counselRequest);
    }
}
