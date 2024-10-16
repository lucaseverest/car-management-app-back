using CarsManagement.Application.DTOs;
using CarsManagement.Domain.Entities.Cars;
using CarsManagement.Domain.Entities.Photos;
using CarsManagement.Domain.Repositories;
using CarsManagement.Infra.Persistence.Repositories.PhotoRepository;

namespace CarsManagement.Application.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IPhotoRepository _photoRepository;

        public CarService(ICarRepository carRepository, IPhotoRepository photoRepository)
        {
            _carRepository = carRepository;
            _photoRepository = photoRepository;
        }
        public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllCarsAsync();

            return cars.Select(c => new CarDto
            (
                c.Id,
                c.Name,
                c.Status,
                c.PhotoId,
                c.Photo.Base64
            ));
        }

        public async Task<CarDto> GetCarByIdAsync(Guid id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            if (car == null)
            {
                return null;
            }

            return new CarDto(
                car.Id,
                car.Name,
                car.Status,
                car.PhotoId,
                car.Photo.Base64
                );
        }

        public async Task<CarDto> AddCarAsync(CreateCarDto carDto)
        {
            var photo = new Photo(Guid.NewGuid(), carDto.PhotoBase64);
            await _photoRepository.AddPhotoAsync(photo);
            var car = new Car(Guid.NewGuid(), carDto.Name, carDto.Status, photo.Id);

            await _carRepository.AddCarAsync(car);

            var newCarDto = new CarDto(car.Id, carDto.Name, carDto.Status, car.PhotoId, photo.Base64);
            return newCarDto;
        }

        public async Task UpdateCarAsync(Guid id, CarDto carDto)
        {
            var car = await _carRepository.GetCarByIdAsync(id) ?? throw new Exception("Car not found.");
            var photo = await _photoRepository.GetPhotoByIdAsync(carDto.PhotoId) ?? throw new Exception("photo not found");

            car.Name = carDto.Name;
            car.Status = carDto.Status;

            if (carDto.PhotoBase64 != photo.Base64)
            {
                photo.Base64 = carDto.PhotoBase64;
                await _photoRepository.UpdatePhotoAsync(photo);
            }

            await _carRepository.UpdateCarAsync(car);
        }

        public async Task DeleteCarAsync(Guid id)
        {
            _ = await _carRepository.GetCarByIdAsync(id) ?? throw new Exception("Car not found.");
            await _carRepository.DeleteCarAsync(id);
        }

    }
}
