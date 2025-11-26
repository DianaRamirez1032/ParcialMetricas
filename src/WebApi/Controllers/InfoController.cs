using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IConfiguration _cfg;

        public InfoController(IConfiguration cfg)
        {
            _cfg = cfg;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                sql = BadDb.ConnectionString,
                env = Environment.GetEnvironmentVariables(),
                version = "v0.0.1-unsecure"
            });
        }
    }
}