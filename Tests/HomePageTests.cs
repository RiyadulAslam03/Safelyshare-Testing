using Allure.NUnit;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;
using SafelyShare.Tests.Pages;
using SafelyShare.Tests.Base;
[assembly: LevelOfParallelism(2)]

namespace SafelyShare.Tests;
[AllureNUnit]
[Category("Smoke")]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.All)]
public class HomePageTests : BaseTest
{
    [SafelyShare.Tests.Tests.Retry(2)]
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
    [Category("Regression")]
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

