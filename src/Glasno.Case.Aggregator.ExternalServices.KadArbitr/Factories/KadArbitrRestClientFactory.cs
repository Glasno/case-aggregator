using RestSharp;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Factories;

public static class KadArbitrRestClientFactory
{
    private const string KadArbitrUrl = "https://kad.arbitr.ru";
    private static readonly RestClientOptions Options = new RestClientOptions(KadArbitrUrl);
    
    public static RestClient Create()
    {
        return new RestClient(Options);
    }
}