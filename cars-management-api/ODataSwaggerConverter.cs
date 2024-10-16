using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace cars_management_api
{
    public class ODataSwaggerConverter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod == "GET")
            {
                if (operation.Parameters == null)
                {
                    operation.Parameters = new List<OpenApiParameter>();
                }

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$filter",
                    In = ParameterLocation.Query,
                    Description = "Filtra os resultados com base em uma expressão",
                    Required = false
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$orderby",
                    In = ParameterLocation.Query,
                    Description = "Ordena os resultados",
                    Required = false
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$top",
                    In = ParameterLocation.Query,
                    Description = "Número de resultados a serem retornados",
                    Required = false
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$skip",
                    In = ParameterLocation.Query,
                    Description = "Número de resultados a serem ignorados",
                    Required = false
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$count",
                    In = ParameterLocation.Query,
                    Description = "Retorna a contagem total de resultados",
                    Required = false
                });
            }
        }
    }
}
