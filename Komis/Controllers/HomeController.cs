﻿using System;
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
		private readonly ICarRepository carRepository;

		public HomeController(ICarRepository carRepository)
		{
			this.carRepository = carRepository;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			var cars = carRepository.GetCars().OrderBy(s => s.Model);

			var homeVM = new HomeVM()
			{
				Title = "Przeglad samochodow",
				carList = cars.ToList()
			};

			return View(homeVM);
		}
	}
}