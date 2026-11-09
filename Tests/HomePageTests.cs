using Allure.NUnit;
using Allure.Net.Commons.Attributes;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;
using SafelyShare.Tests.Pages;
using SafelyShare.Tests.Base;
[assembly: LevelOfParallelism(2)]

namespace SafelyShare.Tests;
[AllureNUnit]
[AllureSuite("Homepage Tests")]
[AllureFeature("Homepage")]
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

        var testData = SafelyShare.Tests.Config.TestDataLoader.LoadHomePage();

        await Expect(homePage.ComingSoonHeading).ToBeVisibleAsync();
        await Expect(homePage.StayTunedText).ToHaveTextAsync(testData.ExpectedEnglishText);
    }
    [Test]
    public async Task HomePage_ShouldDisplayContactAndLanguageLinks()
    {
        var homePage = new HomePage(Page);
        await homePage.OpenAsync();


        var emailVisible = await homePage.SupportEmail.IsVisibleAsync();
        var englishVisible = await homePage.EnglishLink.IsVisibleAsync();
        var swedishVisible = await homePage.SwedishLink.IsVisibleAsync();
        var veyroVisible = await homePage.VeyroTechLink.IsVisibleAsync();

        Assert.Multiple(() =>
        {
            Assert.That(emailVisible, Is.True, "Support email is missing");
            Assert.That(englishVisible, Is.True, "English link is missing");
            Assert.That(swedishVisible, Is.True, "Swedish link is missing");
            Assert.That(veyroVisible, Is.True, "VeyroTech link is missing");
        });

    }

}    

