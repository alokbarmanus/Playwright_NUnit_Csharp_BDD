using Playwright_NUnit_Csharp_BDD.Utils;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Playwright_NUnit_Csharp_BDD.Tests
{
    [Binding]
    public class StepArgumentTransformations
    {
        private readonly Context.ScenarioAppContext _appContext;

        public StepArgumentTransformations(Context.ScenarioAppContext appContext)
        {
            _appContext = appContext;
        }

        [StepArgumentTransformation(@"from data file row (\d+)")]
        public Dictionary<string, object> TransformUserDataFromJson(int rowIndex)
        {
            var users = JsonDataUtil.ReadScenarioDataFile(_appContext.ScenarioContext);
            if (rowIndex < 1 || rowIndex > users.Count)
                throw new ArgumentOutOfRangeException($"Row index {rowIndex} is out of range for scenario data file");
            return users[rowIndex - 1]; // 1-based index in Gherkin
        }
    }
}
