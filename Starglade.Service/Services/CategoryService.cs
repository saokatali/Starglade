using Microsoft.Extensions.Logging;
using Starglade.Core.Entities;
using Starglade.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Starglade.Service.Services
{
    public class CategoryService : ICategoryService
    {
        IDbRepository<Category> dbRepository;
        ILogger<Category> logger;

        public CategoryService(IDbRepository<Category> dbRepository, ILogger<Category> logger)
        {
            this.dbRepository = dbRepository;
            this.logger = logger;
        }

        public async Task<Category> AddAsync(Category category)
        {
            try
            {
                return await dbRepository.AddAsync(category);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to create {nameof(Category)}",ex);
            }
        }

        public async Task<bool> DeleteAsync(Category category)
        {
            try
            {
                return await dbRepository.DeleteAsync(category);
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
                return await dbRepository.GetAllAsync();
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
                return await dbRepository.UpdateAsync(category);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Update {nameof(Category)}", ex);
            }
        }
    }
}
