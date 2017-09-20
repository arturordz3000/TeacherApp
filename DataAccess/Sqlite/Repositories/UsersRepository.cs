using DataAccess.Implementations;
using DataAccess.Sqlite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SQLite;

namespace DataAccess.Sqlite.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private SQLiteConnection context;

        public UsersRepository(IContext context)
        {
            this.context = (SQLiteConnection)context.GetContext();
        }

        public object Add(User entity)
        {
            return context.Insert(entity);
        }

        public object Delete(User entity)
        {
            return context.Delete(entity);
        }

        public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return context.Table<User>().Where(predicate).AsQueryable();
        }

        public IQueryable<User> GetAll()
        {
            return context.Table<User>().AsQueryable();
        }

        public object Update(User entity)
        {
            return context.Update(entity);
        }
    }
}
