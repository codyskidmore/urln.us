using Url.Api.Models;

namespace Url.Api.Data;

public class UrlRepository : IUrlRepository
{
    private static readonly Dictionary<string, UrlMapping> _urlMaps = new Dictionary<string, UrlMapping>
    {
        {
            "portfolio", new UrlMapping
            {
                ShortName = "portfolio",
                ForwardTo = @"http://github.com/codyskidmore"
            }
        },
        {
            "profile", new UrlMapping
            {
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

    public Task<UrlMapping> UpdateAsync(string shortName, string forwardTo, string description)
    {
        var urlMapping = _urlMaps[shortName];
        urlMapping.ForwardTo = forwardTo;
        urlMapping.Description = description;
        
        _urlMaps[shortName] = urlMapping;

        return Task.FromResult(urlMapping);
    }

    public Task DeleteAsync(string map)
    {
       return  Task.FromResult(_urlMaps.Remove(map));
    }

    public Task<UrlMapping> CreateAsync(string shortName, string forwardTo, string description)
    {
        var urlMapping = new UrlMapping
        {
            ForwardTo = forwardTo,
            ShortName = shortName,
            Description = description
        };
        
        _urlMaps[shortName] = urlMapping;
        
        return Task.FromResult(urlMapping);
    }
}