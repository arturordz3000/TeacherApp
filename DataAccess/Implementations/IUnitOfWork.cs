using DataAccess.Implementations;
using DataAccess.Sqlite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public interface IUnitOfWork
    {
        IRepository<User> UserDataRepository { get; }
        void Commit();
    }
}
