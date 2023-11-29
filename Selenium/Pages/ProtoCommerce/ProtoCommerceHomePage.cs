using OpenQA.Selenium;

namespace DemoTestFramework.Selenium.Pages.ProtoCommerce
{
    public class ProtoCommerceHomePage : BasePage
    {
        public ProtoCommerceHomePage(IWebDriver driver) : base(driver)
        {
        }

        #region Components

        private IWebElement LnkShop => driver.FindElement(By.XPath("//a[@class='nav-link'] [contains(text(), 'Shop')]"));

        #endregion

        #region Helper methods

        public ProtoCommerceShopPage LnkShopClick()
        {
            LnkShop.Click();
            return new ProtoCommerceShopPage(driver);
        }

        #endregion

        #region Asserts

        public bool HasLnkShop => LnkShop.Displayed;

        #endregion
    }
}