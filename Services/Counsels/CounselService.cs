using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities.DataTransferObjects;
using Services.Http.Implementations;
using Services.Http.Resolvers;

namespace Services.Counsels
{
    public class CounselService : ICounselService
    {
        private IHttpClient httpClient;
        private EndpointResolver endpointResolver;

        public CounselService(IHttpClient httpClient, EndpointResolver endpointResolver)
        {
            this.httpClient = httpClient;
            this.endpointResolver = endpointResolver;
        }

        public async Task<CounselDto> RegisterCounsel(CounselDto counsel)
        {
            string endpoint = endpointResolver.ResolveUrl("InsProfesorMateriaApp", "ProfesorMateria");
            IHttpClientResponse clientResponse = await httpClient.Post(endpoint, counsel);

            return clientResponse.GetContentAsObject<CounselDto>();
        }

        public async Task<CounselDto[]> GetAvailableCounselsBySubject(SubjectDto subject)
        {
            string endpoint = endpointResolver.ResolveUrl("GetListProfesorMateriaApp", "AlumnoMateria") + "?idMateria=" + subject.SubjectId;
            IHttpClientResponse clientResponse = await httpClient.Get(endpoint);

            return clientResponse.GetContentAsObject<CounselDto[]>();
        }

        public async Task<StudentCounselDto> SignupToCounsel(UserDto student, CounselDto counsel)
        {
            string endpoint = endpointResolver.ResolveUrl("InsProfesorMateriaApp", "AlumnoMateria")
                + "?idAlumno=" + student.UserId + "&idProfesorMateria=" + counsel.TeacherSubjectId;

            IHttpClientResponse clientResponse = await httpClient.Post(endpoint, new { });

            return clientResponse.GetContentAsObject<StudentCounselDto>();
        }
    }
}
