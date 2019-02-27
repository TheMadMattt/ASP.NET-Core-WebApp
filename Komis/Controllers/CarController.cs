using System;
using System.IO;
using System.Threading.Tasks;
using Komis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CarController : Controller
	{
		private readonly ICarRepository _carRepository;
		private readonly IHostingEnvironment _environment;

		public CarController(ICarRepository carRepository, IHostingEnvironment environment)
		{
			_carRepository = carRepository;
			_environment = environment;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			var cars = _carRepository.GetCars();

			return View(cars);
		}

		public IActionResult Create(string Filename)
		{
			if (!string.IsNullOrEmpty(Filename))
			{
				ViewBag.ImgPath = "/images/" + Filename;
			}

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Car car)
		{
			if (!ModelState.IsValid)
			{
				return View(car);
			}
			
			_carRepository.AddCar(car);

			return RedirectToAction("Index");	
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

		public IActionResult Edit(int id, string Filename)
		{
			var car = _carRepository.GetCarById(id);

			if (car == null)
			{
				return NotFound();
			}

			if (!string.IsNullOrEmpty(Filename))
			{
				ViewBag.ImgPath = "/images/" + Filename;
			}
			else
			{
				ViewBag.ImgPath = car.PhotoURL;
			}

			return View(car);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Car car)
		{
			if (!ModelState.IsValid)
			{
				return View(car);
			}

			_carRepository.EditCar(car);

			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var car = _carRepository.GetCarById(id);

			if (car == null)
			{
				return NotFound();
			}

			return View(car);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Car car, string photoUrl)
		{
			_carRepository.DeleteCar(car);

			if (photoUrl != null)
			{
				var webRoot = _environment.WebRootPath;

				var filePath = Path.Combine(webRoot.ToString() + photoUrl);

				System.IO.File.Delete(filePath);
			}

			return RedirectToAction("Index");
		}

		[HttpPost("UploadFile")]
		public async Task<IActionResult> UploadFile(IFormCollection form)
		{
			var webRoot = _environment.WebRootPath;

			var filePath = Path.Combine(webRoot.ToString() + "\\images\\" + form.Files[0].FileName);

			if (form.Files[0].FileName.Length > 0)
			{
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await form.Files[0].CopyToAsync(stream);
				}
			}

			if (Convert.ToString(form["Id"]) == string.Empty || Convert.ToString(form["Id"]) == "0")
			{
				return RedirectToAction("Create", new {Filename = Convert.ToString(form.Files[0].FileName)});
			}
			else
			{
				return RedirectToAction("Edit", new { Filename = Convert.ToString(form.Files[0].FileName), id = Convert.ToString(form["Id"]) });
			}
		}
	}
}
