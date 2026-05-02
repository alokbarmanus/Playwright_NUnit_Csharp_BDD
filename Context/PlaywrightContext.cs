using Microsoft.Playwright;

namespace Playwright_NUnit_Csharp_BDD.Context
{
    public class PlaywrightContext
    {
        public IPlaywright Playwright { get; set; }
        public IBrowser Browser { get; set; }
        public IBrowserContext BrowserContext { get; set; }
        public IPage Page { get; set; }
        public string BaseUrl { get; set; }
    }
}
