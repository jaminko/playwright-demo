using Microsoft.Playwright;

namespace DemoTestFramework.Playwright.Pages
{
    public class LoggedInPage
    {
        private readonly IPage _page;

        public LoggedInPage(IPage page)
        {
            _page = page;
        }
    }
}