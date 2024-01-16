using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr;

public interface IKadArbitrCaseProvider
{
    Task<CaseExternal> SearchCases(SearchQuery query);
}