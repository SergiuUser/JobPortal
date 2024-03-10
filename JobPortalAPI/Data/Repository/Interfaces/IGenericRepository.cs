using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace JobPortalAPI.Data.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> condition);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
