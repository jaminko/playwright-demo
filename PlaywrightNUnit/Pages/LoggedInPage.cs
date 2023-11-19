using Microsoft.Playwright;

namespace PlaywrightDemo.PlaywrightNUnit.Pages
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