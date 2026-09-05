using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightCSharpReqnroll.Pages;
using Reqnroll;

namespace PlaywrightCSharpReqnroll.Features.Steps;

[Binding]
public sealed class LoginSteps
{
    private readonly ScenarioContext _scenarioContext;
    private IPage Page => _scenarioContext.Get<IPage>("Page");
    private LoginPage LoginPage => _scenarioContext.Get<LoginPage>("LoginPage");

    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("I navigate to the login page")]
    public async Task GivenINavigateToTheLoginPage()
    {
        _scenarioContext["LoginPage"] = new LoginPage(Page);
        await LoginPage.NavigateAsync();
    }

    [When("I enter valid username {string} and password {string}")]
    public async Task WhenIEnterValidUsernameAndPassword(string username, string password)
    {
        await LoginPage.LoginAsync(username, password);
    }

    [When("I click the login button")]
    public async Task WhenIClickTheLoginButton()
    {
        await LoginPage.ClickLoginAsync();
    }

    [Then("I should be redirected to the inventory dashboard")]
    public void ThenIShouldBeRedirectedToTheInventoryDashboard()
    {
        Assert.That(LoginPage.GetCurrentUrl(), Does.Contain("inventory.html"));
    }
}
