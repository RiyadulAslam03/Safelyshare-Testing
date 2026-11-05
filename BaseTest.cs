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
        Page.SetDefaultTimeout(Settings.Timeout);
    }
    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            ViewportSize = ViewportSize.NoViewport,
            BaseURL = Settings.BaseUrl
        };
    }
}
