using System.Security.Cryptography;
using Microsoft.Playwright;

namespace PlaywrightCSharpReqnroll.Pages;

public sealed class RegisterPage : BasePage
{
    private const string TxtbxFirstName = "#customer\\.firstName";
    private const string TxtbxLastName = "#customer\\.lastName";
    private const string TxtbxAddress = "#customer\\.address\\.street";
    private const string TxtbxCity = "#customer\\.address\\.city";
    private const string TxtbxState = "#customer\\.address\\.state";
    private const string TxtbxZip = "#customer\\.address\\.zipCode";
    private const string TxtbxPhone = "#customer\\.phoneNumber";
    private const string TxtbxSsn = "#customer\\.ssn";
    private const string TxtbxUsername = "#customer\\.username";
    private const string TxtbxPassword = "#customer\\.password";
    private const string TxtbxPasswordAgain = "#repeatedPassword";
    private const string BtnRegister = "input[value='Register']";
    private const string BtnLogOut = "//*[text()='Log Out']";
    private const string LablAccount = "//*[text()='Your account was created successfully. You are now logged in.']";

    public bool RegisterSuccess { get; private set; }
    public Dictionary<string, string> GlobalData { get; } = new();

    public RegisterPage(IPage page) : base(page) { }

    public async Task RegistrationInitAsync()
    {
        var bytes = RandomNumberGenerator.GetBytes(8);
        var randomString = Convert.ToHexString(bytes).ToLowerInvariant();
        GlobalData["username"] = randomString;

        await EnterTextAsync(TxtbxFirstName, "Jon");
        await EnterTextAsync(TxtbxLastName, "Doe");
        await EnterTextAsync(TxtbxAddress, "221 Baker Street");
        await EnterTextAsync(TxtbxCity, "Reading");
        await EnterTextAsync(TxtbxState, "NY");
        await EnterTextAsync(TxtbxZip, "209876");
        await EnterTextAsync(TxtbxPhone, "7777788888");
        await EnterTextAsync(TxtbxSsn, "1122334455");
        await EnterTextAsync(TxtbxUsername, GlobalData["username"]);
        await EnterTextAsync(TxtbxPassword, "demo");
        await EnterTextAsync(TxtbxPasswordAgain, "demo");

        await ClickElementAsync(BtnRegister);
        await FindElementAsync(BtnLogOut);
        await FindElementAsync(LablAccount);
        RegisterSuccess = true;
    }
}
