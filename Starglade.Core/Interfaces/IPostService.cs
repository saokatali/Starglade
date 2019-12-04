using Starglade.Core.Entities;
using Starglade.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starglade.Core.Interfaces
{
    public interface IPostService
    {
        Task<Post> GetByIdAsync(int id);
        Task<IList<PostModel>> GetAllAsync();
        Task<Post> AddAsync(Post Post);

        Task<int> UpdateAsync(Post Post);

        Task<int> DeleteAsync(Post Post);
    }
}
