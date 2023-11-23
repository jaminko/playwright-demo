using Microsoft.Playwright;
using System.Threading.Tasks;

namespace DemoTestFramework.Playwright.Pages
{
    public class PracticePage
    {
        private readonly IPage _page;

        public PracticePage(IPage page)
        {
            _page = page;
        }

        private ILocator LnkTestLoginPage => _page.GetByText("Test Login Page");

        public async Task<LoginPage> LnkTestLoginPageClick()
        {
            await LnkTestLoginPage.ClickAsync();
            return new LoginPage(_page);
        }
    }
}