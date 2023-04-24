using Microsoft.AspNetCore.OutputCaching;
using Url.Api.Infrastructure;
using Url.Api.Services;

namespace Url.Api.Endpoints;

public static class Delete
{
    public const string Name = "DeleteMap";

    public static IEndpointRouteBuilder MapDelete(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiEndpoints.Urls.Delete, async (string shortName, IUrlService urlService,
                IOutputCacheStore outputCacheStore, CancellationToken token) =>
            {
                await urlService.DeleteAsync(shortName);
                await outputCacheStore.EvictByTagAsync(CacheConstants.TagName, token);

                return TypedResults.Ok();
            }).WithName(Name)
            .Produces(StatusCodes.Status200OK)
            .CacheOutput(Name);

        return app;
    }
}