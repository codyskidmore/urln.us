using Asp.Versioning;
using Microsoft.Extensions.Options;
using Movies.Api.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Url.Api.Data;
using Url.Api.Models;
using Url.Api.Services;

namespace Url.Api.Infrastructure;

public static class UrlConfiguration
{
    public static IServiceCollection AddUrlApiSwaggerOptions(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(x => x.OperationFilter<SwaggerDefaultValues>());
        return services;
    }
    public static IServiceCollection AddMovieApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1.0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
            x.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
        }).AddApiExplorer();

        services.AddEndpointsApiExplorer();
        
        return services;
    }
    
    public static WebApplication UseUrlApiSwaggerUi(this WebApplication app)
    {
        app.UseSwaggerUI(x =>
        {
            foreach (var description in app.DescribeApiVersions())
            {
                x.SwaggerEndpoint( $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName);
            }
        });
        return app;
    }

    public static IServiceCollection AddUrlApiServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUrlService, UrlService>();
        return services;
    }

    public static IServiceCollection AddUrlApiRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUrlRepository, UrlRepository>();
        return services;
    }
    
    public static IServiceCollection AddMovieApiCache(this IServiceCollection services, CacheSettings cacheSettings)
    {
        services.AddOutputCache(x =>
        {
            x.AddBasePolicy(c => c.Cache());
            x.AddPolicy(cacheSettings.PolicyName, c => 
                c.Cache()
                    .Expire(TimeSpan.FromMinutes(cacheSettings.Expiration))
                    .SetVaryByQuery(cacheSettings.QueryKeys)
                    .Tag(cacheSettings.TagName));
        });
        return services;
    }
}