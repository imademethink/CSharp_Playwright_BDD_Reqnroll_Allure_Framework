namespace PlaywrightCSharpReqnroll.Configuration;

public static class TestSettings
{
    public const string BaseUrl = "https://parabank.parasoft.com/parabank/index.htm";
    public const string SauceDemoUrl = "https://saucedemo.com";

    public static string Browser =>
        Environment.GetEnvironmentVariable("BROWSER")?.ToLowerInvariant() ?? "chrome";

    public static bool Headless =>
        bool.TryParse(Environment.GetEnvironmentVariable("HEADLESS"), out var value) && value;
}

// cmd /c rmdir /s /q bin
// cmd /c rmdir /s /q allure-report

// dotnet test --filter "TestCategory=smoke" 
// dotnet test 
// allure generate bin/Debug/net8.0/allure-results -o allure-report --clean
// allure open allure-report




