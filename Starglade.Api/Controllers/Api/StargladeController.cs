using Microsoft.AspNetCore.Mvc;

namespace Starglade.Web.Controllers.Api
{
    [Route("[controller]")]
    [ApiController]
    public class StargladeController : ControllerBase
    {
        protected ActionResult<T> Single<T>(T obj)
        {
            if (obj != null)
            {
                return Ok(obj);

            }
            else
            {
                return NotFound();
            }
        }

        protected IActionResult Updated(int result)
        {
            if (result == 1)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


    }
}