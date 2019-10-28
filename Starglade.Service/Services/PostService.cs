using System;
using System.Collections.Generic;
using System.Text;
using Starglade.Core.Entities;
using Starglade.Core.Interfaces;
using Starglade.Infrastructure.Data;

namespace Starglade.Service.Services
{
    public class PostService: IPostService
    {
        IDbRepository<Post> dbRepository;

        public PostService(IDbRepository<Post> dbRepository)
        {
            this.dbRepository = dbRepository;
        }
    }
}
