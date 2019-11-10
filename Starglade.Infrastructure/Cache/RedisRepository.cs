using Microsoft.Extensions.Caching.Distributed;
using Starglade.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Starglade.Infrastructure.Cache
{
    public class RedisRepository: ICacheRepository
    {
        IDistributedCache cache;


        public RedisRepository(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var data = await cache.GetStringAsync(key);
            T value = default(T);
            if (!string.IsNullOrEmpty(data))
            {
                value = JsonSerializer.Deserialize<T>(data);

            }
            return value;
        }

        public async void SetAsync<T>(string key, T value)
        {
            await cache.SetStringAsync(key, JsonSerializer.Serialize(value));

        }
    }
}
