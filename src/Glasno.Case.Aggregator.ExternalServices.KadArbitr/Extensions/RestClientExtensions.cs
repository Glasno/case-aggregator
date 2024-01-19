using RestSharp;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Extensions;

public static class RestClientExtensions
{
    public static RestClient CreateKadArbitrRestClient(this RestClient client)
    {
        return new RestClient(RestClientOptionsExtensions.CreateKadArbitrRestClientOptions());
    }
}