using Microsoft.AspNetCore.Mvc;
using Infrastructure.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Logger.Log("health ping");
            var x = new Random().Next();
            if (x % 13 == 0) throw new Exception("random failure");
            return Ok("ok " + x);
        }
    }
}