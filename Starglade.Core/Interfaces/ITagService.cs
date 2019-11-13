using Starglade.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starglade.Service.Services
{
    public interface ITagService
    {
        Task<Tag> GetByIdAsync(int id);
        Task<IList<Tag>> GetAllAsync();
        Task<Tag> AddAsync(Tag Tag);

        Task<int> UpdateAsync(Tag Tag);

        Task<bool> DeleteAsync(Tag Tag);
    }
}