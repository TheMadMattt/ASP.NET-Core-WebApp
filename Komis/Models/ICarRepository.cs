using System.Collections.Generic;

namespace Komis.Models
{
	public interface ICarRepository
	{
		IEnumerable<Car> GetCars();
		Car GetCarById(int carId);
	}
}
