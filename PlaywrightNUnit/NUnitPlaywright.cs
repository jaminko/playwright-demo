using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaywrightDemo.PlaywrightNUnit
{
    public class NUnitPlaywright : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://playwright.dev/docs/intro");
        }

        [Test, Description("Is Page Loaded")]
        public async Task Test1()
        {
            await Page.HoverAsync(".dropdown--hoverable");
            await Page.ClickAsync("text=.NET");

            Assert.IsTrue(Page.Url.Contains("dotnet"));
            await Expect(Page.Locator("text=Playwright for .NET")).ToBeVisibleAsync();
        }

        [Test]
        public void Test2()
        {
            HttpClient client = new HttpClient();
            client.GetAsync("https://petstore.swagger.io/v2/user/{{username}}");
            client.Dispose();

        }
    }
}