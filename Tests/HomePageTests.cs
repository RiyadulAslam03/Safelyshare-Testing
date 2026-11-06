
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;
using SafelyShare.Tests.Pages;


namespace SafelyShare.Tests;
[Category("Smoke")]
public class HomePageTests : BaseTest
{

    [Test]
    public async Task HomePage_ShouldHaveCorrectUrlAndTitle()
    {
        var homePage = new HomePage(Page);
        await homePage.OpenAsync();

        await Expect(Page).ToHaveURLAsync(Settings.BaseUrl);
        await Expect(Page).ToHaveTitleAsync(
            new System.Text.RegularExpressions.Regex(
                @"Something new is coming.*SafelyShare",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase));
    }
    [Test]
    public async Task HomePage_ShouldDisplayComingSoonContent()
    {
        var homePage = new HomePage(Page);
        await homePage.OpenAsync();

        await Expect(homePage.ComingSoonHeading).ToBeVisibleAsync();
        await Expect(homePage.StayTunedText).ToBeVisibleAsync();
        await Expect(homePage.Logo).ToBeVisibleAsync();
    }
    [Test]
    public async Task HomePage_ShouldDisplayContactAndLanguageLinks()
    {
        var homePage = new HomePage(Page);
        await homePage.OpenAsync();

        await Expect(homePage.SupportEmail).ToBeVisibleAsync();
        await Expect(homePage.EnglishLink).ToBeVisibleAsync();
        await Expect(homePage.SwedishLink).ToBeVisibleAsync();
        await Expect(homePage.VeyroTechLink).ToBeVisibleAsync();
    }
}    

