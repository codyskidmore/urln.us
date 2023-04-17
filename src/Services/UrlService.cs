using Url.Api.Data;
using Url.Api.Models;

namespace Url.Api.Services;

public class UrlService : IUrlService
{
    private readonly IUrlRepository _urlRepository;

    public UrlService(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public Task<UrlMapping> CreateAsync(UrlMapRequest request)
    {
        return _urlRepository.CreateAsync(request.ShortName, request.ForwardTo, request.Description);
    }

    public Task<UrlMapping> UpdateAsync(UrlMapRequest request)
    {
        return _urlRepository.UpdateAsync(request.ShortName, request.ForwardTo, request.Description);
    }

    public async Task<UrlMapping> GetAsync(string map)
    {
        return await _urlRepository.GetAsync(map);
    }

    public Task<IEnumerable<UrlMapping>> GetAllAsync()
    {
        return _urlRepository.GetAllAsync();
    }

    public Task DeleteAsync(string map)
    {
        return Task.FromResult(_urlRepository.DeleteAsync(map));
    }
}