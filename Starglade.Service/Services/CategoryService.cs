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
        IRepository<Category> dbRepository;
        ILogger<Category> logger;

        public CategoryService(IRepository<Category> dbRepository, ILogger<Category> logger)
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

                throw new Exception($"Failed to create {nameof(Category)}");
            }
        }

        public Task<bool> DeleteAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
