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

## Cleanup

```bash
cmd /c rmdir /s /q bin

cmd /c rmdir /s /q allure-report

cmd /c rmdir /s /q allure-results
```

## Run all BDD tests

```bash
dotnet test
```

## Run a specific tag

```bash
dotnet test --filter "TestCategory=amoke"
```

The framework captures a PNG screenshot in Allure when a Gherkin step fails.

## Allure

The Reqnroll Allure adapter writes results to `allure-results` at the solution/project level using `allureConfig.json`.

```bash
allure generate bin/Debug/net8.0/allure-results -o allure-report --clean
allure open allure-report
```

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
