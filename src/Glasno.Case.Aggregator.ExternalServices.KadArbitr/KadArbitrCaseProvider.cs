using CefSharp.OffScreen;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Factories;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers;
using RestSharp;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr;

public class KadArbitrCaseProvider: IKadArbitrCaseProvider
{
    private readonly RestClient _client;
    private readonly ChromiumWebBrowser _browser;

    public KadArbitrCaseProvider()
    {
        _client = RestClientFactory.Create();
        _browser = BrowserFactory.Create();
    }
    
    public async Task<CaseExternal[]> SearchCases(SearchQuery query)
    {
        var cookie = await _browser.CreateCookies();
        
        var request = SearchCasesRestRequestFactory.CreatePost(query, cookie);
        var response = await _client.ExecutePostAsync(request);

        if (!response.IsSuccessful) 
            throw response.ErrorException;
        
        return CasesParser.ParseHtml(response.Content);
    }
}