using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr;

public interface IKadArbitrCaseProvider
{
    Task<CaseExternal[]> SearchCases(SearchQuery query);
}