using Url.Api.Models;

namespace Url.Api.Data;

public interface IUrlRepository
{
    Task<UrlMapping> GetAsync(string map);
    Task<IEnumerable<UrlMapping>> GetAllAsync();
}