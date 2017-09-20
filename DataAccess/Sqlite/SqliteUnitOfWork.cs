using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Implementations;
using DomainEntities.DataTransferObjects;
using DataAccess.Sqlite.Repositories;
using DataAccess.Sqlite.Models;
using System.Reflection;

namespace DataAccess.Sqlite
{
    public class SqliteUnitOfWork : IUnitOfWork
    {
        private IContext context;
        private UsersRepository usersRepository;

        public IRepository<User> UserDataRepository { get { return usersRepository; } }

        public SqliteUnitOfWork(IContext context)
        {
            if (!isValidContext(context))
                throw new ArgumentException("The context for SqliteUnitOfWork must be an instance of SqliteContext");

            this.context = context;
            usersRepository = new UsersRepository(context);
        }

        private bool isValidContext(IContext context)
        {
            return context.GetType().GetTypeInfo().IsSubclassOf(typeof(SqliteContext))
                || context.GetType() == typeof(SqliteContext);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
