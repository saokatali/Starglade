using System;
using System.Collections.Generic;
using System.Text;
using Starglade.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Starglade.Infrastructure.Data
{
    public class DbContextRepository<T> : IDbRepository<T> where T:class
    {
        readonly StargladeDbContext dbContext;

        public DbContextRepository(StargladeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

      

        public async Task<IList<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> condition)
        {
            return await dbContext.Set<T>().Where(condition).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
            return await dbContext.SaveChangesAsync();
           
        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IList<T>> GetPagedListAsync(int pageNo, int records)
        {
            return await dbContext.Set<T>().OrderBy(e => e).Skip((pageNo - 1) * records).Take(records).ToListAsync();
        }

        public async Task<IList<T>> GetPagedListByConditionAsync(Expression<Func<T, bool>> condition, int pageNo, int records)
        {
            return await dbContext.Set<T>().Where(condition).OrderBy(e => e).Skip((pageNo - 1) * records).Take(records).ToListAsync();
        }
    }
}
