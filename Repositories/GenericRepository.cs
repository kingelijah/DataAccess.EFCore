using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
       
        public async Task UpdateAsync(T entity) => _context.Set<T>().Update(entity);
      
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
       

        public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking();
       
        public async Task<IEnumerable<T>> GetAllAsync() => _context.Set<T>().ToList();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
      

        public async Task RemoveAsync(T entity) => _context.Set<T>().Remove(entity);       


    }
}
