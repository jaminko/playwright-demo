using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace DemoTestFramework.Selenium.Utilities
{
    public class WaitHelper
    {
        public static bool WaitElementIsPresent(IWebDriver driver, IWebElement element, int time = 1)
        {
            var initialTimeoutr = driver.Manage().Timeouts().ImplicitWait;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(_ => element.Displayed);
                return true;
            }
            catch (WebDriverTimeoutException Ex)
            {
                return false;
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = initialTimeoutr;
            }
        }

        public static bool WaitElementIsNotPresent(IWebDriver driver, IWebElement element, int time = 1)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(_ => !element.Displayed);
                return true;
            }
            catch (WebDriverTimeoutException Ex)
            {
                return false;
            }
        }
    }
}
