using Microsoft.Playwright;

namespace PlaywrightDemo.Playwright.Pages
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