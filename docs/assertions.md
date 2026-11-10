
# Assertions – S-08.3

Date: 2026-11-09

## Purpose

Assertions are used to check that the website behaves as expected during automated tests.

## Playwright Assertions

The homepage tests use Playwright assertions to verify:

- The homepage has the correct URL.
- The page title contains the expected text.
- The coming soon heading is visible.
- The displayed text matches the expected test data.

Examples:

```csharp
await Expect(Page).ToHaveURLAsync(Settings.BaseUrl);

await Expect(homePage.ComingSoonHeading)
    .ToBeVisibleAsync();

await Expect(homePage.StayTunedText)
    .ToHaveTextAsync(testData.ExpectedEnglishText);
```

## NUnit Assertions

The framework also uses NUnit assertions.

For example, Assert.Multiple checks several conditions together, so multiple failures can be reported from one test.

The contact and language test checks support email and language links.

## Mobile Assertions

Mobile tests verify that:

- The homepage body is visible.
- The browser viewport width is smaller than 600 pixels.

## Conclusion

Playwright and NUnit assertions help validate website functionality and make test failures easier to understand.
