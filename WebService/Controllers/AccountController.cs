using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebService.ViewModels;
using WebService.ViewModels.Account;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginViewModel vm)
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterViewModel vm)
        {
            return Ok();
        }
    }
}