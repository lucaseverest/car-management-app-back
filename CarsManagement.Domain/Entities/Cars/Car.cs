using CarsManagement.Domain.Entities.Photos;

namespace CarsManagement.Domain.Entities.Cars
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Guid PhotoId { get; set; }
        public virtual Photo Photo { get; set; }
        public DateTime CreatedAt { get; set; }

        public Car(Guid id, string name, string status, Guid photoId)
        {
            Id = id;
            Name = name;
            Status = status;
            PhotoId = photoId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
