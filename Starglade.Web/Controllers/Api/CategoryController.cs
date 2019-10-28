using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Starglade.Core.Entities;
using Starglade.Core.Interfaces;

namespace Starglade.Web.Controllers.Api
{
   
    public class CategoryController : StargladeController
    {

        ICategoryService categoryService;
        IDistributedCache cache;

        public CategoryController(ICategoryService categoryService, IDistributedCache cache)
        {
            this.categoryService = categoryService;
            this.cache = cache;
        }

        [HttpGet("{id}",Name =nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            var data = JsonSerializer.Deserialize<Category>(Encoding.UTF8.GetString(await cache.GetAsync("cs")));
            var category = await categoryService.GetByIdAsync(id);
            return Ok(category);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.GetAllAsync();
            return Ok(categories);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            var result = await categoryService.AddAsync(category);
            var json = JsonSerializer.Serialize(result);
            await cache.SetAsync("cs",Encoding.UTF8.GetBytes(json));

            return CreatedAtRoute( nameof(Get), new { id = result.CategoryId }, result);

        }
        
    }
}
