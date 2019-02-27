using System.Collections.Generic;
using System.Linq;

namespace Komis.Models
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
					Id = 1, Mark = "Chevrolet", Model = "Corvete", ProductionYear = 2005, Mileage = "134 000 km",
					TankSize = "4 900 cm3", FuelType = "Diesel", Price = 54000M,
					Description = "lorem ipsum lorem ipsum lorem ipsum", Power = "109KM",
					PhotoURL = "/images/chevroletCorvete.jpg", ThumbnailURL = "/images/chevroletCorvete.jpg", IsCarOfTheWeek = false
				},
				new Car
				{
				Id = 1, Mark = "Jaguar", Model = " - ", ProductionYear = 2008, Mileage = "200 000 km",
				TankSize = "5 000 cm3", FuelType = "Diesel", Price = 10000M,
				Description = "lorem ipsum lorem ipsum lorem ipsum", Power = "151KM",
				PhotoURL = "/images/jaguar.jpg", ThumbnailURL = "/images/jaguar.jpg", IsCarOfTheWeek = true
				},
                new Car
                {
                Id = 1, Mark = "Audi", Model = "S5", ProductionYear = 2008, Mileage = "200 000 km",
                TankSize = "5 000 cm3", FuelType = "Diesel", Price = 10000M,
                Description = "lorem ipsum lorem ipsum lorem ipsum", Power = "151KM",
                PhotoURL = "/images/audiS5.jpg", ThumbnailURL = "/images/audiS5.jpg", IsCarOfTheWeek = true
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

		public void AddCar(Car car)
		{
			throw new System.NotImplementedException();
		}

		public void EditCar(Car car)
		{
			throw new System.NotImplementedException();
		}

		public void DeleteCar(Car car)
		{
			throw new System.NotImplementedException();
		}
	}
}
