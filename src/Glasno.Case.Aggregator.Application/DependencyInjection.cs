using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Glasno.Case.Aggregator.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddKadArbitrApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg 
            => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}