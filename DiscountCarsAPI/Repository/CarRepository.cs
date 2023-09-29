using DiscountCarsAPI.Interface;

namespace DiscountCarsAPI.Repository
{
    public class CarRepository : ICarRepository

    {
       /* private static List<Car> cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Year = "2021",
                    Make = "Toyota",
                    Model = "Camry",
                    Price = "$25,000",
                    Color = "Silver",
                    VehicleType = "Sedan",
                    VinNumber = "1G1YZ23J9P5803427"
                },
                 new Car
                {
                    Id = 2,
                    Year = "2022",
                    Make = "Honda",
                    Model = "Accord",
                    Price = "$28,000",
                    Color = "White",
                    VehicleType = "Sedan",
                    VinNumber = "3D7KS26TX9G528725"
                },
                  new Car
                {
                    Id = 3,
                    Year = "2023",
                    Make = "Nissan",
                    Model = "Armada",
                    Price = "$45,000",
                    Color = "Black",
                    VehicleType = "SUV",
                    VinNumber = "6P1MZ53H9Z6201938"
                }
        }; */

        private readonly CarDataContext _context;
        public CarRepository(CarDataContext context)
        {
            _context = context;
        }

        public async Task<List<Car>?> CreateCar(Car car)
        {
            _context.cars.Add(car);
            await _context.SaveChangesAsync();
            
            return await _context.cars.ToListAsync();
        }

        public async Task<List<Car>?> DeleteCar(int id)
        {
            var car = await _context.cars.FindAsync(id);
            if (car == null)
                return null;

             _context.cars.Remove(car);

             await _context.SaveChangesAsync();

            return await _context.cars.ToListAsync();
        }

       

        public async Task<List<Car>> GetAllCars()
        {
            var car = await _context.cars.ToListAsync();
         
            return car;
        }

        public async Task<Car>? GetCar(int id)
        {
            var car = await _context.cars.FindAsync(id);
            if (car == null)
               return null;
            return car;
        }

        public async Task<List<Car>?> UpdateCar(int id, Car request)
        {
            var car = await _context.cars.FindAsync(id);
            if (car == null)
                return null;

            car.Year = request.Year;
            car.Make = request.Make;
            car.Model = request.Model;
            car.Price = request.Price;
            car.Color = request.Color;
            car.VehicleType = request.VehicleType;
            car.VinNumber = request.VinNumber;

            await _context.SaveChangesAsync();

            return await _context.cars.ToListAsync();
        }
    }
}
