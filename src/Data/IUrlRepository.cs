using Url.Api.Models;

namespace Url.Api.Data;

public interface IUrlRepository
{
    Task<UrlMapping> GetAsync(string map);
    Task<IEnumerable<UrlMapping>> GetAllAsync();
    Task<UrlMapping> CreateAsync(string shortName, string forwardTo, string description);
    Task<UrlMapping> UpdateAsync(string shortName, string forwardTo, string description);
    Task DeleteAsync(string map);
}