using System.Collections.Generic;
using System.Linq;

namespace Komis.Models
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Car> GetCars()
        {
            return _appDbContext.Cars;
        }

        public Car GetCarById(int carId)
        {
            return _appDbContext.Cars.FirstOrDefault(s => s.Id == carId);
        }
    }
}
