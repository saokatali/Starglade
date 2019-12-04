using Microsoft.AspNetCore.Mvc;
using Starglade.Core.Entities;
using Starglade.Core.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Starglade.Web.Controllers.Api
{

    public class PostController : StargladeController
    {
        IPostService postService;

        public PostController(IPostService postService)
        {

            this.postService = postService;
        }

        [HttpGet("{id}")]

        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var posts = await postService.GetByIdAsync(id);
            return Single(posts);

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Post>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Post>> GetAll()
        {
            var posts = await postService.GetAllAsync();
            return Ok(posts);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create(Post post)
        {
            var result = await postService.AddAsync(post);
            return CreatedAtAction(nameof(Get), new { id = result.PostId }, result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update(Post post)
        {
            var result = await postService.UpdateAsync(post);
            return Updated(result);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(Post post)
        {
            var result = await postService.DeleteAsync(post);
            return Updated(result);
        }
    }
}