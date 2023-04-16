namespace Url.Api.Infrastructure;

public class ApiEndpoints
{
    private const string ApiBase = "/api";

    public static class Urls
    {
        private const string Base = $"{ApiBase}";
        
        public const string Create = Base;
        public const string GetByMap = Base;
    }
}