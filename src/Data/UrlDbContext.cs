using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Url.Api.Models;

namespace Url.Api.Data;

public class UrlDbContext : DbContext
{
    private readonly IOptions<DatabaseOptions> _dbOptions;

    public UrlDbContext(DbContextOptions<UrlDbContext> options) : base(options)
    {
    }

    public UrlDbContext(DbContextOptions<UrlDbContext> options, IOptions<DatabaseOptions> dbOptions) : base(options)
    {
        _dbOptions = dbOptions;
    }

    public DbSet<UrlEntity> UrlEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite(_dbOptions.Value.ConnectionString);
    }
}