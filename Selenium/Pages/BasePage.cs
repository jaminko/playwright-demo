using OpenQA.Selenium;

namespace PlaywrightDemo.Selenium.Pages
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