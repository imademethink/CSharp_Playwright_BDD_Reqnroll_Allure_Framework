using Microsoft.Playwright;

namespace PlaywrightCSharpReqnroll.Pages;

public sealed class OpenAccountPage : BasePage
{
    private const string LnkOpenNewAccount = "//a[@href='openaccount.htm']";
    private const string BtnOpenNewAccount = "//input[@value='Open New Account']";
    private const string LablAccountOpenSuccess = "//*[text()='Account Opened!']";
    private const string LablAccountId = "//*[@id='fromAccountId']";
    private const string BtnTransferFunds = "//*[text()='Transfer Funds']";
    private const string TxtbxTransferAmount = "//*[@id='amount']";
    private const string BtnTransfer = "//input[@type='submit']";
    private const string LablTransferComplete = "//*[text()='Transfer Complete!']";

    public bool AccountOpenSuccess { get; private set; }

    public OpenAccountPage(IPage page) : base(page) { }

    public async Task OpenNewAccountAsync()
    {
        await ClickElementAsync(LnkOpenNewAccount);
        await FindElementAsync(BtnOpenNewAccount);
        await ClickElementAsync(BtnOpenNewAccount);
    }

    public async Task NewAccountValidationAsync()
    {
        await FindElementAsync(LablAccountOpenSuccess);
        var accountId = await GetElementTextAsync(LablAccountId);
        Console.WriteLine(accountId);
        AccountOpenSuccess = true;
    }

    public async Task InitFundTransferAsync(string transferAmount)
    {
        await ClickElementAsync(BtnTransferFunds);
        await FindElementAsync(TxtbxTransferAmount);
        await EnterTextAsync(TxtbxTransferAmount, transferAmount);
    }

    public async Task FundTransferValidationAsync()
    {
        await ClickElementAsync(BtnTransfer);
        await FindElementAsync(LablTransferComplete);
    }
}
