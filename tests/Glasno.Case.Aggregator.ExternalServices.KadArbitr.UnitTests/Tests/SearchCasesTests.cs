using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Extensions;
using Xunit.Abstractions;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.UnitTests.Tests;

public class SearchCasesTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    public SearchCasesTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public async Task CanSearchCases()
    {
        // Arrange
        var kadArbitrCaseProvider = new KadArbitrCaseProvider();
        
        var searchQuery = new SearchQuery(
            Page: 1, 
            Count: 25, 
            DateFrom: null, 
            DateTo: null, 
            CaseNumbers: Array.Empty<string>(), 
            WithVKSInstances:false, 
            Courts: Array.Empty<string>(), 
            Sides: Array.Empty<SideExternal>(),
            Judges: Array.Empty<string>());

        var cookie =
            "__ddg1_=1cHEEA8C87euV0tlf5hQ; CUID=fc5ad075-0482-40fe-be81-bf8ff9794cc3:xNfR1OREkvMU7AuJ2gsiog==; KadLVCards=%d0%9077-80%2f2024~%d0%9084-109%2f2024~%d0%9059-154%2f2024~%d0%9084-108%2f2024; ASP.NET_SessionId=sgxetx5davrbczc32xyloc2t; Notification_All=fbbec45fa241402b9a7b8894aed39dba_1705906800000_shown; pr_fp=edd801b50ec46614907f58e423ffc6740aee160799aef48c0a29589830f0b2fa; wasm=bfcfa32608e8b47c30877fd86e63809b; rcid=112931ac-1177-4ee0-b4bd-519a8b540b6c";
        
        //Act
        var res = await kadArbitrCaseProvider.SearchCases(searchQuery, cookie);
        
        //Assert
        _testOutputHelper.WriteLine(res.ConvertToJson());
    }
}