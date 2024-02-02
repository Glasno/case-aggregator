using Glasno.Case.Aggregator.Infrastructure.Abstractions.Repository.Cases;
using Glasno.Case.Aggregator.Infrastructure.Repository.Cases;
using Microsoft.Extensions.DependencyInjection;

namespace Glasno.Case.Aggregator.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<ICaseRepository, CaseRepository>();

        return services;
    }
}