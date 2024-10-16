using CarsManagement.Domain.Entities.Photos;

namespace CarsManagement.Infra.Persistence.Repositories.PhotoRepository
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetAllPhotosAsync();
        Task<Photo> GetPhotoByIdAsync(Guid id);
        Task AddPhotoAsync(Photo photo);
        Task UpdatePhotoAsync(Photo photo);
        Task DeletePhotoAsync(Guid id);
    }
}
