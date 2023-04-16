using Url.Api.Models;

namespace Url.Api.Services;

public interface IUrlService
{
    Task<bool> CreateAsync(CreateUrlRequest request);
    Task<string> GetAsync(string map);
}