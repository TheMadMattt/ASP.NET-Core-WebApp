using System.Collections.Generic;

namespace Komis.Model
{
	public interface ICarRepository
	{
		IEnumerable<Car> GetCars();
		Car GetCarById(int carId);
	}
}
