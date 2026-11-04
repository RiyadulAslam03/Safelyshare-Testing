
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SafelyShare.Tests.Pages;

public class HomePage : BasePage
{
    public HomePage(IPage page) : base(page)
    {
    }

    public async Task OpenAsync()
    {
        await NavigateAsync(
     Environment.GetEnvironmentVariable("BASE_URL") ?? "https://safelyshare.se/");
        await WaitForLoadAsync();
    }
    public ILocator ComingSoonHeading =>
        GetHeading("Something new is coming");

    public ILocator StayTunedText =>
        Page.GetByText("Stay tuned!");

    public ILocator SupportEmail =>
        Page.GetByRole(AriaRole.Link, new() { Name = "support@veyrotech.com" });

    public ILocator EnglishLink =>
        Page.GetByRole(AriaRole.Link, new() { Name = "English" });

    public ILocator SwedishLink =>
        Page.GetByRole(AriaRole.Link, new() { Name = "Svenska" });

    public ILocator VeyroTechLink =>
        Page.GetByRole(AriaRole.Link, new() { Name = "Veyro Tech" });

}
