using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers.Enums;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers;

public static class CasesParsePatternService
{
    private const string CaseNumberPattern = @"class=""num_case"">\s+([^""]+)</a>";
    private const string CaseTypePattern = @"class=""([^""]+)""\s";
    private const string JudgeNamePattern = @"<div class=""judge"" title=""([^""]+)";
    private const string CourtNamePattern = @"<div title=""([^""]+)";
    private const string DatePattern = @"<span>([^""]+)</span>";
    private const string CaseHrefPattern = @"href=""([^""]+)""";
    private const string PersonAddressPattern = @"br>([^""]+)\s</span>";
    private const string PersonNamePattern = @"<strong>([^""]+)</strong>";
    private const string PersonInnPattern = @": ([^""]+)</div>\s";
    
    public static string SelectParsePattern(ParsePatternType patternType) => patternType switch
    {
        ParsePatternType.CaseNumber => CaseNumberPattern,
        ParsePatternType.CaseType => CaseTypePattern,
        ParsePatternType.JudgeName => JudgeNamePattern,
        ParsePatternType.CourtName => CourtNamePattern,
        ParsePatternType.CaseHref => CaseHrefPattern,
        ParsePatternType.Date => DatePattern,
        ParsePatternType.PersonAddress => PersonAddressPattern,
        ParsePatternType.PersonName => PersonNamePattern,
        ParsePatternType.PersonInn => PersonInnPattern,
        _ => throw new ArgumentOutOfRangeException(nameof(patternType), patternType, null)
    };
}