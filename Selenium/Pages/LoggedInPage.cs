using OpenQA.Selenium;

namespace DemoTestFramework.Selenium.Pages
{
    public class LoggedInPage : BasePage
    {
        private readonly IPage _page;

        public LoggedInPage(IWebDriver driver) : base(driver)
        {
        }

        #region Components

        private IWebElement LnkHelloAdmin => driver.FindElement(By.CssSelector("a[title='Manage']"));

        #endregion

        #region Asserts

        public bool HasLnkHelloAdmin => LnkHelloAdmin.Displayed;

        #endregion

        #region Helper methods

        public string LnkHelloAdminText => LnkHelloAdmin.Text;

        #endregion
    }
}