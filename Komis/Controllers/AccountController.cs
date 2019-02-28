using System.Linq;
using System.Threading.Tasks;
using Komis.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Komis.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<IdentityUser> _signInManager;

		private readonly UserManager<IdentityUser> _userManager;

		private RoleManager<IdentityRole> _roleManager;

		public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_roleManager = roleManager;
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

		public IActionResult AssignRole()
		{
			ViewBag.RoleName = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
			ViewBag.Username = new SelectList(_userManager.Users.ToList(), "UserName", "UserName");

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AssignRole(IdentityRole model, IdentityUser user)
		{

			var currentUser = await _userManager.FindByNameAsync(user.UserName);
			if (!await _userManager.IsInRoleAsync(currentUser, "Admin"))
			{
				var currentRole = _userManager.GetRolesAsync(currentUser).Result;
				if (currentRole.Count == 0)
				{
					await _userManager.AddToRoleAsync(currentUser, model.Name);
				}
				else
				{
					await _userManager.RemoveFromRoleAsync(currentUser, currentRole[0]);
					await _userManager.AddToRoleAsync(currentUser, model.Name);
				}
			}

			return RedirectToAction("Index", "Role");
		}
	}
}
