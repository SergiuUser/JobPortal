using JobPortalAPI.Data.Context;
using JobPortalAPI.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace JobPortalAPI.Data.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly JobPortalContext _context;
        private DbSet<T> table;

        public GenericRepository(JobPortalContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Create(T entity) => table.Add(entity);

        public void Delete(int id)
        {
            var exist = table.Find(id);

            if (exist != null)
                table.Remove(exist);
        }

        public IEnumerable<T> GetAll() => table.ToList();

        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> condition) => table.Where(condition).ToList();

        public void Save() => _context.SaveChanges();

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}


