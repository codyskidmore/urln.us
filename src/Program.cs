using Url.Api.Infrastructure;
using Url.Api.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
//builder.Services.AddMUrlApiAuthentication(config);

//builder.Services.AddScoped<ApiKeyAuthFilter>();
var cacheConfig = config.GetSection(CacheConstants.PolicySection).Get<CacheSettings>();

//builder.Services.AddCorsPolicy();
builder.Services.AddUrlMapCache(cacheConfig!);
builder.Services.AddUrlMapApiVersioning();
builder.Services.Configure<ConfigOptions>(
builder.Configuration.GetSection(ConfigOptions.SectionName));
builder.Services.AddUrlApiSwaggerOptions();
builder.Services.AddUrlApiServices();
builder.Services.AddUrlApiRepositories();

var app = builder.Build();


//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseUrlApiSwaggerUi();
}

app.UseOutputCache();
// app.UseAuthentication();
// app.UseAuthorization();
app.MapApiEndpoints();
app.UseMiddleware<ApiKeyMiddleware>();
//app.UseCors("corsPolicy");
app.Run();