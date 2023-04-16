using Url.Api.Endpoints;

namespace Url.Api.Infrastructure;

public static class EndpointConfiguration
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGetUrlMap();
        app.MapUrlGetAllUrlMaps();
        app.MapCreateUrlMap();
        return app;
    }
}