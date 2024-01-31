using Glasno.Case.Aggregator.Domain.Contracts.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Converters;

public static class ValueObjectsExternalConverter
{
    public static CaseType ToCaseType(this CaseTypeExternal caseTypeExternal) => caseTypeExternal switch
    {
        CaseTypeExternal.None => CaseType.None,
        CaseTypeExternal.Administrative => CaseType.Administrative,
        CaseTypeExternal.Civil => CaseType.None,
        _ => throw new ArgumentOutOfRangeException(nameof(caseTypeExternal), caseTypeExternal, null)
    };

    public static Plaintiff ToPlaintiff(this PlaintiffExternal plaintiffExternal)
    {
        return new Plaintiff
        (
            plaintiffExternal.Name,
            plaintiffExternal.Address,
            plaintiffExternal.Inn
        );
    }
    
    public static Respondent ToRespondent(this RespondentExternal respondentExternal)
    {
        return new Respondent
        (
            respondentExternal.Name,
            respondentExternal.Address,
            respondentExternal.Inn
        );
    }
}