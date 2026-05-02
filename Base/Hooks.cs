using NUnit.Framework;
using Playwright_NUnit_Csharp_BDD.Base;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Playwright_NUnit_Csharp_BDD.Base
{
    [Binding]
    public class Hooks
    {
        private readonly TechTalk.SpecFlow.ScenarioContext _scenarioContext;
        public Hooks(TechTalk.SpecFlow.ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            bool isCi = !string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("GITHUB_ACTIONS"));
            bool headless = isCi ? true : false;
            var browser = await playwright.Chromium.LaunchAsync(new Microsoft.Playwright.BrowserTypeLaunchOptions { Headless = headless });
            var browserContext = await browser.NewContextAsync();
            var page = await browserContext.NewPageAsync();
            var baseUrl = GetBaseUrl();
            await page.GotoAsync(baseUrl);

            var pwContext = new Context.PlaywrightContext
            {
                Playwright = playwright,
                Browser = browser,
                BrowserContext = browserContext,
                Page = page,
                BaseUrl = baseUrl
            };
            _scenarioContext["PlaywrightContext"] = pwContext;
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (_scenarioContext.TryGetValue("PlaywrightContext", out var ctxObj) && ctxObj is Context.PlaywrightContext pwContext)
            {
                await pwContext.Browser.CloseAsync();
                pwContext.Playwright.Dispose();
            }
        }

        private string GetBaseUrl()
        {
            var env = System.Environment.GetEnvironmentVariable("ENV")?.ToLower() ?? "dev";
            var propsPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Properties", "application.properties");
            var props = Playwright_NUnit_Csharp_BDD.Utils.PropertiesUtil.LoadProperties(propsPath);
            string key = env + "_url";
            if (props.ContainsKey(key))
                return props[key];
            return "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        }
    }
}
