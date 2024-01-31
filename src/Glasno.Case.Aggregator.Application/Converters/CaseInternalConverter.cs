using Glasno.Case.Aggregator.Application.Contracts;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.Application.Converters;

public static class CaseInternalConverter
{
    internal static CaseInternal ToInternal(CaseExternal caseExternal)
    {
        return new CaseInternal
        (
            caseExternal.CaseId,
            caseExternal.CaseNumber,
            caseExternal.CaseType.ToInternalCaseType(),
            caseExternal.CourtName,
            caseExternal.JudgeName,
            caseExternal.Date,
            caseExternal.Plaintiffs.Select(p => p.ToInternalPlaintiff()).ToArray(),
            caseExternal.Respondents.Select(r => r.ToInternalRespondent()).ToArray()
        );
    }
    
    
}