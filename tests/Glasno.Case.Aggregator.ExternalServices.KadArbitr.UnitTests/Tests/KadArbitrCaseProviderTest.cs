using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.UnitTests.Extensions;
using Xunit.Abstractions;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.UnitTests.Tests;

public class KadArbitrCaseProviderTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    public KadArbitrCaseProviderTest(ITestOutputHelper testOutputHelper)
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

        
        //Act
        var res = await kadArbitrCaseProvider.SearchCases(searchQuery);
        
        //Assert
        _testOutputHelper.WriteLine(res.ConvertToJson());
    }
}