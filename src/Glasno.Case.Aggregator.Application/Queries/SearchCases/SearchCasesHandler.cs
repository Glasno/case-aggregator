using AutoMapper;
using Glasno.Case.Aggregator.Application.Contracts;
using Glasno.Case.Aggregator.Application.Queries.SearchCases.Contracts;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;
using Glasno.Case.Aggregator.Infrastructure.Abstractions.Repository.Cases;
using MediatR;

namespace Glasno.Case.Aggregator.Application.Queries.SearchCases;

internal class SearchCasesHandler : IRequestHandler<SearchCasesQuery, SearchCasesResponse>
{
    private readonly ICaseRepository _caseRepository;
    private readonly IKadArbitrCaseProvider _kadArbitrCaseProvider;
    private readonly IMapper _mapper;

    public SearchCasesHandler(
        ICaseRepository caseRepository,
        IKadArbitrCaseProvider kadArbitrCaseProvider,
        IMapper mapper)
    {
        _caseRepository = caseRepository;
        _kadArbitrCaseProvider = kadArbitrCaseProvider;
        _mapper = mapper;
    }

    public async Task<SearchCasesResponse> Handle(SearchCasesQuery query, CancellationToken cancellationToken)
    {
        var casesExternal =  await _kadArbitrCaseProvider.SearchCases(query.SearchQuery);

        var casesInternal = _mapper.Map<CaseExternal[], CaseInternal[]>(casesExternal);

        var cases = _mapper.Map<CaseInternal[], Domain.Cases.Case[]>(casesInternal);

        await _caseRepository.Add(cases, cancellationToken);

        return new SearchCasesResponse(casesInternal);
    }
}