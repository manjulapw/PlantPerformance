using System;
using Microsoft.Extensions.DependencyInjection;
using MacSolutions.Application.Alarms;

namespace MacSolutions.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddAutoMapper(applicationAssembly);

        // services.AddValidatorsFromAssembly(applicationAssembly)
        //     .AddFluentValidationAutoValidation();
    }
}
