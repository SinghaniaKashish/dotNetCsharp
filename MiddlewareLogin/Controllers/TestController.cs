using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewareLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok("Data is accessible to all! No authentication needed!");
        }

        [HttpGet("secured")]
        public IActionResult GetSecuredData()
        {
            return Ok(" Api key is correct");
        }


    }
}
