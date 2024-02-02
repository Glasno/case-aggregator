using System.Reflection;
using CefSharp;
using CefSharp.OffScreen;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Factories;

internal static class CefFactory
{
    internal static void Initialize()
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        var settings = new CefSettings();
        settings.CachePath = Path.Combine(path, "ChromiumWebBrowserData");
        settings.RootCachePath = Path.Combine(path, "ChromiumWebBrowserData");
        
        Cef.Initialize(settings);
    }
}