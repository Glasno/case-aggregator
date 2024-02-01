using Glasno.Case.Aggregator.Application.Contracts;

namespace Glasno.Case.Aggregator.Application.Queries.SearchCases.Contracts;

public record SearchCasesResponse(CaseInternal[] Cases);