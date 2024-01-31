using Glasno.Case.Aggregator.Application.Contracts;

namespace Glasno.Case.Aggregator.Application.Queries.SearchCases;

public record SearchCasesResponse(CaseInternal[] Cases);