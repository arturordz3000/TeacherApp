using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.DataTransferObjects
{
    public class SubjectDto
    {
        [JsonProperty("MateriaId")]
        public int SubjectId { get; set; }

        [JsonProperty("Descripcion")]
        public string Description { get; set; }

        [JsonProperty("Disponibles")]
        public int AvailableCounsels { get; set; }

        public override string ToString()
        {
            return Description + string.Format("({0} disponibles)", AvailableCounsels);
        }
    }
}
