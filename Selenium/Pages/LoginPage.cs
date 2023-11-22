using OpenQA.Selenium;

namespace DemoTestFramework.Selenium.Pages
{
    public class LoginPage : BasePage, IPage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        #region Components

        private IWebElement TxtUserName => driver.FindElement(By.CssSelector("#UserName"));

        private IWebElement TxtPassword => driver.FindElement(By.CssSelector("#Password"));

        private IWebElement BtnLogin => driver.FindElement(By.CssSelector(".btn-default"));

        private IWebElement TxtUserNameErrorMsg => driver.FindElement(By.CssSelector("span[data-valmsg-for='UserName']"));

        private IWebElement TxtPasswordErrorMsg => driver.FindElement(By.CssSelector("span[data-valmsg-for='Password']"));


        #endregion

        #region Helper methods

        public LoggedInPage PerformLogin(string userName, string password)
        {
            TxtUserName.SendKeys(userName);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
            return new LoggedInPage(driver);
        }

        public string TxtUserNameErrorMsgText => TxtUserNameErrorMsg.Text;

        public string TxtPasswordErrorMsgText => TxtPasswordErrorMsg.Text;

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