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

        private IWebElement BtnLogOut => driver.FindElement(By.CssSelector(".wp-block-button"));

        #endregion

        #region Asserts

        public bool HasBtnLogOut => BtnLogOut.Displayed;

        #endregion

        #region Helper methods

        public string BtnLogOutText => BtnLogOut.Text;

        #endregion
    }
}