using Starglade.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Starglade.Core.Interfaces
{
    public interface IPostService
    {
        Task<Post> GetByIdAsync(int id);
        Task<IList<Post>> GetAllAsync();
        Task<Post> AddAsync(Post Post);

        Task<int> UpdateAsync(Post Post);

        Task<bool> DeleteAsync(Post Post);
    }
}
