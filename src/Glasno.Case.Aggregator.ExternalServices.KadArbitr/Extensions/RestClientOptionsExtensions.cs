using RestSharp;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Extensions;

public static class RestClientOptionsExtensions
{
    public static RestClientOptions CreateKadArbitrRestClientOptions()
    {
        return new RestClientOptions("https://kad.arbitr.ru");
    }
}