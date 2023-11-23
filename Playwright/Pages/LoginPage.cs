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

        private ILocator TxtUserName => _page.Locator("input[name='username']");
        private ILocator TxtPassword => _page.Locator("input[name='password']");
        private ILocator BtnSubmit => _page.Locator(".btn", new PageLocatorOptions { HasTextString = "Submit" });

        #endregion

        #region Helper methods

        public async Task<LoggedInPage> PerformLogin(string userName, string password)
        {
            await TxtUserName.FillAsync(userName);
            await TxtPassword.FillAsync(password);
            await BtnSubmit.ClickAsync();
            return new LoggedInPage(_page);
        }

        #endregion
    }
}