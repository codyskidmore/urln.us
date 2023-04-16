using Url.Api.Models;

namespace Url.Api.Data;

public class UrlRepository : IUrlRepository
{
    private Dictionary<string, UrlMapping> _urlMaps = new Dictionary<string, UrlMapping>
    {
        {
            "portfolio", new UrlMapping
            {
                Id = Guid.NewGuid(),
                TargetUrl = "portfolio",
                UrlMap = @"http://github.com/codyskidmore"
            }
        },
        {
            "profile", new UrlMapping
            {
                Id = Guid.NewGuid(),
                TargetUrl = "profile",
                UrlMap = @"https://www.linkedin.com/in/codyskidmore/"
            }
        }
    };
    
    public Task<UrlMapping> GetAsync(string map)
    {
        return Task.FromResult(_urlMaps[map]);
    }
}