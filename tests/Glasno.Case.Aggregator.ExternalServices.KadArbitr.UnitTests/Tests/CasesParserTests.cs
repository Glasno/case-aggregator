using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Parsers;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.UnitTests.Extensions;
using Xunit.Abstractions;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.UnitTests.Tests;

public class CasesParserTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CasesParserTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData("Assets/SearchCasesHtmlResponse.html")]
    [InlineData("Assets/SearchCasesHtmlResponse_1.html")]
    public async Task RegexCanParse(string pathToHtml)
    {
        // Arrange
        using var reader = new StreamReader(pathToHtml);
        var html = await reader.ReadToEndAsync();

        //Act
        var cases = CasesParser.ParseHtml(html);
        var json = cases.ConvertToJson();
        
        //Assert
        _testOutputHelper.WriteLine(json);
    }
}