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

    public async Task<string> GetAsync(string map)
    {
        var urlMap = await _urlRepository.GetAsync(map);
        return urlMap.UrlMap;
    }
}