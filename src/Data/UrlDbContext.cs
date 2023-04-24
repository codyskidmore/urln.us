using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Url.Api.Models;

namespace Url.Api.Data;

public class UrlDbContext : DbContext
{
    private readonly IOptions<DatabaseOptions> _dbOptions;
    public DbSet<UrlEntity> UrlEntities { get; set; }

    public UrlDbContext(DbContextOptions<UrlDbContext> options) : base(options)
    {
        
    }
    public UrlDbContext(DbContextOptions<UrlDbContext> options, IOptions<DatabaseOptions> dbOptions) : base(options)
    {
        _dbOptions = dbOptions;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(_dbOptions.Value.ConnectionString);
        }
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<UrlEntity>(e =>
    //     {
    //         e.Property(e => e.Id).UseIdentityColumn();
    //
    //     });
    //     
    //     base.OnModelCreating(modelBuilder);
    // }
}