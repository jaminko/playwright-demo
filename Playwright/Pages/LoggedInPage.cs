using Microsoft.Playwright;
using System.Threading.Tasks;

namespace DemoTestFramework.Playwright.Pages
{
    public class LoggedInPage
    {
        private readonly Microsoft.Playwright.IPage _page;

        public LoggedInPage(Microsoft.Playwright.IPage page)
        {
            _page = page;
        }

        #region Components

        public ILocator BtnLogOut => _page.Locator(".wp-block-button__link", new PageLocatorOptions { HasTextString = "Log out" });

        #endregion

        #region Helper methods

        public async Task<LoginPage> BtnLogOutClick()
        {
            await BtnLogOut.ClickAsync();
            return new LoginPage(_page);
        }

        #endregion

        #region Asserts

        public bool HasBtnLogOut => BtnLogOut.IsVisibleAsync().GetAwaiter().GetResult();

        #endregion
    }
}