﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.DataTransferObjects
{
    public class CounselRequestDto
    {
        [JsonProperty("IdAlumnoMateria")]
        public int StudentSubjectId { get; set; }

        [JsonProperty("IdProfesorMateria")]
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
        public string SubjectName { get; set;  }

        [JsonProperty("NombreProfesor")]
        public string TeacherName { get; set; }

        [JsonProperty("FechaHora")]
        public DateTime CounselDateTime { get; set; }

        [JsonProperty("Latitud")]
        public double Latitude { get; set; }

        [JsonProperty("Longitud")]
        public double Longitude { get; set; }

        [JsonProperty("Aceptada")]
        public bool IsConfirmed { get; set; }

        public override string ToString()
        {
            return string.Format("Solicitada por: {0} - {1}", StudentName, CounselDateTime.ToString("dd/MM/yyyy hh:mm"));
        }
    }
}
