# C# Playwright BDD Automation Framework


## Stack
- C# / .NET 8
- Microsoft Playwright 1.62.0
- Reqnroll 3.3.4 (Gherkin/Cucumber-compatible BDD)
- NUnit
- Allure.Reqnroll 2.15.0

## Project Structure
```text
PlaywrightCSharpReqnroll/
├── Configuration/
├── Features/
│   ├── Steps/
│   ├── Demo.feature
│   ├── Demo1_Parabank.feature
│   └── Demo2_Parabank.feature
├── Hooks/
├── Pages/
├── Utilities/
├── allureConfig.json
├── PlaywrightCSharpReqnroll.csproj
└── README.md
```

## Setup
```powershell
dotnet restore
dotnet build
pwsh .\bin\Debug\net8.0\playwright.ps1 install
```

## Run
```powershell
dotnet test
```

Run a tag:
```powershell
dotnet test --filter "TestCategory=smoke"
```

## Allure
Generate results with:
```powershell
dotnet test
```

If Allure CLI is installed:
```powershell
allure serve allure-results
```

The framework captures a PNG screenshot in Allure when a Gherkin step fails.

## Browser
Default browser is Chromium/Chrome. Change:
```text
Configuration/TestSettings.cs
```
to `firefox` or `edge`.

## Notes
- Gherkin feature files are preserved from the original framework.
- Page Object structure is preserved and converted to C#.
- The original intentionally failing account-opening scenario is preserved.
