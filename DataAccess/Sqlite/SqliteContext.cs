using DataAccess.Implementations;
using DataAccess.Sqlite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.Common;

namespace DataAccess.Sqlite
{
    public class SqliteContext : IContext
    {
        private SQLiteConnection database;

        public SqliteContext()
        {
            database = new SQLiteConnection(Constants.SqliteDBFile);
            initialize();
        }

        private void initialize()
        {
            database.CreateTable<User>();
        }

        public object GetContext()
        {
            return database;
        }
    }
}
