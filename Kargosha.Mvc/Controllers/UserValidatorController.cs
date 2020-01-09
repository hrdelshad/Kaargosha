using System.Threading.Tasks;
using Kargosha.Data.Services.Identity.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kargosha.Mvc.Controllers
{
    [Route("user-validation")]
    public class UserValidatorController : Controller
    {
        private readonly AppUserManager _userManager;

        // public AppUserManager UserManager => _userManager;
        public UserValidatorController(AppUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("validate-username", Name = "ValidateUserName")]
        public async Task<IActionResult> ValidateUserName(string userName)
        {
            var result = await _userManager.Users.AnyAsync(user => user.UserName == userName);
            return Json(!result);
        }

        [HttpGet("validate-email", Name = "ValidateEmail")]
        public async Task<IActionResult> ValidateEmail(string email)
        {
            var result = await _userManager.Users.AnyAsync(user => user.Email == email);
            return Json(!result);
        }
    }
}