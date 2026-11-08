using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using SafelyShare.Tests.Config;
using Serilog;

namespace SafelyShare.Tests.Base;

public class BaseTest : PageTest
{
    protected static readonly TestSettings Settings = ConfigLoader.Load();

    private bool _tracingStarted;
    private static readonly Serilog.Core.Logger Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/test-log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
    
    [SetUp]
    public async Task SetUpAsync()
    {
        Page.SetDefaultTimeout(Settings.DefaultTimeoutMs);
        Logger.Information("Starting test: {TestName}", TestContext.CurrentContext.Test.Name);

        await Context.Tracing.StartAsync(new TracingStartOptions
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        _tracingStarted = true;
    }

    [TearDown]
    public async Task TearDownAsync()
    {
        bool failed = TestContext.CurrentContext.Result.Outcome.Status ==
                      NUnit.Framework.Interfaces.TestStatus.Failed;
        Logger.Information("Finished test: {TestName}, Result: {Result}",
            TestContext.CurrentContext.Test.Name,
            TestContext.CurrentContext.Result.Outcome.Status);

        string artifactsDir = Path.Combine(
            TestContext.CurrentContext.WorkDirectory,
            "artifacts");

        if (failed)
        {
            Directory.CreateDirectory(artifactsDir);
        }

        string tracePath = Path.Combine(
            artifactsDir,
            $"{TestContext.CurrentContext.Test.ID}-trace.zip");

        try
        {
            if (failed)
            {
                string screenshotPath = Path.Combine(
                    artifactsDir,
                    $"{TestContext.CurrentContext.Test.ID}.png");

                await Page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = screenshotPath,
                    FullPage = true
                });

                TestContext.AddTestAttachment(screenshotPath);
            }
        }
        finally
        {
            if (_tracingStarted)
            {
                await Context.Tracing.StopAsync(new TracingStopOptions
                {
                    Path = failed ? tracePath : null
                });

                _tracingStarted = false;
            }

            if (failed && File.Exists(tracePath))
            {
                TestContext.AddTestAttachment(tracePath);
            }
        }
    }

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
            BaseURL = Settings.BaseUrl,
            Locale = "en-US",
            IgnoreHTTPSErrors = false
        };
    }

    [OneTimeTearDown]
    public static void CloseLogger()
    {
        Logger.Dispose();
    }
}
