using Microsoft.Playwright;
using System.Threading.Tasks;

namespace DemoTestFramework.Playwright.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        #region Components

        private ILocator TxtUserName => _page.Locator("#UserName");
        private ILocator TxtPassword => _page.Locator("#Password");
        private ILocator BtnLogin => _page.Locator(".btn-default", new PageLocatorOptions { HasTextString = "Log in" });

        #endregion

        #region Helper methods

        public async Task<LoggedInPage> PerformLogin(string userName, string password)
        {
            await TxtUserName.FillAsync(userName);
            await TxtPassword.FillAsync(password);
            await BtnLogin.ClickAsync();
            return new LoggedInPage(_page);
        }

        #endregion
    }
}