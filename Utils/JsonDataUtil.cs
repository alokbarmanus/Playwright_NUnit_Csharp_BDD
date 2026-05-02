using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Playwright_NUnit_Csharp_BDD.Utils
{
    public static class JsonDataUtil
    {
        public static List<Dictionary<string, object>> ReadJsonData(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
        }

        public static Dictionary<string, object> GetFirstObjectFromEnvFile(string dataFileName)
        {
            var env = System.Environment.GetEnvironmentVariable("env") ?? "dev";
            var filePath = $"data/{env}/{dataFileName}";
            return ReadJsonData(filePath)[0];
        }

        public static IEnumerable<object[]> GetAllObjectsFromEnvFile(string dataFileName)
        {
            var env = System.Environment.GetEnvironmentVariable("env") ?? "dev";
            var filePath = $"data/{env}/{dataFileName}";
            var data = ReadJsonData(filePath);
            foreach (var obj in data)
            {
                yield return new object[] { obj["username"].ToString(), obj["password"].ToString() };
            }
        }

        public static List<Dictionary<string, object>> ReadScenarioDataFile(TechTalk.SpecFlow.ScenarioContext scenarioContext)
        {
            var dataFileTag = scenarioContext.ScenarioInfo.Tags
                .FirstOrDefault(t => t.StartsWith("dataFile:", StringComparison.OrdinalIgnoreCase));
            if (dataFileTag == null)
                throw new InvalidOperationException("No @dataFile tag found on the scenario.");

            var dataFileName = dataFileTag.Replace("dataFile:", "").Trim();
            var env = Environment.GetEnvironmentVariable("env") ?? "dev";
            dataFileName = dataFileName.Replace("${env}", env);

            return ReadJsonData(dataFileName);
        }
    }
}
