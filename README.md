# C# Playwright BDD Automation Framework


---

<img width="1672" height="941" alt="Ready To Use Automation Framework - C sharp, Playwright, BDD Reqnroll Nunit" src="https://github.com/user-attachments/assets/cb78a2bc-6eee-4ec5-b85a-1d9078e34d58" />

# YouTube Video Link

---

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
---

# 🚀 Getting Started

## Clone Repository

```bash
git clone https://github.com/imademethink/CSharp_Playwright_BDD_Reqnroll_Allure_Framework.git
```

---

## Navigate to Folder

```bash
cd CSharp_Playwright_BDD_Reqnroll_Allure_Framework
```

---

## Do the setup

```powershell
dotnet restore
dotnet build
pwsh .\bin\Debug\net8.0\playwright.ps1 install
```

## Run a specific tag

```bash
dotnet test --filter "TestCategory=smoke"   --framework net8.0 
```

## Run all BDD tests
```powershell
dotnet test --framework net8.0 
```

## Allure Report

The Reqnroll Allure adapter writes results to `allure-results` at the solution/project level using `allureConfig.json`.

The framework captures a PNG screenshot in Allure when a Gherkin step fails.

```bash
Download Allure report binary from path : https://github.com/allure-framework/allure2/releases and add this path on System variable.

allure generate bin/Debug/net8.0/allure-results -o allure-report --clean
allure open allure-report
```

## Cleanup (optional)

```bash
cmd /c rmdir /s /q bin

cmd /c rmdir /s /q allure-report

cmd /c rmdir /s /q allure-results
```

## Browser change
Default browser is Chromium/Chrome. 

Change it from below file:
```text
Configuration/TestSettings.cs

Hooks/TestHooks.cs
```
to `firefox` or `edge` (default is `chrome`).


## Notes
- Gherkin feature files are preserved from the original framework.
- Page Object structure is preserved and converted to C#.
- The original intentionally failing account-opening scenario is preserved.
