namespace Url.Api.Models;

public class CreateUrlRequest
{
    public required string TargetUrl { get; init; }
    public required string ShortUrl { get; init; }
    public string Description { get; init; } = string.Empty;
}