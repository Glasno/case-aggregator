using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;
using MediatR;

namespace Glasno.Case.Aggregator.Application.Queries.SearchCases;

public class SearchCasesQuery: IRequest<SearchCasesResponse>
{
    public SearchQuery SearchQuery { get; set; }
    public string Cookie { get; set; }
}