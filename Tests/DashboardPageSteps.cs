using NUnit.Framework;
using Playwright_NUnit_Csharp_BDD.Base;
using Playwright_NUnit_Csharp_BDD.Pages;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Playwright_NUnit_Csharp_BDD.Tests
{
    [Binding]
    public class DashboardPageSteps
    {
        private readonly Context.ScenarioAppContext _appContext;
        private readonly Context.PlaywrightContext _pwContext;
        private DashboardPage _dashboardPage;

        public DashboardPageSteps(Context.ScenarioAppContext appContext)
        {
            _appContext = appContext;
            _pwContext = (Context.PlaywrightContext)_appContext.ScenarioContext["PlaywrightContext"];
        }

        [Then("I should see the dashboard")]
        public async Task ThenIShouldSeeTheDashboard()
        {
            _dashboardPage = new DashboardPage(_pwContext.Page);
            Assert.IsTrue(await _dashboardPage.IsDashboardVisibleAsync(), "Dashboard header is not visible");
        }

        [Then("I should see dashboard widgets")]
        public async Task ThenIShouldSeeDashboardWidgets()
        {
            _dashboardPage = new DashboardPage(_pwContext.Page);
            Assert.IsTrue(await _dashboardPage.AreWidgetsVisibleAsync(), "Dashboard widgets are not visible");
        }
    }
}
