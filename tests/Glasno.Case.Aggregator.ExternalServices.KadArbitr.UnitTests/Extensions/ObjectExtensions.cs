using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.UnitTests.Extensions;

public static class ObjectExtensions
{
    public static string ConvertToJson(this Object o)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        
        return JsonSerializer.Serialize(o, options);
    }
}