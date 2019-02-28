using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Komis.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Komis.Controllers
{
	public class HomeController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly ICarRepository _carRepository;

		public HomeController(ICarRepository carRepository)
		{
			this._carRepository = carRepository;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			var cars = _carRepository.GetCars().OrderBy(s => s.Mark);

			var homeVM = new HomeVM()
			{
				Title = "Przegląd samochodów",
				carList = cars.ToList()
			};

			return View(homeVM);
		}

		public IActionResult Details(int id)
		{
			var car = _carRepository.GetCarById(id);

			if (car == null)
			{
				return NotFound();
			}

			return View(car);
		}
	}
}
