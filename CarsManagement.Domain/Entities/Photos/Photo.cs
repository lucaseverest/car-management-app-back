using CarsManagement.Domain.Entities.Cars;

namespace CarsManagement.Domain.Entities.Photos
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Base64 { get; set; }

        public virtual Car Car { get; set; }

        public DateTime CreatedAt { get; set; }

        public Photo(Guid id, string base64)
        {
            Id = id;
            Base64 = base64;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
