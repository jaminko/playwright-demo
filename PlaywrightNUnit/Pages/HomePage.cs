using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightDemo.PlaywrightNUnit.Pages
{
    public class HomePage
    {
        public HomePage(IPage page)
        {
            _page = page;
        }

        private IPage _page;
        private ILocator LnkLogin => _page.Locator("a[id='loginLink']");

        public async Task LnkLoginClick()
        {
            await LnkLogin.ClickAsync();
        }
    }
}