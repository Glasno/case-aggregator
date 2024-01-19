using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;

public record SearchQuery
(
        int Page,
        int Count,
        string[] Courts,
        DateTime? DateFrom,
        DateTime? DateTo,
        SideExternal[] Sides,
        string[] Judges,
        string[] CaseNumbers,
        bool WithVKSInstances
);