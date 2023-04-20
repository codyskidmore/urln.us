using Microsoft.EntityFrameworkCore;
using Url.Api.Models;

namespace Url.Api.Data;

public class UrlRepository : IUrlRepository
{
    private UrlDbContext _dbContext { get; }

    public UrlRepository(UrlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UrlEntity> GetAsync(string shortName)
    {
        return await _dbContext.UrlEntities.AsNoTracking().SingleAsync(m => m.ShortName == shortName);
    }

    public async Task<IEnumerable<UrlEntity>> GetAllAsync()
    {
        return await _dbContext.UrlEntities.AsNoTracking().ToListAsync();
    }

    public async Task<UrlEntity> UpdateAsync(string shortName, string forwardTo, string description)
    {
        var map = await _dbContext.UrlEntities.SingleAsync(m => m.ShortName == shortName);;
        map.Description = description;
        map.ForwardTo = forwardTo;

        await _dbContext.SaveChangesAsync();

        return map;
    }

    public async Task DeleteAsync(string shortName)
    {

        var map = await _dbContext.UrlEntities.SingleAsync(m => m.ShortName == shortName);
        _dbContext.UrlEntities.Remove(map);
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<UrlEntity> CreateAsync(string shortName, string forwardTo, string description)
    {
        var urlEntity = new UrlEntity
        {
            Id = Guid.NewGuid(),
            ForwardTo = forwardTo,
            ShortName = shortName,
            Description = description
        };

        await _dbContext.AddAsync(urlEntity);
        await _dbContext.SaveChangesAsync();

        return urlEntity;
    }
}