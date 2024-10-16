using CarsManagement.Domain.Entities.Cars;
using CarsManagement.Domain.Entities.Photos;
using Microsoft.EntityFrameworkCore;

namespace CarsManagement.Infra.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Photo>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Photo)
                .WithOne(p => p.Car)
                .HasForeignKey<Car>(c => c.PhotoId);

            modelBuilder.Entity<Car>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Photo>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
