using RestSharp;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Factories;

internal static class RestClientFactory
{
    private const string KadArbitrUrl = "https://kad.arbitr.ru";
    private static readonly RestClientOptions Options = new RestClientOptions(KadArbitrUrl);
    
    internal static RestClient Create()
    {
        return new RestClient(Options);
    }
}