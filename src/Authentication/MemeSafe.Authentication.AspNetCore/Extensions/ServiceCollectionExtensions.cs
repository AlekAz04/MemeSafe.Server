using MemeSafe.Authentication.AspNetCore;
using MemeSafe.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MemeSafe.AspNetCore.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMemeSafeAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemeSafeJwtConfiguration(configuration);

        return services;
    }

    private static IServiceCollection AddMemeSafeJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetValue<JwtOptions>(nameof(JwtOptions));

        if (jwtOptions is null)
        {
            throw new CommonErrorException("Jwt Options was not found");
        }

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                };
            });
        return services;
    }
}
