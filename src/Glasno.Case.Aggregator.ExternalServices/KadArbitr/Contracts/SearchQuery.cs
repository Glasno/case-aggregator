namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;

public record SearchQuery
(
        int Page,
        int Count,
        CaseTypeExternal CaseType,
        string[] Courts,
        DateTime? DateFrom,
        DateTime? DateTo,
        SidesExternal Sides,
        string[] Judges,
        string[] CaseNumbers,
        bool WithVKSInstances
);