using AutoMapper;
using Glasno.Case.Aggregator.Application.Contracts;
using Glasno.Case.Aggregator.Application.Queries.SearchCases.Contracts;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;
using MediatR;

namespace Glasno.Case.Aggregator.Application.Queries.SearchCases;

internal class SearchCasesHandler : IRequestHandler<SearchCasesQuery, SearchCasesResponse>
{
    private readonly IKadArbitrCaseProvider _kadArbitrCaseProvider;
    private readonly IMapper _mapper;

    public SearchCasesHandler(
        IKadArbitrCaseProvider kadArbitrCaseProvider,
        IMapper mapper)
    {
        _kadArbitrCaseProvider = kadArbitrCaseProvider;
        _mapper = mapper;
    }

    public async Task<SearchCasesResponse> Handle(SearchCasesQuery query, CancellationToken cancellationToken)
    {
        var cases =  await _kadArbitrCaseProvider.SearchCases(query.SearchQuery);

        var casesInternal = _mapper.Map<CaseExternal[], CaseInternal[]>(cases);

        return new SearchCasesResponse(casesInternal);
    }
}