using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using SafelyShare.Tests.Config;

namespace SafelyShare.Tests;

public class BaseTest : PageTest
{
    protected static readonly TestSettings Settings = ConfigLoader.Load();
    [SetUp]
    public async Task ConfigureTimeout()
    {
        Page.SetDefaultTimeout(Settings.DefaultTimeoutMs);

        await Context.Tracing.StartAsync(new TracingStartOptions
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
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
            TestContext.AddTestAttachment(Path.GetFullPath(screenshotPath));


        }
        await Context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = TestContext.CurrentContext.Result.Outcome.Status ==
        NUnit.Framework.Interfaces.TestStatus.Failed
        ? Path.Combine("artifacts", $"{TestContext.CurrentContext.Test.ID}-trace.zip")
        : null
        });
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
