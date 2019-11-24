using Microsoft.Extensions.Logging;
using Starglade.Core.Constants;
using Starglade.Core.Entities;
using Starglade.Core.Interfaces;
using Starglade.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Starglade.Service.Services
{
    public class CategoryService : ICategoryService
    {
        IDbRepository<Category> dbRepository;
        ICacheRepository cache;
        ILogger<Category> logger;
        IBusClient busClient;

        public CategoryService(IDbRepository<Category> dbRepository, ICacheRepository cache, ILogger<Category> logger, IBusClient busClient)
        {
            this.dbRepository = dbRepository;
            this.cache = cache;
            this.logger = logger;
            this.busClient = busClient;
        }

        public async Task<Category> AddAsync(Category category)
        {
            try
            {
                category = await dbRepository.AddAsync(category);

                busClient.Publish(new CategoryCreated());

                return category;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to create {nameof(Category)}", ex);
            }
        }

        public async Task<int> DeleteAsync(Category category)
        {
            try
            {
                var result = await dbRepository.DeleteAsync(category);
                busClient.Publish(new CategoryCreated());
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Delete {nameof(Category)}", ex);
            }
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            try
            {
                var data = await cache.GetAsync<IList<Category>>(CacheConstant.CATEGORY_KEY);
                if (data == null)
                {
                    data = await dbRepository.GetAllAsync();
                    cache.SetAsync(CacheConstant.CATEGORY_KEY, data);
                }
                return data;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Get All {nameof(Category)}", ex);
            }
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            try
            {
                return await dbRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Get {nameof(Category)}", ex);
            }
        }

        public async Task<int> UpdateAsync(Category category)
        {
            try
            {
                var result = await dbRepository.UpdateAsync(category);
                busClient.Publish(new CategoryCreated());
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Update {nameof(Category)}", ex);
            }
        }


    }
}
