using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.OutputCaching;
// using Url.Api.Data;
using Url.Api.Models;
using Url.Api.Services;

namespace Url.Api.Endpoints;

public static class CreateUrlEndpoint
{
    public const string Name = "CreateUrl";

    public static IEndpointRouteBuilder MapCreateUrl(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", async ([FromHeader] string authHeader, CreateUrlRequest request, IUrlService urlService) =>
            {
                var result = await urlService.CreateAsync(request);
                return TypedResults.CreatedAtRoute(result, GetUrlByMapEndpoint.Name, new { id = request.ShortUrl });
            })
            .WithName(Name)
            .Produces<string>(StatusCodes.Status201Created);
            //.Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest);
            // .RequireAuthorization(AuthConstants.TrustedMemberPolicyName);

        return app;
    }
}