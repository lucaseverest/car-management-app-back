using CarsManagement.Domain.Entities.Cars;
using CarsManagement.Domain.Repositories;
using CarsManagement.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarsManagement.Infra.Persistence.Repositories.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.Include(c => c.Photo).OrderByDescending(c => c.CreatedAt).ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(Guid id)
        {
            return await _context.Cars.Include(c => c.Photo).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
