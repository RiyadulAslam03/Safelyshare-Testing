
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SafelyShare.Tests.Pages;

public class BasePage
{
    protected readonly IPage Page;

    public BasePage(IPage page)
    {
        Page = page;
    }

    public async Task NavigateAsync(string url)
    {
        await Page.GotoAsync(url);
    }

    public ILocator GetHeading(string text)
    {
        return Page.GetByRole(
            AriaRole.Heading,
            new() { Name = text });
    }
    public async Task WaitForLoadAsync()
    {
        await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }
}
