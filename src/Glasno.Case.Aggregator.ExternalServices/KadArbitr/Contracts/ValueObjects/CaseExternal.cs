namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

public record CaseExternal
(
    Guid CaseId,
    string CaseNumber,
    CaseTypeExternal CaseType,
    string CourtName,
    string JudgeName,
    DateTime Date,
    PlaintiffExternal[] Plaintiffs,
    RespondentExternal[] Respondents
);