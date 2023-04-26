using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Url.Api.Infrastructure;
using Url.Api.Models;
using Url.Api.Services;
// using Microsoft.AspNetCore.OutputCaching;
// using Url.Api.Data;

namespace Url.Api.Endpoints;

public static class Create
{
    public const string Name = "Create";

    public static IEndpointRouteBuilder MapCreate(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Urls.Create, async ([FromBody] UrlMapRequest request,
                IUrlService urlService, IOutputCacheStore outputCacheStore, CancellationToken token) =>
            {
                var result = await urlService.CreateAsync(request);
                await outputCacheStore.EvictByTagAsync(CacheConstants.TagName, token);
                return TypedResults.CreatedAtRoute(result.ToResponse(), Get.Name,
                    new { shortName = request.ShortName });
            })
            .WithName(Name)
            .Produces<UrlMapResponse>(StatusCodes.Status201Created);
        //.Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest);

        return app;
    }
}