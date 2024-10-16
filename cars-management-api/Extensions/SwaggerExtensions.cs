using Microsoft.OpenApi.Models;

namespace cars_management_api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cars Management API", Version = "v1" });
                c.OperationFilter<ODataSwaggerConverter>();
            });

            return services;
        }

        public static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars Management API v1");
            });
        }
    }
}
