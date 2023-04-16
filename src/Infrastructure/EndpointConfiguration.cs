using Url.Api.Endpoints;

namespace Url.Api.Infrastructure;

public static class EndpointConfiguration
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapUrlGetByMap();
        app.MapCreateUrl();
        return app;
    }
}