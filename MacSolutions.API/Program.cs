using System.Net.Mime;
using Microsoft.OpenApi.Models;
using MacSolutions.API.Middlewares;
using MacSolutions.Application.Extensions;
using MacSolutions.Infrastructure.Extensions;

using Serilog;
using Serilog.Events;
using MacSolutions.Application.Services;
using MacSolutions.Application.Alarms.Queries.GetZone;

var builder = WebApplication.CreateBuilder(args);

// Register PerformanceZoneSettings from appsettings.json
builder.Services.Configure<PerformanceZoneSettings>(builder.Configuration.GetSection("PerformanceZoneSettings"));

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.EntityFramework", LogEventLevel.Information)
        .WriteTo.File("Logs/MacSolutions-API.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
        .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MMM HH:mm:ss} {Level:u3} |{SourceContext}| {NewLine}{Message:1j}{NewLine}{Exception}]")
);

builder.Services.AddScoped<PerformanceZoneService>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MacSolutions API",
        Version = "v1"
    });
});

builder.Services.AddScoped<ErrorHandlingMiddleware>();
// builder.Services.AddDbContext<ApplicationDBContext>(options => {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
// });

var app = builder.Build();

var scope = app.Services.CreateScope();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MacSolutions API V1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

