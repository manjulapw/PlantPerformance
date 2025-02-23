using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MacSolutions.Domain.Repositories;
using MacSolutions.Infrastructure.Persistence;
using MacSolutions.Infrastructure.Repositories;

namespace MacSolutions.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<MacSolutionsDbContext>(options => 
            options.UseNpgsql(connectionString)
                .EnableSensitiveDataLogging());

        services.AddScoped<IAlarmRepository, AlarmRepository>();
    }
}
