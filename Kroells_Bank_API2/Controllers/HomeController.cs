using Microsoft.AspNetCore.Mvc;

namespace Kroells_Bank_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello world");
        }
    }
}
