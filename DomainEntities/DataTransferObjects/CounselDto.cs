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

        public override string ToString()
        {
            return string.Format("{0} - {1}", TeacherName, CounselDateTime.ToString("dd/mm/yyyy hh:mm"));
        }
    }
}
