using Microsoft.Playwright;
using PlaywrightCSharpReqnroll.Configuration;

namespace PlaywrightCSharpReqnroll.Utilities;

public static class DriverFactory
{
    public static async Task<(IPlaywright Playwright, IBrowser Browser, IBrowserContext Context, IPage Page)> GetDriverAsync(
        string? browserName = null)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = (browserName ?? TestSettings.Browser).ToLowerInvariant();

        IBrowser browserInstance = browser switch
        {
            "chrome" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = TestSettings.Headless,
                Args = new[] { "--start-maximized" }
            }),
            "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = TestSettings.Headless
            }),
            "edge" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "msedge",
                Headless = TestSettings.Headless,
                Args = new[] { "--start-maximized" }
            }),
            _ => throw new ArgumentException($"Browser '{browser}' is not supported.")
        };

        var context = await browserInstance.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = null
        });

        var page = await context.NewPageAsync();
        return (playwright, browserInstance, context, page);
    }
}
