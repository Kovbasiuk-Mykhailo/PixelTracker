using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(busConfigurator =>
        {
            var executingAssembly = Assembly.GetEntryAssembly();
            busConfigurator.AddConsumers(executingAssembly);
            
            busConfigurator.UsingRabbitMq(((context, configurator) =>
            {
                configurator.ConfigureEndpoints(context);
            }));
        });
        
        return services;
    }   
}