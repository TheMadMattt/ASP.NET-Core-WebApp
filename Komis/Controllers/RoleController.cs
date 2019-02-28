using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
    public class RoleController : Controller
    {
	    private readonly AppDbContext _context;

	    private readonly RoleManager<IdentityRole> _roleManager;

	    public RoleController(AppDbContext context, RoleManager<IdentityRole> roleManager)
	    {
		    _context = context;
		    _roleManager = roleManager;
	    }

	    public IActionResult Index()
	    {
		    var roles = _context.Roles.ToList();
            return View(roles);
        }

	    public IActionResult Create()
	    {
		    var role = new IdentityRole();
		    return View(role);
	    }

		[HttpPost]
		[ValidateAntiForgeryToken]
	    public async Task<IActionResult> Create(IdentityRole role)
	    {
		    if (!await _roleManager.RoleExistsAsync(role.Name))
		    {
			    await _roleManager.CreateAsync(role);
		    }

		    return RedirectToAction("Index");
	    }

	    [HttpPost]
		[ValidateAntiForgeryToken]
	    public async Task<IActionResult> DeleteRole(string id)
	    {
		    var role = await _roleManager.FindByIdAsync(id);

		    if (role != null)
		    {
			    _context.Roles.Remove(role);
			    _context.SaveChanges();
		    }

		    return RedirectToAction("Index");
	    }
    }
}