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
                ShortName = "portfolio",
                ForwardTo = @"http://github.com/codyskidmore"
            }
        },
        {
            "profile", new UrlMapping
            {
                Id = Guid.NewGuid(),
                ShortName = "profile",
                ForwardTo = @"https://www.linkedin.com/in/codyskidmore/"
            }
        }
    };
    
    public Task<UrlMapping> GetAsync(string map)
    {
        return Task.FromResult(_urlMaps[map]);
    }

    public Task<IEnumerable<UrlMapping>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<UrlMapping>>(_urlMaps.Values.ToList());
    }
}