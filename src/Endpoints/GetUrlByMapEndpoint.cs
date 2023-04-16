using Url.Api.Data;
using Url.Api.Infrastructure;
using Url.Api.Services;

namespace Url.Api.Endpoints;

public static class GetUrlByMapEndpoint
{
    public const string Name = "GetUrlByMap";

    public static IEndpointRouteBuilder MapUrlGetByMap(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (string map, IUrlService urlService) =>
        {
            var mappedUrl = await urlService.GetAsync(map);
            if (mappedUrl is null)
            {
                return Results.NotFound();
            }

//            return TypedResults.Ok(mappedUrl);
            return TypedResults.Redirect(mappedUrl);
        }).WithName(Name)
            .Produces<string>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            // .CacheOutput("MovieCache");

        return app;
    }}