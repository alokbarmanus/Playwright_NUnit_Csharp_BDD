using Microsoft.Playwright;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System;

namespace Playwright_NUnit_Csharp_BDD.Base
{
    public class BasePage
    {
        protected IPage Page;
        protected IBrowser Browser;
        protected IBrowserContext Context;
        protected IPlaywright Playwright;
        protected string BaseUrl => GetBaseUrl();

        private string GetBaseUrl()
        {
            var env = Environment.GetEnvironmentVariable("ENV")?.ToLower() ?? "dev";
            var outputDir = System.IO.Path.GetDirectoryName(typeof(BasePage).Assembly.Location);
            // Try both possible output structures
            string propsPath = Path.Combine(outputDir, "Properties", "application.properties");
            if (!File.Exists(propsPath))
            {
                // Try one directory up (for bin/Debug/Properties)
                var parentDir = Directory.GetParent(outputDir)?.FullName;
                if (parentDir != null)
                {
                    var altPath = Path.Combine(parentDir, "Properties", "application.properties");
                    if (File.Exists(altPath))
                        propsPath = altPath;
                }
            }
            var props = Playwright_NUnit_Csharp_BDD.Utils.PropertiesUtil.LoadProperties(propsPath);
            string key = env + "_url";
            if (props.ContainsKey(key))
                return props[key];
            return "https://alokbarmanqa.github.io/personal-website/";
        }

        public async Task InitializeAsync(string browserType = "chromium")
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            // Determine if running in CI (GitHub Actions) or local
            bool isCi = !string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("GITHUB_ACTIONS"));
            bool headless = isCi ? true : false;
            Browser = await Playwright[browserType].LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless });
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        public async Task CleanupAsync()
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}
