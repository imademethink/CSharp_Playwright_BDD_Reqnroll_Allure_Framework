using Microsoft.Playwright;
using PlaywrightCSharpReqnroll.Configuration;

namespace PlaywrightCSharpReqnroll.Pages;

public abstract class BasePage
{
    protected readonly IPage Page;
    protected const int Timeout = 10_000;
    protected string URL = TestSettings.BaseUrl;

    protected BasePage(IPage page) => Page = page;

    public async Task OpenUrlAsync(string url) => await Page.GotoAsync(url);

    protected ILocator FindElement(string locator)
    {
        var element = Page.Locator(locator);
        element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = Timeout }).GetAwaiter().GetResult();
        return element;
    }

    protected async Task<ILocator> FindElementAsync(string locator, int index = 0)
    {
        var element = Page.Locator(locator).Nth(index);
        await element.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Attached,
            Timeout = Timeout
        });
        return element;
    }

    protected async Task ClickElementAsync(string locator)
    {
        await (await FindElementAsync(locator)).ClickAsync();
    }

    protected async Task EnterTextAsync(string locator, string text)
    {
        await (await FindElementAsync(locator)).FillAsync(text);
    }

    public string GetCurrentUrl() => Page.Url;

    protected async Task<string?> GetElementTextAsync(string locator, int index = 0)
    {
        return await (await FindElementAsync(locator, index)).TextContentAsync();
    }
}
