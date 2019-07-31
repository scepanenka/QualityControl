using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Delete(T entity);
        void Insert(T entity);
        T GetById(int id);
    }
}
