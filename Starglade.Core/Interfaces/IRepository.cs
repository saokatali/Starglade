using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Starglade.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();

        Task<IList<T>> GetByConditionAsync(Expression<Func<T,bool>> condition);

        Task<T> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);


    }
}
