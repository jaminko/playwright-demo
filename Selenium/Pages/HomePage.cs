using OpenQA.Selenium;

namespace PlaywrightDemo.Selenium.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        #region Components

        private IWebElement LnkLogin => driver.FindElement(By.CssSelector("a[id='loginLink']"));

        private IWebElement LnkRegister => driver.FindElement(By.CssSelector("a[id='registerLink']"));

        #endregion

        #region Helper methods

        public LoginPage LnkLoginClick()
        {
            LnkLogin.Click();
            return new LoginPage(driver);
        }

        #endregion

        #region Asserts

        public bool HasLnkLogin => LnkLogin.Displayed;

        #endregion
    }
}