namespace Url.Api.Models;

public class UrlMapRequest
{
    public required string ForwardTo { get; init; }
    public required string ShortName { get; init; }
    public string Description { get; init; } = string.Empty;

    public override string ToString()
    {
        return $"{ForwardTo}:{ShortName}";
    }
}