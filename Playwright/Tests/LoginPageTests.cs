using DemoTestFramework.Playwright.Pages;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DemoTestFramework.Playwright.Tests
{
    [TestFixture]
    public class LoginPageTests : PageTest
    {
        private readonly string homePageUrl = "http://eaapp.somee.com/";

        [SetUp]
        public async Task Setup()
        {
            await Page.SetViewportSizeAsync(1920, 1080);
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
            LoginPage loginPage = await NavigateToLoginPage();
            LoggedInPage loggedInPage = await loginPage.PerformLogin(userName, password);
            Assert.IsNotNull(loggedInPage, "Logged-in in page could not be found.");

            await Expect(Page.Locator("text=Hello admin!")).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Employee" })).ToBeVisibleAsync();
        }

        [TestCase("", "password", "The UserName field is required.")]
        public async Task IsUserNameFldErrorMsgDisplayed(string userName, string password, string expectedErrMsg)
        {
            LoginPage loginPage = await NavigateToLoginPage();
            await loginPage.PerformLogin(userName, password);

            await Expect(Page.Locator("span[data-valmsg-for='UserName']")).ToContainTextAsync(expectedErrMsg);
        }

        [TestCase("admin", "", "The Password field is required.")]

        public async Task IsPasswordFldErrorMsgDisplayed(string userName, string password, string expectedErrMsg)
        {
            LoginPage loginPage = await NavigateToLoginPage();
            await loginPage.PerformLogin(userName, password);

            await Expect(Page.Locator("span[data-valmsg-for='Password']")).ToContainTextAsync(expectedErrMsg);
        }

        #region Helper methods

        private async Task<LoginPage> NavigateToLoginPage()
        {
            HomePage homePage = new HomePage(Page);
            Assert.IsNotNull(await homePage.LnkLoginClick(), "Login page could not be found.");

            return new LoginPage(Page);
        }

        #endregion
    }
}