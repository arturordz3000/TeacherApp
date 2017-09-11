using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Sqlite.Models
{
    public class Users
    {
        [PrimaryKey]
        public string User { get; set; }

        public int UserType { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Token { get; set; }
    }
}
