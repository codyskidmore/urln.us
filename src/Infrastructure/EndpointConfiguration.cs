using Url.Api.Endpoints;

namespace Url.Api.Infrastructure;

public static class EndpointConfiguration
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet();
        app.MapGetAll();
        app.MapCreate();
        app.MapPut();
        app.MapDelete();
        return app;
    }
}