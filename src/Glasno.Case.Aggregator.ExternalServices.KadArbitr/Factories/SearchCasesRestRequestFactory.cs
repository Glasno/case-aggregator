using System.Text.Json;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;
using RestSharp;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Factories;

internal static class SearchCasesRestRequestFactory
{
    private static readonly Dictionary<string, string> Headers = new()
    {
        {"Accept", "*/*"},
        {"Accept-Encoding", "gzip, deflate, br"},
        {"Content-Type", "application/json"},
        {"Referer", "https://kad.arbitr.ru/"},
        {"x-date-format", "iso"},
        {"X-Requested-With", "XMLHttpRequest"}
    };

    internal static RestRequest CreatePost(SearchQuery query, string cookie)
    {
        var request = new RestRequest("Kad/SearchInstances", Method.Post);
        
        var jsonBody = JsonSerializer.Serialize(query);
        request.AddJsonBody(jsonBody);

        request.AddHeaders(Headers);
        request.AddHeader("Cookie", cookie);
        
        return request;
    }
}