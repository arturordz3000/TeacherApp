using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.DataTransferObjects
{
    public class StudentCounselDto
    {
        [JsonProperty("IdAlumnoMateria")]
        public int StudentSubjectId { get; set; }

        [JsonProperty("IdProfesoMateria")]
        public int TeacherSubjectId { get; set; }

        [JsonProperty("IdAlumno")]
        public int StudentId { get; set; }

        [JsonProperty("IdProfesor")]
        public int TeacherId { get; set; }

        [JsonProperty("IdMateria")]
        public int SubjectId { get; set; }

        [JsonProperty("NombreAlumno")]
        public string StudentName { get; set; }

        [JsonProperty("NombreMateria")]
        public string SubjectName { get; set; }

        [JsonProperty("NombreProfesor")]
        public string TeacherName { get; set; }

        [JsonProperty("FechaHora")]
        public DateTime CounselDateTime { get; set; }

        [JsonProperty("Latitud")]
        public double Latitude { get; set; }

        [JsonProperty("Longitud")]
        public double Longitude { get; set; }

        [JsonProperty("Aceptada")]
        public bool IsAccepted { get; set; }
    }
}
