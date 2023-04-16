using Url.Api.Models;

namespace Url.Api.Services;

public interface IUrlService
{
    Task<bool> CreateAsync(CreateUrlRequest request);
    Task<UrlMapping> GetAsync(string map);
    Task<IEnumerable<UrlMapping>> GetAllAsync();
}