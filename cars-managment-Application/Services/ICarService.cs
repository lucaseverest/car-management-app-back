using CarsManagement.Application.DTOs;

namespace CarsManagement.Application.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllCarsAsync();
        Task<CarDto> GetCarByIdAsync(Guid id);
        Task<CarDto> AddCarAsync(CreateCarDto carDto);
        Task UpdateCarAsync(Guid id, CarDto carDto);
        Task DeleteCarAsync(Guid id);
    }
}
