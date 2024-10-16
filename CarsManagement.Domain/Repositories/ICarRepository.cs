using CarsManagement.Domain.Entities.Cars;

namespace CarsManagement.Domain.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(Guid id);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(Guid id);
    }
}
