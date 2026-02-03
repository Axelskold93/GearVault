using GearVault.Data;
using GearVault.Models;
using GearVault.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoMapper;
using GearVault.Mappings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);
var key = builder.Configuration["LicenseKey"];

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());

// Add services to the container.
builder.Services.AddControllers();
// Add Razor Pages and Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<GearVault.Services.GearService>();
// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "GearVault API",
        Version = "v1",
        Description = "API for managing PC gear inventory"
    });
});

builder.Services.AddDbContext<GearVaultContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var loggerFactory = LoggerFactory.Create(logging =>
{
    logging.AddConsole();
});

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<GearMappingProfile>();
    cfg.LicenseKey = key;
}, loggerFactory);

builder.Services.AddSingleton(mapperConfig.CreateMapper());

// register a HttpClient for Blazor components to call local API endpoints
// Use NavigationManager when available; otherwise fall back to configuration or a default
builder.Services.AddScoped(sp =>
{
    // try to get NavigationManager from the current scope (available in Blazor component scopes)
    var nav = sp.GetService<NavigationManager>();
    if (nav != null && Uri.TryCreate(nav.BaseUri, UriKind.Absolute, out var navUri))
    {
        return new System.Net.Http.HttpClient { BaseAddress = navUri };
    }

    // fallback to configuration value (if present) or a sensible https localhost default
    var apiBase = builder.Configuration["ApiBaseUrl"];
    if (!string.IsNullOrEmpty(apiBase) && Uri.TryCreate(apiBase, UriKind.Absolute, out var cfgUri))
    {
        return new System.Net.Http.HttpClient { BaseAddress = cfgUri };
    }

    return new System.Net.Http.HttpClient { BaseAddress = new Uri("https://localhost:7119") };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

// Map Razor pages and Blazor hub
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();