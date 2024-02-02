using System.Reflection;
using Glasno.Case.Aggregator.Application.Mappers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Glasno.Case.Aggregator.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg 
            => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        services.AddAutoMapper(typeof(InternalMappingProfile));

        return services;
    }
}