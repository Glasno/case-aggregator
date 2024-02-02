namespace Glasno.Case.Aggregator.Infrastructure.Abstractions.Repository.Cases.Contracts;

public sealed record SearchQuery
(
    string[] Id,
    string[] Courts,
    DateTime? DateFrom,
    DateTime? DateTo,
    string[] Judges,
    string[] CaseNumbers,
    int Limit,
    int Skip
);