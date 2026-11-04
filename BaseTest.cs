
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace SafelyShare.Tests;

public class BaseTest : PageTest
{
    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            ViewportSize = ViewportSize.NoViewport
        };
    }
}
