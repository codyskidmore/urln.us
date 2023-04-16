namespace Url.Api.Models;

public record UrlMapping
{
    public required Guid Id { get; set; }
    public required string TargetUrl { get; init; }
    public required string UrlMap { get; init; }
    public string Description { get; init; } = string.Empty;

    // public UrlMapping(Guid id, string targetUrl, string urlMap, string description = string.Empty)
    // {
    //     Id = id;
    //     TargetUrl = targetUrl;
    //     UrlMap = urlMap;
    //     Description = description;
    // }
}