# Safelyshare-Testing
Safelyshare automation testing
## Running Tests

This project uses C#, .NET, NUnit and Playwright for automated testing.

To run the tests, use:

dotnet test --settings test.runsettings

The tests validate the SafelyShare website using the configured base URL.

Test configuration is managed through appsettings.json and test.runsettings.