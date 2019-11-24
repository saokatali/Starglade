using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Starglade.Core.Entities;

namespace Starglade.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);
        Task<IList<Category>> GetAllAsync();
        Task<Category> AddAsync(Category category);

        Task<int> UpdateAsync(Category category );

        Task<int> DeleteAsync(Category category);

    }
}
