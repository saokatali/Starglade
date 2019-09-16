using Starglade.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pluralize.NET.Core;


namespace Starglade.Infrastructure.Data
{
    public class MongoDbRepository<T> : IDbRepository<T> where T : class
    {
        readonly MonoDBContext dbContext;

        public MongoDbRepository(MonoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            var cl = dbContext.GetDatabase().GetCollection<T>(new Pluralizer().Pluralize(nameof(T)));
            await cl.InsertOneAsync(entity);
            return entity;
        }

        public Task<bool> DeleteAsync(T entity)
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

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
