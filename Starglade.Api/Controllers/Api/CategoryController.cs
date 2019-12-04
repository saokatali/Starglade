using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Starglade.Core.Entities;
using Starglade.Core.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var category = await categoryService.GetByIdAsync(id);
            return Single<Category>(category);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Category>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var categories = await categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(Category category)
        {
            var result = await categoryService.AddAsync(category);
            var json = JsonSerializer.Serialize(result);
            await cache.SetAsync("cs", Encoding.UTF8.GetBytes(json));

            return CreatedAtAction(nameof(Get), new { id = result.CategoryId }, result);

        }

    }
}
