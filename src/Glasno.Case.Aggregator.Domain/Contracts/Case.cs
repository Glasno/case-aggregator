using Glasno.Case.Aggregator.Domain.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.Domain.Contracts;

public record Case
(
    Guid CaseId,
    string CaseNumber,
    CaseType CaseType,
    string CourtName,
    string JudgeName,
    DateTime? Date,
    Plaintiff[] Plaintiffs,
    Respondent[] Respondents
);