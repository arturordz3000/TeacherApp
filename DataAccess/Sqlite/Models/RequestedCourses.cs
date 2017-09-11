using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Sqlite.Models
{
    public class RequestedCourses
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime CourseDateTime { get; set; }

        public string TeacherName { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string User { get; set; } 
    }
}
