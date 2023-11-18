using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightDemo.PlaywrightNUnit.Pages
{
    public class LoginPage
    {
        public LoginPage(IPage page)
        {
            _page = page;
        }

        private IPage _page;
        private ILocator TxtUserName => _page.Locator("#UserName");
        private ILocator TxtPassword => _page.Locator("#Password");
        private ILocator BtnLogin => _page.Locator(".btn-default", new PageLocatorOptions { HasTextString = "Log in" });


        public async Task PerformLogin(string userName, string password)
        {
            await TxtUserName.FillAsync(userName);
            await TxtPassword.FillAsync(password);
            await BtnLogin.ClickAsync();
        }
    }
}