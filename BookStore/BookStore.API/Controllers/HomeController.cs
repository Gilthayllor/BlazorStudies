using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    /// <summary>
    /// <see cref="HomeController"/>
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Index
        /// </summary>
        /// <returns><see cref="int"/></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello World");
        }
    }
}
