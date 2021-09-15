using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.API.Controllers
{
    /// <summary>
    /// <see cref="HomeController"/>
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
