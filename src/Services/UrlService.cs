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

    public Task<bool> CreateAsync(CreateUrlRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<UrlMapping> GetAsync(string map)
    {
        return await _urlRepository.GetAsync(map);
    }

    public Task<IEnumerable<UrlMapping>> GetAllAsync()
    {
        return _urlRepository.GetAllAsync();
    }
}