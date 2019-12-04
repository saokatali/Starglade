using Microsoft.AspNetCore.Mvc;

namespace Starglade.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("API Works!");
        }


    }
}
