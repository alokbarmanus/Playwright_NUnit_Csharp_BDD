using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_NUnit_Csharp_BDD.Pages
{
    public class DashboardPage
    {
        private readonly IPage _page;
        public DashboardPage(IPage page)
        {
            _page = page;
        }

        // Locators
        public ILocator DashboardHeader => _page.Locator("h6:has-text('Dashboard')");
        public ILocator WidgetSection => _page.Locator("//body/div[@id='app']/div[@class='oxd-layout orangehrm-upgrade-layout']/div[@class='oxd-layout-container']/div[@class='oxd-layout-context']/div[@class='oxd-grid-3 orangehrm-dashboard-grid']/div[1]");

        // Actions
        public async Task<bool> IsDashboardVisibleAsync()
        {
            return await DashboardHeader.IsVisibleAsync();
        }

        public async Task<bool> AreWidgetsVisibleAsync()
        {
            return await WidgetSection.IsVisibleAsync();
        }
    }
}
