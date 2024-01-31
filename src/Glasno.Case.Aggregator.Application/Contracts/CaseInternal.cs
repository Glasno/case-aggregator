using Glasno.Case.Aggregator.Application.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.Application.Contracts;

public record CaseInternal
(
    Guid CaseId,
    string CaseNumber,
    CaseTypeInternal CaseTypeInternal,
    string CourtName,
    string JudgeName,
    DateTime? Date,
    PlaintiffInternal[] Plaintiffs,
    RespondentInternal[] Respondents
);