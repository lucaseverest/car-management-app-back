using CarsManagement.Application.Services;
using CarsManagement.Application.Services.Implementations;
using CarsManagement.Domain.Entities.Cars;
using CarsManagement.Domain.Repositories;
using CarsManagement.Infra.Persistence.Context;
using CarsManagement.Infra.Persistence.Repositories.CarRepository;
using CarsManagement.Infra.Persistence.Repositories.PhotoRepository;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace cars_management_api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("default", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Total-Count"));
            });

            services.AddControllers()
                .AddOData(options =>
                    options.EnableQueryFeatures()
                        .Select().Expand().Filter().OrderBy().SetMaxTop(1000).Count()
                        .AddRouteComponents("api", GetEdmModel()));

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<ICarService, CarService>();

            return services;
        }

        private static IEdmModel GetEdmModel()
        {
            var builderOData = new ODataConventionModelBuilder();
            builderOData.EntitySet<Car>("Cars");
            return builderOData.GetEdmModel();
        }
    }
}
