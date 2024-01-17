namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;

public record CaseExternal
(
    Guid CaseId,
    string CaseNumber,
    CaseTypeExternal CaseType,
    string CourtName,
    string Judge,
    DateTime Date,
    PlaintiffExternal[] Plaintiffs,
    RespondentExternal[] Respondents,
    bool IsSimpleJustice
);