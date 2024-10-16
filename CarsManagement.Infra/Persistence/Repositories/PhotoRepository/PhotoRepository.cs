using CarsManagement.Domain.Entities.Photos;
using CarsManagement.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace CarsManagement.Infra.Persistence.Repositories.PhotoRepository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext _context;

        public PhotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Photo>> GetAllPhotosAsync()
        {
            return await _context.Photos.ToListAsync();
        }

        public async Task<Photo> GetPhotoByIdAsync(Guid id)
        {
            return await _context.Photos.FindAsync(id);
        }

        public async Task AddPhotoAsync(Photo photo)
        {
            await _context.Photos.AddAsync(photo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePhotoAsync(Photo photo)
        {
            _context.Photos.Update(photo);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePhotoAsync(Guid id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                await _context.SaveChangesAsync();
            }
        }

    }
}
