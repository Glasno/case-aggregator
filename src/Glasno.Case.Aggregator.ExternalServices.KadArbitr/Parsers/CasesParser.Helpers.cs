using System.Globalization;
using System.Text.RegularExpressions;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;
using HtmlAgilityPack;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers;

public static partial class CasesParser
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

    private enum ParsePatternType
    {
        CaseHref,
        Date,
        CaseNumber,
        CaseType, 
        CourtName,
        JudgeName,
        PersonAddress,
        PersonName,
        PersonInn
    }

    private static Guid ParseGuidFromHtml(string html)
    {
        var href = GetCaseExternalObjectFromHtml(html, ParsePatternType.CaseHref);
        var guid = href.Split('/').Last();

        return new Guid(guid);
    }

    private static DateTime ParseDateFromHtml(string html)
    {
        var date = GetCaseExternalObjectFromHtml(html, ParsePatternType.Date);
        
        if (DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
            return dateTime;
        
        return new DateTime();
    }

    private static CaseTypeExternal ParseCaseTypeFromHtml(string html)
    {
        var type = GetCaseExternalObjectFromHtml(html, ParsePatternType.CaseType);

        return GetCaseTypeExternal(type);
    }
    
    private static string GetCaseExternalObjectFromHtml(string html, ParsePatternType patternType)
    {
        var pattern = SelectParsePattern(patternType);
        var match = Regex.Match(html, pattern);
        
        return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
    }

    private static PlaintiffExternal[] ParsePlaintiff(HtmlNode num)
    {
        var container = num.ChildNodes.First(node => node.Name == "div");
        var result = new List<PlaintiffExternal>();

        foreach (var childNode in container.ChildNodes.Where(node => node.Name == "div"))
        {
            if (childNode.ChildNodes.All(node => node.Name != "span")) continue;
            
            result.Add(new PlaintiffExternal(
                Name: GetCaseExternalObjectFromHtml(childNode.InnerHtml, ParsePatternType.PersonName).Replace("&quot;", @""""),
                Address: GetCaseExternalObjectFromHtml(childNode.ChildNodes.First(node => node.Name == "span").InnerHtml, ParsePatternType.PersonAddress),
                Inn: GetCaseExternalObjectFromHtml(childNode.InnerHtml, ParsePatternType.PersonInn)
            ));
        }

        return result.ToArray();
    }

    private static RespondentExternal[] ParseRespondent(HtmlNode num)
    {
        var container = num.ChildNodes.First(node => node.Name == "div");
        var result = new List<RespondentExternal>();

        foreach (var childNode in container.ChildNodes.Where(node => node.Name == "div"))
        {
            if (childNode.ChildNodes.All(node => node.Name != "span")) continue;
            
            result.Add(new RespondentExternal(
                Name: GetCaseExternalObjectFromHtml(childNode.InnerHtml, ParsePatternType.PersonName).Replace("&quot;", @""""),
                Address: GetCaseExternalObjectFromHtml((childNode.ChildNodes.First(node => node.Name == "span")).InnerHtml, ParsePatternType.PersonAddress),
                Inn: GetCaseExternalObjectFromHtml(childNode.InnerHtml, ParsePatternType.PersonInn)
            ));
        }

        return result.ToArray();
    }

    private static CaseTypeExternal GetCaseTypeExternal(string type) => type switch
    {
        "administrative" => CaseTypeExternal.Administrative,
        "civil" => CaseTypeExternal.Civil,
        _ => CaseTypeExternal.None
    };
    
    private static string SelectParsePattern(ParsePatternType patternType) => patternType switch
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