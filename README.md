
# Safelyshare-Testing

Automated testing framework for SafelyShare using C#, .NET, NUnit and Playwright.

## Prerequisites

- .NET 8 SDK
- PowerShell 7
- Playwright browser installed

## Install Playwright

Run the following command after building the project:

```powershell
dotnet build
pwsh bin/Debug/net8.0/playwright.ps1 install
```

## Running Tests

Run the automated tests using:

```powershell
dotnet test --settings test.runsettings
```

## Configuration

The base URL is configured in `appsettings.json`.

To override the base URL in PowerShell:

```powershell
$env:TestSettings__BaseUrl = "https://safelyshare.se/"
dotnet test --settings test.runsettings
```

Browser selection is configured through `test.runsettings`.

## Test Artifacts

Screenshots and Playwright traces are saved in the test work directory under `artifacts/` when tests fail.

## Test Coverage

The homepage tests verify the page URL, title, main content, contact information and language links.

## Test Categories

Smoke tests check the main functionality of the website.

Regression tests check that existing functionality still works after changes.

Run Smoke tests:
dotnet test --settings test.runsettings --filter "TestCategory=Smoke"

Run Regression tests:
dotnet test --settings test.runsettings --filter "TestCategory=Regression"

## Allure Reporting

The project uses Allure NUnit to generate test reports.

Run the automated tests:

```powershell
dotnet test --settings test.runsettings
```

Open the Allure report:

```powershell
allure serve .\bin\Debug\net8.0\allure-results
```

The report displays test results, execution time, test categories, and passed or failed tests.

Allure CLI and Java 21 are required to view the report.


## PowerShell Test Runner

The project includes a PowerShell script for running automated tests.

Run all tests:
```powershell
.\scripts\run-tests.ps1
```

Run Smoke tests:
```powershell
.\scripts\run-tests.ps1 -Category Smoke
```

Run Regression tests:
```powershell
.\scripts\run-tests.ps1 -Category Regression
```

Run tests and open the Allure report:
```powershell
.\scripts\run-tests.ps1 -Report
```

Verified results:
- Smoke: 3 passed, 0 failed.
- Regression: 1 passed, 0 failed.
