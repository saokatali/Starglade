using System.Threading.Tasks;

namespace Starglade.Core.Interfaces
{
    public interface ICacheRepository
    {
        void SetAsync<T>(string key, T value);

        Task<T> GetAsync<T>(string key);
    }
}
