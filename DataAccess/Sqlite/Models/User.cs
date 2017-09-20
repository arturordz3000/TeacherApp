using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Sqlite.Models
{
    public class User
    {
        [PrimaryKey]
        public int UserId { get; set; }

        public int UserTypeId { get; set; }

        public string Name { get; set; }

        public DateTime UserCreatedOn { get; set; }

        public string Token { get; set; }
    }
}
