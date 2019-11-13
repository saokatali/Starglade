using Microsoft.Extensions.Logging;
using Starglade.Core.Constants;
using Starglade.Core.Entities;
using Starglade.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Starglade.Core.Messages;

namespace Starglade.Service.Services
{
    public class TagService : ITagService
    {
        IDbRepository<Tag> dbRepository;
        ICacheRepository cache;
        ILogger<Tag> logger;
        IBusClient busClient;

        public TagService(IDbRepository<Tag> dbRepository, ICacheRepository cache, ILogger<Tag> logger, IBusClient busClient)
        {
            this.dbRepository = dbRepository;
            this.cache = cache;
            this.logger = logger;
            this.busClient = busClient;
        }

        public async Task<Tag> AddAsync(Tag Tag)
        {
            try
            {
                Tag = await dbRepository.AddAsync(Tag);

                busClient.Publish(new TagCreated());

                return Tag;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to create {nameof(Tag)}", ex);
            }
        }

        public async Task<bool> DeleteAsync(Tag Tag)
        {
            try
            {
                var result = await dbRepository.DeleteAsync(Tag);
                busClient.Publish(new TagCreated());
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Delete {nameof(Tag)}", ex);
            }
        }

        public async Task<IList<Tag>> GetAllAsync()
        {
            try
            {
                var data = await cache.GetAsync<IList<Tag>>(CacheConstant.TAG_KEY);
                if (data == null)
                {
                    data = await dbRepository.GetAllAsync();
                    cache.SetAsync(CacheConstant.TAG_KEY, data);
                }
                return data;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Get All {nameof(Tag)}", ex);
            }
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            try
            {
                return await dbRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Get {nameof(Tag)}", ex);
            }
        }

        public async Task<int> UpdateAsync(Tag Tag)
        {
            try
            {
                var result = await dbRepository.UpdateAsync(Tag);
                busClient.Publish(new TagCreated());
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Update {nameof(Tag)}", ex);
            }
        }


    }
}
