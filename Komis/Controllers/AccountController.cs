using System.Threading.Tasks;
using Komis.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<IdentityUser> _signInManager;

		private readonly UserManager<IdentityUser> _userManager;

		public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		// GET: /<controller>/
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVm)
		{
			if (!ModelState.IsValid)
			{
				return View(loginVm);
			}

			var user = await _userManager.FindByNameAsync(loginVm.Username);

			if (user != null)
			{
				var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
			}

			ModelState.AddModelError("", "Nazwa użytkownika lub hasło są niepoprawne!");

			return View(loginVm);
		}

		public IActionResult Register()
		{
			return View(new LoginVM());
		}

		[HttpPost]
		public async Task<IActionResult> Register(LoginVM loginVm)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser() {UserName = loginVm.Username};
				var result = await _userManager.CreateAsync(user, loginVm.Password);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
			}

			return View(loginVm);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}
