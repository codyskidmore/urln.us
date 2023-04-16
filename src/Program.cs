using Microsoft.AspNetCore.Cors.Infrastructure;
using Url.Api.Infrastructure;
using Url.Api.Models;

var builder = WebApplication.CreateBuilder(args);
//var config = builder.Configuration;

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: "_myAllowSpecificOrigins",
//         policy  =>
//         {
//             policy.AllowAnyOrigin();
//             policy.AllowAnyHeader();
//             policy.AllowAnyMethod();
//         });
// });

builder.Services.AddMovieApiVersioning();

builder.Services.Configure<ConfigOptions>(
builder.Configuration.GetSection(ConfigOptions.SectionName));
builder.Services.AddUrlApiSwaggerOptions();
builder.Services.AddUrlApiServices();
builder.Services.AddUrlApiRepositories();

var app = builder.Build();
//app.UseCors("_myAllowSpecificOrigins");
app.MapApiEndpoints();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseUrlApiSwaggerUi();
}

//app.MapGet("/", () => "Hello World!");

app.Run();