using Kronos;
using Kronos.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

// Initialize RedmineAgent with RedmineApiKey and RedmineURL
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile(builder.Environment.IsDevelopment() ? "appsettings.Development.json" : "appsettings.json")
    .AddEnvironmentVariables()
    .Build();

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
    .ReadFrom.Configuration(ctx.Configuration));


string RedmineApiKey = configuration["RedmineApiKey"];
string RedmineURL = configuration["RedmineURL"];


Log.Information("Starting Kronos Service");

// Register RedmineAgent as a service with the required parameters
builder.Services.AddScoped<RedmineAgent>(sp => new RedmineAgent( redmineUrl : RedmineURL, redmineApiKey : RedmineApiKey));
Log.Debug("Connected to " + RedmineURL);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();