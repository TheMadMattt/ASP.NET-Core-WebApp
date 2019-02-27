using System.Linq;
using Komis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
    public class RoleController : Controller
    {
	    private AppDbContext _context;

	    public RoleController(AppDbContext context)
	    {
		    _context = context;
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
	    public IActionResult Create(IdentityRole role)
	    {
		    _context.Roles.Add(role);
		    _context.SaveChanges();
		    return RedirectToAction("Index");
	    }
	}
}