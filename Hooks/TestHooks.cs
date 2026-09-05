using Allure.Net.Commons;
using Microsoft.Playwright;
using PlaywrightCSharpReqnroll.Utilities;
using Reqnroll;

namespace PlaywrightCSharpReqnroll.Hooks;

[Binding]
public sealed class TestHooks
{
    private readonly ScenarioContext _scenarioContext;

    public TestHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario(Order = 0)]
    public async Task BeforeScenarioAsync()
    {
        var driver = await DriverFactory.GetDriverAsync("chrome");
        _scenarioContext["Playwright"] = driver.Playwright;
        _scenarioContext["Browser"] = driver.Browser;
        _scenarioContext["BrowserContext"] = driver.Context;
        _scenarioContext["Page"] = driver.Page;
    }

    [AfterStep]
    public async Task AfterStepAsync()
    {
        if (_scenarioContext.TestError is not null)
        {
            if (_scenarioContext.TryGetValue("Page", out IPage? page) && page is not null)
            {
                var screenshot = await page.ScreenshotAsync(new PageScreenshotOptions { FullPage = true });
                AllureApi.AddAttachment(
                    $"Failed - {_scenarioContext.ScenarioInfo.Title}.png",
                    "image/png",
                    screenshot,
                    ".png");
            }
        }
    }

    [AfterScenario(Order = 100)]
    public async Task AfterScenarioAsync()
    {
        if (_scenarioContext.TryGetValue("Page", out IPage? page) && page is not null)
            await page.CloseAsync();

        if (_scenarioContext.TryGetValue("BrowserContext", out IBrowserContext? context) && context is not null)
            await context.CloseAsync();

        if (_scenarioContext.TryGetValue("Browser", out IBrowser? browser) && browser is not null)
            await browser.CloseAsync();

        if (_scenarioContext.TryGetValue("Playwright", out IPlaywright? playwright) && playwright is not null)
            playwright.Dispose();
    }
}
