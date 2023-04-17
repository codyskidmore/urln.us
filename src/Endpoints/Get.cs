using Url.Api.Data;
using Url.Api.Infrastructure;
using Url.Api.Services;

namespace Url.Api.Endpoints;

public static class Get
{
    public const string Name = "Get";

    public static IEndpointRouteBuilder MapGet(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Urls.Get, async (string shortName, IUrlService urlService) =>
        {
            var mappedUrl = await urlService.GetAsync(shortName);
            if (mappedUrl is null)
            {
                return Results.NotFound();
            }

            return TypedResults.Redirect(mappedUrl.ForwardTo);
        }).WithName(Name)
            .Produces<string>(StatusCodes.Status302Found)
            .Produces(StatusCodes.Status404NotFound)
            .CacheOutput(CacheConstants.PolicyName);

        return app;
    }}