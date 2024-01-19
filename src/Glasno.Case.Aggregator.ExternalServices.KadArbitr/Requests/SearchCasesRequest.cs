using System.Text.Json;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;
using RestSharp;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Requests;

public static class SearchCasesRequest
{
    private static readonly List<KeyValuePair<string, string>> Headers = new()
    {
        new KeyValuePair<string, string>("Accept", "*/*"),
        new KeyValuePair<string, string>("Accept-Encoding", "gzip, deflate, br"),
        new KeyValuePair<string, string>("Content-Type", "application/json"),
        new KeyValuePair<string, string>("Referer", "https://kad.arbitr.ru/"),
        new KeyValuePair<string, string>("x-date-format", "iso"),
        new KeyValuePair<string, string>("X-Requested-With", "XMLHttpRequest")
    };

    public static RestRequest CreatePost(SearchQuery query, string cookie)
    {
        var request = new RestRequest("Kad/SearchInstances", Method.Post);
        
        var jsonBody = JsonSerializer.Serialize(query);
        request.AddJsonBody(jsonBody);

        request.AddHeaders(Headers);
        request.AddHeader("Cookie", cookie);
        
        return request;
    }
}