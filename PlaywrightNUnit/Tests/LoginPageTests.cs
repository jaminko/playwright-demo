using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightDemo.PlaywrightNUnit.Tests
{
    public class LoginPageTests : PageTest
    {
        private readonly string homePageUrl = "http://eaapp.somee.com/";

        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync(homePageUrl);

        }

        [TearDown]
        public void Teardown()
        {
            Page.CloseAsync().GetAwaiter().GetResult();
        }

        [Test]
        public async Task CanUserLogin()
        {
            await Page.ClickAsync("a[id='loginLink']");
            await Page.GetByLabel("UserName").FillAsync("admin");
            await Page.FillAsync("#UserName", "admin");
            await Page.FillAsync("#Password", "password");
            await Page.ClickAsync(".btn-default");

            await Expect(Page.Locator("text=Hello admin!")).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Employee" })).ToBeVisibleAsync();
        }
    }
}
