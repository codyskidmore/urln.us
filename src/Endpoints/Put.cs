using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Url.Api.Infrastructure;
using Url.Api.Models;
using Url.Api.Services;

namespace Url.Api.Endpoints;

public static class Put
{
    public const string Name = "Put";

    public static IEndpointRouteBuilder MapPut(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiEndpoints.Urls.Put, async ([FromBody] UrlMapRequest request, IUrlService urlService,
                IOutputCacheStore outputCacheStore, CancellationToken token) =>
            {
                var result = await urlService.UpdateAsync(request);
                if (result is null) return Results.NotFound();

                await outputCacheStore.EvictByTagAsync(CacheConstants.TagName, token);

                return TypedResults.Ok(result.ToResponse());
            })
            .WithName(Name)
            .Produces<UrlMapResponse>()
            .Produces(StatusCodes.Status404NotFound);
        // .Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest)

        return app;
    }
}