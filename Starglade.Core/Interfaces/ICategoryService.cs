using Starglade.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starglade.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);
        Task<IList<Category>> GetAllAsync();
        Task<Category> AddAsync(Category category);

        Task<int> UpdateAsync(Category category);

        Task<int> DeleteAsync(Category category);

    }
}
