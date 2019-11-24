using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starglade.Web.Controllers.Api
{
    [Route("[controller]")]
    [ApiController]
    public class StargladeController : ControllerBase
    {
        protected ActionResult<T> Single<T>(T obj )
        {
            if(obj != null)
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