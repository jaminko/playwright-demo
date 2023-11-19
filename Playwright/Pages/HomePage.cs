using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightDemo.Playwright.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        private ILocator LnkLogin => _page.Locator("a[id='loginLink']");
        private ILocator LnkRegister => _page.Locator("a[id='registerLink']");

        public async Task<LoginPage> LnkLoginClick()
        {
            await LnkLogin.ClickAsync();
            return new LoginPage(_page);
        }

        public async Task LnkRegisterClick()
        {
            await LnkRegister.ClickAsync();
        }
    }
}