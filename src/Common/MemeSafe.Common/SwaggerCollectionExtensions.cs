using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MemeSafe.AspNetCore.Extensions;

public static class SwaggerCollectionExtensions
{
    public static IServiceCollection AddMemeSafeSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                In = ParameterLocation.Header,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the Bearer scheme."
            });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });


        return services;
    }
}
