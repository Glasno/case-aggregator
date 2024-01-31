﻿using CefSharp;
using CefSharp.OffScreen;

namespace Glasno.Case.Aggregator.ExternalServices.KadArbitr.Factories;

public static class KadArbitrBrowserFactory
{
    private const string KadArbitrUrl = "https://kad.arbitr.ru";
    private const string ClickOnSearchButtonScript = "document.getElementsByClassName('b-button-container')[0].click()";

    public static ChromiumWebBrowser Create()
    {
       var browser = new ChromiumWebBrowser(KadArbitrUrl);
       browser.Load().GetAwaiter().GetResult();
       
       return browser;
    }

    private static async Task Load(this ChromiumWebBrowser browser)
    {
        var loadUrl = await browser.WaitForInitialLoadAsync();

        if (!loadUrl.Success)
        {
            throw new Exception(
                $"Page load failed with ErrorCode:{loadUrl.ErrorCode}, HttpStatusCode:{loadUrl.HttpStatusCode}");
        }
    }
        

    public static async Task<string> CreateCookies(this ChromiumWebBrowser browser)
    {
        browser.ExecuteScriptAsync(ClickOnSearchButtonScript);

        await Task.Delay(10000);

        var cookiesList = await browser.GetCookieManager().VisitAllCookiesAsync();
        var cookies = cookiesList.FindAll(cookie => cookie.Name is "pr_fp" or "wasm");
        
        return FormattingCookies(cookies);
    }

    private static string FormattingCookies(List<Cookie> cookies)
    {
        var cookie = cookies.Select(cookie => $"{cookie.Name}={cookie.Value}").ToArray();
        return $"{cookie[0]}; {cookie[1]}";
    }
}