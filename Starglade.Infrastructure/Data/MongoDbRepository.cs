using Pluralize.NET.Core;
using Starglade.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Starglade.Infrastructure.Data
{
    public class MongoDbRepository<T> : IMongoDBRepository<T> where T : class
    {
        readonly MongoDBContext dbContext;

        public MongoDbRepository(MongoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            var cl = dbContext.GetDatabase().GetCollection<T>(new Pluralizer().Pluralize(entity.GetType().Name));
            await cl.InsertOneAsync(entity);
            return entity;
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetPagedListAsync(int pageNo, int records)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetPagedListByConditionAsync(Expression<Func<T, bool>> condition, int pageNo, int records)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
