using Url.Api.Data;
using Url.Api.Models;

namespace Url.Api.Infrastructure;

public static class ModelMappings
{
  public static UrlMapping ToUrlMapping(this UrlEntity entity)
  {
    return new UrlMapping
    {
      ForwardTo = entity.ForwardTo,
      ShortName = entity.ShortName,
      Description = entity.Description
    };
  }

  public static IEnumerable<UrlMapping> ToUrlMappings(this IEnumerable<UrlEntity> entities)
  {
    return entities.Select<UrlEntity, UrlMapping>(m => m.ToUrlMapping());
  }

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
    return urlMappings.Select<UrlMapping, UrlMapResponse>(m => m.ToResponse());
  }
}
