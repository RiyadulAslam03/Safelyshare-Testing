
using Microsoft.Playwright;

namespace SafelyShare.Tests.Utils;

public static class PlaywrightHelpers
{
    // 1. Wait until an element is visible
    public static async Task ExpectVisibleAsync(this ILocator locator)
    {
        await locator.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Visible
        });
    }

    // 2. Safely click an element
    public static async Task SafeClickAsync(this ILocator locator)
    {
        await locator.ExpectVisibleAsync();
        await locator.ClickAsync();
    }

    // 3. Get all links from a page
    public static async Task<List<string>> GetAllLinksAsync(this IPage page)
    {
        var links = new List<string>();
        var elements = await page.Locator("a[href]").AllAsync();

        foreach (var element in elements)
        {
            var href = await element.GetAttributeAsync("href");

            if (!string.IsNullOrWhiteSpace(href))
            {
                links.Add(href);
            }
        }

        return links;
    }

    // 4. Get text without extra spaces
    public static async Task<string> GetTextTrimmedAsync(this ILocator locator)
    {
        var text = await locator.InnerTextAsync();
        return text.Trim();
    }
}
