using Glasno.Case.Aggregator.Application.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.Application.Contracts;

public class CaseInternal
{
    public Guid CaseId { get; init; }
    public string CaseNumber { get; init; }
    public CaseTypeInternal CaseTypeInternal { get; init; }
    public string CourtName { get; init; }
    public string JudgeName { get; init; }
    public DateTime? Date { get; init; }
    public PlaintiffInternal[] Plaintiffs { get; init; }
    public RespondentInternal[] Respondents { get; init; }
}