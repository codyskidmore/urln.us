using Url.Api.Data;
using Url.Api.Infrastructure;
using Url.Api.Models;

namespace Url.Api.Services;

public class UrlService : IUrlService
{
    private readonly IUrlRepository _urlRepository;

    public UrlService(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<UrlMapping> CreateAsync(UrlMapRequest request)
    {
        var urlEntity = await _urlRepository.CreateAsync(request.ShortName, request.ForwardTo, request.Description);
        return urlEntity.ToUrlMapping();
    }

    public async Task<UrlMapping> UpdateAsync(UrlMapRequest request)
    {
        var urlMapping = await _urlRepository.UpdateAsync(request.ShortName, request.ForwardTo, request.Description);
        
        return urlMapping.ToUrlMapping();
    }

    public async Task<UrlMapping> GetAsync(string shortName)
    {
        var mapEntity = await _urlRepository.GetAsync(shortName);
        return mapEntity.ToUrlMapping();
    }

    public async Task<IEnumerable<UrlMapping>> GetAllAsync()
    {
        var urlEntities = await _urlRepository.GetAllAsync();
        return urlEntities.ToUrlMappings();
    }

    public async Task DeleteAsync(string shortName)
    {
        await _urlRepository.DeleteAsync(shortName);
    }
}