using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace JobPortalAPI.Data.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllByCondition(Expression<Func<T, bool>> condition);
        Task<T> GetOneByCondition(Expression<Func<T, bool>> condition);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
