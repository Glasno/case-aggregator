using Glasno.Case.Aggregator.Application.Contracts.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.Application.Converters;

public static class ValueObjectsInternalConverter
{
    public static CaseTypeInternal ToInternalCaseType(this CaseTypeExternal caseTypeExternal) => caseTypeExternal switch
    {
        CaseTypeExternal.None => CaseTypeInternal.None,
        CaseTypeExternal.Administrative => CaseTypeInternal.Administrative,
        CaseTypeExternal.Civil => CaseTypeInternal.Civil,
        _ => throw new ArgumentOutOfRangeException(nameof(caseTypeExternal), caseTypeExternal, null)
    };

    public static PlaintiffInternal ToInternalPlaintiff(this PlaintiffExternal plaintiffExternal)
    {
        return new PlaintiffInternal
        (
            plaintiffExternal.Name,
            plaintiffExternal.Address,
            plaintiffExternal.Inn
        );
    }
    
    public static RespondentInternal ToInternalRespondent(this RespondentExternal respondentExternal)
    {
        return new RespondentInternal
        (
            respondentExternal.Name,
            respondentExternal.Address,
            respondentExternal.Inn
        );
    }
}