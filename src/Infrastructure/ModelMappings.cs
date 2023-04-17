using Url.Api.Models;

namespace Url.Api.Infrastructure;

public static class ModelMappings
{
    // public static UrlMapping MapTo(this CreateUrlMapRequest request)
    // {
    //     return new UrlMapping
    //     {
    //         Id = Guid.NewGuid(),
    //         ForwardTo = request.ForwardTo,
    //         ShortName = request.ShortName,
    //         Description = request.Description
    //     };
    // }

    public static UrlMapResponse ToResponse(this UrlMapping urlMapping)
    {
        return new UrlMapResponse
        {
            Description = urlMapping.Description,
            ForwardTo = urlMapping.ForwardTo,
            ShortName = urlMapping.ShortName
        };
    }

    public static IEnumerable<UrlMapResponse> ToResponses(this IEnumerable<UrlMapping> urlMappings)
    {
        return urlMappings.Select<UrlMapping,UrlMapResponse>(m => m.ToResponse());
    }
}