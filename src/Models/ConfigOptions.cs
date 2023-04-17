namespace Url.Api.Models;

public class ConfigOptions
{
    public static string SectionName = "ConfigOptions";
    
    public required string AuthToken { get; init; }
    public required string DomainName { get; init; }
}