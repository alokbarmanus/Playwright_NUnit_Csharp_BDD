using TechTalk.SpecFlow;

namespace Playwright_NUnit_Csharp_BDD.Context
{
    public class ScenarioAppContext
    {
        public ScenarioContext ScenarioContext { get; }

        public ScenarioAppContext(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }
    }
}
