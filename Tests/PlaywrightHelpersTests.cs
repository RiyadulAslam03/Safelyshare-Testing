
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using SafelyShare.Tests.Utils;

namespace SafelyShare.Tests.Tests;

[TestFixture]
[Category("Unit")]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class PlaywrightHelpersTests : PageTest
{
    [Test]
    public async Task ExpectVisibleAsync_ShouldFindVisibleElement()
    {
        await Page.SetContentAsync("<p id='status'>Ready</p>");

        var element = Page.Locator("#status");
        await element.ExpectVisibleAsync();

        Assert.That(await element.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task SafeClickAsync_ShouldClickButton()
    {
        await Page.SetContentAsync(
            "<button onclick=\"this.textContent='Clicked'\">Click me</button>");

        var button = Page.GetByRole(
            Microsoft.Playwright.AriaRole.Button);

        await button.SafeClickAsync();

        Assert.That(await button.InnerTextAsync(),
            Is.EqualTo("Clicked"));
    }

    [Test]
    public async Task GetAllLinksAsync_ShouldReturnLinks()
    {
        await Page.SetContentAsync(
            "<a href='/first'>First</a><a href='/second'>Second</a>");

        var links = await Page.GetAllLinksAsync();

        Assert.That(links,
            Is.EquivalentTo(new[] { "/first", "/second" }));
    }

    [Test]
    public async Task GetTextTrimmedAsync_ShouldTrimText()
    {
        await Page.SetContentAsync(
            "<pre id='message'>  Stay tuned!  </pre>");

        var text = await Page.Locator("#message").GetTextTrimmedAsync();

        Assert.That(text, Is.EqualTo("Stay tuned!"));
    }
}
