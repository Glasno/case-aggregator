using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Extensions;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Requests;
using RestSharp;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr;

public class KadArbitrCaseProvider: IKadArbitrCaseProvider
{
    private readonly RestClient _client;

    public KadArbitrCaseProvider()
    {
        _client = new RestClient().CreateKadArbitrRestClient();
    }
    
    public async Task<CaseExternal[]> SearchCases(SearchQuery query, string cookie)
    {
        var request = SearchCasesRequest.CreatePost(query, cookie);
        var response = await _client.ExecutePostAsync(request);

        if (!response.IsSuccessful) 
            throw response.ErrorException;
        
        return CasesParser.ParseHtml(response.Content);
    }
}