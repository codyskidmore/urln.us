namespace Url.Api.Data;

public interface IUrlRepository
{
    Task<UrlEntity?> GetAsync(string shortName);
    Task<IEnumerable<UrlEntity>> GetAllAsync();
    Task<UrlEntity> CreateAsync(string shortName, string forwardTo, string description);
    Task<UrlEntity?> UpdateAsync(string shortName, string forwardTo, string description);
    Task DeleteAsync(string shortName);
}