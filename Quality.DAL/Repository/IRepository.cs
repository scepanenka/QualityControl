using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Delete(T entity);
        void Insert(T entity);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
    }
}
