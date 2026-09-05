using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightCSharpReqnroll.Pages;
using Reqnroll;

namespace PlaywrightCSharpReqnroll.Features.Steps;

[Binding]
public sealed class ParabankSteps
{
    private readonly ScenarioContext _scenarioContext;
    private IPage Page => _scenarioContext.Get<IPage>("Page");

    public ParabankSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    private HomePage HomePage => _scenarioContext.Get<HomePage>("HomePage");
    private RegisterPage RegisterPage => _scenarioContext.Get<RegisterPage>("RegisterPage");
    private OpenAccountPage OpenAccountPage => _scenarioContext.Get<OpenAccountPage>("OpenAccountPage");

    [Given("User is in on home page")]
    public async Task GivenUserIsInOnHomePage()
    {
        _scenarioContext["HomePage"] = new HomePage(Page);
        await HomePage.NavigateHomeAsync();
        await HomePage.ValidateLoginElementsAsync();
    }

    [When("User validates main menu items")]
    public async Task WhenUserValidatesMainMenuItems() =>
        await HomePage.ValidateMainMenuItemsAsync();

    [Then("Main menu item validation should be successful")]
    public void ThenMainMenuItemValidationShouldBeSuccessful() =>
        Assert.That(HomePage.MainMenuItemsCheck, Is.True, "Log: Main menu item validation failed");

    [When("User validates welcome section items")]
    public async Task WhenUserValidatesWelcomeSectionItems() =>
        await HomePage.ValidateWelcomeSectionElementsAsync();

    [Then("Welcome section item validation should be successful")]
    public void ThenWelcomeSectionItemValidationShouldBeSuccessful() =>
        Assert.That(HomePage.MainMenuItemsCheck, Is.True, "Log: Welcome section item validation failed");

    [When("User perform registration")]
    public async Task WhenUserPerformRegistration()
    {
        await HomePage.NavigateRegistrationAsync();
        _scenarioContext["RegisterPage"] = new RegisterPage(Page);
        await RegisterPage.RegistrationInitAsync();
    }

    [Then("Registration should be successful")]
    public void ThenRegistrationShouldBeSuccessful() =>
        Assert.That(RegisterPage.RegisterSuccess, Is.True, "Log: Registration failed");

    [Then("Account opening should not be successful")]
    public void ThenAccountOpeningShouldNotBeSuccessful()
    {
        _scenarioContext["OpenAccountPage"] = new OpenAccountPage(Page);
        Assert.That(OpenAccountPage.AccountOpenSuccess, Is.True, "Log: Account opened without user intention!");
    }

    [Given("User registration is successful")]
    public async Task GivenUserRegistrationIsSuccessful()
    {
        _scenarioContext["HomePage"] = new HomePage(Page);
        await HomePage.NavigateHomeAsync();
        await HomePage.NavigateRegistrationAsync();
        _scenarioContext["RegisterPage"] = new RegisterPage(Page);
        await RegisterPage.RegistrationInitAsync();
    }

    [When("User initiate New Account Opening")]
    public async Task WhenUserInitiateNewAccountOpening()
    {
        _scenarioContext["OpenAccountPage"] = new OpenAccountPage(Page);
        await OpenAccountPage.OpenNewAccountAsync();
    }

    [Then("New Account Opening should be successful")]
    public async Task ThenNewAccountOpeningShouldBeSuccessful() =>
        await OpenAccountPage.NewAccountValidationAsync();

    [When("User initiate Fund Transfer {string}")]
    public async Task WhenUserInitiateFundTransfer(string transferAmount) =>
        await OpenAccountPage.InitFundTransferAsync(transferAmount);

    [Then("Fund Transfer should be successful")]
    public async Task ThenFundTransferShouldBeSuccessful() =>
        await OpenAccountPage.FundTransferValidationAsync();
}
