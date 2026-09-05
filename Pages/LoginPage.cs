using Microsoft.Playwright;
using PlaywrightCSharpReqnroll.Configuration;

namespace PlaywrightCSharpReqnroll.Pages;

public sealed class LoginPage : BasePage
{
    private const string UsernameInput = "#user-name";
    private const string PasswordInput = "#password";
    private const string LoginButton = "#login-button";

    public LoginPage(IPage page) : base(page)
    {
        URL = TestSettings.SauceDemoUrl;
    }

    public async Task NavigateAsync() => await OpenUrlAsync(URL);

    public async Task LoginAsync(string username, string password)
    {
        await EnterTextAsync(UsernameInput, username);
        await EnterTextAsync(PasswordInput, password);
    }

    public async Task ClickLoginAsync() => await ClickElementAsync(LoginButton);
}
