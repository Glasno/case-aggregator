﻿using System.Globalization;
using System.Text.RegularExpressions;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers.Enums;
using HtmlAgilityPack;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers;

public static partial class CasesParser
{
    private static string GetCaseExternalObjectFromHtml(string html, ParsePatternType patternType)
    {
        var pattern = CasesParsePatternService.SelectParsePattern(patternType);
        var match = Regex.Match(html, pattern);

        return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
    }

    private static Guid ParseGuidFromHtml(string html)
    {
        var href = GetCaseExternalObjectFromHtml(html, ParsePatternType.CaseHref);
        var guid = href.Split('/').Last();

        return new Guid(guid);
    }

    private static DateTime? ParseDateFromHtml(string html)
    {
        var date = GetCaseExternalObjectFromHtml(html, ParsePatternType.Date);

        if (DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
            return dateTime;

        return null;
    }

    private static CaseTypeExternal ParseCaseTypeFromHtml(string html)
    {
        var type = GetCaseExternalObjectFromHtml(html, ParsePatternType.CaseType);

        return GetCaseTypeExternal(type);
    }

    private static PlaintiffExternal[] ParsePlaintiff(HtmlNode num)
    {
        var container = num.ChildNodes.First(node => node.Name == "div");
        var result = new List<PlaintiffExternal>();

        var childNodes = container.ChildNodes
            .Where(node => 
                node.Name == "div" 
                && node.ChildNodes
                    .Any(n => n.Name == "span"));

        foreach (var childNode in childNodes)
        {
            result.Add(new PlaintiffExternal(
                Name: GetCaseExternalObjectFromHtml(childNode.InnerHtml, ParsePatternType.PersonName)
                    .Replace("&quot;", @""""),
                Address: GetCaseExternalObjectFromHtml(childNode.ChildNodes.First(node => node.Name == "span").InnerHtml,
                    ParsePatternType.PersonAddress),
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
                Name: GetCaseExternalObjectFromHtml(childNode.InnerHtml, ParsePatternType.PersonName)
                    .Replace("&quot;", @""""),
                Address: GetCaseExternalObjectFromHtml((childNode.ChildNodes.First(node => node.Name == "span")).InnerHtml,
                    ParsePatternType.PersonAddress),
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
}