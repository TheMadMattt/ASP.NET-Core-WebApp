using System.Collections.Generic;
using System.Linq;

namespace Komis.Model
{
	public class MockCarRepository : ICarRepository
	{
		private List<Car> carList;

		public MockCarRepository()
		{
			if (carList == null)
			{
				LoadCars();
			}
		}

		private void LoadCars()
		{
			carList = new List<Car>
			{
				new Car
				{
					Id = 1, Mark = "Ford", Model = "Mustang", ProductionYear = 2016, Mileage = "34 000 km",
					TankSize = "4 900 cm3", FuelType = "Benzyna", Price = 160000M,
					Description = "lorem ipsum lorem ipsum lorem ipsum", Power = "412KM",
					PhotoURL = "/images/fordMustang.jpg", ThumbnailURL = "/images/fordMustang.jpg",
					IsCarOfTheWeek = true
				},
				new Car
				{
					Id = 1, Mark = "Ford", Model = "Galaxy", ProductionYear = 2005, Mileage = "134 000 km",
					TankSize = "4 900 cm3", FuelType = "Diesel", Price = 54000M,
					Description = "lorem ipsum lorem ipsum lorem ipsum", Power = "109KM",
					PhotoURL = "/images/fordGalaxy.jpg", ThumbnailURL = "/images/fordGalaxy.jpg", IsCarOfTheWeek = false
				},
				new Car
				{
				Id = 1, Mark = "Ford", Model = "Focus", ProductionYear = 2008, Mileage = "200 000 km",
				TankSize = "5 000 cm3", FuelType = "Diesel", Price = 10000M,
				Description = "lorem ipsum lorem ipsum lorem ipsum", Power = "151KM",
				PhotoURL = "/images/fordFocus.jpg", ThumbnailURL = "/images/fordFocus.jpg", IsCarOfTheWeek = true
				}
			};

		}

		public IEnumerable<Car> GetCars()
		{
			return carList;
		}

		public Car GetCarById(int carId)
		{
			return carList.FirstOrDefault(s => s.Id == carId);
		}
	}
}
