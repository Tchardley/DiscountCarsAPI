using Microsoft.AspNetCore.Mvc;

namespace DiscountCarsAPI.Interface
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCars();

       Task<Car>? GetCar(int id);

        Task<List<Car>?> CreateCar(Car car);

        Task<List<Car>?> UpdateCar(int id, Car request);

        Task<List<Car>?> DeleteCar(int id);

    }
}
