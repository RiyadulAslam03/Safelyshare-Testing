
# Daily Log – 2026-11-03

1. Completed the Playwright test in both headed and headless modes.
2. Updated BasePage and HomePage with a reusable page load method.
3. Validated the website URL, exact page title, and six page elements.
4. Organized the project folders and created a GitHub pull request template.
5. Learned more about Page Object Model and Git. Next, I will continue with the framework tasks.

**Blockers:** Waiting for access to the team's GitHub repository.
# Daily Log – 2026-11-05

1. Updated the test configuration using appsettings.json.
2. Configured ConfigLoader and TestSettings.
3. Updated BaseTest and HomePage to use configuration settings.
4. Successfully ran the Playwright test using test.runsettings.
5. Test result: 1 passed, 0 failed.
6. Verified the homepage elements, including the logo.
7. Verified that Playwright runs in both headed and headless mode.
8. Updated BaseTest.cs with viewport, BaseURL, locale and HTTPS error handling.
9. Ran the test again using test.runsettings.
10. Final result: 1 test passed, 0 failed. Build succeeded.
	 
## Additional work – 2026-11-05

11. Added automatic screenshots when a Playwright test fails.
12. Tested the screenshot functionality and verified that the PNG file was created.
13. Added Playwright tracing to help investigate failed tests.
14. Updated BaseTest.cs to save screenshots and trace files when tests fail.
15. Successfully built and ran the project after the changes.
16. Final test result: 1 passed, 0 failed.
17. Committed and pushed the latest changes to my GitHub feature branch.
 ## Environment verification – 2026-11-07

- .NET SDK: 9.0.312
- Git: 2.51.0.windows.1
- PowerShell: 7.6.9
- Development environment verified successfully.
## Daily Log – 2026-11-08

1. Added Serilog logging to the test automation framework.
2. Configured automatic log files using Serilog.Sinks.File.
3. Added logging for test start times and test results.
4. Ran all three Playwright tests successfully.
5. Verified that the log file contains test names and Passed results.
6. Final result: 3 tests passed, 0 failed. Build succeeded.

## Additional work – 2026-11-08

1. Configured parallel test execution using NUnit.
2. Added a custom RetryAttribute to support automatic test retries.
3. Updated HomePageTests to use the custom RetryAttribute.
4. Tested and verified the retry functionality.
5. Ran all three Playwright tests successfully.
6. Final result: 3 tests passed, 0 failed. Build succeeded.

## Daily Log – 2026-11-09

1. Installed Allure.NUnit 2.15.0 for automated test reporting.
2. Created and configured allureConfig.json.
3. Added AllureNUnit attribute to HomePageTests.
4. Successfully built the project after the changes.
5. Executed all three Playwright tests successfully.
6. Installed Allure CLI and Java 21.
7. Generated and opened the Allure HTML report.
8. Verified that the report displays all three tests as passed.
9. Updated README.md with instructions for running tests and viewing Allure reports.
10. Final result: 3 tests passed, 0 failed.
 ## Daily Log – 2026-11-10

1. Added Allure attachments for failure screenshots and Playwright traces.
2. Built the project successfully after the changes.
3. Created a temporary test failure to verify error reporting.
4. Confirmed that Allure displays the failure message, screenshot, and trace.
5. Restored the original test assertion.
6. Ran all three automated tests successfully.
7. Final result: 3 tests passed, 0 failed. Build succeeded.


