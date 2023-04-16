using Url.Api.Data;
using Url.Api.Infrastructure;
using Url.Api.Services;

namespace Url.Api.Endpoints;

public static class GetUrlMapEndpoint
{
    public const string Name = "GetUrlMap";

    public static IEndpointRouteBuilder MapGetUrlMap(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Urls.GetMap, async (string shortName, IUrlService urlService) =>
        {
            var mappedUrl = await urlService.GetAsync(shortName);
            if (mappedUrl is null)
            {
                return Results.NotFound();
            }

            return TypedResults.Redirect(mappedUrl.ForwardTo);
        }).WithName(Name)
            .Produces<string>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .CacheOutput(Name);

        return app;
    }}