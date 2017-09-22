using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities.DataTransferObjects;
using Services.Http.Implementations;
using Services.Http.Resolvers;

namespace Services.Subjects
{
    public class SubjectsService : ISubjectsService
    {
        private IHttpClient httpClient;
        private EndpointResolver endpointResolver;

        public SubjectsService(IHttpClient httpClient, EndpointResolver endpointResolver)
        {
            this.httpClient = httpClient;
            this.endpointResolver = endpointResolver;
        }

        public async Task<List<SubjectDto>> GetSubjects()
        {
            string endpoint = endpointResolver.ResolveUrl("GetListMateriaApps", "Materia");
            IHttpClientResponse clientResponse = await httpClient.Get(endpoint);

            return clientResponse.GetContentAsObject<List<SubjectDto>>();
        }
    }
}
