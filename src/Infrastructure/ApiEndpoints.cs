namespace Url.Api.Infrastructure;

public class ApiEndpoints
{
    private const string ApiBase = "/";

    public static class Urls
    {
        private const string Base = $"{ApiBase}";
        
        public const string Create = Base;
        public const string GetMap =  $"{Base}{{ShortName}}";
        public const string GetAllMaps =  Base;
    }
}