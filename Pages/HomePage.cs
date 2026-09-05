using Microsoft.Playwright;

namespace PlaywrightCSharpReqnroll.Pages;

public sealed class HomePage : BasePage
{
    private const string TxtbxUser = "[name='username']";
    private const string TxtbxPwd = "[name='password']";
    private const string BtnLogIn = "//input[@value='Log In']";
    private const string LinkSolutions = "//*[text()='Solutions']";
    private const string LinkAboutUs = "//*[text()='About Us']";
    private const string LinkServices = "//*[text()='Services']";
    private const string LinkProducts = "//*[text()='Products']";
    private const string LinkLocations = "//*[text()='Locations']";
    private const string IconHome = ".home";
    private const string IconAboutUs = ".aboutus";
    private const string IconContact = ".contact";
    private const string LnkRegister = "//*[text()='Register']";
    private const string BtnRegister = "input[value='Register']";

    public bool MainMenuItemsCheck { get; private set; }

    public HomePage(IPage page) : base(page) { }

    public async Task NavigateHomeAsync() => await OpenUrlAsync(URL);

    public async Task ValidateLoginElementsAsync()
    {
        await FindElementAsync(TxtbxUser);
        await FindElementAsync(TxtbxPwd);
        await FindElementAsync(BtnLogIn);
    }

    public async Task ValidateMainMenuItemsAsync()
    {
        await FindElementAsync(LinkSolutions);
        await FindElementAsync(LinkAboutUs);
        await FindElementAsync(LinkServices);
        await FindElementAsync(LinkProducts);
        await FindElementAsync(LinkLocations);
        MainMenuItemsCheck = true;
    }

    public async Task ValidateWelcomeSectionElementsAsync()
    {
        await FindElementAsync(IconHome);
        await FindElementAsync(IconAboutUs);
        await FindElementAsync(IconContact);
        MainMenuItemsCheck = true;
    }

    public async Task NavigateRegistrationAsync()
    {
        await ClickElementAsync(LnkRegister);
        await FindElementAsync(BtnRegister);
    }
}
