using DemoTestFramework.Selenium.Pages;
using NUnit.Framework;
namespace DemoTestFramework.Selenium.Tests
{
    public class LoginPageTests : BaseTest
    {
        private readonly string practicePageUrl = "https://practicetestautomation.com/practice/";
        private LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            InitDriver(practicePageUrl);
            loginPage = new LoginPage(driver);
        }

        [TestCase("https://practicetestautomation.com/practice-test-login/", "Test Login | Practice Test Automation")]
        public void HasCorrectUrlAndTitle(string url, string title)
        {
            var loginPage = NavigateToLoginPage();

            Assert.AreEqual(url, loginPage.HasCorrectUrl(), "Page URL isn't correct.");
            Assert.AreEqual(title, loginPage.HasCorrectPageTitle(), "Page title isn't correct.");
        }

        [TestCase("student", "Password123", "Log out")]
        public void CanUserLogin(string userName, string password, string expectedLnkText)
        {
            var loginPage = NavigateToLoginPage();
            var loggedInPage = loginPage.PerformLogin(userName, password);

            Assert.IsNotNull(loggedInPage, "Logged-in page could not be found.");
            Assert.IsTrue(loggedInPage.HasBtnLogOut, "Log out CTA button could not be found.");
            Assert.AreEqual(expectedLnkText, loggedInPage.BtnLogOutText, "Log out CTA button signature isn't correct.");
        }

        [TestCase("", "Password123", "Your username is invalid!")]
        public void IsUserNameFldErrorMsgDisplayed(string userName, string password, string expectedErrMsg)
        {
            var loginPage = NavigateToLoginPage();
            loginPage.PerformLogin(userName, password);

            Assert.AreEqual(expectedErrMsg, loginPage.ErrorMsgText(), "User name text field error message text signatuse isn't correct.");
        }

        [TestCase("student", "", "Your password is invalid!")]

        public void IsPasswordFldErrorMsgDisplayed(string userName, string password, string expectedErrMsg)
        {
            var loginPage = NavigateToLoginPage();
            loginPage.PerformLogin(userName, password);

            Assert.AreEqual(expectedErrMsg, loginPage.ErrorMsgText(), "User name text field error message text signatuse isn't correct.");
        }

        #region Helper methods

        private LoginPage NavigateToLoginPage()
        {
            PracticePage homePage = new PracticePage(driver);
            var loginPage = homePage.LnkTestLoginPageClick();
            return loginPage;
        }

        #endregion
    }
}