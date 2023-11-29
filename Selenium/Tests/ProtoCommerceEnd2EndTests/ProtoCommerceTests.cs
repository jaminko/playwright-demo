using DemoTestFramework.Selenium.Pages.ProtoCommerce;
using NUnit.Framework;
using System.Linq;

namespace DemoTestFramework.Selenium.Tests.ProtoCommerceEnd2EndTests
{
    public class ProtoCommerceTests : BaseTest
    {
        private readonly string protoCommercePageUrl = "https://rahulshettyacademy.com/angularpractice/";
        private ProtoCommerceHomePage homePage;

        [SetUp]
        public void Setup()
        {
            InitDriver(protoCommercePageUrl);
            homePage = new ProtoCommerceHomePage(driver);
        }

        [TestCase("iphone X", "Samsung Note 8", "Nokia Edge", "Blackberry")]
        [TestCase("Samsung Note 8", "Blackberry")]
        [TestCase("Nokia Edge")]
        [Ignore("For some reason, the test could not be passed in the 'headless' mode. Need additional investigating.")]
        public void End2EndForDifferentProducts(params string[] targetProducts)
        {
            var shopPage = homePage.LnkShopClick();

            shopPage.ClickTargetProduct(targetProducts);
            shopPage.BtnCheckoutClick();
            var actualProducts = shopPage.GetAddedProducts(targetProducts.Count());

            Assert.AreEqual(targetProducts, actualProducts, "Products were added incorrectly.");
        }

        [TestCase("iphone X", "iphone X", "iphone X")]
        [Ignore("For some reason, the test could not be passed in the 'headless' mode. Need additional investigating.")]
        public void End2EndFlowForSameProduct(params string[] targetProducts)
        {
            var shopPage = homePage.LnkShopClick();

            shopPage.ClickTargetProduct(targetProducts);
            shopPage.BtnCheckoutClick();

            Assert.IsTrue(shopPage.GetCheckOutCardsQuantity == 1, "Products were added incorrectly.");
            Assert.IsTrue(shopPage.CardQuantityFieldValue == "3", "Card quantity field value is incorrect.");

        }
    }
}