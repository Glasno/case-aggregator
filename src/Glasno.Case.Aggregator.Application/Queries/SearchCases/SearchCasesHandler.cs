using Glasno.Case.Aggregator.Application.Converters;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr;
using MediatR;

namespace Glasno.Case.Aggregator.Application.Queries.SearchCases;

public class SearchCasesHandler : IRequestHandler<SearchCasesQuery, SearchCasesResponse>
{
    private readonly IKadArbitrCaseProvider _kadArbitrCaseProvider;

    public SearchCasesHandler(IKadArbitrCaseProvider kadArbitrCaseProvider)
    {
        _kadArbitrCaseProvider = kadArbitrCaseProvider;
    }

    public async Task<SearchCasesResponse> Handle(SearchCasesQuery query, CancellationToken cancellationToken)
    {
        var cases =  await _kadArbitrCaseProvider.SearchCases(query.SearchQuery);

        return new SearchCasesResponse(cases.Select(CaseInternalConverter.ToInternal).ToArray());
    }
}