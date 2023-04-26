using Url.Api.Infrastructure;
using Url.Api.Models;
using Url.Api.Services;

namespace Url.Api.Endpoints;

public static class GetAll
{
    public const string Name = "GetAll";

    public static IEndpointRouteBuilder MapGetAll(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Urls.GetAll, async (IUrlService urlService) =>
            {
                var urlMaps = await urlService.GetAllAsync();
                return TypedResults.Ok(urlMaps);
            }).WithName(Name)
            .Produces<IEnumerable<UrlMapping>>()
            .CacheOutput(CacheConstants.PolicyName);

        return app;
    }
}