using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightDemo.PlaywrightNUnit.Pages;
using System.Threading.Tasks;

namespace PlaywrightDemo.PlaywrightNUnit.Tests
{
    [TestFixture]
    public class LoginPageTests : PageTest
    {
        private readonly string homePageUrl = "http://eaapp.somee.com/";

        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync(homePageUrl);

        }

        [TearDown]
        public void Teardown()
        {
            Page.SetDefaultTimeout(5000);
            Page.CloseAsync().GetAwaiter().GetResult();
        }

        [TestCase("admin", "password")]
        public async Task CanUserLogin(string userName, string password)
        {
            LoginPage loginPage = new LoginPage(Page);

            await Page.FullscreenAsync();
            await NavigateToLoginPage();
            await loginPage.PerformLogin(userName, password);

            await Expect(Page.Locator("text=Hello admin!")).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Employee" })).ToBeVisibleAsync();
        }

        [TestCase("", "password", "The UserName field is required.")]
        public async Task IsUserNameFldErrorMsgDisplayed(string userName, string password, string expectedErrMsg)
        {
            LoginPage loginPage = new LoginPage(Page);

            await NavigateToLoginPage();
            await loginPage.PerformLogin(userName, password);

            await Expect(Page.Locator("span[data-valmsg-for='UserName']")).ToContainTextAsync(expectedErrMsg);
        }

        [TestCase("admin", "", "The Password field is required.")]

        public async Task IsPasswordFldErrorMsgDisplayed(string userName, string password, string expectedErrMsg)
        {
            LoginPage loginPage = new LoginPage(Page);
        
            await NavigateToLoginPage();
            await loginPage.PerformLogin(userName, password);

            await Expect(Page.Locator("span[data-valmsg-for='Password']")).ToContainTextAsync(expectedErrMsg);
        }

        #region Helper methods

        private async Task NavigateToLoginPage()
        {
            HomePage homePage = new HomePage(Page);
            await homePage.LnkLoginClick();
        }

        #endregion
    }
}
