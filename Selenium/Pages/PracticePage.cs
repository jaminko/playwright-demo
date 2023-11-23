using OpenQA.Selenium;

namespace DemoTestFramework.Selenium.Pages
{
    public class PracticePage : BasePage
    {
        public PracticePage(IWebDriver driver) : base(driver)
        {
        }

        #region Components

        private IWebElement LnkTestLoginPage => driver.FindElement(By.XPath("//*[contains(text(),'Test Login Page')]"));

        #endregion

        #region Helper methods

        public LoginPage LnkTestLoginPageClick()
        {
            LnkTestLoginPage.Click();
            return new LoginPage(driver);
        }

        #endregion

        #region Asserts

        public bool HasLnkTestLoginPage => LnkTestLoginPage.Displayed;

        #endregion
    }
}