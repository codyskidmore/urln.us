using Url.Api.Models;

namespace Url.Api.Services;

public interface IUrlService
{
    Task<UrlMapping> CreateAsync(UrlMapRequest request);
    Task<UrlMapping> UpdateAsync(UrlMapRequest request);
    Task<UrlMapping> GetAsync(string map);
    Task<IEnumerable<UrlMapping>> GetAllAsync();
    Task DeleteAsync(string map);
}