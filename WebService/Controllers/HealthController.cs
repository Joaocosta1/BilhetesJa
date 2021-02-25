using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Repository;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : Controller
    {
        private readonly ApplicationContext _context;

        public HealthController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult Ping() => Ok("pong");

        [HttpGet]
        [Route("database")]
        public IActionResult Database()
        {
            if ((_context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                return Ok();
            else
                return BadRequest();
        }
    }
}