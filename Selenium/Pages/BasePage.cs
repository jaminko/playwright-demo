using OpenQA.Selenium;

namespace DemoTestFramework.Selenium.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}