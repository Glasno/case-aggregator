using Microsoft.Extensions.DependencyInjection;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr;

public static class DependencyInjection
{
    public static IServiceCollection AddKadArbitrProvider(
        this IServiceCollection services)
    {
        services.AddSingleton<IKadArbitrCaseProvider, KadArbitrCaseProvider>();

        return services;
    }
}