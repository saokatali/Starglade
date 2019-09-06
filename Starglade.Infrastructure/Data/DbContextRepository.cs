﻿using System;
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

        public async Task<bool> DeleteAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
            int deletedRecord =  await dbContext.SaveChangesAsync();

            return deletedRecord == 1 ? true : false;

        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }
    }
}