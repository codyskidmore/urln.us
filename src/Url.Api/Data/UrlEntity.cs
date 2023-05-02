namespace Url.Api.Data;

public class UrlEntity
{
  public Guid Id { get; set; }
  public required string ShortName { get; set; }
  public required string ForwardTo { get; set; }
  public string Description { get; set; } = string.Empty;
}
