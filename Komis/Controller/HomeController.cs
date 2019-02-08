using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Komis.Controller
{
	public class HomeController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly ICarRepository carRepository;

		public HomeController(ICarRepository carRepository)
		{
			this.carRepository = carRepository;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View(carRepository.GetCars());
		}
	}
}
