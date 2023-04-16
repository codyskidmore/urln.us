namespace Url.Api.Models;

public record UrlMapping
{
    public required Guid Id { get; set; }
    public required string ShortName { get; init; }
    public required string ForwardTo { get; init; }
    public string Description { get; init; } = string.Empty;
}