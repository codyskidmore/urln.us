namespace Url.Api.Models;

public record UrlMapping
{
  public required string ShortName { get; set; }
  public required string ForwardTo { get; set; }
  public string Description { get; set; } = string.Empty;
}
