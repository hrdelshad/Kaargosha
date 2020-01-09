using System.Threading.Tasks;
using Kargosha.Data.Domain.Identity;
using Kargosha.Data.DTOs.Account;
using Kargosha.Data.Services.Identity.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kargosha.Mvc.Controllers
{
	[Route("account")]
	public class AccountController : Controller
	{
		private readonly AppUserManager _userManager;
		private readonly AppSigninManager _signinManager;

		public AccountController(AppUserManager userManager, AppSigninManager signinManager)
		{
			_userManager = userManager;
			_signinManager = signinManager;
		}

		[HttpGet("sign-up", Name = "GetRegister")]
		public IActionResult Register(string returnTo)
		{
			ViewData["returnTo"] = returnTo;
			return View();
		}

		[HttpPost("sign-up", Name = "PostRegister")]
		public async Task<IActionResult> Register(RegisterAccount account, string returnTo)
		{
			if (ModelState.IsValid)
			{
				var user = new User
				{
					UserName = account.UserName,
					Email = account.Email,
					FirstName = account.FirstName,
					LastName = account.LastName,
				};
				var result = await _userManager.CreateAsync(user, account.Password);
				if (result.Succeeded)
				{
					// Todo 
					await _signinManager.SignInAsync(user, false);
					return RedirectToLocal(returnTo);
				}
				this.addErrors(result);
			}
			return View(account);
		}

		[HttpGet("sign-in", Name = "GetLogin")]
		public IActionResult Login(string returnTo)
		{
			ViewData["returnTo"] = returnTo;
			return View();
		}

		[HttpPost("sign-in", Name = "PostLogin")]
		public async Task<IActionResult> Login(LoginAccount account, string returnTo = "/")
		{
			if (ModelState.IsValid)
			{

				var result = await _signinManager.PasswordSignInAsync(
					userName: account.UserName,
					password: account.Password,
					isPersistent: account.RememberMe,
					lockoutOnFailure: false);

				if (result.Succeeded)
				{
					return RedirectToLocal(returnTo);
				}

				if (result.RequiresTwoFactor)
				{

				}
				if (result.IsLockedOut)
				{
					return View("LockOut");
				}
				if (result.IsNotAllowed)
				{
					if (_userManager.Options.SignIn.RequireConfirmedPhoneNumber)
					{
						if (!await _userManager.IsPhoneNumberConfirmedAsync(new User { UserName = account.UserName }))
						{
							ModelState.AddModelError(string.Empty, "شماره مویایل شما تایید نشده است!");
							return View(account);
						}

					}
					if (_userManager.Options.SignIn.RequireConfirmedEmail)
					{
						if (!await _userManager.IsEmailConfirmedAsync(new User { UserName = account.UserName }))
						{
							ModelState.AddModelError(string.Empty, "آدرس ایمیل شما تایید نشده است!");
							return View(account);
						}

					}
					ModelState.AddModelError(string.Empty, "شما اجازه ورود ندارید!");
				}
			}
			return View(account);
		}
		private IActionResult RedirectToLocal(string returnTo)
		{
			return Redirect(Url.IsLocalUrl(returnTo) ? returnTo : "/");
		}
		private void addErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}
	}
}