using DemoTestFramework.Selenium.Utilities;
using OpenQA.Selenium;

namespace DemoTestFramework.Selenium.Pages
{
    public class LoginPage : BasePage, IPage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        #region Components

        private IWebElement TxtUsername => driver.FindElement(By.Id("username"));

        private IWebElement TxtPassword => driver.FindElement(By.Id("password"));

        private IWebElement BtnSubmit => driver.FindElement(By.Id("submit"));

        private IWebElement ErrorMsg => driver.FindElement(By.CssSelector(".show"));

        #endregion

        #region Helper methods

        public LoggedInPage PerformLogin(string userName, string password)
        {
            TxtUsername.SendKeys(userName);
            TxtPassword.SendKeys(password);
            BtnSubmit.Click();
            return new LoggedInPage(driver);
        }

        public string ErrorMsgText()
        {
            if (WaitHelper.WaitElementIsPresent(driver, ErrorMsg, 2))
            {
                return ErrorMsg.Text;
            }
            else
                return string.Empty;             
        }

        #endregion

        #region Asserts

        public string HasCorrectUrl()
        {
            return driver.Url;
        }

        public string HasCorrectPageTitle()
        {
            return driver.Title;
        }

        #endregion
    }
}