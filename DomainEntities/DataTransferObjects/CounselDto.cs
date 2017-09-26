using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.DataTransferObjects
{
    public class CounselDto
    {
        [JsonProperty("IdProfesorMateria")]
        public int TeacherSubjectId { get; set; }

        [JsonProperty("IdMateria")]
        public int SubjectId { get; set; }

        [JsonProperty("IdProfesor")]
        public int TeacherUserId { get; set; }

        [JsonProperty("FechaHora")]
        public DateTime CounselDateTime { get; set; }

        [JsonProperty("Latitud")]
        public double Latitude { get; set; }

        [JsonProperty("Longitud")]
        public double Longitude { get; set; }

        [JsonProperty("NombreMateria")]
        public string SubjectName { get; set; }

        [JsonProperty("NombreProfesor")]
        public string TeacherName { get; set; }
    }
}
