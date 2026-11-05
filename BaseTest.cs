using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using SafelyShare.Tests.Config;

namespace SafelyShare.Tests;

public class BaseTest : PageTest
{
    protected static readonly TestSettings Settings = ConfigLoader.Load();
    [SetUp]
    public void ConfigureTimeout()
    {

        Page.SetDefaultTimeout(Settings.DefaultTimeoutMs);

    }
    [TearDown]
    public async Task SaveScreenshotOnFailure()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status ==
            NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Directory.CreateDirectory("artifacts");

            string screenshotPath = Path.Combine(
                "artifacts",
                $"{TestContext.CurrentContext.Test.ID}.png");

            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = screenshotPath,
                FullPage = true
            });

            TestContext.AddTestAttachment(
                Path.GetFullPath(screenshotPath));
        }
    }
    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            ViewportSize = ViewportSize.NoViewport,
            BaseURL = Settings.BaseUrl,
            Locale = "en-US",
            IgnoreHTTPSErrors = true
        };
    }
}
