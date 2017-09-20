using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.DataTransferObjects
{
    public class UserDto
    {
        [JsonProperty("Id")]
        public int UserId { get; set; }

        [JsonProperty("IdTipoPerson")]
        public int UserTypeId { get; set; }

        [JsonProperty("Nombre")]
        public string Name { get; set; }

        [JsonProperty("ClientCreatedOn")]
        public DateTime UserCreatedOn { get; set; }

        public string Token { get; set; }
    }
}
