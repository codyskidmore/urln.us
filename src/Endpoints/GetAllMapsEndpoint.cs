using Url.Api.Data;
using Url.Api.Infrastructure;
using Url.Api.Models;
using Url.Api.Services;

namespace Url.Api.Endpoints;

public static class GetUrlByMapEndpoint
{
    public const string Name = "GetAllMaps";

    public static IEndpointRouteBuilder MapUrlGetAllUrlMaps(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Urls.GetAllMaps, async (IUrlService urlService) =>
        {
            var urlMaps = await urlService.GetAllAsync();
            return TypedResults.Ok(urlMaps);
        }).WithName(Name)
            .Produces<IEnumerable<UrlMapping>>(StatusCodes.Status200OK)
            .CacheOutput(Name);

        return app;
    }}