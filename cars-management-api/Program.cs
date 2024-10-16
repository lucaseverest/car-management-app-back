using cars_management_api.Extensions;
using CarsManagementApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseApplicationMiddleware(app.Environment);

app.Run();
