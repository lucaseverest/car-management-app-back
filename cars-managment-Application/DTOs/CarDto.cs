namespace CarsManagement.Application.DTOs
{
    public class CarDto
    {
        public CarDto(Guid id, string name, string status, Guid photoId, string photoBase64)
        {
            Id = id;
            Name = name;
            Status = status;
            PhotoId = photoId;
            PhotoBase64 = photoBase64;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Guid PhotoId { get; set; }
        public string PhotoBase64 { get; set; }
    }
}
