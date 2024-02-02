using Glasno.Case.Aggregator.Domain.Cases.ValueObjects;

namespace Glasno.Case.Aggregator.Domain.Cases;

public class Case
{
    public Guid CaseId { get; init; }
    public string CaseNumber { get; init; }
    public CaseType CaseType { get; init; }
    public string CourtName { get; init; }
    public string JudgeName { get; init; }
    public DateTime? Date { get; init; }
    public Plaintiff[] Plaintiffs { get; init; }
    public Respondent[] Respondents { get; init; }

    public void Deconstruct(out Guid CaseId, out string CaseNumber, out CaseType CaseType, out string CourtName, out string JudgeName, out DateTime? Date, out Plaintiff[] Plaintiffs, out Respondent[] Respondents)
    {
        CaseId = this.CaseId;
        CaseNumber = this.CaseNumber;
        CaseType = this.CaseType;
        CourtName = this.CourtName;
        JudgeName = this.JudgeName;
        Date = this.Date;
        Plaintiffs = this.Plaintiffs;
        Respondents = this.Respondents;
    }
}