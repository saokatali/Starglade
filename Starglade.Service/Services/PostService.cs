using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Starglade.Core.Entities;
using Starglade.Core.Interfaces;
using Starglade.Infrastructure.Data;

namespace Starglade.Service.Services
{
    public class PostService: IPostService
    {
        IDbRepository<Post> dbRepository;
        private readonly ILogger<Category> logger;

        public PostService(IDbRepository<Post> dbRepository, ILogger<Category> logger)
        {

            this.dbRepository = dbRepository;
            this.logger = logger;
        }

        public async Task<Post> AddAsync(Post Post)
        {
            try
            {
                Post = await dbRepository.AddAsync(Post);
             
                return Post;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to create {nameof(Post)}", ex);
            }
        }

        public async Task<int> DeleteAsync(Post Post)
        {
            try
            {
                return await dbRepository.DeleteAsync(Post);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Delete {nameof(Post)}", ex);
            }
        }

        public async Task<IList<Post>> GetAllAsync()
        {
            try
            {

                return await dbRepository.GetAllAsync(e => new Post { PostId=e.PostId, Title= e.Title, Content= e.Content, Tags= e.Tags, Categories=e.Categories, PublishedOn=e.PublishedOn, TotalComments= e.Comments.Count });
              
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Get All {nameof(Post)}", ex);
            }
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            try
            {
                return await dbRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Get {nameof(Post)}", ex);
            }
        }

        public async Task<int> UpdateAsync(Post Post)
        {
            try
            {
                return await dbRepository.UpdateAsync(Post);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                throw new Exception($"Failed to Update {nameof(Post)}", ex);
            }
        }
    }
}
