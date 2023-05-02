namespace Url.Api.Infrastructure;

public class ApiEndpoints
{
  private const string ApiBase = "/";

  public static class Urls
  {
    private const string Base = $"{ApiBase}";

    public const string Create = Base;
    public const string Get = $"{Base}{{ShortName}}";
    public const string GetAll = Base;
    public const string Put = Base;
    public const string Delete = $"{Base}{{ShortName}}";
  }
}
