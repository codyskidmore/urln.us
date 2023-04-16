using Url.Api.Infrastructure;
using Url.Api.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var cacheConfig = config.GetSection(CacheConstants.CachePolicySection).Get<CacheSettings>();
builder.Services.AddMovieApiCache(cacheConfig!);
builder.Services.AddMovieApiVersioning();
builder.Services.Configure<ConfigOptions>(
builder.Configuration.GetSection(ConfigOptions.SectionName));
builder.Services.AddUrlApiSwaggerOptions();
builder.Services.AddUrlApiServices();
builder.Services.AddUrlApiRepositories();

var app = builder.Build();

app.UseOutputCache();
app.MapApiEndpoints();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseUrlApiSwaggerUi();
}

app.Run();