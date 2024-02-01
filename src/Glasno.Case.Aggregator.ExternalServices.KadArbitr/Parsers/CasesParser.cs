using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers.Enums;
using HtmlAgilityPack;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers;

public static partial class CasesParser
{
    public static CaseExternal[] ParseHtml(string htmlPage)
    {
        var document = new HtmlDocument();
        document.LoadHtml(htmlPage);

        var allCases = document.DocumentNode.SelectNodes("//tr");
        
        return allCases?.Select(GetCases).ToArray() ?? Array.Empty<CaseExternal>();
    }

    private static CaseExternal GetCases(HtmlNode courtСases)
    {
        var caseInfoHtml = string.Empty;
        var courtInfoHtml = string.Empty;
        var plaintiffsHtml = HtmlNode.CreateNode(string.Empty);
        var respondentsHtml =  HtmlNode.CreateNode(string.Empty);
        
        foreach (var courtСase in courtСases.ChildNodes.Where(node => node.Name == "td"))
        {
            switch (courtСase.Attributes["class"].Value)
            {
                case "num":
                    caseInfoHtml = courtСase.InnerHtml;
                    break;
                case "court":
                    courtInfoHtml = courtСase.InnerHtml;;
                    break;
                case "plaintiff":
                    plaintiffsHtml = courtСase;
                    break;
                case "respondent":
                    respondentsHtml = courtСase;
                    break;
            }
        }

        return new CaseExternal
        {
            CaseId = ParseGuidFromHtml(caseInfoHtml),
            Date = ParseDateFromHtml(caseInfoHtml),
            CaseNumber = GetCaseExternalObjectFromHtml(caseInfoHtml, ParsePatternType.CaseNumber),
            CaseType = ParseCaseTypeFromHtml(caseInfoHtml),
            CourtName = GetCaseExternalObjectFromHtml(courtInfoHtml, ParsePatternType.CourtName),
            JudgeName = GetCaseExternalObjectFromHtml(courtInfoHtml, ParsePatternType.JudgeName),
            Plaintiffs = ParsePlaintiff(plaintiffsHtml),
            Respondents = ParseRespondent(respondentsHtml)
        };
    }
}