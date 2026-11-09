

param(
    [ValidateSet("All", "Smoke", "Regression")]
    [string]$Category = "All",

    [ValidateSet("chromium", "firefox", "webkit")]
    [string]$Browser = "chromium",

    [bool]$Headless = $true,

    [switch]$Report
)


$projectRoot = Split-Path -Parent $PSScriptRoot

Push-Location $projectRoot

try {
    Write-Host "Starting SafelyShare tests..."

    $testArgs = @("test", "--settings", "test.runsettings")

    if ($Category -ne "All") {
        $testArgs += @("--filter", "TestCategory=$Category")
    }
    
        $testArgs += @(
            "--",
            "Playwright.BrowserName=$Browser",
            "Playwright.LaunchOptions.Headless=$($Headless.ToString().ToLowerInvariant())"
        )

    & dotnet @testArgs
    $testExitCode = $LASTEXITCODE

    if ($Report) {
        $resultsPath = Join-Path $projectRoot "bin/Debug/net8.0/allure-results"

        if (Test-Path $resultsPath) {
            Write-Host "Opening Allure report..."
            & allure serve $resultsPath
        }
        else {
            Write-Warning "No Allure results found."
        }
    }

    if ($testExitCode -ne 0) {
        throw "Tests failed with exit code $testExitCode"
    }

    Write-Host "Test execution completed successfully."
}
finally {
    Pop-Location
}
