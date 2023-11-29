using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DemoTestFramework.Selenium.Pages.ProtoCommerce
{
    public class ProtoCommerceShopPage : BasePage
    {
        public ProtoCommerceShopPage(IWebDriver driver) : base(driver)
        {
        }

        #region Components

        private IWebElement BtnCheckout => driver.FindElement(By.CssSelector("a[class='nav-link btn btn-primary']"));

        private IList<IWebElement> CheckOutCards => driver.FindElements(By.CssSelector("h4 a"));

        #endregion

        #region Helper methods

        public void BtnCheckoutClick()
        {
            BtnCheckout.Click();
        }

        public string BtnCheckoutText => BtnCheckout.Text;

        public void ClickTargetProduct(string[] targetProducts)
        {
            var btnCheckoutText = BtnCheckoutText;

            foreach (var productSignature in targetProducts)
            {
                if (!string.IsNullOrEmpty(productSignature))
                {
                    var targetCard = GetRootElement(GetProductBySignature(productSignature));
                    targetCard.FindElement(By.CssSelector(".card-footer button")).Click();

                    Assert.IsTrue(Utilities.WaitHelpers.WaitUntilCondition(driver, _ => btnCheckoutText != BtnCheckoutText),
                        "Checkout button signature was not changed.");
                    btnCheckoutText = BtnCheckoutText;
                }
            }
        }

        public string[] GetAddedProducts(int itemsCount)
        {
            string[] actualItems = new string[itemsCount];
            for (int i = 0; i < CheckOutCards.Count(); i++)
            {
                actualItems[i] = CheckOutCards[i].Text;
            }

            return actualItems;
        }

        private IWebElement GetProductBySignature(string productSignature)
        {
            return driver.FindElement(By.XPath($"//a[contains(text(), '{productSignature}')]"));
        }

        private IWebElement GetRootElement(IWebElement element)
        {
            return element.FindElement(By.XPath("../../.."));
        }

        public int GetCheckOutCardsQuantity => 
            CheckOutCards.Count();

        public string CardQuantityFieldValue => 
            driver.FindElement(By.CssSelector("input[class='form-control']")).GetAttribute("value");

        #endregion

        #region Asserts

        #endregion
    }
}