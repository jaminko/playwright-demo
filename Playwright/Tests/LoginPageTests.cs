using DemoTestFramework.Playwright.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DemoTestFramework.Playwright.Tests
{
    [TestFixture]
    public class LoginPageTests : PageTest
    {
        private readonly string practicePageUrl = "https://practicetestautomation.com/practice/";

        [SetUp]
        public async Task Setup()
        {
            await Page.SetViewportSizeAsync(1920, 1080);
            await Page.GotoAsync(practicePageUrl);
        }

        [TearDown]
        public void Teardown()
        {
            Page.SetDefaultTimeout(5000);
            Page.CloseAsync().GetAwaiter().GetResult();
        }

        [TestCase("student", "Password123")]
        public async Task CanUserLogin(string userName, string password)
        {
            LoginPage loginPage = await NavigateToLoginPage();
            LoggedInPage loggedInPage = await loginPage.PerformLogin(userName, password);
            Assert.IsNotNull(loggedInPage, "Logged-in in page could not be found.");

            await Expect(Page.Locator("text=Logged In Successfully")).ToBeVisibleAsync();
            await Expect(Page.Locator("text=Congratulations student. You successfully logged in!")).ToBeVisibleAsync();
            Assert.IsTrue(await loggedInPage.BtnLogOut.IsVisibleAsync(), "Log out CTA button could not be found.");
        }

        [TestCase("", "Password123", "Your username is invalid!")]
        public async Task IsUserNameFldErrorMsgDisplayed(string userName, string password, string expectedErrMsg)
        {
            LoginPage loginPage = await NavigateToLoginPage();
            await loginPage.PerformLogin(userName, password);

            await Expect(Page.Locator(".show")).ToContainTextAsync(expectedErrMsg);
        }

        [TestCase("student", "", "Your password is invalid!")]

        public async Task IsPasswordFldErrorMsgDisplayed(string userName, string password, string expectedErrMsg)
        {
            LoginPage loginPage = await NavigateToLoginPage();
            await loginPage.PerformLogin(userName, password);

            await Expect(Page.Locator(".show")).ToContainTextAsync(expectedErrMsg);
        }

        #region Helper methods

        private async Task<LoginPage> NavigateToLoginPage()
        {
            PracticePage practicePage = new PracticePage(Page);
            Assert.IsNotNull(await practicePage.LnkTestLoginPageClick(), "Login page could not be found.");

            return new LoginPage(Page);
        }

        #endregion
    }
}