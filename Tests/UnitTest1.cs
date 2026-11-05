
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;
using SafelyShare.Tests.Pages;


namespace SafelyShare.Tests;

public class Tests : BaseTest
{
    [Test]
    public async Task StartsidanSkaOppnas()
    {

        var homePage = new HomePage(Page);
        await homePage.OpenAsync();



        await Expect(Page).ToHaveURLAsync(
      new System.Text.RegularExpressions.Regex(
          "^" + System.Text.RegularExpressions.Regex.Escape(Settings.BaseUrl.TrimEnd('/')) + "/?$"));
        await Expect(Page).ToHaveTitleAsync("Something new is coming · SafelyShare");


        await Expect(homePage.ComingSoonHeading).ToBeVisibleAsync();

        await Expect(homePage.StayTunedText).ToBeVisibleAsync();
        await Expect(homePage.SupportEmail).ToBeVisibleAsync();
        await Expect(homePage.EnglishLink).ToBeVisibleAsync();
        await Expect(homePage.SwedishLink).ToBeVisibleAsync();
        await Expect(homePage.VeyroTechLink).ToBeVisibleAsync();
        await Expect(homePage.Logo).ToBeVisibleAsync();



    }
}
