using Microsoft.EntityFrameworkCore;
using Url.Api.Data;
using Url.Api.Infrastructure;
using Url.Api.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var cacheConfig = config.GetSection(CacheConstants.PolicySection).Get<CacheSettings>();

builder.Services.AddDatabase(config);

builder.Services.AddUrlMapCache(cacheConfig!);
builder.Services.AddUrlMapApiVersioning();
builder.Services.Configure<ConfigOptions>(builder.Configuration.GetSection(ConfigOptions.SectionName));
builder.Services.AddUrlApiSwaggerOptions();
builder.Services.AddUrlApiServices();
builder.Services.AddUrlApiRepositories();

var app = builder.Build();


//Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseUrlApiSwaggerUi();
// }

app.UseSwagger();
app.UseUrlApiSwaggerUi();


app.MapApiEndpoints();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseOutputCache();

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<UrlDbContext>();
    
    // Here is the migration executed
    dbContext.Database.Migrate();
}

app.Run();