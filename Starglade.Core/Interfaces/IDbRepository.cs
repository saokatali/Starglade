using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Starglade.Core.Interfaces
{
    public interface IDbRepository<T> : IRepository<T>
    {
        Task<IList<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selection);
    }
}
