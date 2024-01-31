using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Converters;

public static class CaseExternalConverter
{
    public static Domain.Contracts.Case ToCase(CaseExternal caseExternal)
    {
        return new Domain.Contracts.Case
        (
            caseExternal.CaseId,
            caseExternal.CaseNumber,
            caseExternal.CaseType.ToCaseType(),
            caseExternal.CourtName,
            caseExternal.JudgeName,
            caseExternal.Date,
            caseExternal.Plaintiffs.Select(p => p.ToPlaintiff()).ToArray(),
            caseExternal.Respondents.Select(r => r.ToRespondent()).ToArray()
        );
    }
}