
using Microsoft.Playwright;
using NUnit.Framework;
using SafelyShare.Tests.Config;
using SafelyShare.Tests.Utils;

namespace SafelyShare.Tests.Tests;

[TestFixture]
[Category("Mobile")]
public class MobilePageTests
{
    [TestCase("iPhone 13")]
    [TestCase("Pixel 5")]
    public async Task Homepage_ShouldWorkOnMobile(string deviceName)
    {
        using var playwright = await Playwright.CreateAsync();

        await using var browser =
            await playwright.Chromium.LaunchAsync();

        var options = DeviceFactory.GetDeviceOptions(
            playwright, deviceName);

        await using var context =
            await browser.NewContextAsync(options);

        var page = await context.NewPageAsync();

        await page.GotoAsync(ConfigLoader.Load().BaseUrl);

        Assert.That(
            await page.Locator("body").IsVisibleAsync(),
            Is.True,
            "Homepage should be visible");

        Assert.That(
            page.ViewportSize?.Width,
            Is.LessThan(600),
            "Mobile viewport should be active");
    }
}
