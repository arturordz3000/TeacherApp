using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void AddRange(IEnumerable<T> range);

        void Update(T entity);

        void Delete(T entity);
    }
}
