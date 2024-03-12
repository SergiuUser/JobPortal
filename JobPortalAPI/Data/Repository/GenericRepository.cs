using JobPortalAPI.Data.Context;
using JobPortalAPI.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobPortalAPI.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly JobPortalContext _context;
        private DbSet<T> table;

        public GenericRepository(JobPortalContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task CreateAsync(T entity) => await table.AddAsync(entity);

        public async Task DeleteAsync(int id)
        {
            var exist = await table.FindAsync(id);

            if (exist != null)
                table.Remove(exist);
        }

        public async Task<IEnumerable<T>> GetAll() => await table.ToListAsync();

        public async Task<IEnumerable<T>> GetAllByCondition(Expression<Func<T, bool>> condition) => await table.Where(condition).ToListAsync();

        public async Task<T> GetOneByCondition(Expression<Func<T, bool>> condition) => await table.FirstOrDefaultAsync(condition);
        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task UpdateAsync(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }
    }
}


