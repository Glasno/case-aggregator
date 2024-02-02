namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

public class CaseExternal
{
    public Guid CaseId { get; init; }
    public string CaseNumber { get; init; }
    public CaseTypeExternal CaseType { get; init; }
    public string CourtName { get; init; }
    public string JudgeName { get; init; }
    public DateTime? Date { get; init; }
    public PlaintiffExternal[] Plaintiffs { get; init; }
    public RespondentExternal[] Respondents { get; init; }
}