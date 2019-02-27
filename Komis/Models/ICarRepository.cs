using System.Collections.Generic;

namespace Komis.Models
{
	public interface ICarRepository
	{
		IEnumerable<Car> GetCars();
		Car GetCarById(int carId);

		void AddCar(Car car);
		void EditCar(Car car);
		void DeleteCar(Car car);
	}
}
